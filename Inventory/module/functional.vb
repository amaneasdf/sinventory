﻿Imports MadMilkman.Ini
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
        If sender.Value = 0 Then
            sender.ResetText()
        End If
    End Sub

    Public Sub numericLostFocus(x As NumericUpDown)
        x.Controls.Item(1).Text = x.Value
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

    Public Function removeCommaThousand(x As String) As Double
        Dim s As String = 0
        s = Replace(Replace(x, ",00", ""), ".", "")
        Dim y = Split(s, ",")
        Dim z As Double = 0
        If y.Count = 2 Then
            z = CDbl(y(0)) + (CDbl(y(1)) / 100)
        Else
            z = CDbl(y(0))
        End If
        Return z
    End Function

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
            Console.WriteLine("ERR:" & Date.Now.ToString("yyyyMMdd-hhmmss") & ":" & ex.Message & ":" & ex.StackTrace & ":" & ex.TargetSite.ToString)
        End Try

        Return x
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

    Public Sub errLog(errList As List(Of String))
        Dim file As String = "\error_" & Date.Today.ToString("yyyyMMdd") & ".syslg"
        createTXTfile(appSysDir & "log", file, errList, True)
    End Sub
End Module
