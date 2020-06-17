Public Class UserData
    'PROTECTED PROPERTIES
    Private _User_Alias As String
    Private _User_Group As String
    Private _User_Salescode As String

    Private _Add_Master As Boolean
    Private _Add_Transaksi As Boolean
    Private _Add_Akuntansi As Boolean
    Private _Edit_Master As Boolean
    Private _Edit_Transaksi As Boolean
    Private _Edit_Stock As Boolean
    Private _Edit_Akuntansi As Boolean
    Private _Valid_Master As Boolean
    Private _Valid_Transaksi As Boolean
    Private _Valid_Stock As Boolean
    Private _Valid_Akuntansi As Boolean
    Private _SysAdmin As Boolean 'Allow user to edit/manage app and system configuration, other normal user could access some app config (In Future)
    Private _IsDev As Boolean

    'GENERAL INFO
    Public Property User_Alias As String
        Get
            Return _User_Alias
        End Get
        Set(value As String)
            _User_Alias = value
            consoleWriteLine("User Alias Changed : " & value & " : " & Now)
        End Set
    End Property
    Public User_Session As String
    Public User_Nama As String
    Public saleskode As String
    Public ReadOnly Property User_Version As String
        Get
            Return Application.ProductVersion
        End Get
    End Property

    'COMPUTER VERSION
    Public ReadOnly Property User_IP() As String
        Get
            Return GetIPv4Address()
        End Get
    End Property
    Public ReadOnly Property User_MAC() As String
        Get
            Return GetMac(User_IP)
        End Get
    End Property
    Public ReadOnly Property User_Host() As String
        Get
            Return System.Net.Dns.GetHostName()
        End Get
    End Property
    Public ReadOnly Property User_HWID() As String
        Get
            Return GetHWID()
        End Get
    End Property

    'USER GROUP AND ACCESS PRIVILEDGE
    Public ReadOnly Property User_Group() As String
        Get
            GetGroup() : Return _User_Group
        End Get
    End Property
    Public ReadOnly Property AllowEdit_Master As Boolean
        Get
            _Edit_Master = If(GetUserDataValue("user_allowedit_master").ToString = "1", True, False)
            Return _Edit_Master
        End Get
    End Property
    Public ReadOnly Property AllowEdit_Transaction As Boolean
        Get
            _Edit_Transaksi = If(GetUserDataValue("user_allowedit_trans").ToString = "1", True, False)
            Return _Edit_Transaksi
        End Get
    End Property
    Public ReadOnly Property AllowEdit_Accounting As Boolean
        Get
            _Edit_Akuntansi = If(GetUserDataValue("user_allowedit_akun").ToString = "1", True, False)
            Return _Edit_Akuntansi
        End Get
    End Property
    Public ReadOnly Property Validasi_Master As Boolean
        Get
            _Valid_Master = If(GetUserDataValue("user_validasi_master").ToString = "1", True, False)
            Return _Valid_Master
        End Get
    End Property
    Public ReadOnly Property Validasi_Transaction As Boolean
        Get
            _Valid_Transaksi = If(GetUserDataValue("user_validasi_trans").ToString = "1", True, False)
            Return _Valid_Transaksi
        End Get
    End Property
    Public ReadOnly Property Validasi_Accounting As Boolean
        Get
            _Valid_Akuntansi = If(GetUserDataValue("user_validasi_akun").ToString = "1", True, False)
            Return _Valid_Akuntansi
        End Get
    End Property
    Public ReadOnly Property PC_SysAdmin As Boolean
        Get
            _SysAdmin = If(GetUserDataValue("user_admin_pc").ToString = "1", True, False)
            Return _SysAdmin
        End Get
    End Property

    'OTHER
    Public ReadOnly Property IsEmpty As Boolean
        Get
            Return String.IsNullOrWhiteSpace(User_Alias)
        End Get
    End Property

    'CHANGE / REMOVE
    Public User_ID As String = User_Alias
    Public ReadOnly AllowEdit_Transact = AllowEdit_Transaction
    Public ReadOnly AllowEdit_Akun = AllowEdit_Accounting
    Public ReadOnly Validasi_Trans = Validasi_Transaction
    Public ReadOnly Validasi_Akun = Validasi_Accounting
    Public ReadOnly Admin_PC = PC_SysAdmin

    'FUNCTION
    Public Function GetNama() As String
        Dim _nama As String = GetUserDataValue("user_nama").ToString
        If Not String.IsNullOrWhiteSpace(_nama) Then User_Nama = _nama
        Return _nama
    End Function

    Public Function GetGroup() As String
        Dim _nama As String = GetUserDataValue("user_group").ToString
        If Not String.IsNullOrWhiteSpace(_nama) Then _User_Group = _nama
        Return _nama
    End Function

    Private Function GetUserDataValue(ColumnName As String) As Object
        If Me.IsEmpty Then Return String.Empty
        If MainConnData.IsEmpty Then Return String.Empty

        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = "SELECT {1} FROM data_pengguna_alias WHERE user_alias='{0}'"
                    Dim _nama = x.ExecScalar(String.Format(q, User_Alias, ColumnName))
                    User_Nama = _nama
                    Return _nama
                Else
                    Return String.Empty
                End If
            End Using
        Catch ex As Exception
            LogError(ex) : consoleWriteLine(ex.Message)
            Return String.Empty
        End Try
    End Function
End Class
