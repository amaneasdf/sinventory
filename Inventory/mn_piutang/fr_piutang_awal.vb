Public Class fr_piutang_awal
    Private fak_date As Date = Today

    'TAMBAH KETERANGAN LUNAS, JUMLAH GIRO BELUM CAIR, DKK
    'ADD MORE DETAIL ON TRANS DETAIL TABLE
    'REFURBISH THE UI [done?]
    'OPTIONAL : ADD CETAK KARTU PIUTANG(?)

    Public Sub DoLoadView(KodePiutang As String)
        If loadData(KodePiutang) Then
            Me.Show(main)
            dgv_hutang.ClearSelection()
            'If TransStartDate > Today Then bt_bayar.Enabled = False
        Else : Me.Dispose()
        End If
    End Sub

    'LOAD DATA
    Public Function loadData(kode As String) As Boolean
        Dim q As String = ""
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    'LOAD DETAIL PIUTANG
                    q = "SELECT piutang_faktur, piutang_tgl, piutang_awal, IFNULL(ppn.ref_text,'ERROR') bayar_kat, " _
                        & "piutang_custo, customer_nama piutang_custo_n, piutang_sales, salesman_nama piutang_sales_n," _
                        & "DATEDIFF(piutang_jt,piutang_tgl) faktur_term, piutang_status_lunas, piutang_tgl_lunas " _
                        & "FROM data_piutang_awal " _
                        & "LEFT JOIN data_customer_master ON piutang_custo=customer_kode " _
                        & "LEFT JOIN data_salesman_master ON piutang_sales=salesman_kode " _
                        & "LEFT JOIN ref_jenis ppn ON piutang_pajak=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2' " _
                        & "WHERE piutang_faktur='{0}'"
                    Using rdx = x.ReadCommand(String.Format(q, kode))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            Dim _date As Date = rdx.Item("piutang_tgl")
                            Dim _datejt As Date = _date.AddDays(rdx.Item("faktur_term"))
                            Dim _lunas As String = rdx.Item("piutang_status_lunas")

                            in_faktur.Text = kode
                            in_tgl.Text = _date.ToLongDateString
                            in_custo.Text = rdx.Item("piutang_custo")
                            in_custo_n.Text = rdx.Item("piutang_custo_n")
                            in_sales.Text = rdx.Item("piutang_sales")
                            in_sales_n.Text = rdx.Item("piutang_sales_n")
                            in_kat.Text = rdx.Item("bayar_kat")
                            in_piutangawal.Text = commaThousand(rdx.Item("piutang_awal"))
                            in_term.Text = rdx.Item("faktur_term")
                            in_tgl_term.Text = _datejt.ToLongDateString
                            If _lunas = 1 Then
                                in_status.Text = "LUNAS"
                                in_tgllunas.Text = CDate(rdx.Item("piutang_tgl_lunas")).ToLongDateString
                                bt_bayar.Enabled = False
                            Else
                                in_status.Text = "AKTIF"
                            End If
                        Else
                            MessageBox.Show("Tidak dapat mengambil data piutang.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False : Exit Function
                        End If
                    End Using

                    'LOAD TABLE
                    'q = String.Format("GetDataList_PiutangHist('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}')", kode, selectperiode.tglawal, selectperiode.tglakhir)
                    q = String.Format("GetDataList_PiutangHist('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}')", kode, DataListStartDate, DataListEndDate)
                    With dgv_hutang
                        .AutoGenerateColumns = False
                        .DataSource = x.GetDataTable(q)
                        .Columns("bayar").DefaultCellStyle = dgvstyle_currency
                        .Columns("piutang").DefaultCellStyle = dgvstyle_currency
                    End With

                    'LOAD NILAI PIUTANG
                    q = "SELECT GetPiutangSaldoAwal('giro', '{0}', ADDDATE('{1:yyyy-MM-dd}',1)) "
                    'Dim _nilaigiro = CDec(x.ExecScalar(String.Format(q, kode, IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir))))
                    Dim _nilaigiro = CDec(x.ExecScalar(String.Format(q, kode, IIf(DataListEndDate > Today, Today, DataListEndDate))))
                    in_giro.Text = commaThousand(_nilaigiro)
                    countTotal()

                    'If selectperiode.closed Then bt_bayar.Enabled = False
                    Return True
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Tidak dapat mengambil data piutang.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False : Exit Function
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
    End Function

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
        If _hutang - _bayar = 0 Then bt_bayar.Enabled = False
    End Sub

    'LOAD PEMBAYARAN
    Private Sub doBayar()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        If selectperiode.closed Then Exit Sub

        Dim x As New fr_piutang_bayar
        Dim q As String = ""

        Using dd = MainConnection
            dd.Open() : If dd.ConnectionState = ConnectionState.Open Then
                q = "SELECT piutang_custo, customer_nama, piutang_sales, salesman_nama, GetPiutangSaldoAwal('titipan', piutang_customer, ADDDATE(CURDATE(),1)), " _
                    & "GetPiutangSaldoAwal('piutang', '{0}', ADDDATE(CURDATE(),1)), piutang_awal, piutang_jt,piutang_pajak " _
                    & "FROM data_piutang_awal " _
                    & "LEFT JOIN data_customer_master ON piutang_custo=customer_kode " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=piutang_sales " _
                    & "WHERE piutang_faktur='{0}'"
                Using rdx = dd.ReadCommand(String.Format(q, in_faktur.Text))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        x.doLoadNew()
                        x.Owner = main

                        x.cb_pajak.SelectedValue = rdx.Item("piutang_pajak")
                        x.in_custo.Text = rdx.Item(0)
                        x.in_custo_n.Text = rdx.Item(1)
                        x.in_sales.Text = rdx.Item(2)
                        x.in_sales_n.Text = rdx.Item(3)
                        x.in_saldotitipan.Text = commaThousand(rdx.Item(4))

                        x.in_faktur.Text = in_faktur.Text
                        x.in_tgl_jtfaktur.Text = CDate(rdx.Item(7)).ToString("dd/MM/yyyy")
                        x.in_sisafaktur.Text = commaThousand(rdx.Item(5))
                        x._totalhutang = rdx.Item(6)

                    Else
                        MessageBox.Show("Data piutang tidak dapat ditemukan.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End Using

        Me.Close()
    End Sub

    'UI : DRAG FORM
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

    'UI : CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_bataljual.Click
        'If MessageBox.Show("Tutup Form?", "Piutang Awal", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        'End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_bataljual.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_piutang_awal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    'UI : BUTTON
    Private Sub bt_bayar_Click(sender As Object, e As EventArgs) Handles bt_bayar.Click
        If MessageBox.Show("Tambah Pembayaran?", "Piutang Awal", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            doBayar()
        End If
    End Sub
End Class