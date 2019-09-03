Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_stock_view
    Public inlap_type As String = ""
    Private inquery As String = ""
    Private header As String = ""

    Public Sub setVar(tipe As String, queryLap As String, headerLap As String)
        inlap_type = tipe
        inquery = queryLap
        header = headerLap
    End Sub

    'FILL TEMP DATA TABLE
    Private Sub filldatatabel(query As String, dt As DataTable)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim data_adpt As New MySqlDataAdapter(query, x.Connection)
                    consoleWriteLine(query)
                    data_adpt.SelectCommand.CommandTimeout = 360
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

    Private Sub repViewerSelector(lap_type As String)
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parPeriode As New ReportParameter("parPeriode", header)
        Dim repdatasource, repdatasource1, repdatasource2 As New ReportDataSource
        Dim dt As DataTable

        With Me.rv_beli_nota
            With .LocalReport
                Select Case lap_type
                    Case "lapKartuStok", "lapKartuPersediaan", "lapKartuPersediaanGudang"
                        dt = ds_stock.dt_kartustok
                        repdatasource.Name = "ds_kartu_stok"
                        repdatasource.Value = ds_stock.dt_kartustok

                        .DataSources.Add(repdatasource)
                        If lap_type = "lapKartuStok" Then
                            .ReportEmbeddedResource = "Inventory.lap_stok_kartustok.rdlc"
                        ElseIf lap_type = "lapKartuPersediaan" Then
                            .ReportEmbeddedResource = "Inventory.lap_stok_kartupersediaan.rdlc"
                        Else
                            .ReportEmbeddedResource = "Inventory.lap_stok_kartupersediaan_gudang.rdlc"
                        End If

                    Case "lapPersediaan", "lapStok", "lapStokSupplier"
                        dt = ds_stock.dt_persediaan_supplier
                        repdatasource.Name = "ds_lap_stock"
                        repdatasource.Value = ds_stock.dt_persediaan_supplier

                        .DataSources.Add(repdatasource)
                        If lap_type = "lapPersediaan" Then
                            .ReportEmbeddedResource = "Inventory.lap_stok_persedianbrg.rdlc"
                        ElseIf lap_type = "lapStok" Then
                            .ReportEmbeddedResource = "Inventory.lap_stok_stok.rdlc"
                        Else
                            .ReportEmbeddedResource = "Inventory.lap_stok_supplier.rdlc"
                        End If

                    Case "lapStokMutasi", "lapPersediaanMutasi"
                        dt = ds_stock.dt_pers_det
                        repdatasource.Name = "ds_stok_mutasi"
                        repdatasource.Value = ds_stock.dt_pers_det

                        .DataSources.Add(repdatasource)
                        If lap_type = "lapStokMutasi" Then
                            .ReportEmbeddedResource = "Inventory.lap_stok_mutasistok.rdlc"
                        Else
                            .ReportEmbeddedResource = "Inventory.lap_stok_mutasipersediaan.rdlc"
                        End If

                    Case Else
                        Exit Sub
                End Select

                dt.Clear()
                filldatatabel(inquery, dt)

                .SetParameters(New ReportParameter() {parUserId, parPeriode})
            End With
        End With
    End Sub

    Private Sub fr_lap_beli_nota_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        repViewerSelector(inlap_type)
        With rv_beli_nota
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
        Me.Cursor = Cursors.Default
    End Sub
End Class