Imports MadMilkman.Ini
Imports System.IO
Imports OfficeOpenXml
Imports System.Security.Cryptography
Imports ZXing
Imports ZXing.Common
Imports ZXing.QrCode

Module functional

    '---------get network data-------------
    Declare Function SendARP Lib "iphlpapi.dll" Alias "SendARP" (ByVal DestIP As Int32, ByVal SrcIP As Int32, ByVal pMacAddr() As Byte, ByRef PhyAddrLen As Int32) As Int32

    Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next
    End Function

    Public Function GetMac(ByVal ipAddr As String) As String
        Dim macAddress As String = String.Empty
        Try
            Dim destIP As Net.IPAddress = Net.IPAddress.Parse(ipAddr)
            Dim IP() As Byte = destIP.GetAddressBytes()
            Dim IPInt As Int32 = BitConverter.ToInt32(IP, 0)
            Dim mac() As Byte = New Byte(5) {}
            SendARP(IPInt, 0, mac, mac.Length)
            macAddress = BitConverter.ToString(mac, 0, mac.Length)
        Catch ex As Exception
            Debug.Write(ex.Message)
        End Try
        Return macAddress
    End Function

    '----form & control manipulation----------
    Private drag As Boolean
    Private mousex As Integer
    Private mousey As Integer

    Public Sub startdrag(fr As Form, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            drag = True
            mousex = Windows.Forms.Cursor.Position.X - fr.Left
            mousey = Windows.Forms.Cursor.Position.Y - fr.Top
            fr.Cursor = Cursors.SizeAll
        End If
    End Sub

    Public Sub dragging(fr As Form)
        If drag Then
            fr.Top = Windows.Forms.Cursor.Position.Y - mousey
            fr.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Public Sub stopdrag(fr As Form)
        drag = False
        fr.Cursor = Cursors.Default
    End Sub

    Public Sub numericGotFocus(sender As NumericUpDown)
        If sender.Value = 0 Then
            sender.ResetText()
        Else
            sender.Controls.Item(1).Text = sender.Value
        End If
    End Sub

    Public Sub numericLostFocus(x As NumericUpDown, Optional format As String = "N2")
        x.Controls.Item(1).Text = x.Value.ToString(format)
    End Sub

    Public Sub keyshortenter(nextcontrol As Control, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nextcontrol.Focus()
        End If
    End Sub

    Public Sub PopUpSearchKeyPress(e As KeyPressEventArgs, x As TextBox)
        If Char.IsLetterOrDigit(e.KeyChar) Then
            x.Text += e.KeyChar
        ElseIf e.KeyChar = ControlChars.Back Then
            x.Text = x.Text.Remove(x.TextLength - 1, 1)
        Else
            Exit Sub
        End If
        e.Handled = True
        x.Focus()
        x.Select(x.TextLength, x.TextLength)
    End Sub

    '----string manipulation----------
    'split string into two string and the nth string
    Function SplitText(ByVal text As String, ByVal separator As String, ByVal ke As Double)
        Dim SplitStr As String = text
        Dim SplitArr As String()

        SplitArr = SplitStr.Split(separator)
        Return Trim(SplitArr(ke))

    End Function

    Function sLeft(ByVal Str As String, ByVal Len1 As Integer)
        Str = Left(Str, Len1)
        Return Str
    End Function

    Function sMid(ByVal Val As String, ByVal Len As Integer)
        Return Val.Substring(Val.Length / 2 - Len / 2, Len)
    End Function

    Function sRight(ByVal Val As String, ByVal Len As Integer)
        Return Val.Substring(Val.Length - Len, Len)
    End Function

    'string format
    Public Function stringCurrency(x As Decimal) As String
        Dim s As String = ""
        s = x.ToString("C2", System.Globalization.CultureInfo.CreateSpecificCulture("id-ID"))
        Return s
    End Function

    Public Function commaThousand(x As Decimal) As String
        Dim s As String = ""
        s = x.ToString("N2", System.Globalization.CultureInfo.CreateSpecificCulture("id-ID"))
        Return s
    End Function

    Public Function removeCommaThousand(x As String) As Decimal
        If x = Nothing Then
            Return 0 : Exit Function
        End If

        Dim retval As Decimal = Decimal.Parse(x, System.Globalization.CultureInfo.CreateSpecificCulture("id-ID"))

        Return retval
    End Function

    ''' <summary>
    ''' Convert number to  <see cref="String" />s of words.
    ''' </summary>
    ''' <param name="NumAmount">
    ''' Number to be descripted.
    ''' </param>
    ''' <returns>
    ''' A formated <see cref="String"/> of the input.
    ''' </returns>
    Public Function AmountToString(NumAmount As Long) As String
        If Not IsNumeric(NumAmount) Then Throw New InvalidDataException

        Dim _nilai As String() = {"", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas"}

        If NumAmount < 12 Then
            Return _nilai(NumAmount)
        ElseIf NumAmount < 20 Then
            Return _nilai(NumAmount - 10) & " Belas "
        ElseIf NumAmount < 100 Then
            Return AmountToString(Math.Floor(NumAmount / 10)) & " Puluh " & AmountToString(NumAmount Mod 10)
        ElseIf NumAmount < 200 Then
            Return " Seratus " & AmountToString(NumAmount - 100)
        ElseIf NumAmount < 1000 Then
            Return AmountToString(Math.Floor(NumAmount / 100)) & " Ratus " & AmountToString(NumAmount Mod 100)
        ElseIf NumAmount < 2000 Then
            Return " Seribu " & AmountToString(NumAmount - 1000)
        ElseIf NumAmount < 1000000 Then
            Return AmountToString(Math.Floor(NumAmount / 1000)) & " Ribu " & AmountToString(NumAmount Mod 1000)
        ElseIf NumAmount < 1000000000 Then
            Return AmountToString(Math.Floor(NumAmount / 1000000)) & " Juta " & AmountToString(NumAmount Mod 1000000)
        ElseIf NumAmount < 1000000000000 Then
            Return AmountToString(Math.Floor(NumAmount / 1000000000)) & " Milyar " & AmountToString(NumAmount Mod 1000000000)
        ElseIf NumAmount < 1000000000000000 Then
            Return AmountToString(Math.Floor(NumAmount / 1000000000000)) & " Trilyun " & AmountToString(NumAmount Mod 1000000000000)
        Else
            Return NumAmount
        End If
    End Function

    ''' <summary>
    ''' Returns a MYSQL query friendly <see cref="String" />.
    ''' </summary>
    ''' <param name="text">
    ''' The input <see cref="String" />.
    ''' </param>
    ''' <returns>
    ''' A formated <see cref="String"/> for MSYQL CRUD query.
    ''' </returns>
    Public Function mysqlQueryFriendlyStringFeed(text As String) As String
        Return text.Replace("\", "\\").Replace("'", "\'").Replace("%", "\%").Replace("_", "\_")
    End Function

    '-----------BARCODE ENCODER DECODER-------------
    '-----------QR CODE-------------
    ''' <summary>
    ''' Returns a version 1 QRCode <see cref="Bitmap" /> containing the inputed <see cref="String" />.
    ''' </summary>
    ''' <param name="text">
    ''' The input <see cref="String" />.
    ''' </param>
    ''' <param name="imgsize">
    ''' Bitmap size.
    ''' </param>
    ''' <returns>
    ''' A <see cref="Bitmap"/> containing the field values from the row separated by the specified delimiter.
    ''' </returns>
    Public Function createQR(text As String, Optional imgsize As Integer = 100) As Bitmap
        Return createQR(text, imgsize, 1)
    End Function

    ''' <summary>
    ''' Returns a QRCode <see cref="Bitmap" /> containing the inputed <see cref="String" />.
    ''' </summary>
    ''' <param name="text">
    ''' The input <see cref="String" />.
    ''' </param>
    ''' <param name="imgsize">
    ''' The result dimension.
    ''' </param>
    ''' <param name="QrVer">
    ''' QR Code version, between 1 to 40.
    ''' </param>
    ''' <param name="CorrectionLvl">
    ''' QR Code correction level, must be H,L,M or Q.
    ''' </param>
    ''' <returns>
    ''' A <see cref="Bitmap"/> containing the field values from the row separated by the specified delimiter.
    ''' </returns>
    Public Function createQR(text As String, imgsize As Integer, QrVer As Integer, Optional CorrectionLvl As String = "M") As Bitmap
        If String.IsNullOrEmpty(text) Then
            Throw New ArgumentNullException("Inputed content cannot be empty")
        End If
        If QrVer < 1 Or QrVer > 40 Then
            Throw New ArgumentException("QrVersion must between 1 t0 40")
        End If
        If imgsize <= 0 Then
            Throw New ArgumentException("Requested dimensions are too small: " & imgsize & "x" & imgsize)
        End If
        If String.IsNullOrEmpty(CorrectionLvl) Then
            Throw New ArgumentNullException("Correction level cannot be empty")
        ElseIf Not {"M", "L", "H", "Q"}.Contains(CorrectionLvl) Then
            Throw New ArgumentException("Correction level must be H,L,M or Q")
        End If

        Dim corLvl As QrCode.Internal.ErrorCorrectionLevel = QrCode.Internal.ErrorCorrectionLevel.M
        Select Case UCase(CorrectionLvl)
            Case "H"
                corLvl = QrCode.Internal.ErrorCorrectionLevel.H
            Case "L"
                corLvl = QrCode.Internal.ErrorCorrectionLevel.L
            Case "Q"
                corLvl = QrCode.Internal.ErrorCorrectionLevel.Q
            Case "M"
                corLvl = QrCode.Internal.ErrorCorrectionLevel.M
        End Select

        Dim x As Bitmap = Nothing
        Dim hints As New Hashtable
        Dim writer As New BarcodeWriter With {
            .Format = BarcodeFormat.QR_CODE,
            .Options = New QrCodeEncodingOptions With {.QrVersion = QrVer, .Width = imgsize, .Height = imgsize, .ErrorCorrection = corLvl}
        }

        Try
            x = writer.Write(text)
        Catch ex As Exception
            logError(ex)
        End Try

        Return x
    End Function

    '-----------BARCODE DECODER-------------
    ''' <summary>
    ''' Returns a <see cref="String" /> decoded from inputed QR Code/Barcode <see cref="Bitmap" />.
    ''' </summary>
    ''' <param name="BarPic">
    ''' The input QRcode/Barcode <see cref="Bitmap" />.
    ''' </param>
    ''' <returns>
    ''' A <see cref="String"/> <see cref="KeyValuePair"/> containing the decode result as value and BarcodeFormat as key from inputed barcode.
    ''' </returns>
    Public Function decodeBarcode(BarPic As Bitmap) As KeyValuePair(Of String, String)
        Dim reader As New BarcodeReader With {.Options = New DecodingOptions With {.TryHarder = True}}
        Dim dec = reader.Decode(BarPic)

        Return IIf(dec Is Nothing,
                   New KeyValuePair(Of String, String)(String.Empty, Now().ToLongDateString),
                   New KeyValuePair(Of String, String)(dec.BarcodeFormat.ToString, dec.Text)
                   )
    End Function


    '-----------SET PERIODE
    Public Function getPeriode(Optional kodeperiode As String = Nothing, Optional selecteddate As Date = Nothing) As periode
        'app startup
        Dim q As String
        Dim selected As New periode

        If kodeperiode = Nothing Then
            q = "SELECT IFNULL(MAX(tutupbk_id),1) FROM data_tutup_buku " _
                & "WHERE {0} BETWEEN tutupbk_periode_tglawal AND ADDDATE(tutupbk_periode_tglakhir,1) AND tutupbk_status=1"
            readcommd(String.Format(q, IIf(selecteddate = Nothing, "NOW()", "'" & selecteddate.ToString("yyyy-MM-dd") & "'")))
            If rd.HasRows Then
                kodeperiode = rd.Item(0)
            End If
            rd.Close()
        End If

        q = "SELECT tutupbk_id,tutupbk_periode_tglawal, tutupbk_periode_tglakhir, tutupbk_closed FROM data_tutup_buku " _
            & "WHERE tutupbk_status=1 AND tutupbk_id='{0}'"
        readcommd(String.Format(q, kodeperiode))
        If rd.HasRows Then
            selected.id = rd.Item(0)
            selected.tglawal = rd.Item(1)
            selected.tglakhir = rd.Item(2)
            selected.closed = IIf(rd.Item(3) = 1, True, False)
        Else
            selected.id = "1"
            selected.tglawal = "1990-01-01"
            selected.tglakhir = "2100-12-01"
            selected.closed = False
        End If
        rd.Close()

        Return selected
    End Function

    Public Sub setperiode(selecteddate As Date, Optional ShowMsgBox As Boolean = True)
        Dim x As Date = selecteddate
        Dim lastperiod As String = selectperiode.id
        Dim _text As String = "Periode has been changed to {0}" & Environment.NewLine & "Current periode is {1}"

        selectperiode = getPeriode(, selecteddate)

        If lastperiod <> selectperiode.id Then
            main.strip_periode.Text = "Periode : " & selectperiode.tglawal.ToShortDateString & " s.d. " & selectperiode.tglakhir.ToShortDateString
            main.strip_status.Text = "Status Input : " & IIf(selectperiode.closed = True, "Closed", "Open")
            Dim tbpg As TabPage() = {
                pgperkiraan,
                pgstockop,
                pgstok,
                pgpembelian,
                pgpenjualan,
                pgpesanjual,
                pgreturbeli,
                pgreturjual,
                pgmutasigudang,
                pgmutasistok,
                pghutangawal,
                pghutangbayar,
                pghutangbgo,
                pgpiutangawal,
                pgpiutangbayar,
                pgpiutangbgcair,
                pgpiutangbgtolak,
                pgkas,
                pgjurnalumum,
                pgtutupbuku
                }
            doRefreshTab(tbpg)

            If ShowMsgBox = True Then
                Dim _tglawal As Date = selectperiode.tglawal
                Dim _tglakhir As Date = selectperiode.tglakhir
                Dim _periode As String

                If _tglawal.ToString("MMyyyy") = _tglakhir.ToString("MMyyyy") And _tglawal.Day = 1 And _tglakhir = DateSerial(_tglakhir.Year, _tglakhir.Month + 1, 0) Then
                    _periode = _tglawal.ToString("MMMM yyyy")
                Else
                    _periode = _tglawal.ToString("dd/MM/yyyy") & " S.d " & _tglakhir.ToString("dd/MM/yyyy")
                End If

                Dim curper As String = currentperiode.tglawal.ToString("dd/MM/yyyy") & " S.d " & currentperiode.tglakhir.ToString("dd/MM/yyyy")
                MessageBox.Show(String.Format(_text, _periode, curper))
            End If
        End If
    End Sub

    Public Sub doRefreshTab(tab As TabPage())
        DoRefreshTab_v2(tab)
        'For Each y As TabPage In tab
        '    If main.tabcontrol.Contains(y) = True Then
        '        refreshTabPage(y.Name.ToString)
        '    End If
        'Next
    End Sub

    Public Function DoRefreshTab_v2(tab As TabPage()) As KeyValuePair(Of Boolean, String)
        Dim retBool As Boolean = False
        Dim retMsg As String = ""

        For Each x As TabPage In tab
            Dim userCon As Object
            retBool = False

            If Not main.tabcontrol.Contains(x) Then
                retBool = True : retMsg = "Success" : GoTo NextTab
            End If

            Select Case x.Name
                Case "pgsupplier" : userCon = frmsupplier
                Case "pgbarang" : userCon = frmbarang
                Case "pggudang" : userCon = frmgudang
                Case "pgsales" : userCon = frmsales
                Case "pgcusto" : userCon = frmcusto
                Case "pgperkiraan" : userCon = frmperkiraan
                Case "pgpembelian" : userCon = frmpembelian
                Case "pgreturbeli" : userCon = frmreturbeli
                Case "pgpesanjual" : userCon = frmpesanjual
                Case "pgpenjualan" : userCon = frmpenjualan
                Case "pgreturjual" : userCon = frmreturjual
                Case "pgdraftrekap" : userCon = frmrekap
                Case "pgdrafttagihan" : userCon = frmtagihan
                Case "pgstok" : userCon = frmstok
                Case "pgmutasistok" : userCon = frmmutasistok
                Case "pgmutasigudang" : userCon = frmmutasigudang
                Case "pgstockop" : userCon = frmstockop
                Case "pghutangawal" : userCon = frmhutangawal
                Case "pghutangbayar" : userCon = frmhutangbayar
                Case "pghutangbgo" : userCon = frmhutangbgo
                Case "pgpiutangawal" : userCon = frmpiutangawal
                Case "pgpiutangbayar" : userCon = frmpiutangbayar
                Case "pgpiutangbgcair" : userCon = frmpiutangbgcair
                Case "pgkas" : userCon = frmkas
                Case "pgjurnalumum" : userCon = frmjurnalumum
                Case Else : retMsg = "TabPage tidak sesuai." : GoTo NextTab
            End Select

            Try
                userCon.PerformRefresh()
                retBool = True : retMsg = "Success"
            Catch ex As Exception
                logError(ex, True)
                retBool = False
                retMsg = "Terjadi kesalahan saat melakukan refresh data." & Environment.NewLine & ex.Message
            End Try
NextTab:
            consoleWriteLine(retBool.ToString & ":" & retMsg)
        Next

        Return New KeyValuePair(Of Boolean, String)(retBool, retMsg)
    End Function

    'EXPORT EXCEL
    Public Function ExportExcel(ColHeader As List(Of String), DataTbl As List(Of DataTable), DataTitle As List(Of String),
                                FileDir As String, FileExt As String, ByRef FileDirReturn As String,
                                Optional SubTitlePerSheet As List(Of String()) = Nothing) As Boolean
        If String.IsNullOrWhiteSpace(FileDir) Then
            Throw New NullReferenceException
        End If

        Dim _dir As String = IO.Path.GetDirectoryName(FileDir)
        Dim _filename As String = FileDir.Replace(_dir & "\", "")
        Dim _filenameSplit = Strings.Split(_filename, ".")
        If _filenameSplit(_filenameSplit.Length - 1) <> LCase(FileExt) Then
            _filename += If(String.IsNullOrWhiteSpace(FileExt) = False, ".", "") & FileExt
        End If

        If String.IsNullOrWhiteSpace(_filename) Then
            _filename = "ExportData" & Today.ToString("yyyyMMdd")
        End If

        Dim sssss As Integer = 1
        Using xls As New ExcelPackage
            For Each tbl As DataTable In DataTbl
                Dim _sheet As ExcelWorksheet = xls.Workbook.Worksheets.Add("Sheet" & sssss)
                Dim _rowidx As Integer = 1
                Dim _lastcol As Integer = tbl.Columns.Count
                Dim _firstrow As Integer = 1

                'DATA TITLE
                For Each _title As String In DataTitle
                    _sheet.Cells(_rowidx, 1).Value = _title
                    _rowidx += 1
                Next
                If Not IsNothing(SubTitlePerSheet) Then
                    If SubTitlePerSheet.Count >= sssss Then
                        Dim i As Integer = 1
                        For Each Str As String In SubTitlePerSheet.Item(sssss - 1)
                            _sheet.Cells(_rowidx, i).Value = Str
                            i += 1
                        Next
                        _rowidx += 1
                    End If
                End If

                'COMPANY NAME AND ADDRESS
                Dim _rowcomp As Integer = 2
                _sheet.Cells(1, _lastcol).Value = "CV. CATRA UPAYA"
                _sheet.Cells(2, _lastcol).Value = "JL. BIMA NO. 14 JATIWINANGUN - PURWOKERTO"
                _sheet.Cells(1, _lastcol, 2, _lastcol).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right
                If _rowcomp >= _rowidx Then
                    _rowidx = _rowcomp + 1
                End If

                'COLUMN HEADER
                Dim _col As Integer = 1
                For Each _colhead As String In ColHeader
                    _sheet.Cells(_rowidx, _col).Value = _colhead
                    _col += 1
                Next
                If ColHeader.Count <> 0 Then
                    With _sheet.Cells(_rowidx, 1, _rowidx, ColHeader.Count).Style
                        .Border.Top.Style = Style.ExcelBorderStyle.Thin
                        .Border.Left.Style = Style.ExcelBorderStyle.Thin
                        .Border.Right.Style = Style.ExcelBorderStyle.Thin
                        .Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                        .Font.Bold = True
                    End With
                    _rowidx += 2
                End If
                _firstrow = _rowidx

                'DATA
                For Each _row As DataRow In tbl.Rows
                    For i = 0 To _lastcol - 1
                        If IsDBNull(_row.ItemArray(i)) Then
                            _sheet.Cells(_rowidx, i + 1).Value = ""
                        Else
                            If _row.ItemArray(i).GetType() = GetType(Date) Then
                                _sheet.Cells(_rowidx, i + 1).Style.Numberformat.Format = "dd/MM/yyyy"
                            ElseIf {GetType(Decimal), GetType(Double)}.Contains(_row.ItemArray(i).GetType()) Then
                                _sheet.Cells(_rowidx, i + 1).Style.Numberformat.Format = "#,##0.00"
                            ElseIf _row.ItemArray(i).GetType() = GetType(Integer) Then
                                _sheet.Cells(_rowidx, i + 1).Style.Numberformat.Format = "#,##0"
                            End If
                            _sheet.Cells(_rowidx, i + 1).Value = _row.ItemArray(i)
                        End If
                    Next
                    _rowidx += 1
                Next
                If tbl.Rows.Count > 0 Then
                    With _sheet.Cells(_firstrow, 1, _rowidx - 1, _lastcol).Style.Border
                        .Top.Style = Style.ExcelBorderStyle.Thin
                        .Left.Style = Style.ExcelBorderStyle.Thin
                        .Right.Style = Style.ExcelBorderStyle.Thin
                        .Bottom.Style = Style.ExcelBorderStyle.Thin
                    End With
                    _sheet.Cells(_firstrow - IIf(ColHeader.Count <> 0, 2, 0), 1, _rowidx - 1, _lastcol).AutoFitColumns(5)
                End If

                sssss += 1
            Next
            If sssss - 1 > 0 Then
                xls.SaveAs(New FileInfo(_dir & "\" & _filename))
            Else
                Return False
            End If
        End Using

        If File.Exists(_dir & "\" & _filename) Then
            FileDirReturn = _dir & "\" & _filename
            Return True
        Else
            Return False
        End If
    End Function

    Public Function exportXlsx(colheader As List(Of String), datatbl As DataTable, outputDir As String, Optional workbookname As String = Nothing, Optional title As String = Nothing) As Boolean
        If workbookname = Nothing Then
            workbookname = "dataexport" & Today.ToString("yyyyMMdd")
        End If

        Try
            Using xls As New ExcelPackage
                Dim wrksht As ExcelWorksheet = xls.Workbook.Worksheets.Add("DataExport1")
                Dim rows As Integer = 1
                Dim firstrow As Integer = 1
                Dim colcount As Integer = datatbl.Columns.Count
                'CREATE HEADER
                'A1 :JUDUL; A2: Periode; A3:Kategori; A4: OPTIONAL
                'LASTCOL1: COMPANY NAME; LASTCOL2: ADDRESS; LASTCOL3: ADDRESS2
                'A5-LASTCOL5 : COLHEADER
                'A6-END : DATA
                'END+1 :SUMMARIZE

                wrksht.Cells(1, 1).Value = "CV. Catra Upaya"
                wrksht.Cells("A1:E1").Merge = True
                wrksht.Cells(1, 1).Style.Font.Size = 14
                wrksht.Cells(1, 1).Style.Font.Bold = True
                wrksht.Cells(2, 1).Value = "Jl. Bima No.14 Jatiwinangun Purwokerto"
                wrksht.Cells("A2:E2").Merge = True
                wrksht.Cells(2, 1).Style.Font.Size = 12

                If title <> Nothing Then
                    wrksht.Cells(4, 1).Value = title
                    wrksht.Cells(4, 1, 4, colcount).Merge = True
                    wrksht.Cells(4, 1).Style.Font.Bold = True
                    wrksht.Cells(4, 1).Style.Font.Size = 12
                    wrksht.Cells(4, 1).Style.Font.Color.SetColor(Color.MidnightBlue)
                    wrksht.Cells(4, 1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                    rows += 1
                End If
                rows += 3

                'ADD COLUMNS HEADER
                Dim cols As Integer = 1
                For Each colhdr As String In colheader
                    wrksht.Cells(rows, cols).Value = colhdr
                    cols += 1
                Next
                Using ch = wrksht.Cells(rows, 1, rows, colcount)
                    ch.Style.Font.Bold = True
                    ch.Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                    ch.Style.Fill.BackgroundColor.SetColor(Color.CornflowerBlue)
                End Using
                firstrow = rows
                rows += 1

                'ADD DATA
                For Each dtrows As DataRow In datatbl.Rows
                    cols = 1
                    For i = 0 To colcount - 1
                        If dtrows.ItemArray(i).GetType() = GetType(Date) Then
                            Dim sd = CDate(dtrows.ItemArray(i)).ToShortDateString
                            'consoleWriteLine(sd)
                            wrksht.Cells(rows, cols).Value = sd
                        Else
                            wrksht.Cells(rows, cols).Value = dtrows.ItemArray(i)
                        End If

                        If dtrows.ItemArray(i).ToString.Contains(Environment.NewLine) = True Then
                            wrksht.Cells(rows, cols).Style.WrapText = True
                        End If
                        cols += 1
                    Next
                    rows += 1
                Next

                'STYLE
                Using vr = wrksht.Cells(firstrow, 1, rows - 1, colcount)
                    vr.Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
                    vr.Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                    vr.Style.Border.Left.Style = Style.ExcelBorderStyle.Thin
                    vr.Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
                    vr.Style.VerticalAlignment = Style.ExcelVerticalAlignment.Top
                    vr.AutoFitColumns(4)
                End Using

                xls.SaveAs(New FileInfo(outputDir & Strings.Replace(workbookname, ".xlsx", "") & ".xlsx"))
            End Using
            Return True
        Catch ex As Exception
            logError(ex)
            consoleWriteLine("ERR:" & Date.Now.ToString("yyyyMMdd-hhmmss") & ":" & ex.Message & ":" & ex.StackTrace & ":" & ex.TargetSite.ToString)
            'Application.Exit()
            Return False
        End Try
    End Function

    'EXCEL TO DATATABLE
    Public Function GetDataTablefromExcel(path As String, Optional hasheader As Boolean = True) As DataTable
        Try
            Using pck As New ExcelPackage
                Using fs As FileStream = File.OpenRead(path)
                    pck.Load(fs)
                End Using
                Dim ws As ExcelWorksheet = pck.Workbook.Worksheets.First()
                Dim dt As New DataTable
                For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
                    dt.Columns.Add(IIf(hasheader, firstRowCell.Text, String.Format("Column {0}", firstRowCell.Start.Column)))
                Next
                Dim startrow As Integer = IIf(hasheader, 2, 1)
                For rowNum = startrow To ws.Dimension.End.Row
                    Dim wsRow = ws.Cells(rowNum, 1, rowNum, dt.Columns.Count)
                    Dim row As DataRow = dt.Rows.Add()
                    For Each cell In wsRow
                        row(cell.Start.Column - 1) = cell.Text
                    Next
                Next
                Return dt
            End Using
        Catch ex As Exception
            logError(ex)
            consoleWriteLine("ERR:" & Date.Now.ToString("yyyyMMdd-hhmmss") & ":" & ex.Message & ":" & ex.StackTrace & ":" & ex.TargetSite.ToString)
            Return Nothing
        End Try
    End Function

    '-----------.ini file manipulation-------------
    Private Function getConfigFile() As String
        Dim _appSysDir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & Application.ProductName
        Dim fileloc As String = ""

        If File.Exists(_appSysDir & "\bin\config") Then
            fileloc = _appSysDir & "\bin\config"
        ElseIf File.Exists(Application.StartupPath & "\config") = True Then
            fileloc = Application.StartupPath & "\config"
        ElseIf File.Exists(Application.StartupPath & "\bin\config") = True Then
            fileloc = Application.StartupPath & "\bin\config"
        Else
            If Not Directory.Exists(_appSysDir & "\bin\") Then
                Directory.CreateDirectory(_appSysDir & "\bin\")
            End If
            File.WriteAllText(_appSysDir & "\bin\config", My.Resources.ResourceManager.GetObject("configfile").ToString)
            fileloc = _appSysDir & "\bin\config"
        End If

        Return fileloc
    End Function

    ''' <summary>
    ''' Insert new value to config file.
    ''' </summary>
    ''' <param name="SectionName">
    ''' THe section name for the configuration.
    ''' </param>
    ''' <param name="KeyName">
    ''' The configuration variable name.
    ''' </param>
    ''' <param name="Value">
    ''' The value for configuration.
    ''' </param>
    Public Sub InsertConfigIniKey(SectionName As String, KeyName As String, Value As String)
        Dim options As New IniOptions() With {.SectionNameCaseSensitive = True, .KeyNameCaseSensitive = True}
        Dim iniFile As New IniFile
        Dim FileLoc As String = getConfigFile()

        iniFile.Load(FileLoc)

        If iniFile.Sections.Contains(SectionName) Then
            Dim iniSect As IniSection = iniFile.Sections(SectionName)
            If iniSect.Keys.Contains(KeyName) Then iniSect.Keys(KeyName).Value = Value Else iniSect.Keys.Add(KeyName, Value)
        Else
            iniFile.Sections.Add(SectionName).Keys.Add(KeyName, Value)
        End If

        iniFile.Save(FileLoc)
    End Sub

    'load connection
    Public Function loadCon(con_type As String, Optional showErrMsg As Boolean = True) As cnction
        Dim options As New IniOptions()
        Dim inifile As New IniFile(options)
        Dim x As New cnction

        Try
            inifile.Load(getConfigFile)

            With inifile.Sections(con_type)
                x.host = .Keys("Host").Value
                x.uid = .Keys("UID").Value
                x.pass = .Keys("Pass").Value
                x.db = .Keys("DB").Value
            End With
        Catch ex As Exception
            logError(ex, IIf(showErrMsg = True, False, True))
            consoleWriteLine("ERR:" & Date.Now.ToString("yyyyMMdd-hhmmss") & ":" & ex.Message & ":" & ex.StackTrace & ":" & ex.TargetSite.ToString)
            'Application.Exit()
        End Try

        Return x
    End Function

    '--------------------Stream IMG-----------------------
    Public Function streamImgUrl(imgurl As String) As Bitmap
        Dim webClient As System.Net.WebClient = New System.Net.WebClient
        Dim retImage As Bitmap
        Try
            retImage = Bitmap.FromStream(New System.IO.MemoryStream(webClient.DownloadData(imgurl)))

        Catch ex As Exception
            logError(ex)
            retImage = Global.Inventory.My.Resources.Resources.close
        End Try

        Return retImage
    End Function

    '--------------------logging db-----------------------


    '--------------logging file
    Private appSysDir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & Application.ProductName & "\"
    Private filename As String

    Private Sub createTXTfile(filedir As String, filenm As String, contain As List(Of String), append As Boolean)
        filename = filedir & filenm

        If Directory.Exists(filedir) = False Then
            Directory.CreateDirectory(filedir)
        End If

        If File.Exists(filename) = False Then
            File.Create(filename).Dispose()
        End If

        Dim writer As New StreamWriter(filename, append)
        For Each x As String In contain
            writer.WriteLine(x)
        Next
        writer.Close()
    End Sub

    Private Sub logErrToDb(err As List(Of String))

    End Sub

    Public Sub errLog(errList As List(Of String))
        Dim file As String = "\error_" & Date.Today.ToString("yyyyMMdd") & ".syslg"
        createTXTfile(appSysDir & "log", file, errList, True)
        logErrToDb(errList)
    End Sub

    '---------------Crytograph
    Private KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
    Private IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
    Private symmetricKey As RijndaelManaged = New RijndaelManaged() With {.Mode = CipherMode.CBC}
    Private enc As New System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(KEY_128, IV_128)
    Private decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(KEY_128, IV_128)

    Public Function encryptString(ByVal inputString As String) As String
        Dim _retString As String = ""

        If Not String.IsNullOrEmpty(inputString) Then
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
            cryptoStream.Write(enc.GetBytes(inputString), 0, inputString.Length)
            cryptoStream.FlushFinalBlock()
            _retString = Convert.ToBase64String(memoryStream.ToArray())
            memoryStream.Close()
            cryptoStream.Close()
        End If

        Return _retString
    End Function

    Public Function decryptString(ByVal cypherText As String) As String
        Dim _retString As String = ""

        If Not String.IsNullOrEmpty(cypherText) Then
            Dim cypherTextBytes As Byte() = Convert.FromBase64String(cypherText)
            Dim memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes(cypherTextBytes.Length) As Byte
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            _retString = enc.GetString(plainTextBytes, 0, decryptedByteCount)
        End If

        Return _retString
    End Function

    'MD5
    ''' <summary>
    ''' Generate MD5 from a <see cref="String"/>
    ''' </summary>
    ''' <param name="inputstring"><see cref="String"/> that need tobe hashed</param>
    ''' <returns>Generated MD5 <see cref="String"/></returns>
    ''' <remarks></remarks>
    Public Function computeHash(ByVal inputstring As String) As String
        Dim _retval As String = ""

        If Not String.IsNullOrEmpty(inputstring) Then
            Dim md5 As New MD5CryptoServiceProvider
            Dim hasByte() As Byte = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(inputstring))

            For Each s In hasByte
                _retval += s.ToString("x2")
            Next
        End If

        Return _retval
    End Function
End Module
