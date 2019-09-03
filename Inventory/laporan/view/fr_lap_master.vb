Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_master
    Private inlap_type As String = ""
    Private inquery As String = ""
    Private inheadpar As String = ""
    Private indatatable As DataTable = Nothing

    Public Sub setVar(laptipe As String, query As String, Optional headerparam1 As String = "...")
        If String.IsNullOrWhiteSpace(laptipe) Then
            Throw New ArgumentException("Report type cannot be null or empty string")
        End If
        If String.IsNullOrWhiteSpace(query) Then
            Throw New ArgumentException("Query cannot be null or empty string")
        End If

        inlap_type = LCase(laptipe)
        inquery = query
        inheadpar = headerparam1
    End Sub

    Public Sub setVar(laptipe As String, dt As DataTable, Optional headerparam1 As String = "...")
        If String.IsNullOrWhiteSpace(laptipe) Then
            Throw New ArgumentException("Report type cannot be nothing or empty string")
        End If

        If IsNothing(dt) Then
            Throw New ArgumentNullException("Datatable cannot be null/nothing")
        End If

        inlap_type = LCase(laptipe)
        inheadpar = headerparam1
        indatatable = dt
    End Sub

    Private Sub filldatatabel(query As String, dt As DataTable)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim data_adpt As New MySqlDataAdapter(query, x.Connection)
                    data_adpt.SelectCommand.CommandTimeout = 360
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

    Private Sub repViewerSelector(lap_type As String)
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parPeriode As New ReportParameter("parPeriode", inheadpar)
        Dim repdatasource, repdatasource1 As New ReportDataSource

        Dim _pgset As New System.Drawing.Printing.PaperSize
        With Me.rv_nota
            With .LocalReport

                Select Case inlap_type
                    Case "m_custo_qr"
                        repdatasource.Name = "ds_custo_qr"
                        repdatasource.Value = data_master.dt_custo_qr

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.master_custo_qr.rdlc"

                        If Not loadRepTable(data_master.dt_custo_qr) Then Exit Sub

                    Case Else : Exit Sub
                End Select
                .SetParameters(New ReportParameter() {parUserId, parPeriode})
            End With
        End With
    End Sub

    Private Function loadRepTable(dt As DataTable) As Boolean
        If IsNothing(dt) Then
            Throw New ArgumentNullException("Datatable cannot be null/nothing")
        End If

        Dim _retval As Boolean = False

        dt.Clear()
        If IsNothing(indatatable) Then
            If Not String.IsNullOrWhiteSpace(inquery) Then
                filldatatabel(inquery, dt)
            Else
                Return False
                Exit Function
            End If
        Else
            dt.Load(indatatable.CreateDataReader)
        End If

        Return True
    End Function

    Private Sub LoadReport()
        With Me.rv_nota
            .RefreshReport()

            If inlap_type = "m_custo_qr" Then
                Dim ps As Drawing.Printing.PageSettings = New System.Drawing.Printing.PageSettings()

                ps.Landscape = False
                ps.Margins = New System.Drawing.Printing.Margins(0, 0, 0.1, 0)
                ps.PaperSize = New System.Drawing.Printing.PaperSize("Custom", 295, 138)
                rv_nota.SetPageSettings(ps)
            End If

            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
    End Sub

    Public Sub do_load()
        Me.Cursor = Cursors.WaitCursor
        repViewerSelector(inlap_type)
        LoadReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog(main)
    End Sub
End Class