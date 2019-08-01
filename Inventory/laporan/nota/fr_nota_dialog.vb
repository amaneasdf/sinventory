Public Class fr_nota_dialog
    Private _jenisNota As String = ""
    Private _kodeNota As String = ""
    Private cancelClose As Boolean = False

    'CLOSE
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_nota_dialog_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then bt_cl.PerformClick()
    End Sub

    'DRAG FORM
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

    'CHECK STATUS NOTA
    Private Function checkNota(ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Dim _retval As Boolean = False
        Dim q As String
        Dim _status As String = ""

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Select Case _jenisNota
                    Case "beli"
                        q = "SELECT faktur_status FROM data_pembelian_faktur WHERE faktur_kode='{0}'"
                    Case "returbeli"
                        q = "SELECT faktur_status FROM data_pembelian_retur_faktur WHERE faktur_kode_bukti='{0}'"
                    Case "jual"
                        q = "SELECT faktur_status FROM data_penjualan_faktur WHERE faktur_kode='{0}'"
                    Case "returjual"
                        q = "SELECT faktur_status FROM data_penjualan_retur_faktur WHERE faktur_kode_bukti='{0}'"
                    Case Else
                        Msg = "Jenis nota tidak ditemukan/salah."
                        Return False
                        Exit Function
                End Select

                Using rdx = x.ReadCommand(String.Format(q, _kodeNota))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _status = rdx.Item(0)
                    Else
                        _status = "A-read"
                    End If
                End Using
                If _status <> 1 Then
                    Dim resp As String = "Transaksi dg nomor faktur {0} {1}"
                    Select Case _status
                        Case 0
                            resp = String.Format(resp, _kodeNota, "belum tervalidasi")
                        Case 2
                            resp = String.Format(resp, _kodeNota, "sudah dibatalkan")
                        Case 9
                            resp = "Error this data shouldn't've avaliable in/from this app"
                        Case "A-read"
                            resp = "Data tidak dapat ditemukan."
                        Case Else
                            resp = "There is something wrong with the source code or query dude. Sorry."
                    End Select
                    _retval = False
                    Msg = "Faktur tidak dapat diprint." & Environment.NewLine & resp
                Else
                    Msg = "OK"
                    _retval = True
                End If
            Else
                Msg = "Tidak dapat terhubung ke server."
                _retval = False
            End If
        End Using

        Return _retval
    End Function

    'LOAD CB
    Private Sub loadCB()
        Dim _prntDoc As New Printing.PrintDocument
        Dim _dt As New DataTable
        _dt.Columns.Add("Text", GetType(String))
        _dt.Columns.Add("Value", GetType(String))
        For Each PrinterName As String In Printing.PrinterSettings.InstalledPrinters
            _dt.Rows.Add(PrinterName, PrinterName)
        Next

        With cb_printer
            .DataSource = _dt
            .ValueMember = "Value"
            .DisplayMember = "Text"
            '.SelectedValue = _prntDoc.PrinterSettings.PrinterName
            .SelectedValue = LastUsedPrinter
        End With
    End Sub

    Public Sub do_load(JenisNota As String, KodeNota As String)
        Dim _msg As String = ""
        _jenisNota = JenisNota
        _kodeNota = KodeNota

        loadCB()

        If checkNota(_msg) Then
            ShowDialog()
        Else
            MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    'UI : Button
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_cetaknota.Click
        Me.Cursor = Cursors.AppStarting
        Using nota As New fr_view_nota
            nota.setVar(_jenisNota, _kodeNota, "")
            If nota.do_load() Then nota.printRep(cb_printer.SelectedValue)
            LastUsedPrinter = cb_printer.SelectedValue
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_previewnota.Click
        Me.Cursor = Cursors.WaitCursor
        Using nota As New fr_view_nota
            nota.setVar(_jenisNota, _kodeNota, "")
            If nota.do_load() Then nota.viewRep()
        End Using
        Me.Cursor = Cursors.Default
    End Sub
End Class