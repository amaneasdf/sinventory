Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_keuangan
    Private inlap_type As String = ""
    Private inquery As String = ""
    Private inheadpar As String = ""

    'FILL VARIABLE VALUE/CONSTUCTOR
    Public Sub setVar(laptipe As String, query As String, Optional headerparam1 As String = "...")
        inlap_type = laptipe
        inquery = query
        inheadpar = headerparam1
    End Sub

    'FILL TEMP DATA TABLE
    Private Sub filldatatabel(query As String, dt As DataTable)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim data_adpt As New MySqlDataAdapter(query, x.Connection)
                    data_adpt.SelectCommand.CommandTimeout = 720
                    consoleWriteLine(query)
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

    Private Sub repViewerSelector()
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parPeriode As New ReportParameter("parPeriode", inheadpar)
        Dim repdatasource, repdatasource1 As New ReportDataSource

        With Me.rv_nota
            With .LocalReport
                Select Case inlap_type
                    Case "k_biayasales", "k_biayasales_global"
                        repdatasource.Name = "ds_biayasales"
                        repdatasource.Value = ds_keuangan.dt_biaya

                        .DataSources.Add(repdatasource)
                        If inlap_type = "k_biayasales" Then
                            .ReportEmbeddedResource = "Inventory.uang_biayasales.rdlc"
                        Else
                            .ReportEmbeddedResource = "Inventory.uang_biayasales_global.rdlc"
                        End If

                        ds_keuangan.dt_biaya.Clear()
                        filldatatabel(inquery, ds_keuangan.dt_biaya)

                    Case "k_daftarperk"
                        repdatasource.Name = "ds_daftarakun"
                        repdatasource.Value = ds_keuangan.dt_akun

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_daftarakun.rdlc"

                        With ds_keuangan
                            .dt_akun.Clear()
                            filldatatabel(inquery, .dt_akun)
                        End With

                    Case "k_jurnalumum", "k_jurnalsesuai", "k_jurnaltutup"
                        Dim parTitle As New ReportParameter
                        repdatasource.Name = "ds_jurnalumum"
                        repdatasource.Value = ds_keuangan.dt_jurnalumum

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_jurnalumum.rdlc"
                        If inlap_type = "k_jurnalumum" Then
                            parTitle = New ReportParameter("parTitle", "JURNAL UMUM")
                        ElseIf inlap_type = "k_jurnalsesuai" Then
                            parTitle = New ReportParameter("parTitle", "JURNAL PENYESUAIAN")
                        Else
                            parTitle = New ReportParameter("parTitle", "JURNAL PENUTUPAN")
                        End If

                        ds_keuangan.dt_jurnalumum.Clear()
                        filldatatabel(inquery, ds_keuangan.dt_jurnalumum)
                        .SetParameters(New ReportParameter() {parTitle})

                    Case "k_bukubesar"
                        repdatasource.Name = "ds_bukubesar"
                        repdatasource.Value = ds_keuangan.dt_bukubesar

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_bukubesar.rdlc"

                        ds_keuangan.dt_bukubesar.Clear()
                        filldatatabel(inquery, ds_keuangan.dt_bukubesar)

                    Case "k_labarugi", "k_neraca"
                        repdatasource.Name = "ds_laporan"
                        repdatasource.Value = ds_keuangan.dt_neraca

                        .DataSources.Add(repdatasource)
                        If inlap_type = "k_labarugi" Then
                            .ReportEmbeddedResource = "Inventory.uang_labarugi.rdlc"
                        Else
                            .ReportEmbeddedResource = "Inventory.uang_neraca.rdlc"
                        End If

                        ds_keuangan.dt_neraca.Clear()
                        filldatatabel(inquery, ds_keuangan.dt_neraca)

                    Case "k_neracalajur"
                        repdatasource.Name = "ds_neracalajur"
                        repdatasource.Value = ds_keuangan.dt_neracalajur

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_neracalajur.rdlc"

                        ds_keuangan.dt_neracalajur.Clear()
                        filldatatabel(inquery, ds_keuangan.dt_neracalajur)

                    Case Else
                        Exit Sub
                End Select
                .SetParameters(New ReportParameter() {parUserId, parPeriode})
            End With
        End With
    End Sub

    Private Sub fr_view_nota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        repViewerSelector()
        With rv_nota
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
        Me.Cursor = Cursors.Default
    End Sub
End Class