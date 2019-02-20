Module dbChecking
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
        Return GetItemStock(IdBarang, "ALL")
    End Function

    Public Function GetItemStock(IdBarang As String, IdGudang As String) As Integer
        If String.IsNullOrWhiteSpace(IdGudang) Then
            Throw New ArgumentNullException("ID Gudang cannot be empty, If you want to get the ammout for all warehouse use 'ALL', OR use the other function")
        End If

        Dim retval As Integer = -1
        Dim q As String = "SELECT getStockSisa('{0}','{1}')"

        If LCase(IdGudang) = "ALL" Then IdGudang = "%"

        Using x = MainConnection
            x.Open()
            Using rdx As MySql.Data.MySqlClient.MySqlDataReader = x.ReadCommand(String.Format(q, IdBarang, IdGudang), CommandBehavior.SingleResult)
                Dim red = rdx.Read()
                If red And rdx.HasRows Then
                    retval = IIf(IsDBNull(rdx.Item(0)), Nothing, rdx.Item(0))
                Else
                    retval = -1
                End If
            End Using
        End Using
        Return retval
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
    Public Function TransConfirmValid(ByRef Keterangan As String) As Boolean
        Dim valid As Boolean = False

        Using x As New fr_jualconfirm_dialog
            With x
                .lbl_title.Text = "Konfirmasi"
                .in_user.Text = loggeduser.user_id
                .do_load("jual")
                If .returnval = True Then
                    If loggeduser.user_id <> .in_user.Text Then
                        MessageBox.Show("User tidak sama dengan user yg anda gunakan untuk login. Pastikan anda menggunakan user yang sama untuk meakukan validasi",
                                        .Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        valid = False
                    Else
                        Keterangan += IIf(Keterangan = Nothing, "", Environment.NewLine) & .in_ket.Text
                        valid = .returnval
                    End If
                End If
            End With
        End Using
        Return valid
    End Function

    'CONFIRM DIALOG -> VALID MASTER
    Public Function MasterConfirmValid(ByRef Keterangan As String) As Boolean
        Dim valid As Boolean = False

        Using x As New fr_jualconfirm_dialog

        End Using

        Return valid
    End Function

    'CANCEL PENJUALAN/PIUTANG AWAL
    Public Function CheckCancelPenjualan(KodeFaktur As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim retval As Boolean = False
        Dim q As String = "SELECT faktur_kode, IFNULL(faktur_status,0) status, IFNULL(piutang_awal,0) piutang, getPiutangSisa(piutang_faktur) sisa, COUNT(p_bayar_bukti) bayar " _
                          & "FROM data_piutang_awal " _
                          & "LEFT JOIN data_penjualan_faktur ON faktur_kode=piutang_faktur " _
                          & "LEFT JOIN data_piutang_bayar_trans ON p_trans_kode_piutang=faktur_kode AND p_trans_status=1 " _
                          & "LEFT JOIN data_piutang_bayar ON p_bayar_bukti=p_trans_bukti AND p_bayar_status IN (0,1) " _
                          & "WHERE piutang_faktur='{0}'"
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim _status As Integer = 0
                Dim _piutang As Decimal = 0
                Dim _sisa As Decimal = 0
                Dim _bayar As Integer = 0
                Dim _next As Boolean = False
                Using rdx = x.ReadCommand(String.Format(q, KodeFaktur), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _status = rdx.Item("status")
                        _piutang = rdx.Item("piutang")
                        _sisa = rdx.Item("sisa")
                        _bayar = rdx.Item("bayar")
                        _next = True
                    Else
                        _next = False
                    End If
                End Using

                If _next Then
                    If {0, 1}.Contains(_status) Then
                        If _piutang = _sisa Then
                            If _bayar = 0 Then
                                retval = True
                            Else
                                retval = False
                                Msg = "Transaksi pembayaran utk faktur/piutang tsb telah dilakukan"
                            End If
                        Else
                            retval = False
                            Msg = "Transaksi pembayaran utk faktur/piutang tsb telah dilakukan"
                        End If
                    Else
                        retval = False
                        Msg = ""
                    End If
                Else
                    retval = _next
                    Msg = "Terjadi kesalahan saat melakukan pengecekan data"
                End If
            Else
                Msg = "Tidak dapat terhubung ke database"
                retval = False
            End If
        End Using


        Return retval
    End Function

    'CANCEL PEMBELIAN/HUTANG AWAL
    Public Function CheckCancelPembelian(KodeFaktur As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim retval As Boolean = False
        Dim q As String = "SELECT faktur_kode, IFNULL(faktur_status,0) status, IFNULL(hutang_awal,0) hutang, getHutangSisa(hutang_faktur) sisa, COUNT(h_bayar_bukti) bayar " _
                          & "FROM data_hutang_awal " _
                          & "RIGHT JOIN data_pembelian_faktur ON faktur_kode=hutang_faktur " _
                          & "LEFT JOIN data_hutang_bayar_trans ON h_trans_faktur=faktur_kode AND h_trans_status=1 " _
                          & "LEFT JOIN data_hutang_bayar ON h_bayar_bukti=h_trans_bukti AND h_bayar_status IN (0,1) " _
                          & "WHERE hutang_faktur='{0}'"
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim _status As Integer = 0
                Dim _piutang As Decimal = 0
                Dim _sisa As Decimal = 0
                Dim _bayar As Integer = 0
                Dim _next As Boolean = False
                Using rdx = x.ReadCommand(String.Format(q, KodeFaktur), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _status = rdx.Item("status")
                        _piutang = rdx.Item("hutang")
                        _sisa = rdx.Item("sisa")
                        _bayar = rdx.Item("bayar")
                        _next = True
                    Else
                        _next = False
                    End If
                End Using

                If _next Then
                    If {0, 1}.Contains(_status) Then
                        If _piutang = _sisa Then
                            If _bayar = 0 Then
                                retval = True
                            Else
                                retval = False
                                Msg = "Transaksi pembayaran utk faktur/piutang tsb telah dilakukan"
                            End If
                        Else
                            retval = False
                            Msg = "Transaksi pembayaran utk faktur/piutang tsb telah dilakukan"
                        End If
                    Else
                        retval = False
                        Msg = ""
                    End If
                Else
                    retval = _next
                    Msg = "Terjadi kesalahan saat melakukan pengecekan data"
                End If
            Else
                Msg = "Tidak dapat terhubung ke database"
                retval = False
            End If
        End Using

        Return retval
    End Function

    'CANCEL RETUR
    Public Function CheckCancelRetur(KodeFaktur As String, JenisRetur As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim retval As Boolean = False
        Dim q As String = ""

        Select Case LCase(JenisRetur)
            Case "beli"
                q = "SELECT faktur_kode_bukti, faktur_status status FROM data_pembelian_retur_faktur WHERE faktur_kode_bukti='{0}'"
            Case "jual"
                q = "SELECT faktur_kode_bukti, faktur_status status FROM data_penjualan_retur_faktur WHERE faktur_kode_bukti='{0}'"
            Case Else
                retval = False
                Throw New Exception("Jenis Retur tidak sesuai")
        End Select

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim _next As Boolean = False
                Dim _state As Integer = 0
                Using rdx = x.ReadCommand(String.Format(q, KodeFaktur))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _state = rdx.Item("status")
                        _next = True
                    Else
                        _next = False
                    End If
                End Using
                If _next Then
                    If {0, 1}.Contains(_state) Then : retval = True : Else : retval = False : Msg = "" : End If
                Else
                    retval = _next
                    Msg = "Terjadi kesalahan saat melakukan pengecekan data"
                End If
            Else
                Msg = "Tidak dapat terhubung ke database"
                retval = False
            End If
        End Using

        Return retval
    End Function

    'CANCEL KAS
    Public Function CheckCancelKas(KodeFaktur As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim retval As Boolean = False
        Dim q As String = "SELECT kas_kode, kas_status status FROM data_kas_faktur WHERE kas_kode='{0}'"
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim _next As Boolean = False
                Dim _state As Integer = 0
                Using rdx = x.ReadCommand(String.Format(q, KodeFaktur))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _state = rdx.Item("status")
                        _next = True
                    Else
                        _next = False
                    End If
                End Using
                If _next Then
                    If {0, 1}.Contains(_state) Then : retval = True : Else : retval = False : Msg = "" : End If
                Else
                    retval = _next
                    Msg = "Terjadi kesalahan saat melakukan pengecekan data"
                End If
            Else
                Msg = "Tidak dapat terhubung ke database"
                retval = False
            End If
        End Using
        Return retval
    End Function

    'CANCEL PEMBAYARAN HUTANG/PIUTANG
    Public Function CheckCancelBayar(KodeFaktur As String, JenisBayar As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim retval As Boolean = False
        Dim q As String = ""

        Select Case LCase(JenisBayar)
            Case "hutang"
                q = "SELECT h_bayar_bukti kode, h_bayar_status status, IFNULL(giro_status_pencairan,0) statusgiro " _
                    & "FROM data_hutang_bayar LEFT JOIN data_giro ON giro_ref= h_bayar_bukti AND giro_type='OUT' AND giro_status =1 WHERE h_bayar_bukti='{0}'"
            Case "piutang"
                q = "SELECT p_bayar_bukti kode, p_bayar_status status, IFNULL(giro_status_pencairan,0) statusgiro " _
                    & "FROM data_piutang_bayar LEFT JOIN data_giro ON giro_ref= p_bayar_bukti AND giro_type='IN' AND giro_status =1 WHERE p_bayar_bukti='{0}'"
            Case Else
                retval = False
                Throw New Exception("Jenis bayar tidak sesuai")
        End Select

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim _next As Boolean = False
                Dim _state As Integer = 0
                Dim _girostate As Integer = 0
                Using rdx = x.ReadCommand(String.Format(q, KodeFaktur))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _state = rdx.Item("status")
                        _girostate = rdx.Item("statusgiro")
                        _next = True
                    Else
                        _next = False
                    End If
                End Using
                If _next Then
                    If {0, 1}.Contains(_state) Then
                        If _girostate = 0 Then
                            retval = True
                        Else
                            retval = False
                            Msg = "Pembayaran melalui bilyet giro telah dicairkan"
                        End If
                    Else
                        retval = False
                        Msg = ""
                    End If
                Else
                    retval = _next
                    Msg = "Terjadi kesalahan saat melakukan pengecekan data"
                End If
            Else
                Msg = "Tidak dapat terhubung ke database"
                retval = False
            End If
        End Using

        Return retval
    End Function
End Module
