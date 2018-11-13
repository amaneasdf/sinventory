Imports MadMilkman.Ini
Imports System.IO

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
                & "WHERE {0} BETWEEN tutupbk_periode_tglawal AND IFNULL(tutupbk_periode_tglakhir,NOW()) AND tutupbk_status=1"
            readcommd(String.Format(q, IIf(selecteddate = Nothing, "NOW()", "'" & selecteddate.ToString("yyyy-MM-dd") & "'")))
            If rd.HasRows Then
                kodeperiode = rd.Item(0)
            End If
            rd.Close()
        End If

        q = "SELECT tutupbk_id,tutupbk_periode_tglawal, tutupbk_periode_tglakhir FROM data_tutup_buku " _
            & "WHERE tutupbk_status=1 AND tutupbk_id='{0}'"
        readcommd(String.Format(q, kodeperiode))
        If rd.HasRows Then
            selected.id = rd.Item(0)
            selected.tglawal = rd.Item(1)
            selected.tglakhir = rd.Item(2)
        Else
            selected.id = "1"
            selected.tglawal = "1990-01-01"
            selected.tglakhir = "2100-12-01"
        End If
        rd.Close()

        Return selected
    End Function

    Public Sub setperiode(selecteddate As Date)
        Dim x As Date = selecteddate
        Dim lastperiod As String = selectperiode.id

        getPeriode(, selecteddate)

        If lastperiod <> selectperiode.id Then
            main.strip_periode.Text = "Periode Data : " & selectperiode.tglawal.ToShortDateString & " s.d. " & selectperiode.tglakhir.ToShortDateString

            Dim tbpg As TabPage() = {
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
                pgjurnalumum
                }
            doRefreshTab(tbpg)

            MessageBox.Show("Periode has been changed to " & selectperiode.tglawal.ToShortDateString & " s.d. " & selectperiode.tglakhir.ToShortDateString)
        End If

        If x.ToString("MMMM yyyy") <> selectedperiode.ToString("MMMM yyyy") Then
            selectedperiode = DateSerial(x.Year, x.Month, 1)
            main.strip_periode.Text = "Periode data : " & selectedperiode.ToString("MMMM yyyy")

            'TODO:REFRESH TAB
            Dim tbpg As TabPage() = {
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
                pgjurnalumum
                }
            doRefreshTab(tbpg)

            MessageBox.Show("Periode has been changed to " & selectedperiode.ToString("MMMM yyyy"))

        End If
    End Sub

    Public Sub doRefreshTab(tab As TabPage())
        For Each y As TabPage In tab
            If main.tabcontrol.Contains(y) = True Then
                refreshTabPage(y.Name.ToString)
            End If
        Next
    End Sub

    '-----------.ini file manipulation-------------
    'load connection
    Public Function loadCon(con_type As String) As cnction
        Dim options As New IniOptions()
        Dim inifile As New IniFile(options)
        Dim x As cnction

        x.host = "localhost"
        x.uid = "root"
        x.pass = "root"
        x.db = "db-inventory"

        Try
            inifile.Load(Application.StartupPath & "\config.ini")
            Console.WriteLine(Application.StartupPath & "\config.ini")
            With inifile.Sections(con_type)
                x.host = .Keys("Host").Value
                x.uid = .Keys("UID").Value
                x.pass = .Keys("Pass").Value
                x.db = .Keys("DB").Value
            End With
        Catch ex As Exception
            logError(ex)
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
            Console.WriteLine("log act added")
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
    Private appSysDir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SIMInvent\"
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
End Module
