Imports MadMilkman.Ini
Imports System.IO
Imports OfficeOpenXml
Imports System.Security.Cryptography

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
            Console.WriteLine(fr.Left & "*" & fr.Top)
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
        Console.WriteLine(sender.Value)
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
    Public Function stringCurrency(x As Double) As String
        Dim s As String = ""
        s = x.ToString("C2", System.Globalization.CultureInfo.CreateSpecificCulture("id-ID"))
        Return s
    End Function

    Public Function commaThousand(x As Double) As String
        Dim s As String = ""
        s = x.ToString("N2", System.Globalization.CultureInfo.CreateSpecificCulture("id-ID"))
        Return s
    End Function

    Public Function removeCommaThousand(x As String) As Decimal
        If x = Nothing Then
            Return 0
            Exit Function
        End If

        Dim s As String = 0
        s = Replace(Replace(x, ",00", ""), ".", "")
        Dim y = Split(s, ",")
        Dim z As Decimal = 0
        If y.Count = 2 Then
            z = CDec(y(0)) + (CDec(y(1)) / 100)
        Else
            z = CDec(y(0))
        End If
        Return z
    End Function

    Public Function mysqlQueryFriendlyStringFeed(text As String) As String
        Return text.Replace("'", "\'").Replace("%", "\%").Replace("_", "\_")
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
            main.strip_periode.Text = "Periode Data : " & selectperiode.tglawal.ToShortDateString & " s.d. " & selectperiode.tglakhir.ToShortDateString
            main.strip_status.Text = "Status Input : " & IIf(selectperiode.closed = True, "Closed", "Open")
            Dim tbpg As TabPage() = {
                pgperkiraan,
                pgstockop,
                pgstok,
                pgpembelian,
                pgpenjualan,
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
                pgjurnalmemorial,
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
        For Each y As TabPage In tab
            If main.tabcontrol.Contains(y) = True Then
                refreshTabPage(y.Name.ToString)
            End If
        Next
    End Sub

    'EXPORT EXCEL
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
                    Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
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
    'load connection
    Public Function loadCon(con_type As String, Optional showErrMsg As Boolean = True) As cnction
        Dim options As New IniOptions()
        Dim inifile As New IniFile(options)
        Dim x As cnction

        Try
            inifile.Load(Application.StartupPath & "\config.ini")
            consoleWriteLine(Application.StartupPath & "\config.ini")
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
    'log activity
    Public Sub createLogAct(act As String)
        If log_switch.log_act = False Then
            Exit Sub
        End If

        Dim querycheck As Boolean = False
        Dim dataAct As String() = {
            "aktivitas_tanggal=NOW()",
            "aktivitas_jam=NOW()",
            "aktivitas_user='" & loggeduser.user_id & "'",
            "aktivitas_ip='" & loggeduser.user_ip & "'",
            "aktivitas_mac='" & loggeduser.user_mac & "'",
            "aktivitas_komputer='" & loggeduser.user_host & "'",
            "aktivitas_versi='" & Application.ProductVersion & "'",
            "aktivitas_log='" & act & "'"
            }

        op_con()
        querycheck = commnd("INSERT INTO log_aktivitas SET " & String.Join(",", dataAct))

        If querycheck = False Then
            Exit Sub
        Else
            consoleWriteLine("log act added")
        End If
    End Sub

    'log stock
    Public Sub createLogStock(query As List(Of String))
        If log_switch.log_stock = False Then
            Exit Sub
        End If

        Dim errorquery As New List(Of String)
        Dim querycheck As Boolean = False

        For Each x As String In query
            querycheck = commnd(x)
            If querycheck = False Then
                errorquery.Add(x)
            End If
        Next
        'If errorquery.Count > 0 Then

        'End If
    End Sub

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

    'MD5 x2 compute hash
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
