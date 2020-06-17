Module dbChecking
    '================================================================================================================
    'GET APP AND DATABASE STATUS AND PROPERTY/VARIABLE
    'GET SERVER DATE TIME
    Public Function GetServerDate() As Date
        Return GetServerDate(MainConnData)
    End Function

    Public Function GetServerDate(ConnData As ConnectionData) As Date
        If ConnData.IsEmpty Then Throw New ArgumentNullException("ConnData", "Database connection configuration is empty.")
        Dim _serverdate As Date = Now
        Using x = New MySqlThing(ConnData.host, ConnData.db, decryptString(ConnData.uid), decryptString(ConnData.pass))
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Return Date.Parse(x.ExecScalar("SELECT NOW()"))
            Else
                Throw New Exception("Cannot connect to database.")
            End If
        End Using
    End Function

    Public Function TryGetServerDate(ByRef ServerDate As Date, Optional ByRef Msg As String = "") As Boolean
        Try
            ServerDate = GetServerDate()
            Return True
        Catch ex As Exception
            LogError(ex) : Msg = ex.Message
            Return False
        End Try
    End Function

    Public Function TryGetServerDate(ConnData As ConnectionData, ByRef ServerDate As Date, Optional ByRef Msg As String = "") As Boolean
        Try
            ServerDate = GetServerDate(ConnData)
            Return True
        Catch ex As Exception
            LogError(ex) : Msg = ex.Message
            Return False
        End Try
    End Function

    'GET SYSTEMWIDE SETTING VARIABLE FROM DB
    Public Function GetSettingFromDB(SettingName As String) As Object
        If MainConnData.IsEmpty Then Throw New ArgumentNullException("MainConnData", "Database connection configuration is empty.")
        Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Return x.ExecScalar(String.Format("SELECT var_value FROM system_var WHERE var_name='{0}'", SettingName))
            Else
                Throw New Exception("Cannot connect to database.")
            End If
        End Using
    End Function

    '================================================================================================================
    'GET USER DATA FOR LOGIN
    'CHECKING INPUTED USERNAME AND PASSWORD
    Public Function CheckUser(UserAlias As String, Pass As String, ByRef RespMsg As String, ByRef UserID As String) As Integer
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = "" : Dim _count As Integer = 0

                    'CHECK DATA AVALIABILITY
                    q = "SELECT COUNT(user_alias) FROM data_pengguna_alias WHERE user_alias='{0}' AND user_status<9"
                    _count = Integer.Parse(x.ExecScalar(String.Format(q, UserAlias)))
                    If _count = 1 Then
                        'IF EXIST
                        'COMPARE INPUTED PASSWORD AND GETTING USER STATUS
                        q = "SELECT user_pwd='{1}' FROM data_pengguna_alias WHERE user_alias='{0}' AND user_status<9"
                        Using rdx = x.ReadCommand(String.Format(q, UserAlias, computeHash(Pass)))
                            Dim red = rdx.Read
                            If red And rdx.HasRows Then
                                _count = Integer.Parse(rdx.Item(0))
                            Else
                                RespMsg = "Tidak dapat menemukan data user."
                                LogError(New Exception("Cannot find user data. Query:" & String.Format(q, UserAlias, computeHash(Pass))))
                                Return 10
                            End If
                        End Using

                        If _count = 0 Then
                            'IF INPUTED PASSWORD DOESNT MATCH WITH STORED PASSWORD
                            RespMsg = "Username/Password yang dimasukan salah." : Return 2
                        Else
                            'GET USER ID
                            q = "SELECT user_id FROM data_pengguna_alias WHERE user_alias='{0}' AND user_status<9"
                            UserID = x.ExecScalar(String.Format(q, UserAlias)).ToString
                            If String.IsNullOrWhiteSpace(UserID) Then
                                RespMsg = "User ID untuk user tersebut tidak dapat ditemukan."
                                LogError(New Exception(String.Format("User ID for user {0} is empty.", UserAlias)))
                                Return 10
                            Else
                                RespMsg = "OK" : Return 1
                            End If
                        End If
                    ElseIf _count > 1 Then
                        'IF DUPLICATED
                        RespMsg = "Duplicate user data entry for user " & UserAlias & ". Please contact R&D Div. ASAP, PLS, THX."
                        LogError(New Exception("Duplicate user data entry for user " & UserAlias & "."))
                        Return 10
                    Else
                        'IF NOT EXIST
                        RespMsg = "Username/Password yang dimasukan salah." : Return 0
                    End If
                Else
                    RespMsg = "Tidak dapat terhubung ke database." : Return 10
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            RespMsg = String.Format("An error has been occured.{0}{1}{0}Please contact R&D Div. ASAP, PLS, THX.", Environment.NewLine, ex.Message)
            Return 10
        End Try
    End Function

    'LOGIN LOG
    Public Function LogLogin(ByRef LoggedUser As UserData) As KeyValuePair(Of Boolean, String)
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = "" : Dim _SessionID As String = ""
                    'UPDATE LAST LOGIN FROM SAME COMPUTER AND HWID THAT DIDNT LOGGED OUT
                    q = "UPDATE system_login_log SET log_status=3, log_end=NOW() WHERE log_user='{0}' AND log_komputer='{1}' AND log_HWID='{2}' AND log_status=1"
                    x.ExecCommand(String.Format(q, LoggedUser.User_Alias, LoggedUser.User_Host, LoggedUser.User_HWID))

                    'INSERT NEW LOGIN LOG AND GET SESSION ID
                    q = "SELECT Log_NewLogin('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')"
                    _SessionID = x.ExecScalar(String.Format(q, LoggedUser.User_Alias, LoggedUser.User_IP, LoggedUser.User_MAC,
                                                            LoggedUser.User_Host, LoggedUser.User_HWID, LoggedUser.User_Version
                                                            )
                                                ).ToString

                    'SET SESSION ID TO USER DATA
                    If String.IsNullOrWhiteSpace(_SessionID) Then
                        Return New KeyValuePair(Of Boolean, String)(False, "Session ID kosong.")
                    Else
                        LoggedUser.User_Session = _SessionID
                        Return New KeyValuePair(Of Boolean, String)(True, _SessionID)
                    End If
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, ex.Message)
        End Try
    End Function
    '================================================================================================================


    '================================================================================================================
    'CHECKING IS DATA MASTER ALLOWED TO BE DEACTIVATED OR DELETED
    Public Function IsAllowedToDeactivate_Master(DataType As String, DataID As String) As KeyValuePair(Of Boolean, String)
        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _qLst As New List(Of String)
                    Select Case DataType.ToLower
                        Case "supplier", "suplier"
                            _qLst.Add("SELECT COUNT(barang_id) FROM data_barang_master WHERE barang_supplier='{0}' AND barang_status IN (0,1)")

                        Case Else
                            Return New KeyValuePair(Of Boolean, String)(False, "Jenis data tidak sesuai.")
                    End Select

                    For Each q As String In _qLst
                        Dim _count = Integer.Parse(x.ExecScalar(String.Format(q, DataID)))
                        If _count > 0 Then Return New KeyValuePair(Of Boolean, String)(False, "")
                    Next

                    Return New KeyValuePair(Of Boolean, String)(True, "")
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, "Terjadi kesalahan saat melakukan pengecekan status data." & Environment.NewLine & ex.Message)
        End Try
    End Function

    Private Function getsingleresult(query As String) As Object
        If MainConnection.Connection Is Nothing Then Throw New NullReferenceException("Main DB connection setting is empty")
        Dim retval As Object = Nothing

        Using x = MainConnection
            x.Open()
            Using rdx As MySql.Data.MySqlClient.MySqlDataReader = x.ReadCommand(query, CommandBehavior.SingleResult)
                Dim red = rdx.Read()
                If red And rdx.HasRows Then
                    retval = rdx.Item(0)
                Else
                    retval = Nothing
                End If
            End Using
        End Using

        Return retval
    End Function

    Private Async Function getsingleresultAsync(query As String) As Task(Of Object)
        If MainConnection.Connection Is Nothing Then Throw New NullReferenceException("Main DB connection setting is empty")
        Dim retval As Object = Nothing

        Using x = MainConnection
            Await x.OpenAsync()
            Using rdx As MySql.Data.MySqlClient.MySqlDataReader = Await x.ReadCommandAsync(query, CommandBehavior.SingleResult)
                Dim red = Await rdx.ReadAsync
                If red And rdx.HasRows Then
                    retval = rdx.Item(0)
                Else
                    retval = Nothing
                End If
            End Using
        End Using

        Return retval
    End Function

    'STOCK
    Public Function GetItemStock(IdBarang As String) As Integer
        Return GetItemStock(IdBarang, "")
    End Function

    Public Function GetItemStock(IdBarang As String, IdGudang As String) As Integer
        Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Return Integer.Parse(x.ExecScalar(String.Format("SELECT Stock_GetSisaQTY('{0}','{1}')", IdBarang, IdGudang)))
            Else
                Throw New Exception("Cannot connect to database.")
            End If
        End Using
    End Function

    Public Function GetItemSmallQty(IdBarang As String, Qty As Integer, SatType As String) As Integer
        Dim retval As Integer = Nothing
        Dim q As String = "SELECT countQTYItem('{0}','{1}','{2}')"

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, IdBarang, Qty, SatType), CommandBehavior.SingleResult)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        retval = rdx.Item(0)
                    End If
                End Using
            End If
        End Using
        Return retval
    End Function

    Public Function GetSatuanForCombo(KodeBarang As String, ByRef IsiTengah As Integer, ByRef IsiBesar As Integer) As DataTable
        If String.IsNullOrWhiteSpace(KodeBarang) Then
            Throw New ArgumentNullException("KodeBarang cannot be empty")
        End If
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If
        Dim retval As New DataTable
        retval.Columns.Add("Text", GetType(String))
        retval.Columns.Add("Value", GetType(String))

        Dim q As String = "SELECT barang_satuan_kecil, barang_satuan_tengah, barang_satuan_besar,barang_satuan_tengah_jumlah, " _
                                  & "barang_satuan_besar_jumlah FROM data_barang_master WHERE barang_kode='{0}'"
        Using x As MySqlThing = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using rdx As MySql.Data.MySqlClient.MySqlDataReader = x.ReadCommand(String.Format(q, KodeBarang), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        retval.Rows.Add(rdx.Item("barang_satuan_kecil"), "kecil")
                        retval.Rows.Add(rdx.Item("barang_satuan_tengah"), "tengah")
                        retval.Rows.Add(rdx.Item("barang_satuan_besar"), "besar")
                        IsiTengah = rdx.Item("barang_satuan_tengah_jumlah")
                        IsiBesar = rdx.Item("barang_satuan_besar_jumlah")
                    End If
                End Using
            End If
        End Using

        Return retval
    End Function

    'GET VALUE OF HUTANG/PIUTANG
    Public Function GetPiutangCusto(KodeCusto As String) As Decimal
        Return GetHutangPiutang(KodeCusto, "PiutangCusto")
    End Function

    Public Function GetPiutang(KodePiutang As String) As Decimal
        Return GetHutangPiutang(KodePiutang, "Piutang")
    End Function

    Public Function GetHutangSupl(KodeSupl As String) As Decimal
        Return GetHutangPiutang(KodeSupl, "HutangSupl")
    End Function

    Public Function GetHutang(KodeHutang As String) As Decimal
        Return GetHutangPiutang(KodeHutang, "Hutang")
    End Function

    Private Function GetHutangPiutang(Kode As String, TransType As String) As Decimal
        If String.IsNullOrWhiteSpace(TransType) Then
            Throw New ArgumentNullException("TransType cannot be empty")
        End If
        If String.IsNullOrWhiteSpace(Kode) Then
            Throw New ArgumentNullException("Kode " & TransType & " cannot be empty")
        End If

        Dim q As String = ""
        Dim retval As Decimal = 0

        Select Case TransType
            Case "HutangSupl" : q = "SELECT getHutangSisaSupl('{0}')"
            Case "Hutang" : q = "SELECT getHutangSisa('{0}');"
            Case "PiutangCusto" : q = "SELECT getPiutangSisaCusto('{0}');"
            Case "Piutang" : q = "SELECT getPiutangSisa('{0}');"
        End Select

        If Not Decimal.TryParse(getsingleresult(String.Format(q, Kode)), retval) Then Throw New Exception("Result type from db is not decimal")

        Return retval
    End Function

    'CONFIRM DIALOG -> VALID TRANSAKSI
    Public Function TransConfirmValid(ByRef ValidUid As String) As Boolean
        Using valid As New fr_jualconfirm_dialog
            valid.doLoadValid()
            If valid.returnval.Key Then
                ValidUid = valid.returnval.Value
                Return True
            Else
                If valid.returnval.Value <> String.Empty Then
                    MessageBox.Show(valid.returnval.Value, valid.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                Return False
            End If
        End Using
    End Function

    Public Function AkunConfirmValid(ByRef ValidUid As String) As Boolean
        Using valid As New fr_akun_confirmdialog
            'valid.doLoadValid()
            If valid.returnval.Key Then
                ValidUid = valid.returnval.Value
                Return True
            Else
                If valid.returnval.Value <> String.Empty Then
                    MessageBox.Show(valid.returnval.Value, valid.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                Return False
            End If
        End Using
    End Function

    'CONFIRM DIALOG -> VALID MASTER
    Public Function MasterConfirmValid(ByRef Keterangan As String) As Boolean
        Dim valid As Boolean = False

        Using x As New fr_master_confirmdialog
            x.lbl_title.Text = "Konfirmasi Data Master"
            x.in_user.Text = loggeduser.User_Alias
            x.do_loaddialog()
            If x.returnval = True Then
                If loggeduser.User_Alias <> x.in_user.Text Then
                    MessageBox.Show("User tidak sama dengan user yg anda gunakan untuk login. Pastikan anda menggunakan user yang sama untuk meakukan validasi",
                                    x.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    valid = False
                Else
                    Keterangan += IIf(Keterangan = Nothing, "", Environment.NewLine) & x.in_ket.Text
                    valid = x.returnval
                End If
            End If
        End Using

        Return valid
    End Function

    'CHECK TRANSACTION DATA BEFORE CANCELING OR DELETING TRANSACTION
    'ORDER PENJUALAN
    Public Function CheckCancelPesanan(KodeFaktur As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim retval As Boolean = False
        Dim q As String = "SELECT j_order_kode, j_order_status status, IFNULL(j_order_ref_faktur,'') faktur FROM data_penjualan_order_faktur WHERE j_order_kode='{0}'"
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _status As Integer = 0 : Dim _kode As String = Nothing : Dim _next As Boolean = False
                Using rdx = x.ReadCommand(String.Format(q, KodeFaktur), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _status = rdx.Item("status") : _kode = rdx.Item("faktur") : _next = True
                    Else
                        _next = False
                    End If
                End Using

                'CHECK TRANSACTION DATE
                q = "SELECT j_order_tanggal_trans FROM data_penjualan_order_faktur WHERE j_order_kode={0}"
                If Date.Parse(x.ExecScalar(String.Format(q, KodeFaktur))) < TransStartDate Then
                    Msg = "Periode transaksi untuk order penjualan tersebut sudah diclosing."
                    Return False
                End If

                If _next Then
                    If {0, 1}.Contains(_status) Then
                        If _status = 1 And String.IsNullOrWhiteSpace(_kode) = False Then
                            retval = False : Msg = "Transaksi sudah divalidasi dan dilakukan proses penjualan."
                        Else
                            retval = True
                        End If
                    ElseIf _status = 2 Then
                        retval = False : Msg = "Transaksi sudah di batalkan."
                    Else
                        retval = False : Msg = "Kode status transaksi tidak sesuai."
                    End If
                Else
                    retval = _next
                    Msg = "Terjadi kesalahan saat melakukan pengecekan data order. Data tidak dapat ditemukan."
                End If
            Else
                Msg = "Tidak dapat terhubung ke database." : retval = False
            End If
        End Using
        Return retval
    End Function

    'PENJUALAN
    Public Function CheckCancelPenjualan(KodeFaktur As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim q As String = ""
                    'CHECK AVALIABILITY
                    q = "SELECT COUNT(faktur_id) FROM data_penjualan_faktur WHERE faktur_kode='{0}'"
                    If Integer.Parse(x.ExecScalar(String.Format(q, KodeFaktur))) > 0 Then
                        'IF EXIST
                        'CHECK STATUS TRANSAKSI
                        q = "SELECT faktur_status FROM data_penjualan_faktur WHERE faktur_kode='{0}' AND faktur_status<9 ORDER BY faktur_id DESC LIMIT 1"
                        Dim _sts As Integer = Integer.Parse(x.ExecScalar(String.Format(q, KodeFaktur)))
                        If {0, 1}.Contains(_sts) Then
                            'IF TRANSACTION STATUS IS ACTIVE OR PENDING
                            'COMPARE TRANSACTION DATE AND TRANSACTION STARTING DATE
                            q = "SELECT faktur_tanggal_trans FROM data_penjualan_faktur WHERE faktur_kode = '{0}' AND faktur_status<9"
                            If Date.Parse(x.ExecScalar(String.Format(q, KodeFaktur))) < TransStartDate Then
                                Msg = "Periode transaksi untuk faktur tersebut sudah diclosing." : Return False
                            End If

                            'CHECK PEMBAYARAN PIUTANG
                            q = "SELECT COUNT(p_trans_id) FROM data_piutang_trans WHERE p_trans_kode_piutang='{0}' AND p_trans_jenis<>'jual' AND p_trans_status=1"
                            If Integer.Parse(x.ExecScalar(String.Format(q, KodeFaktur))) = 0 Then
                                Return True
                            Else
                                Msg = "Transaksi penjualan/piutang sudah dilakukan pembayaran." : Return False
                            End If

                        ElseIf _sts = 2 Then
                            'IF TRANSACTION STATUS IS CANCELED
                            Msg = "Transaksi sudah di batalkan." : Return False

                        Else
                            Msg = "Kode status transaksi tidak sesuai." : Return False
                        End If
                    Else
                        'IF DATA NOT FOUND
                        Msg = "Data faktur penjualan " & KodeFaktur & " tidak dapat ditemukan." : Return False
                    End If
                Catch ex As Exception
                    logError(ex, True)
                    Msg = "Terjadi kesalahan saat melakukan pengecekan transaksi." & Environment.NewLine & ex.Message
                    Return False
                End Try
            Else
                Msg = "Tidak dapat terhubung ke database." : Return False
            End If
        End Using
    End Function

    'PEMBELIAN
    Public Function CheckCancelPembelian(KodeFaktur As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim q As String = ""
                    'CHECK AVALIABILITY
                    q = "SELECT COUNT(faktur_id) FROM data_pembelian_faktur WHERE faktur_kode='{0}'"
                    If Integer.Parse(x.ExecScalar(String.Format(q, KodeFaktur))) > 0 Then
                        'IF EXIST
                        'CHECK STATUS TRANSAKSI
                        q = "SELECT faktur_status FROM data_pembelian_faktur WHERE faktur_kode='{0}' AND faktur_status<9 ORDER BY faktur_id DESC LIMIT 1"

                        Dim _sts As Integer = Integer.Parse(x.ExecScalar(String.Format(q, KodeFaktur)))
                        If {0, 1}.Contains(_sts) Then
                            'IF TRANSACTION STATUS IS ACTIVE OR PENDING
                            'COMPARE TRANSACTION DATE AND TRANSACTION STARTING DATE
                            q = "SELECT faktur_tanggal_trans FROM data_pembelian_faktur WHERE faktur_kode = '{0}' AND faktur_status<9"
                            If Date.Parse(x.ExecScalar(String.Format(q, KodeFaktur))) < TransStartDate Then
                                Msg = "Periode transaksi untuk faktur tersebut sudah diclosing." : Return False
                            End If

                            'CHECK PEMBAYARAN HUTANG
                            q = "SELECT COUNT(h_trans_id) FROM data_hutang_trans WHERE h_trans_kode_hutang='{0}' AND h_trans_jenis<>'beli' AND h_trans_status=1"
                            If Integer.Parse(x.ExecScalar(String.Format(q, KodeFaktur))) = 0 Then
                                Return True
                            Else
                                Msg = "Transaksi pembelian/hutang sudah dilakukan pembayaran." : Return False
                            End If

                        ElseIf _sts = 2 Then
                            'IF TRANSACTION STATUS IS CANCELED
                            Msg = "Transaksi sudah di batalkan." : Return False

                        Else
                            Msg = "Kode status transaksi tidak sesuai." : Return False
                        End If
                    Else
                        'IF DATA NOT FOUND
                        Msg = "Data faktur pembelian " & KodeFaktur & " tidak dapat ditemukan." : Return False
                    End If
                Catch ex As Exception
                    logError(ex, True)
                    Msg = "Terjadi kesalahan saat melakukan pengecekan transaksi." & Environment.NewLine & ex.Message
                    Return False
                End Try
            Else
                Msg = "Tidak dapat terhubung ke database." : Return False
            End If
        End Using
    End Function

    'RETUR
    Public Function CheckCancelRetur(KodeFaktur As String, JenisRetur As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim retval As Boolean = False
        Dim q As String = ""

        Select Case LCase(JenisRetur)
            Case "beli"
                q = "SELECT faktur_kode_bukti, faktur_tanggal_trans, faktur_status status FROM data_pembelian_retur_faktur " _
                    & "WHERE faktur_kode_bukti='{0}' AND faktur_status<9"
            Case "jual"
                q = "SELECT faktur_kode_bukti, faktur_tanggal_trans, faktur_status status FROM data_penjualan_retur_faktur " _
                    & "WHERE faktur_kode_bukti='{0}' AND faktur_status<9"
            Case Else
                Return False
        End Select

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _next As Boolean = False
                Dim _state As Integer = 0 : Dim _date As Date = Today

                Using rdx = x.ReadCommand(String.Format(q, KodeFaktur))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _state = rdx.Item("status")
                        _date = rdx.Item(1)
                    Else
                        Msg = "Terjadi kesalahan saat melakukan pengecekan data. Data retur tidak dapat ditemukan"
                        Return False
                    End If
                End Using

                If _date < TransStartDate Then
                    Msg = "Periode transaksi untuk faktur tersebut sudah diclosing."
                    Return False
                End If

                If {0, 1}.Contains(_state) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Msg = "Tidak dapat terhubung ke database."
                Return False
            End If
        End Using
    End Function

    'KAS
    Public Function CheckCancelKas(KodeFaktur As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Try
            Dim retval As Boolean = False
            Dim q As String = "SELECT kas_tgl, kas_status status FROM data_kas_faktur WHERE kas_kode='{0}' AND kas_status<9"
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _state As Integer = 0 : Dim _date As Date = Today
                    Using rdx = x.ReadCommand(String.Format(q, KodeFaktur))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            _state = rdx.Item("status")
                            _date = rdx.Item(0)
                        Else
                            Msg = "Terjadi kesalahan saat melakukan pengecekan data. Data kas tidak dapat ditemukan."
                            Return False
                        End If
                    End Using

                    If _date < TransStartDate Then
                        Msg = "Periode transaksi untuk transaksi kas tersebut sudah diclosing."
                        Return False
                    End If

                    If Not {0, 1}.Contains(_state) Then Return False

                    Return True
                Else
                    Msg = "Tidak dapat terhubung ke database" : Return False
                End If
            End Using
        Catch ex As Exception
            logError(ex, True)
            Msg = "Terjadi kesalahan saat melakukan pengecekan transaksi." & Environment.NewLine & ex.Message
            Return False
        End Try
    End Function

    'PEMBAYARAN HUTANG/PIUTANG
    Public Function CheckCancelBayar(KodeFaktur As String, JenisBayar As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim retval As Boolean = False
        Dim q As String = ""

        Select Case LCase(JenisBayar)
            Case "hutang"
                q = "SELECT h_bayar_tgl_bayar, h_bayar_status status, IFNULL(giro_status_pencairan,0) statusgiro FROM data_hutang_bayar " _
                    & "LEFT JOIN data_giro ON giro_ref= h_bayar_bukti AND giro_type='OUT' AND giro_status =1 " _
                    & "WHERE h_bayar_bukti='{0}' AND h_bayar_status<9"
            Case "piutang"
                q = "SELECT p_bayar_tanggal_bayar, p_bayar_status status, IFNULL(giro_status_pencairan,0) statusgiro FROM data_piutang_bayar " _
                    & "LEFT JOIN data_giro ON giro_ref= p_bayar_bukti AND giro_type='IN' AND giro_status =1 " _
                    & "WHERE p_bayar_bukti='{0}' AND p_bayar_status<9"
            Case Else
                Msg = "Wrong transaction type."
                Return False
        End Select

        Try
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _state As Integer = 0 : Dim _date As Date = Today
                    Dim _girostate As Integer = 0
                    Using rdx = x.ReadCommand(String.Format(q, KodeFaktur))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            _state = rdx.Item("status")
                            _girostate = rdx.Item("statusgiro")
                            _date = rdx.Item(0)
                        Else
                            Msg = "Terjadi kesalahan saat melakukan pengecekan data. Data pembayaran tidak dapat ditemukan."
                            Return False
                        End If
                    End Using

                    'CHECK TRANSACTION DATE
                    If _date < TransStartDate Then
                        Msg = "Periode transaksi untuk pembayaran tersebut telah di closing."
                        Return False
                    End If

                    'CHECK STATUS
                    If {0, 1}.Contains(_state) Then
                        'CHECK STATUS GIRO
                        If Not _girostate = 0 Then
                            Msg = "Pembayaran melalui bilyet giro telah diproses"
                            Return False
                        End If

                        Return True
                    Else
                        Return False
                    End If
                Else
                    Msg = "Tidak dapat terhubung ke database."
                    Return False
                End If
            End Using
        Catch ex As Exception
            logError(ex, True)
            Msg = "Terjadi kesalahan saat melakukan pengecekan transaksi." & Environment.NewLine & ex.Message
            Return False
        End Try
    End Function

    'GET TRANS STATUS
    Public Function getTransStatus(KodeFaktur As String, JenisTrans As String, ByRef Msg As String) As Integer
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim _retval As Integer = 0
        Dim q As String = ""

        Msg = Nothing

        Select Case JenisTrans
            Case "pesanan"
                q = "SELECT j_order_status FROM data_penjualan_order_faktur WHERE j_order_kode='{0}'"
            Case "penjualan"
                q = "SELECT faktur_status FROM data_penjualan_faktur WHERE faktur_kode='{0}' AND faktur_status<9"
            Case "returjual"
                q = "SELECT faktur_status FROM data_penjualan_retur_faktur WHERE faktur_kode_bukti='{0}' AND faktur_status<9"
            Case "pembelian"
                q = "SELECT faktur_status FROM data_pembelian_faktur WHERE faktur_kode='{0}' AND faktur_status<9"
            Case "returbeli"
                q = "SELECT faktur_status FROM data_pembelian_retur_faktur WHERE faktur_kode_bukti='{0}' AND faktur_status<9"
            Case "piutangbayar"
                q = "SELECT p_bayar_status FROM data_piutang_bayar WHERE p_bayar_bukti='{0}'"
            Case "hutangbayar"
                q = "SELECT h_bayar_status FROM data_hutang_bayar WHERE h_bayar_bukti='{0}'"
            Case "kas"
                q = "SELECT kas_status FROM data_kas_faktur WHERE kas_kode='{0}'"
            Case Else
                Msg = "Tipe Transaksi tidak sesuai"
                Return 9
                Exit Function
        End Select

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, KodeFaktur))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _retval = rdx.Item(0)
                        Msg = Nothing
                    Else
                        _retval = 9
                        Msg = "Data tidak ditemukan"
                    End If
                End Using
            Else
                _retval = 9
                Msg = "Tidak dapat terhubung ke database"
            End If
        End Using

        Return _retval
    End Function

    'GET STATUS DATA HUTANG


    'GET STATUS DATA PIUTANG



    'GET PERIODE STATUS FROM TRANSACTION DATE
    Public Function GetPeriodeStatus(TransDate As Date, Optional ByRef Respond As String = "", Optional ByRef RetMsg As String = "") As Boolean
        Dim q As String = ""
        Dim _retBool As Boolean = False
        Dim _retResp As String = ""
        Dim _retMsg As String = ""
        Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT tutupbk_id, tutupbk_closed FROM data_tutup_buku " _
                    & "WHERE '{0:yyyy-MM-dd}' BETWEEN tutupbk_periode_tglawal AND tutupbk_periode_tglakhir AND tutupbk_status=1 " _
                    & "ORDER BY tutupbk_id DESC LIMIT 1"
                Try
                    Using rdx = x.ReadCommand(String.Format(q, TransDate))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            If rdx.Item(1) = 0 Then
                                _retBool = True : _retResp = "open" : _retMsg = rdx.Item(0)
                            Else
                                _retBool = False : _retResp = "closed"
                                _retMsg = "Periode keuangan transaksi telah diclosing."
                            End If
                        Else
                            _retBool = False : _retResp = "error"
                            _retMsg = "Data not found."
                        End If
                    End Using
                Catch ex As Exception
                    logError(ex, True)
                    _retBool = False : _retResp = "error" : _retMsg = ex.Message
                End Try
            Else
                _retBool = False : _retResp = "error"
                _retMsg = "Tidak dapat terhubung ke database."
            End If
        End Using

        Respond = _retResp : RetMsg = _retMsg
        Return _retBool
    End Function

    Public Function GetPeriodeDate(PeriodeID As String, ByRef StartDate As Date, ByRef EndDate As Date) As Boolean
        Dim q As String = ""
        Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))

        End Using
        Return False
    End Function
End Module
