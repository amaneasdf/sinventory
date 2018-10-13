Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_hutang
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
            Dim data_adpt As New MySqlDataAdapter(query, getConn)
            data_adpt.Fill(dt)
            data_adpt.Dispose()
        Catch ex As Exception
            consoleWriteLine(ex.Message)
            logError(ex)
            'MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
        'cl_con()

        'DataGridView1.DataSource = dt
    End Sub

    Private Sub repViewerSelector(lap_type As String)
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parPeriode As New ReportParameter("parPeriode", inheadpar)
        Dim repdatasource, repdatasource1 As New ReportDataSource

        With Me.rv_nota
            With .LocalReport

                Select Case inlap_type
                    Case "h_nota"
                        repdatasource.Name = "ds_hutang_nota"
                        repdatasource.Value = ds_hutangpiutang.dt_hutang_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.hutang_nota.rdlc"
                        '.SetParameters(New ReportParameter() {parSupplier, parSupplierAl, parTerm, parTglFaktur, parJml, parDiskon, parPPN, parNetto})
                        With ds_hutangpiutang
                            .dt_hutang_nota.Clear()
                            filldatatabel(inquery, .dt_hutang_nota)
                        End With
                    Case "h_titipsupplier"
                        repdatasource.Name = "ds_hutang_piutangsupplier"
                        repdatasource.Value = ds_hutangpiutang.dt_hutang_piutangsupplier

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.hutang_titipsupplier.rdlc"
                        With ds_hutangpiutang
                            .dt_hutang_piutangsupplier.Clear()
                            filldatatabel(inquery, .dt_hutang_piutangsupplier)
                        End With

                    Case "h_kartuhutang"
                        repdatasource.Name = "ds_piutang_kartupiutang"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_kartu

                        Dim parTitleLaporan As New ReportParameter("parTitleLaporan", "Kartu Hutang")

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_kartupiutang.rdlc"
                        .SetParameters(New ReportParameter() {parTitleLaporan})

                        'DataGridView1.DataSource = getDataTablefromDB(inquery)
                        consoleWriteLine(inquery)

                        With ds_hutangpiutang
                            .dt_piutang_kartu.Clear()
                            filldatatabel(inquery, .dt_piutang_kartu)
                            consoleWriteLine(.dt_piutang_kartu.Rows.Count)
                        End With

                    Case "h_bayarnota"
                        repdatasource.Name = "ds_hutang_bayardetail"
                        repdatasource.Value = ds_hutangpiutang.dt_hutang_bayardetail

                        inquery = "SELECT * FROM( " _
                            & "SELECT supplier_nama as hbd_supplier_n, hutang_faktur as hbd_faktur,if(@faktur<>hutang_faktur,@ct:=0,@ct:=1) as count, " _
                            & "faktur_tanggal_trans as hbd_tanggal, " _
                            & "	(CASE WHEN @ct=0 THEN if(faktur_tanggal_trans<'{1}',@sisa:=hutang_awal,0) " _
                            & "		ELSE TRUNCATE(@sisa,2) END) as hbd_saldoawal, " _
                            & "	(CASE WHEN @ct=0 THEN if(faktur_tanggal_trans>='{1}',@sisa:=hutang_awal,0) " _
                            & "		ELSE 0 END) as hbd_beli, " _
                            & "	if(jenis='retur',h_trans_nilaibayar,0) as hbd_retur, if(jenis='bayar',h_trans_nilaibayar,0) as hbd_bayar, " _
                            & "	TRUNCATE(@sisa:= @sisa-h_trans_nilaibayar,2) as hbd_sisa, " _
                            & "	ket as hbd_ket,h_trans_tgl as hbd_tglbayar,h_trans_tgl,h_trans_tgl-faktur_tanggal_trans as hbd_hari,@faktur:=hutang_faktur " _
                            & "FROM ( " _
                            & "SELECT h_trans_faktur, h_trans_nilaibayar, h_bayar_tgl_bayar as h_trans_tgl, " _
                            & "	CONCAT(h_bayar_bukti,':',h_bayar_jenis_bayar) as ket, 'bayar' as jenis, h_bayar_reg_date as reg_date " _
                            & "FROM data_hutang_bayar LEFT JOIN data_hutang_bayar_trans ON h_trans_status=1 AND h_trans_bukti=h_bayar_bukti " _
                            & "WHERE h_bayar_status=1 AND h_bayar_tgl_bayar BETWEEN '{1}' AND '{2}' " _
                            & "UNION " _
                            & "SELECT h_retur_faktur, h_retur_total, faktur_tanggal_trans, " _
                            & "	CONCAT(faktur_kode_bukti, ':RETUR'), 'retur' as jenis, h_retur_reg_date " _
                            & "FROM data_hutang_retur LEFT JOIN data_pembelian_retur_faktur ON h_retur_bukti_retur=faktur_kode_bukti AND faktur_status=1 " _
                            & "WHERE h_retur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                            & "ORDER BY h_trans_tgl,reg_date " _
                            & ")transaksi " _
                            & "LEFT JOIN data_hutang_awal ON hutang_faktur=h_trans_faktur AND hutang_status=1 AND hutang_idperiode={0} " _
                            & "LEFT JOIN data_pembelian_faktur ON hutang_faktur=faktur_kode AND faktur_status=1 " _
                            & "LEFT JOIN data_supplier_master ON supplier_kode= faktur_supplier " _
                            & "JOIN (SELECT @ct:=0, @sisa:=0, @faktur:='') para " _
                            & "ORDER BY supplier_nama,hutang_faktur, h_trans_tgl,count" _
                            & ") hhh "
                        inquery = (String.Format(inquery, selectperiode.id, selectperiode.tglawal.ToString("yyyy-MM-dd"), selectperiode.tglakhir.ToString("yyyy-MM-dd")))

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.hutang_detailbayar.rdlc"

                        consoleWriteLine(inquery)

                        With ds_hutangpiutang
                            .dt_hutang_bayardetail.Clear()
                            filldatatabel(inquery, .dt_hutang_bayardetail)
                            consoleWriteLine(.dt_hutang_bayardetail.Rows.Count)
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