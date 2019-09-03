Public Class UserData
    Public Enum UserStatus
        Setup
        Active
        Block
        Unknown
    End Enum

    Public Enum UserPriviledge
        MasterAdd
        MasterEdit
        MasterValid
        TransAdd
        TransEdit
        TransValid
        AccountAdd
        AccountEdit
        AccountValid
        ADMIN
    End Enum

    'Private WithEvents tmer As New Timer

    'PROTECTED PROPERTIES
    Private _User_ID As String
    Private _User_Level As String
    Private _Add_Master As Boolean
    Private _Add_Transaksi As Boolean
    Private _Add_akuntansi As Boolean
    Private _Edit_Master As Boolean
    Private _Edit_Transaksi As Boolean
    Private _Edit_Akuntansi As Boolean
    Private _Valid_Master As Boolean
    Private _Valid_Transaksi As Boolean
    Private _Valid_Akuntansi As Boolean
    Private _Admin As Boolean 'Allow user to edit/manage app and system configuration, other normal user could access some app config (In Future)

    'general info
    Public Property user_id As String
        Get
            Return _User_ID
        End Get
        Set(value As String)
            _User_ID = value
            consoleWriteLine("User ID Changed : " & value & " : " & Now)
        End Set
    End Property
    Public user_nama As String
    Public saleskode As String
    Public user_status As UserStatus
    Public user_session As String
    Public ReadOnly user_ver As String = Application.ProductVersion

    'Public Sub New()

    'End Sub

    'Public Sub New(ByVal AutoRefresh As Boolean, Optional ByVal RefreshInterval As Integer = 10000)
    '    If AutoRefresh = True Then
    '        tmer.Interval = RefreshInterval
    '        tmer.Start()
    '    End If
    'End Sub

    'computer info
    Public ReadOnly Property user_ip() As String
        Get
            Return GetIPv4Address()
        End Get
    End Property
    Public ReadOnly Property user_mac() As String
        Get
            Return GetMac(user_ip)
        End Get
    End Property
    Public ReadOnly Property user_host() As String
        Get
            Return System.Net.Dns.GetHostName()
        End Get
    End Property

    'level and access info
    Public Property user_lev() As String
        Get
            Return _User_Level
        End Get
        Set(value As String)
            _User_Level = value
        End Set
    End Property
    Public Property allowedit_master As Boolean
        Get
            Dim x = GetPriviledgeStatus(UserPriviledge.MasterEdit)
            _Edit_Master = IIf(x = TriState.UseDefault, _Edit_Master, x)
            Return _Edit_Master
        End Get
        Set(value As Boolean)
            _Edit_Master = value
        End Set
    End Property
    Public Property allowedit_transact As Boolean
        Get
            Dim x = GetPriviledgeStatus(UserPriviledge.TransEdit)
            _Edit_Transaksi = IIf(x = TriState.UseDefault, _Edit_Transaksi, x)
            Return _Edit_Transaksi
        End Get
        Set(value As Boolean)
            _Edit_Transaksi = value
        End Set
    End Property
    Public Property allowedit_akun As Boolean
        Get
            Dim x = GetPriviledgeStatus(UserPriviledge.AccountEdit)
            _Edit_Akuntansi = IIf(x = TriState.UseDefault, _Edit_Akuntansi, x)
            Return _Edit_Akuntansi
        End Get
        Set(value As Boolean)
            _Edit_Akuntansi = value
        End Set
    End Property
    Public Property validasi_master As Boolean
        Get
            Dim x = GetPriviledgeStatus(UserPriviledge.MasterValid)
            _Valid_Master = IIf(x = TriState.UseDefault, _Valid_Master, x)
            Return _Valid_Master
        End Get
        Set(value As Boolean)
            _Valid_Master = value
        End Set
    End Property
    Public Property validasi_trans As Boolean
        Get
            Dim x = GetPriviledgeStatus(UserPriviledge.TransValid)
            _Valid_Transaksi = IIf(x = TriState.UseDefault, _Valid_Transaksi, x)
            Return _Valid_Transaksi
        End Get
        Set(value As Boolean)
            _Valid_Transaksi = value
        End Set
    End Property
    Public Property validasi_akun As Boolean
        Get
            Dim x = GetPriviledgeStatus(UserPriviledge.AccountValid)
            _Valid_Akuntansi = IIf(x = TriState.UseDefault, _Valid_Akuntansi, x)
            Return _Valid_Akuntansi
        End Get
        Set(value As Boolean)
            _Valid_Akuntansi = value
        End Set
    End Property
    Public Property admin_pc As Boolean
        Get
            Dim x = GetPriviledgeStatus(UserPriviledge.ADMIN)
            _Admin = IIf(x = TriState.UseDefault, _Admin, x) : Return _Admin
        End Get
        Set(value As Boolean)
            _Admin = value
        End Set
    End Property

    Private Function GetPriviledgeStatus(type As UserPriviledge) As TriState
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Config is empty")
        End If
        If IsNothing(type) Then
            Throw New ArgumentNullException("Type cannot be empty")
        End If
        Dim retval As TriState = TriState.UseDefault
        Dim q As String = "SELECT {0} FROM data_pengguna_alias WHERE user_alias='{1}'"
        Dim _col As String = ""
        Select Case type
            Case UserPriviledge.MasterEdit : _col = "user_allowedit_master"
            Case UserPriviledge.MasterValid : _col = "user_validasi_master"
            Case UserPriviledge.TransEdit : _col = "user_allowedit_trans"
            Case UserPriviledge.TransValid : _col = "user_validasi_trans"
            Case UserPriviledge.AccountEdit : _col = "user_allowedit_akun"
            Case UserPriviledge.AccountValid : _col = "user_validasi_akun"
            Case UserPriviledge.ADMIN : _col = "user_admin_pc"
            Case Else
                Return Nothing
                Exit Function
        End Select

        q = String.Format(q, _col, user_id)
        Using x As New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Using rdx = x.ReadCommand(q, CommandBehavior.SingleResult)
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            retval = IIf(rdx.Item(0) = 1, TriState.True, TriState.False)
                        Else
                            retval = TriState.UseDefault
                        End If
                    End Using
                Catch ex As Exception
                    logError(ex, True)
                    retval = TriState.UseDefault
                End Try
            Else
                retval = TriState.UseDefault
            End If
        End Using
        Return retval
    End Function

    'Private Async Sub RefreshUserData(sender As Object, e As EventHandler) Handles tmer.Tick
    '    Dim _forcestop As Boolean = False
    '    If MainConnection.Connection Is Nothing Then
    '        _forcestop = True
    '    End If

    '    If _forcestop Then
    '        tmer.Stop()
    '    End If
    'End Sub

End Class
