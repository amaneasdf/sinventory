Public Class fr_hutang_awal
    Private fak_date As Date = Today

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
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = ""
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    q = "SELECT hutang_faktur, hutang_tgl, hutang_tgl_jt, hutang_supplier, supplier_nama, " _
                        & "GetHutangSaldo('awal', hutang_faktur, '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}') hutang_awal, " _
                        & "DATEDIFF(hutang_tgl_jt,hutang_tgl) faktur_term, hutang_status_lunas, hutang_tgl_lunas, " _
                        & "IFNULL(ppn.ref_text,'ERROR') hutang_kat " _
                        & "FROM data_hutang_awal " _
                        & "LEFT JOIN data_supplier_master ON supplier_kode=hutang_supplier " _
                        & "LEFT JOIN ref_jenis ppn ON hutang_pajak=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2' " _
                        & "WHERE hutang_faktur='{0}'"
                    Using rdx = x.ReadCommand(String.Format(q, kode, DataListStartDate, DataListEndDate))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            Dim _date As Date = rdx.Item("hutang_tgl")
                            Dim _datejt As Date = rdx.Item("hutang_tgl_jt")
                            Dim _lunas As String = rdx.Item("hutang_status_lunas")

                            in_faktur.Text = kode
                            in_tgl.Text = _date.ToLongDateString
                            in_supplier.Text = rdx.Item("hutang_supplier")
                            in_supplier_n.Text = rdx.Item("supplier_nama")
                            in_kat.Text = rdx.Item("hutang_kat")
                            in_term.Text = rdx.Item("faktur_term")
                            in_tgl_term.Text = _datejt.ToLongDateString
                            in_piutangawal.Text = commaThousand(rdx.Item("hutang_awal"))
                            If _lunas = 1 Then
                                in_status.Text = "LUNAS"
                                in_tgllunas.Text = CDate(rdx.Item("hutang_tgl_lunas")).ToLongDateString
                                bt_bayar.Enabled = False
                            Else
                                in_status.Text = "AKTIF"
                            End If
                        Else
                            MessageBox.Show("Tidak dapat mengambil data hutang.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False : Exit Function
                        End If
                    End Using

                    'LOAD TABLE
                    'q = String.Format("CALL GetDataList_HutangHist('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}')", kode, selectperiode.tglawal, selectperiode.tglakhir)
                    q = String.Format("CALL GetDataList_HutangHist('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}')", kode, DataListStartDate, DataListEndDate)
                    With dgv_hutang
                        .AutoGenerateColumns = False
                        .DataSource = x.GetDataTable(q)
                        .Columns("bayar").DefaultCellStyle = dgvstyle_currency
                        .Columns("hutang").DefaultCellStyle = dgvstyle_currency
                    End With

                    'LOAD NILAI GIRO
                    q = "SELECT GetHutangSaldoAwal('giro', '{0}', ADDDATE('{1:yyyy-MM-dd}',1)) "
                    'Dim _nilaigiro = CDec(x.ExecScalar(String.Format(q, kode, IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir))))
                    Dim _nilaigiro = CDec(x.ExecScalar(String.Format(q, kode, IIf(DataListEndDate > Today, Today, DataListEndDate))))
                    in_giro.Text = commaThousand(_nilaigiro)
                    countTotal()

                    'If selectperiode.closed Then bt_bayar.Enabled = False
                    Return True
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Tidak dapat mengambil data hutang.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                _hutang += row.Cells("hutang").Value
            Next
        End If
        in_total.Text = commaThousand(_bayar)
        in_sisa.Text = commaThousand(_hutang - _bayar)
    End Sub

    'LOAD PEMBAYARAN
    Private Sub doBayar()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        If selectperiode.closed Then Exit Sub

        Dim x As New fr_hutang_bayar
        Dim q As String = ""

        Using dd = MainConnection
            dd.Open() : If dd.ConnectionState = ConnectionState.Open Then
                q = "SELECT hutang_supplier, supplier_nama, GetHutangSaldoAwal('titipan', hutang_supplier, ADDDATE(CURDATE(),1)), " _
                    & "GetHutangSaldoAwal('hutang', hutang_faktur, ADDDATE(CURDATE(),1)), hutang_awal, hutang_tgl_jt, hutang_pajak " _
                    & "FROM data_hutang_awal " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=hutang_supplier " _
                    & "WHERE hutang_faktur='{0}'"
                Using rdx = dd.ReadCommand(String.Format(q, in_faktur.Text))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        x.doLoadNew()
                        x.Owner = main

                        x.in_supplier.Text = rdx.Item(0)
                        x.in_supplier_n.Text = rdx.Item(1)
                        x.in_saldotitipan.Text = rdx.Item(2)
                        x.cb_pajak.SelectedValue = rdx.Item("hutang_pajak")

                        x.in_faktur.Text = in_faktur.Text
                        x.in_tgl_jtfaktur.Text = CDate(rdx.Item(5)).ToString("dd/MM/yyyy")
                        x.in_sisafaktur.Text = commaThousand(rdx.Item(3))
                        x._totalhutang = rdx.Item(4)

                    Else
                        MessageBox.Show("Data piutang tidak dapat ditemukan.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        Me.Close()
    End Sub

    'UI : DRAG FORM
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

    'UI : CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_bataljual.Click
        Me.Close()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'e.Cancel = True
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
        If MessageBox.Show("Tambah Pembayaran?", "Hutang Awal", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            doBayar()
        End If
    End Sub
End Class