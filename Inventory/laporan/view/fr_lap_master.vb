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
        op_con()
        Try
            Dim _cmd As New MySqlCommand(query, getConn)
            Dim data_adpt As New MySqlDataAdapter(_cmd)
            consoleWriteLine(query)
            data_adpt.Fill(dt)
            data_adpt.Dispose()
        Catch ex As Exception
            consoleWriteLine(ex.Message)
            logError(ex)
            'MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try

        'DataGridView1.DataSource = dt
    End Sub

    Private Sub repViewerSelector(lap_type As String)
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parPeriode As New ReportParameter("parPeriode", inheadpar)
        Dim repdatasource, repdatasource1 As New ReportDataSource

        With Me.rv_nota
            With .LocalReport

                Select Case inlap_type
                    Case "m_custo_qr"
                        repdatasource.Name = "ds_custo_qr"
                        repdatasource.Value = data_master.dt_custo_qr

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.master_custo_qr.rdlc"

                        If Not loadRepTable(data_master.dt_custo_qr) Then
                            Exit Sub
                        End If

                    Case Else
                        Exit Sub
                End Select
                .SetParameters(New ReportParameter() {parUserId, parPeriode})
            End With
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
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

    Public Sub do_load()
        repViewerSelector(inlap_type)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fr_view_nota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.AppStarting
    End Sub
End Class