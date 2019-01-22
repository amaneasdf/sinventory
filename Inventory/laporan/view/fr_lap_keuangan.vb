﻿Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_keuangan
    Private inlap_type As String = ""
    Private inquery As String = ""
    Private inheadpar As String = ""

    Public Sub setVar(laptipe As String, query As String, Optional headerparam1 As String = "...")
        inlap_type = LCase(laptipe)
        inquery = query
        inheadpar = headerparam1
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
                    Case "k_biayasales"
                        repdatasource.Name = "ds_biayasales"
                        repdatasource.Value = ds_keuangan.dt_biaya

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_biayasales.rdlc"

                        With ds_keuangan
                            .dt_biaya.Clear()
                            filldatatabel(inquery, .dt_biaya)
                        End With

                    Case "k_biayasales_global"
                        repdatasource.Name = "ds_biayasales"
                        repdatasource.Value = ds_keuangan.dt_biaya

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_biayasales_global.rdlc"

                        With ds_keuangan
                            .dt_biaya.Clear()
                            filldatatabel(inquery, .dt_biaya)
                        End With

                    Case "k_daftarperk"
                        repdatasource.Name = "ds_daftarakun"
                        repdatasource.Value = ds_keuangan.dt_akun

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_daftarakun.rdlc"

                        With ds_keuangan
                            .dt_akun.Clear()
                            filldatatabel(inquery, .dt_akun)
                        End With

                    Case "k_jurnalumum"
                        repdatasource.Name = "ds_jurnalumum"
                        repdatasource.Value = ds_keuangan.dt_jurnalumum

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_jurnalumum.rdlc"

                        With ds_keuangan
                            .dt_jurnalumum.Clear()
                            filldatatabel(inquery, .dt_jurnalumum)
                        End With

                    Case "k_jurnaltutup"
                        Dim parTitle As New ReportParameter("parTitle", "JURNAL PENUTUPAN")

                        repdatasource.Name = "ds_jurnalumum"
                        repdatasource.Value = ds_keuangan.dt_jurnalumum

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_jurnalumum.rdlc"

                        With ds_keuangan
                            .dt_jurnalumum.Clear()
                            filldatatabel(inquery, .dt_jurnalumum)
                        End With
                        .SetParameters(New ReportParameter() {parTitle})

                    Case "k_bukubesar"
                        repdatasource.Name = "ds_bukubesar"
                        repdatasource.Value = ds_keuangan.dt_bukubesar

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_bukubesar.rdlc"

                        With ds_keuangan
                            .dt_bukubesar.Clear()
                            filldatatabel(inquery, .dt_bukubesar)
                        End With

                    Case "k_labarugi"
                        repdatasource.Name = "ds_labarugi"
                        repdatasource.Value = ds_keuangan.dt_labarugi

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_labarugi.rdlc"

                        With ds_keuangan
                            .dt_labarugi.Clear()
                            filldatatabel(inquery, .dt_labarugi)
                        End With

                    Case "k_neraca"
                        repdatasource.Name = "ds_neraca"
                        repdatasource.Value = ds_keuangan.dt_neraca

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_neraca.rdlc"

                        With ds_keuangan
                            .dt_neraca.Clear()
                            filldatatabel(inquery, .dt_neraca)
                        End With

                    Case "k_neracalajur"
                        repdatasource.Name = "ds_neracalajur"
                        repdatasource.Value = ds_keuangan.dt_neracalajur

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.uang_neracalajur.rdlc"

                        With ds_keuangan
                            .dt_neracalajur.Clear()
                            filldatatabel(inquery, .dt_neracalajur)
                        End With

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

    Public Sub do_load()
        repViewerSelector(inlap_type)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fr_view_nota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.AppStarting
    End Sub
End Class