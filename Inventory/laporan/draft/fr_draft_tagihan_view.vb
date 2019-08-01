Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_draft_tagihan_view
    Private kodedraft As String = ""
    Private tgldraft As String = ""
    Public printing As Integer = 0

    Public Sub setHeader(kode As String, tgl As String)
        kodedraft = kode
        tgldraft = tgl
    End Sub

    Public Sub SetDraft(KodeDraft As String)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = "SELECT draft_tanggal FROM data_tagihan_faktur WHERE draft_kode='{0}' AND draft_status<9"
                Try
                    tgldraft = CDate(x.ExecScalar(String.Format(q, KodeDraft)))
                    Me.kodedraft = KodeDraft : Me.ShowDialog(main)
                Catch ex As Exception
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    logError(ex, True)
                    Me.Close()
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using
    End Sub

    Private Sub filldatatabel(query As String, dt As DataTable)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim data_adpt As New MySqlDataAdapter(query, x.Connection)
                    data_adpt.Fill(dt)
                    data_adpt.Dispose()
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                    logError(ex, True) : Me.Close()
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using
    End Sub

    Private Sub fr_draft_barang_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parTglTagihan As New ReportParameter("parTglTagihan", tgldraft)
        Dim parNoTagihan As New ReportParameter("parNoTagihan", kodedraft)
        Dim query2 As String = String.Format("CALL viewTagihan('{0}','detailtagih')", kodedraft)

        ds_transaksi.dt_rekap_tagihan_detail.Clear()
        filldatatabel(query2, ds_transaksi.dt_rekap_tagihan_detail)
        With Me.rv_draft_barang
            .LocalReport.SetParameters(New ReportParameter() {parUserId, parNoTagihan, parTglTagihan})
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
    End Sub

    Private Sub rv_draft_barang_PrintingBegin(sender As Object, e As ReportPrintEventArgs) Handles rv_draft_barang.PrintingBegin
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = "UPDATE data_tagihan_faktur SET draft_printstatus='Y' WHERE draft_kode='{0}' AND draft_status<9"
                Try
                    x.ExecCommand(String.Format(q, kodedraft))
                    DoRefreshTab_v2({pgdraftrekap})
                Catch ex As Exception
                    logError(ex, True)
                End Try
            End If
        End Using
        printing = 1
    End Sub
End Class