Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_view_nota
    Private inlap_type As String = ""
    Private inquery As String = ""
    Private innofaktur As String = ""
    Private m_streams As IList(Of IO.Stream)
    Private m_currentPageIndex As Integer
    Private m_pageSetting As System.Drawing.Printing.PageSettings

    Public Sub setVar(laptipe As String, nofaktur As String, query As String)
        inlap_type = laptipe
        inquery = query
        innofaktur = nofaktur
    End Sub

    Private Sub filldatatabel(query As String, dt As DataTable)
        op_con()
        Try
            Dim data_adpt As New MySqlDataAdapter(query, getConn)
            dt.Clear()
            data_adpt.Fill(dt)
            data_adpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
            logError(ex)
        End Try
        cl_con()
    End Sub

    Private Sub repViewerSelector(lap_type As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parNoFaktur As New ReportParameter("parNoFaktur", innofaktur)
        Dim repdatasource, repdatasource1, repdatasource2 As New ReportDataSource

        With Me.rv_nota
            With .LocalReport
                Dim q As String = ""
                Dim _parArr As ReportParameter()
                Dim _repNm As String = ""
                Dim _dt As DataTable

                Dim FakturDate As String = ""
                Dim RecipientName As String = ""
                Dim RecipientAddress As String = ""
                Dim Term As Integer = 0
                Dim Netto As Decimal = 0
                Dim jenbyr As String = Nothing
                Dim IDReff As String = Nothing
                Dim UserIdInput As String = ""

                Using x = MainConnection
                    x.Open()
                    If x.ConnectionState = ConnectionState.Open Then
                        Select Case inlap_type
                            Case "beli"
                                q = "SELECT DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y'),faktur_term, supplier_nama, supplier_alamat, " _
                                    & "faktur_netto, faktur_reg_alias " _
                                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                                    & "WHERE faktur_kode='" & innofaktur & "'"
                                Using rdx = x.ReadCommand(q, CommandBehavior.SingleRow)
                                    Dim red = rdx.Read
                                    If red And rdx.HasRows Then
                                        FakturDate = rdx.Item(0)
                                        term = rdx.Item(1)
                                        RecipientName = rdx.Item(2)
                                        RecipientAddress = rdx.Item(3)
                                        netto = rdx.Item(4)
                                        UserIdInput = rdx.Item(5)
                                    End If
                                End Using

                                Dim parTglFaktur As New ReportParameter("parTglFaktur", FakturDate)
                                Dim parTerm As New ReportParameter("parTerm", term)
                                Dim parSupplier As New ReportParameter("parSupplier", "A.N. " & RecipientName)
                                Dim parSupplierAl As New ReportParameter("parSupplierAl", RecipientAddress)
                                Dim parNetto As New ReportParameter("parNetto", netto)
                                parUserId = New ReportParameter("parUserId", UserIdInput)

                                _parArr = {parSupplier, parSupplierAl, parTerm, parTglFaktur, parNetto, parUserId}
                                _repNm = "Inventory.nota_beli.rdlc"
                                _dt = ds_transaksi.dt_nota_beli
                                repdatasource.Name = "ds_nota_beli"
                                repdatasource.Value = _dt

                                inquery = "SELECT trans_barang as beli_barang ,barang_nama as beli_brg_n , " _
                                    & "CONCAT(CAST(trans_qty AS CHAR),' ',trans_satuan) as beli_qty , trans_harga_beli as beli_harga, " _
                                    & "trans_disc1 as beli_disc1,trans_disc2 as beli_disc2, trans_disc3 as beli_disc3, trans_disc_rupiah as beli_discrp, " _
                                    & "trans_harga_beli*trans_qty - trans_jumlah as beli_disctot, trans_jumlah as beli_jml " _
                                    & "FROM data_pembelian_trans LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                                    & "WHERE trans_faktur='" & innofaktur & "' AND trans_status=1"

                            Case "jual"
                                Dim sales As String = ""
                                q = "SELECT DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y'), faktur_term, customer_nama, " _
                                      & "TRIM(BOTH ', ' FROM CONCAT_WS(', ',customer_alamat,customer_kecamatan,customer_kabupaten))	customer_alamat, " _
                                      & "salesman_nama, IF(IFNULL(faktur_upd_alias,'')='',faktur_reg_alias,faktur_upd_alias), " _
                                      & "faktur_netto, IFNULL(j_order_kode,'') " _
                                      & "FROM data_penjualan_faktur LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                                      & "LEFT JOIN data_penjualan_order_faktur ON j_order_ref_faktur=faktur_kode AND j_order_status=1 " _
                                      & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                                      & "WHERE faktur_kode='" & innofaktur & "'"
                                Using rdx = x.ReadCommand(q, CommandBehavior.SingleRow)
                                    Dim red = rdx.Read
                                    If red And rdx.HasRows Then
                                        FakturDate = rdx.Item(0)
                                        term = rdx.Item(1)
                                        RecipientName = rdx.Item(2)
                                        RecipientAddress = rdx.Item(3)
                                        sales = rdx.Item(4)
                                        UserIdInput = rdx.Item(5)
                                        netto = rdx.Item(6)
                                        IDReff = rdx.Item(7)
                                    End If
                                End Using

                                Dim parTglFaktur As New ReportParameter("parTglFaktur", FakturDate)
                                Dim parTerm As New ReportParameter("parTerm", CDate(FakturDate).AddDays(Term).ToString("dd/MM/yyyy"))
                                Dim parSales As New ReportParameter("parSales", sales)
                                Dim parCusto As New ReportParameter("parSupplier", RecipientName)
                                Dim parCustoAl As New ReportParameter("parSupplierAl", RecipientAddress)
                                parUserId = New ReportParameter("parUserId", UserIdInput)
                                Dim parNetto As New ReportParameter("parNetto", netto)
                                Dim parKodeOrder As New ReportParameter("parKodeOrder", IDReff)
                                Dim parNettoAmount As New ReportParameter("parNettoN", AmountToString(netto) & " Rupiah")

                                _parArr = {parCusto, parCustoAl, parTerm, parTglFaktur, parSales, parNetto, parKodeOrder, parNettoAmount}
                                _repNm = "Inventory.nota_jual.rdlc"
                                _dt = ds_transaksi.dt_nota_jual
                                repdatasource.Name = "ds_nota_jual"
                                repdatasource.Value = _dt

                                inquery = "SELECT trans_barang as jual_barang ,barang_nama as jual_barang_n, " _
                                    & "CONCAT(CAST(trans_qty AS CHAR),' ',trans_satuan) as Jual_qty , trans_harga_jual as jual_harga, " _
                                    & "@subtotal:=trans_harga_jual*trans_qty jual_subtotal, " _
                                    & "trans_disc_rupiah jual_discrp, @discrp:=trans_disc_rupiah*trans_qty lap_discrp_n, " _
                                    & "trans_disc1 jual_d1, @disc1:=ROUND(IF(trans_disc1=0, 0, (@subtotal-@discrp) * (trans_disc1/100)),2) lap_disc1_n, " _
                                    & "trans_disc2 jual_d2, @disc2:=ROUND(IF(trans_disc2=0, 0, (@subtotal-(@discrp+@disc1)) * (trans_disc2/100)),2) lap_disc2_n, " _
                                    & "trans_disc3 jual_d3, @disc3:=ROUND(IF(trans_disc3=0, 0, (@subtotal-(@discrp+@disc1+@disc2)) * (trans_disc3/100)),2) lap_disc3_n, " _
                                    & "trans_disc4 jual_d4, @disc4:=ROUND(IF(trans_disc4=0, 0, (@subtotal-(@discrp+@disc1+@disc2+@disc3)) * (trans_disc4/100)),2) lap_disc4_n, " _
                                    & "trans_disc5 jual_d5, @disc5:=ROUND(IF(trans_disc5=0, 0, (@subtotal-(@discrp+@disc1+@disc2+@disc3+@disc4)) * (trans_disc5/100)),2) lap_disc5_n, " _
                                    & "ROUND(@discrp+@disc1+@disc2+@disc3+@disc4+@disc5,2) jual_disctot, " _
                                    & "(trans_harga_jual*trans_qty)-ROUND(@discrp+@disc1+@disc2+@disc3+@disc4+@disc5,2) jual_jml " _
                                    & "FROM data_penjualan_trans LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                                    & "WHERE trans_faktur='" & innofaktur & "' AND trans_status<>9"

                            Case "returbeli"
                                Exit Sub
                                q = "SELECT DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y'), "
                            Case Else
                                Exit Sub
                        End Select
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = _repNm
                        .SetParameters(_parArr)
                        .SetParameters(New ReportParameter() {parUserId, parNoFaktur})
                        filldatatabel(inquery, _dt)
                    End If
                End Using

            End With
        End With
    End Sub

    'LOAD
    Public Sub do_load()
        Me.Cursor = Cursors.AppStarting
        repViewerSelector(inlap_type)
        Me.Cursor = Cursors.Default
    End Sub

    'PRINT?
    Public Sub printRep(sPrinter As String)
        Dim warnings() As Warning = Nothing
        Dim ps As Printing.PrinterSettings = rv_nota.PrinterSettings
        Dim _papersize As Printing.PaperSize = rv_nota.LocalReport.GetDefaultPageSettings.PaperSize

        ps.PrinterName = sPrinter
        ps.DefaultPageSettings.PaperSize = New Printing.PaperSize("custom", _papersize.Height, _papersize.Width)

        'ps.DefaultPageSettings.Margins = rv_nota.LocalReport.GetDefaultPageSettings.Margins
        'ps.DefaultPageSettings.Landscape = True

        Dim deviceInfo As String = "<DeviceInfo>" & _
            " <OutputFormat>EMF</OutputFormat>" & _
            " <PageWidth>" & _papersize.Height / 100 & "in</PageWidth>" & _
            " <PageHeight>" & _papersize.Width / 100 & "in</PageHeight>" & _
            " <MarginTop>" & 0.1 & "in</MarginTop>" & _
            " <MarginLeft>" & 0.1 & "in</MarginLeft>" & _
            " <MarginRight>" & 0.1 & "in</MarginRight>" & _
            " <MarginBottom>" & 0.1 & "in</MarginBottom>" & _
            "</DeviceInfo>"
        m_streams = New List(Of IO.Stream)
        rv_nota.LocalReport.Render("Image", deviceInfo, AddressOf CreateStream, warnings)

        For Each stream In m_streams
            stream.Position = 0
        Next stream

        Print(ps)
    End Sub

    'VIEW REPORT
    Public Sub viewRep()
        rv_nota.RefreshReport()
        rv_nota.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        rv_nota.ZoomMode = 2
        rv_nota.ZoomPercent = 100
        ShowDialog(main)
    End Sub

    'PRINT FUNCTION
    Private Sub Print(ByVal pPS As Printing.PrinterSettings)

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If

        Dim printDoc As New Printing.PrintDocument()
        printDoc.PrinterSettings = pPS
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
        m_streams.Clear()
    End Sub

    Private Sub PrintPage(ByVal sender As Object, ByVal ev As Printing.PrintPageEventArgs)
        Dim pageImage As New Imaging.Metafile(m_streams(m_currentPageIndex))
        ev.Graphics.DrawImage(pageImage, ev.PageBounds)
        m_currentPageIndex += 1
        ev.HasMorePages = m_currentPageIndex < m_streams.Count
    End Sub

    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As System.Text.Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As IO.Stream
        Dim _appSysDir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & Application.ProductName & "\temp\"
        Dim rc As IO.Stream
        If Not IO.Directory.Exists(_appSysDir) Then
            IO.Directory.CreateDirectory(_appSysDir)
        End If
        rc = New IO.FileStream(_appSysDir + name + "." + fileNameExtension, IO.FileMode.Create)
        m_streams.Add(rc)
        Return rc
    End Function

    Private Sub fr_view_nota_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class