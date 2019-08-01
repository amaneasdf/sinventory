Module mdl_importdata
    'IMPORT SUPPLIER

    'IMPORT BARANG
    Public Function DoImportBarang(DataBarang As DataTable, ByRef SucceedItem As List(Of String)) As KeyValuePair(Of Boolean, String)
        Dim RetCheck As Boolean = False
        Dim RetMsg As String = ""
        Dim q As String = ""

        Dim _succCt As Integer = 0

        For Each row As DataRow In DataBarang.Select("", "KODE_ITEM ASC")
            Dim _arr As New List(Of String)
            Dim _kode As String = row.ItemArray(0)
            Dim _supplier As String = row.Item("KODE_SUPPLIER")
            Dim _supCk As Integer = 0 : Dim _kodeCk As Integer = 0
            Dim _jenispajak As Integer = 0

            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    q = "SELECT COUNT(barang_kode) FROM data_barang_master WHERE barang_kode='{0}'"
                    _kodeCk = CInt(x.ExecScalar(String.Format(q, _kode)))
                    q = "SELECT COUNT(supplier_kode) FROM data_supplier_master WHERE supplier_kode='{0}'"
                    _supCk = CInt(x.ExecScalar(String.Format(q, _supplier)))

                    If _kodeCk > 0 Then
                        consoleWriteLine(_kode & " already exist")
                        GoTo NextItem
                    End If

                    If _supCk = 0 Then
                        q = "INSERT INTO data_supplier_master SET {0}"
                        Dim _fk = {"supplier_kode='" & _supplier & "'",
                                   "supplier_nama='" & row.Item("NAMA_SUPPLIER") & "'",
                                   "supplier_reg_date=NOW()",
                                   "supplier_reg_alias='" & loggeduser.user_id & "'"
                                  }
                        _arr.Add(String.Format(q, String.Join(",", _fk)))
                        consoleWriteLine("ADD NEW SUPPLIER : " & _supplier)
                    End If

                    Select Case Trim(LCase(row.Item("PAJAK").ToString.Replace("-", "")))
                        Case "nonpajak" : _jenispajak = 0
                        Case "pajak" : _jenispajak = 1
                        Case Else
                            RetCheck = False : RetMsg = "Input data tidak sesuai. Jenis pajak tidak sesuai dengan ketentuan."
                            GoTo EndFunct
                    End Select

                    q = "INSERT INTO data_barang_master SET {0}"
                    Dim _jenis As String = IIf(String.IsNullOrWhiteSpace(row.Item("KODE_JENIS")), "1", row.Item("KODE_JENIS"))
                    Dim _kateg As String = IIf(String.IsNullOrWhiteSpace(row.Item("KODE_KATEGORI")), "000", row.Item("KODE_KATEGORI"))
                    Dim _beli As Decimal = 0 : Dim _jual As Decimal = 0 : Dim _mt As Decimal = 0 : Dim _horeka As Decimal = 0 : Dim _rita As Decimal = 0
                    Decimal.TryParse(row.Item("HARGA_BELI"), _beli)
                    Decimal.TryParse(row.Item("HARGA_JUAL"), _jual)
                    Decimal.TryParse(row.Item("HARGA_JUAL_MT"), _mt)
                    Decimal.TryParse(row.Item("HARGA_JUAL_HOREKA"), _horeka)
                    Decimal.TryParse(row.Item("HARGA_JUAL_RITA"), _rita)

                    Dim s = {"barang_kode='" & _kode & "'",
                             "barang_nama='" & mysqlQueryFriendlyStringFeed(row.Item("NAMA_ITEM")) & "'",
                             "barang_supplier='" & _supplier & "'",
                             "barang_jenis='" & _jenis & "'",
                             "barang_kategori='" & _kateg & "'",
                             "barang_pajak=" & _jenispajak,
                             "barang_satuan_kecil='" & row.Item("SATUAN_KECIL") & "'",
                             "barang_satuan_tengah='" & row.Item("SATUAN_TENGAH") & "'",
                             "barang_satuan_besar='" & row.Item("SATUAN_BESAR") & "'",
                             "barang_satuan_tengah_jumlah=" & row.Item("ISI_SATUAN_TENGAH"),
                             "barang_satuan_besar_jumlah=" & row.Item("ISI_SATUAN_BESAR"),
                             "barang_harga_beli=" & _beli.ToString.Replace(",", "."),
                             "barang_harga_jual=" & _jual.ToString.Replace(",", "."),
                             "barang_harga_jual_mt=" & _mt.ToString.Replace(",", "."),
                             "barang_harga_jual_horeka=" & _horeka.ToString.Replace(",", "."),
                             "barang_harga_jual_rita=" & _rita.ToString.Replace(",", "."),
                             "barang_reg_date=NOW()",
                             "barang_reg_alias='" & loggeduser.user_id & "-migrasi'"
                            }
                    _arr.Add(String.Format(q, String.Join(",", s)))

                    Dim _ck As Boolean = False

                    Try
                        _ck = x.TransactCommand(_arr)
                        If _ck Then
                            _succCt += 1 : SucceedItem.Add(_kode)
                            consoleWriteLine(_kode & " added")
                        End If
                    Catch ex As Exception
                        logError(ex, True)
                        RetCheck = False
                        RetMsg = String.Join(Environment.NewLine,
                                             "Terjadi kesalahan saat melakukan proses import.",
                                             ex.Message,
                                             IIf(_succCt > 0, _succCt & " item telah tersimpan.", "")
                                             )
                        GoTo EndFunct
                    End Try
                Else
                    RetCheck = False : RetMsg = "Tidak dapat terhubung ke database."
                GoTo EndFunct
                End If
            End Using
NextItem:
        Next
        RetCheck = True : RetMsg = _succCt & " dari " & DataBarang.Rows.Count & " data barang telah di tambahkan ke database."

EndFunct:
        Return New KeyValuePair(Of Boolean, String)(RetCheck, RetMsg)
    End Function

    'IMPORT PIUTANG
    Private Function DoImportPiutang(DataPiutang As DataTable, Optional JenisPajak As String = "1") As KeyValuePair(Of Boolean, String)
        Dim RetCheck As Boolean = False
        Dim RetMsg As String = ""
        Dim q As String = ""
        Dim qArr As New List(Of String)

        Dim HeaderRows = DataPiutang.Select("", "KodeFaktur ASC")
        Dim TotalPiutang As Decimal = 0
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                For Each row As DataRow In DataPiutang.Rows
                    Dim _kodepiutang = row.Item(0)
                    q = "SELECT piutang_status FROM data_piutang_awal WHERE piutang_faktur='{0}'"
                    Dim _status = x.ExecScalar(String.Format(q, _kodepiutang))
                    If IsNothing(_status) Or _status = 9 Then
                        q = "SELECT customer_kode FROM data_customer_master WHERE customer_kode='{0}' AND customer_nama='{1}'"
                        Dim _ck As String = CStr(x.ExecScalar(String.Format(q, row.Item(2), row.Item(3))))
                        If String.IsNullOrWhiteSpace(_ck) Then
                            q = "SELECT customer_kode FROM data_customer_master WHERE customer_kode='{0}'"
                            _ck = CStr(x.ExecScalar(String.Format(q, row.Item(2))))
                            If String.IsNullOrWhiteSpace(_ck) Then
                                q = "INSERT INTO data_customer_master SET customer_kode='{0}', customer_jenis='01', customer_nama='{1}', " _
                                    & "customer_reg_date=NOW(), customer_reg_alias='migrasi-{2}' ON DUPLICATE KEY UPDATE customer_id=customer_id"
                                qArr.Add(String.Format(q, row.Item(2), row.Item(3), loggeduser.user_id))
                            End If
                        End If

                        Dim _piutang As Decimal = row.Item(6)
                        Dim _pajak As String = IIf(LCase(row.Item(7)) = "pajak", 1, 0)

                        If _pajak <> JenisPajak Then
                            RetCheck = False : RetMsg = "Data tidak dapat tersimpan. Kategori piutang " & _kodepiutang & " tidak sesuai."
                            GoTo EndFunct
                        End If

                        q = "DELETE FROM data_piutang_awal WHERE piutang_faktur = '{0}'; DELETE FROM data_piutang_trans WHERE p_trans_kode_piutang='{0}';"
                        qArr.Add(String.Format(q, _kodepiutang))

                        q = "INSERT INTO data_piutang_awal SET {0}"
                        Dim _df = {"piutang_faktur='" & _kodepiutang & "'",
                                   "piutang_pajak='" & _pajak & "'",
                                   "piutang_tgl='" & CDate(row.Item(4)).ToString("yyyy-MM-dd") & "'",
                                   "piutang_jt='" & CDate(row.Item(5)).ToString("yyyy-MM-dd") & "'",
                                   "piutang_sales='" & row.Item(1) & "'",
                                   "piutang_custo='" & row.Item(2) & "'",
                                   "piutang_awal=" & _piutang.ToString.Replace(",", "."),
                                   "piutang_reg_date=NOW()",
                                   "piutang_reg_alias='" & loggeduser.user_id & "'"
                                   }
                        qArr.Add(String.Format(q, String.Join(",", _df)))

                        q = "INSERT INTO data_piutang_trans SET {0}"
                        Dim _ff = {"p_trans_kode_piutang='" & _kodepiutang & "'",
                                   "p_trans_tgl='" & selectperiode.tglawal.ToString("yyyy-MM-dd") & "'",
                                   "p_trans_periode='" & selectperiode.id & "'",
                                   "p_trans_nilai=" & _piutang.ToString.Replace(",", "."),
                                   "p_trans_jenis='migrasi'",
                                   "p_trans_reg_date=NOW()",
                                   "p_trans_reg_alias='migrasi-" & loggeduser.user_id & "'"
                                  }
                        qArr.Add(String.Format(q, String.Join(",", _ff)))

                        TotalPiutang += _piutang
                    Else
                        RetCheck = False : RetMsg = _kodepiutang & " tidak dapat tersimpan. Piutang " & _kodepiutang & " sudah ada di database."
                        GoTo EndFunct
                    End If
                Next

                q = "CALL insertJurnalImportPiutang('{0}','{1}','{2}','{3}')"
                qArr.Add(String.Format(q, TotalPiutang.ToString.Replace(",", "."), selectperiode.id, JenisPajak, loggeduser.user_id))

            Else
                RetCheck = False : RetMsg = "Tidak dapat terhubung ke database."
                GoTo EndFunct
            End If
        End Using

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    RetCheck = x.TransactCommand(qArr)
                    If Not RetCheck Then
                        RetMsg = "Terjadi kesalahan saat melakukan import data."
                    End If
                Catch ex As Exception
                    RetCheck = False : RetMsg = "Terjadi kesalahan saat melakukan proses import." & Environment.NewLine & ex.Message
                End Try
            Else
                RetCheck = False : RetMsg = "Tidak dapat terhubung ke database."
            End If
        End Using

EndFunct:
        Return New KeyValuePair(Of Boolean, String)(RetCheck, RetMsg)
    End Function

    Public Function DoImportPiutangNonPajak(DataPiutang As DataTable) As KeyValuePair(Of Boolean, String)
        Return DoImportPiutang(DataPiutang, 0)
    End Function

    Public Function DoImportPiutangPajak(DataPiutang As DataTable) As KeyValuePair(Of Boolean, String)
        Return DoImportPiutang(DataPiutang, 1)
    End Function

    'IMPORT HUTANG
    Public Function DoImportHutang(DataHutang As DataTable, Optional JenisPajak As String = "1") As KeyValuePair(Of Boolean, String)
        Dim RetCheck As Boolean = False
        Dim RetMsg As String = ""
        Dim q As String = ""
        Dim qArr As New List(Of String)

        Dim HeaderRows = DataHutang.Select("", "KodeFaktur ASC")
        Dim TotalHutang As Decimal = 0

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                For Each row As DataRow In HeaderRows
                    Dim _kodehutang = row.Item(0)
                    q = "SELECT hutang_status FROM data_hutang_awal WHERE hutang_faktur='{0}'"
                    Dim _status = x.ExecScalar(String.Format(q, _kodehutang))
                    If IsNothing(_status) Or _status = 9 Then
                        Dim _hutang As Decimal = row.Item(5)
                        Dim _pajak As String = IIf(LCase(row.Item(6)) = "pajak", 1, 0)

                        q = "DELETE FROM data_hutang_awal WHERE hutang_faktur = '{0}'; DELETE FROM data_hutang_trans WHERE h_trans_kode_hutang='{0}';"
                        qArr.Add(String.Format(q, _kodehutang))

                        q = "INSERT INTO data_hutang_awal SET {0}"
                        Dim _df = {"hutang_faktur='" & _kodehutang & "'",
                                   "hutang_pajak='" & _pajak & "'",
                                   "hutang_tgl='" & CDate(row.Item(3)).ToString("yyyy-MM-dd") & "'",
                                   "hutang_jt='" & CDate(row.Item(4)).ToString("yyyy-MM-dd") & "'",
                                   "hutang_supplier='" & row.Item(1) & "'",
                                   "hutang_awal=" & _hutang.ToString.Replace(",", "."),
                                   "hutang_reg_date=NOW()",
                                   "hutang_reg_alias='" & loggeduser.user_id & "'"
                                   }
                        qArr.Add(String.Format(q, String.Join(",", _df)))

                        q = "INSERT INTO data_hutang_trans SET {0}"
                        Dim _ff = {"h_trans_kode_hutang='" & _kodehutang & "'",
                                   "h_trans_tgl='" & selectperiode.tglawal.ToString("yyyy-MM-dd") & "'",
                                   "h_trans_periode='" & selectperiode.id & "'",
                                   "h_trans_nilai=" & _hutang.ToString.Replace(",", "."),
                                   "h_trans_jenis='migrasi'",
                                   "h_trans_reg_date=NOW()",
                                   "h_trans_reg_alias='migrasi-" & loggeduser.user_id & "'"
                                  }
                        qArr.Add(String.Format(q, String.Join(",", _ff)))

                        TotalHutang += _hutang
                    Else
                        RetCheck = False : RetMsg = _kodehutang & " tidak dapat tersimpan. Kode hutang " & _kodehutang & " sudah ada di database."
                        GoTo EndFunct
                    End If
                Next

                q = "CALL insertJurnalImportHutang('{0}','{1}','{2}','{3}')"
                qArr.Add(String.Format(q, TotalHutang.ToString.Replace(",", "."), selectperiode.id, JenisPajak, loggeduser.user_id))

            Else
                RetCheck = False : RetMsg = "Tidak dapat terhubung ke database."
                GoTo EndFunct
            End If
        End Using

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    RetCheck = x.TransactCommand(qArr)
                    If Not RetCheck Then
                        RetMsg = "Terjadi kesalahan saat melakukan import data."
                    End If
                Catch ex As Exception
                    RetCheck = False : RetMsg = "Terjadi kesalahan saat melakukan proses import." & Environment.NewLine & ex.Message
                End Try
            Else
                RetCheck = False : RetMsg = "Tidak dapat terhubung ke database."
            End If
        End Using

EndFunct:
        Return New KeyValuePair(Of Boolean, String)(RetCheck, RetMsg)
    End Function

    'IMPORT JUAL
    Public Function CheckDatatableJual(Datajual As DataTable, Optional IdType As Integer = 0)
        Dim _col As New List(Of String)

        Select Case IdType
            Case 0
                _col.AddRange({"KodeFaktur", "Tgl", "KodeSalesman", "Salesman", "KodeCustomer", "NamaCustomer", "TipeCustomer", "AlamatCustomer",
                               "KotaCustomer", "KodeGudang", "NamaGudang", "Term", "JenisPajak", "KodeFaktur", "KodeBarang", "NamaBarang", "Hargajual",
                               "Qty", "SatuanJual", "JenisSatuan", "JumlahDiskon", "JumlahJualNetto", "Disc1", "Disc2", "Disc3", "Disc4", "Disc5", "DiscRp"
                              })
            Case 1
                _col.AddRange({"KodeFaktur", "Tgl", "KodeSalesman", "Salesman", "KodeCustomer", "NamaCustomer", "TipeCustomer", "AlamatCustomer",
                               "KotaCustomer", "KodeGudang", "NamaGudang", "Term", "JenisPajak"})
            Case 2
                _col.AddRange({"KodeFaktur", "KodeBarang", "NamaBarang", "Hargajual", "Qty", "SatuanJual", "JenisSatuan", "JumlahDiskon",
                               "JumlahJualNetto", "Disc1", "Disc2", "Disc3", "Disc4", "Disc5", "DiscRp"})
            Case Else
                Return False : Exit Function
        End Select

        If Datajual.Columns.Count <> _col.Count Then
            Return False : Exit Function
        End If

        For i = 0 To Datajual.Columns.Count - 1
            If Datajual.Columns(i).ColumnName.ToString <> _col(i) Then
                Return False : Exit Function
            End If
        Next

        Return True
    End Function

    Public Function GetImportJual(DataJual As DataTable, IdType As Integer) As DataTable
        Select Case IdType
            Case 1 'HEADER
                Dim SelectedCol As String() = {"KodeFaktur", "Tgl", "KodeSalesman", "NamaSalesman", "KodeCustomer", "NamaCustomer", "TipeCustomer", "AlamatCustomer",
                                               "KotaCustomer", "KodeGudang", "NamaGudang", "Term", "JenisPajak"}
                Return New DataView(DataJual).ToTable(True, SelectedCol)

            Case 2 'BARANG
                Dim SelectedCol As String() = {"KodeFaktur", "KodeBarang", "NamaBarang", "HargaJual", "Qty", "SatuanJual", "JenisSatuan", "JumlahDiskon",
                                               "JumlahJualNetto", "Disc1", "Disc2", "Disc3", "Disc4", "Disc5", "DiscRp"}
                Return New DataView(DataJual).ToTable(False, SelectedCol)

            Case Else
                Return Nothing
        End Select
    End Function

    Public Function DoImportPenjualan(HeaderJual As DataTable, DataJual As DataTable, ByRef SucceedFaktur As List(Of String)) As KeyValuePair(Of Boolean, String)
        Dim RetCheck As Boolean = False
        Dim RetMsg As String = ""
        Dim q As String = ""
        Dim qArr As New List(Of List(Of String))

        Dim HeaderRows = HeaderJual.Select("", "KodeFaktur ASC")
        Dim _succCt As Integer = 0

        For Each row As DataRow In HeaderRows
            Dim _arr As New List(Of String)

            Dim _subtotal As Decimal = 0 : Dim _diskon As Decimal = 0 : Dim _total As Decimal = 0
            Dim _pajak As Decimal = 0 : Dim _netto As Decimal = 0
            Dim _jenisPajak As Integer = 0
            Dim _kode As String = mysqlQueryFriendlyStringFeed(row.ItemArray(0))

            Dim _sales As String = row.Item("KodeSalesman")
            Dim _custo As String = row.Item("KodeCustomer")
            Dim _gudang As String = row.Item("KodeGudang")

            Dim _expression = String.Format("KodeFaktur = '{0}'", _kode)
            Dim _ListBrg = DataJual.Select(_expression)

            'INSERT CUSTOMER
            Dim _custock As Integer = 0
            Dim _kodeCk As Integer = 0
            Dim _gudangCk As Integer = 0
            Dim _salesCk As Integer = 0
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    q = "SELECT COUNT(customer_id) FROM data_customer_master WHERE customer_kode='{0}'"
                    _custock = CInt(x.ExecScalar(String.Format(q, _custo)))
                    q = "SELECT COUNT(faktur_kode) FROM data_penjualan_faktur WHERE faktur_kode='{0}' AND faktur_status < 9"
                    _kodeCk = CInt(x.ExecScalar(String.Format(q, _kode)))
                    q = "SELECT COUNT(gudang_kode) FROM data_barang_gudang WHERE gudang_kode='{0}'"
                    _gudangCk = CInt(x.ExecScalar(String.Format(q, _gudang)))
                    q = "SELECT COUNT(salesman_kode) FROM data_salesman_master WHERE salesman_kode='{0}'"
                    _salesCk = CInt(x.ExecScalar(String.Format(q, _sales)))
                End If
            End Using

            If _kodeCk > 0 Then
                consoleWriteLine(_kode & " already exist")
                GoTo NextTrans
            End If

            If _custock = 0 Then
                q = "INSERT INTO data_customer_master SET {0} ON DUPLICATE KEY UPDATE customer_id=customer_id;"
                Dim _ct = {"customer_kode='" & _custo & "'",
                           "customer_nama='" & mysqlQueryFriendlyStringFeed(row.Item("NamaCustomer")) & "'",
                           "customer_alamat='" & mysqlQueryFriendlyStringFeed(row.Item("AlamatCustomer")) & "'",
                           "customer_jenis=GetKodeJenisCusto('" & row.Item("TipeCustomer") & "')",
                           "customer_kabupaten='" & mysqlQueryFriendlyStringFeed(row.Item("KotaCustomer")) & "'",
                           "customer_reg_date=NOW()",
                           "customer_reg_alias='" & loggeduser.user_id & "'"
                          }
                _arr.Add(String.Format(q, String.Join(",", _ct)))
                q = "UPDATE data_customer_master LEFT JOIN data_customer_jenis ON customer_jenis=jenis_kode " _
                    & "SET customer_kriteria_harga_jual=jenis_def_jual WHERE customer_kode='{0}'"
                _arr.Add(String.Format(q, _custo))
                consoleWriteLine("ADD NEW CUSTO : " & _custo)
            End If

            If _gudangCk = 0 Then
                q = "INSERT INTO data_barang_gudang(gudang_kode, gudang_nama, gudang_reg_date, gudang_reg_alias) " _
                    & "VALUE('{0}', '{1}', NOW(), 'Migrasi-{2}') ON DUPLICATE KEY UPDATE gudang_id=gudang_id"
                _arr.Add(String.Format(q, _gudang, row.Item("NamaGudang"), loggeduser.user_id))
                consoleWriteLine("ADD NEW GUDANG : " & _gudang)
            End If

            If _salesCk = 0 Then
                q = "INSERT INTO data_salesman_master(salesman_kode, salesman_nama, salesman_reg_date, salesman_reg_alias) " _
                    & "VALUE('{0}', '{1}', NOW(), 'Migrasi-{2}') ON DUPLICATE KEY UPDATE salesman_id=salesman_id"
                _arr.Add(String.Format(q, _sales, mysqlQueryFriendlyStringFeed(row.Item("NamaSalesman")), loggeduser.user_id))
                consoleWriteLine("ADD NEW SALES : " & _sales)
            End If

            'GET JENIS PAJAK
            Select Case Trim(LCase(row.Item("JenisPajak").ToString.Replace("-", "").Replace(" ", "")))
                Case "nonpajak" : _jenisPajak = 0
                Case "include", "pajak" : _jenisPajak = 1
                Case "exclude" : _jenisPajak = 2
                Case Else
                    RetCheck = False : RetMsg = "Input data tidak sesuai. Jenis pajak tidak sesuai dengan ketentuan."
                    GoTo EndFunct
            End Select

            'GET DATA BARANG
            q = "UPDATE data_penjualan_trans SET trans_status=9 WHERE trans_faktur='{0}'"
            _arr.Add(String.Format(q, _kode))
            For Each _brg As DataRow In _ListBrg
                Dim _kodebarang As String = _brg.ItemArray(1)
                Dim _hargajual As Decimal = _brg.Item("HargaJual") * _brg.Item("Qty")
                Dim _brgCk As Integer = 0
                Dim _hpp As Decimal = 0

                Dim _drp As Decimal = _hargajual - (_brg.Item("DiscRp") * _brg.Item("Qty"))

                _subtotal += _hargajual
                For Each dsk As Decimal In {_brg.Item("Disc1"), _brg.Item("Disc2"), _brg.Item("Disc3"), _brg.Item("Disc4"), _brg.Item("Disc5")}
                    If dsk <> 0 Then
                        _drp = _drp * (1 - dsk / 100)
                    End If
                Next
                _diskon += _hargajual - _drp

                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        q = "SELECT COUNT(barang_kode) FROM data_barang_master WHERE barang_kode='{0}'"
                        _brgCk = CInt(x.ExecScalar(String.Format(q, _kodebarang)))
                        If _brgCk = 0 Then
                            RetCheck = False
                            RetMsg = String.Join(Environment.NewLine,
                                                 _kodebarang & " tidak ditemukan di DB barang.",
                                                 IIf(_succCt > 0, _succCt & " faktur telah tersimpan.", "")
                                                 )
                            GoTo EndFunct
                        End If
                        q = "SELECT getHppAvg_v2('{0}','{1}')"
                        _hpp = x.ExecScalar(String.Format(q, _kodebarang, CDate(row.Item("Tgl")).ToString("yyyy-MM-dd")))
                    End If
                End Using

                q = "INSERT INTO data_penjualan_trans SET {0}"
                Dim _fb = {"trans_faktur='" & _kode & "'",
                           "trans_barang='" & _kodebarang & "'",
                           "trans_harga_jual=" & CDec(_brg.Item("HargaJual")).ToString.Replace(",", "."),
                           "trans_qty='" & _brg.Item("Qty") & "'",
                           "trans_satuan='" & _brg.Item("SatuanJual") & "'",
                           "trans_satuan_type='" & LCase(_brg.Item("JenisSatuan")) & "'",
                           "trans_disc1=" & Decimal.Parse(_brg.Item("Disc1")).ToString.Replace(",", "."),
                           "trans_disc2=" & Decimal.Parse(_brg.Item("Disc2")).ToString.Replace(",", "."),
                           "trans_disc3=" & Decimal.Parse(_brg.Item("Disc3")).ToString.Replace(",", "."),
                           "trans_disc4=" & Decimal.Parse(_brg.Item("Disc4")).ToString.Replace(",", "."),
                           "trans_disc5=" & Decimal.Parse(_brg.Item("Disc5")).ToString.Replace(",", "."),
                           "trans_disc_rupiah=" & Decimal.Parse(_brg.Item("DiscRp")).ToString.Replace(",", "."),
                           "trans_jumlah=" & _drp.ToString.Replace(",", "."),
                           "trans_hpp=" & _hpp.ToString.Replace(",", "."),
                           "trans_status=1",
                           "trans_reg_date=NOW()",
                           "trans_reg_alias='Migrasi-" & loggeduser.user_id & "'"
                          }
                _arr.Add(String.Format(q, String.Join(",", _fb)))
            Next

            'COUNT BIAYA
            _total = _subtotal - _diskon
            _netto = _total
            If _jenisPajak = 2 Then
                _pajak = _subtotal * 0.1 : _netto = _total + _pajak
            ElseIf _jenisPajak = 1 Then
                _pajak = _subtotal * (1 - 10 / 11)
            End If

            'INPUT HEADER JUAL
            q = "INSERT INTO data_penjualan_faktur SET {0}"
            Dim _fh = {"faktur_kode = '" & _kode & "'",
                       "faktur_tanggal_trans = '" & CDate(row.Item("Tgl")).ToString("yyyy-MM-dd") & "'",
                       "faktur_pajak_tanggal=faktur_tanggal_trans",
                       "faktur_gudang='" & _gudang & "'",
                       "faktur_sales='" & _sales & "'",
                       "faktur_customer='" & _custo & "'",
                       "faktur_term=" & IIf(String.IsNullOrWhiteSpace(row.Item("Term")), 0, row.Item("Term")),
                       "faktur_jumlah=" & _subtotal.ToString.Replace(",", "."),
                       "faktur_disc_rupiah=" & _diskon.ToString.Replace(",", "."),
                       "faktur_total=" & _total.ToString.Replace(",", "."),
                       "faktur_ppn_persen=" & _pajak.ToString.Replace(",", "."),
                       "faktur_ppn_jenis=" & _jenisPajak,
                       "faktur_netto=" & _netto.ToString.Replace(",", "."),
                       "faktur_status=1",
                       "faktur_reg_date=NOW()",
                       "faktur_reg_alias='Migrasi-" & loggeduser.user_id & "'"
                      }
            _arr.Add(String.Format(q, String.Join(",", _fh)))

            'qArr.Add(_arr)

            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _ck As Boolean = False

                    Try
                        _ck = x.TransactCommand(_arr)
                        If _ck Then
                            _succCt += 1 : SucceedFaktur.Add(_kode)
                            consoleWriteLine(_kode & " added")
                        End If
                    Catch ex As Exception
                        logError(ex, True)
                        RetCheck = False
                        RetMsg = String.Join(Environment.NewLine,
                                             "Terjadi kesalahan saat melakukan proses import.",
                                             ex.Message,
                                             IIf(_succCt > 0, _succCt & " faktur telah tersimpan.", "")
                                             )
                        GoTo EndFunct
                    End Try
                Else
                    RetCheck = False : RetMsg = "Tidak dapat terhubung ke database."
                    GoTo EndFunct
                End If
            End Using
NextTrans:
        Next
        RetCheck = True : RetMsg = _succCt & " dari " & HeaderJual.Rows.Count & " faktur penjualan telah di tambahkan ke database."

EndFunct:
        Return New KeyValuePair(Of Boolean, String)(RetCheck, RetMsg)
    End Function

    'IMPORT RETUR JUAL
    Public Function GetImportRetur(DataRetur As DataTable, IdType As Integer) As DataTable
        Select Case IdType
            Case 1 'HEADER
                Dim SelectedCol As String() = {"KodeBukti", "Tgl", "KodeSalesman", "NamaSalesman", "KodeCustomer", "NamaCustomer", "TipeCustomer", "AlamatCustomer",
                                               "KotaCustomer", "KodeGudang", "NamaGudang", "JenisPajak", "JenisBayar", "KodeFaktur", "KodeExFaktur"}
                Return New DataView(DataRetur).ToTable(True, SelectedCol)

            Case 2 'BARANG
                Dim SelectedCol As String() = {"KodeBukti", "KodeBarang", "NamaBarang", "HargaRetur", "Qty", "SatuanJual", "JenisSatuan", "JumlahDiskon",
                                               "JumlahReturNetto", "Diskon"}
                Return New DataView(DataRetur).ToTable(False, SelectedCol)

            Case 3 'HEADER RETUR BELI
                Dim SelectedCol As String() = {"KodeBukti", "Tgl", "KodeSupplier", "NamaSupplier", "AlamatSupplier", "KodeGudang", "NamaGudang",
                                               "JenisPajak", "JenisBayar", "KodeFaktur", "KodeExFaktur"}
                Return New DataView(DataRetur).ToTable(True, SelectedCol)

            Case 4 'BARANG RETUR BELI
                Dim SelectedCol As String() = {"KodeBukti", "KodeBarang", "NamaBarang", "HargaRetur", "Qty", "SatuanBeli", "JenisSatuan", "JumlahDiskon",
                                               "JumlahReturNetto", "Diskon"}
                Return New DataView(DataRetur).ToTable(False, SelectedCol)

            Case Else
                Return Nothing
        End Select
    End Function

    Public Function DoImportReturJual(HeaderRetur As DataTable, DataRetur As DataTable) As KeyValuePair(Of Boolean, String)
        Dim RetCheck As Boolean = False
        Dim RetMsg As String = ""
        Dim q As String = ""
        Dim qArr As New List(Of List(Of String))

        Dim HeaderRows = HeaderRetur.Select("", "KodeBukti ASC")

        For Each row As DataRow In HeaderRows
            Dim _arr As New List(Of String)

            Dim _subtotal As Decimal = 0 : Dim _diskon As Decimal = 0 : Dim _total As Decimal = 0
            Dim _pajak As Decimal = 0 : Dim _netto As Decimal = 0
            Dim _jenisPajak As Integer = 0
            Dim _jenisBayar As Integer = 0
            Dim _kode As String = row.ItemArray(0)

            Dim _sales As String = row.Item("KodeSalesman")
            Dim _custo As String = row.Item("KodeCustomer")
            Dim _gudang As String = row.Item("KodeGudang")

            Dim _expression = String.Format("KodeBukti = '{0}'", _kode)
            Dim _ListBrg = DataRetur.Select(_expression)

            'INSERT CUSTOMER
            Dim _custock As Integer = 0
            Dim _kodeCk As Integer = 0
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    q = "SELECT COUNT(customer_id) FROM data_customer_master WHERE customer_kode='{0}'"
                    _custock = CInt(x.ExecScalar(String.Format(q, _custo)))
                    q = "SELECT COUNT(faktur_kode_bukti) FROM data_penjualan_retur_faktur WHERE faktur_kode_bukti='{0}' AND faktur_status < 9"
                    _kodeCk = CInt(x.ExecScalar(String.Format(q, _kode)))
                End If
            End Using

            If _kodeCk > 0 Then GoTo NextTrans

            If _custock = 0 Then
                q = "INSERT INTO data_customer_master SET {0};"
                Dim _ct = {"customer_kode='" & _custo & "'",
                           "customer_nama='" & row.Item("NamaCustomer") & "'",
                           "customer_alamat='" & row.Item("AlamatCustomer") & "'",
                           "customer_jenis=GetKodeJenisCusto('" & row.Item("TipeCustomer") & "')",
                           "customer_kabupaten='" & row.Item("KotaCustomer") & "'"
                          }
                _arr.Add(String.Format(q, String.Join(",", _ct)))
                q = "UPDATE data_customer_master LEFT JOIN data_customer_jenis ON customer_jenis=jenis_kode " _
                    & "SET customer_kriteria_harga_jual=jenis_def_jual WHERE customer_kode='{0}'"
                _arr.Add(String.Format(q, _custo))
            End If

            'GET JENIS PAJAK
            Select Case LCase(row.Item("JenisPajak"))
                Case "non-pajak" : _jenisPajak = 0
                Case "include", "pajak" : _jenisPajak = 1
                Case "exclude" : _jenisPajak = 2
                Case Else
                    RetCheck = False : RetMsg = "Input data tidak sesuai. Jenis pajak tidak sesuai dengan ketentuan."
                    GoTo EndFunct
            End Select

            'GET JENIS PEMBAYARAN
            Select Case LCase(row.Item("JenisBayar"))
                Case "potong nota" : _jenisBayar = 1
                Case "tunai" : _jenisBayar = 2
                Case "titip" : _jenisBayar = 3
                Case Else
                    RetCheck = False : RetMsg = "Input data tidak sesuai. Jenis pembayaran tidak sesuai dengan ketentuan."
                    GoTo EndFunct
            End Select

            'GET DATA BARANG
            For Each _brg As DataRow In _ListBrg
                Dim _kodebarang As String = _brg.ItemArray(1)
                Dim _hargaretur As Decimal = _brg.Item("HargaRetur") * _brg.Item("Qty")
                Dim _hpp = 0

                _subtotal += _hargaretur
                _diskon += _brg.Item("JumlahDiskon")

                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        q = "SELECT getHPPAVG('{0}','{1}','{2}')"
                        _hpp = x.ExecScalar(String.Format(q, _kodebarang, CDate(row.Item("Tgl")).ToString("yyyy-MM-dd"), selectperiode.id))
                    End If
                End Using

                q = "INSERT INTO data_penjualan_retur_trans SET {0}"
                Dim _fb = {"trans_faktur='" & _kode & "'",
                           "trans_barang='" & _kodebarang & "'",
                           "trans_harga_retur=" & CDec(_brg.Item("HargaRetur")).ToString.Replace(",", "."),
                           "trans_qty='" & _brg.Item("Qty") & "'",
                           "trans_satuan='" & _brg.Item("SatuanJual") & "'",
                           "trans_satuan_type='" & LCase(_brg.Item("JenisSatuan")) & "'",
                           "trans_diskon=" & Decimal.Parse(_brg.Item("Diskon")).ToString.Replace(",", "."),
                           "trans_hpp=" & Decimal.Parse(_hpp).ToString.Replace(",", "."),
                           "trans_status=1"
                          }
                _arr.Add(String.Format(q, String.Join(",", _fb)))
            Next

            'COUNT BIAYA
            _total = _subtotal - _diskon
            _netto = _total
            If _jenisPajak = 2 Then
                _pajak = _subtotal * 0.1 : _netto = _total + _pajak
            ElseIf _jenisPajak = 1 Then
                _pajak = _subtotal * (1 - 10 / 11)
            End If

            'INPUT HEADER JUAL
            q = "INSERT INTO data_penjualan_retur_faktur SET {0}"
            Dim _fh = {"faktur_kode_bukti = '" & _kode & "'",
                       "faktur_tanggal_trans = '" & CDate(row.Item("Tgl")).ToString("yyyy-MM-dd") & "'",
                       "faktur_pajak_tanggal=faktur_tanggal_trans",
                       "faktur_gudang='" & _gudang & "'",
                       "faktur_sales='" & _sales & "'",
                       "faktur_custo='" & _custo & "'",
                       "faktur_jen_bayar='" & _jenisBayar & "'",
                       "faktur_kode_faktur='" & row.Item("KodeFaktur") & "'",
                       "faktur_kode_exfaktur='" & row.Item("KodeExFaktur") & "'",
                       "faktur_jumlah=" & _subtotal.ToString.Replace(",", "."),
                       "faktur_netto=" & _netto.ToString.Replace(",", "."),
                       "faktur_ppn_persen=" & _pajak.ToString.Replace(",", "."),
                       "faktur_ppn_jenis=" & _jenisPajak,
                       "faktur_status=1",
                       "faktur_reg_date=NOW()",
                       "faktur_reg_alias='Migrasi-" & loggeduser.user_id & "'"
                      }
            _arr.Add(String.Format(q, String.Join(",", _fh)))

            q = "CALL transReturJualFin('{0}','{1}')"
            _arr.Add(String.Format(q, _kode, loggeduser.user_id))

            qArr.Add(_arr)
NextTrans:
        Next

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _ck As Boolean = False
                Dim _succCt As Integer = 0

                Try
                    For Each StrList As List(Of String) In qArr
                        _ck = x.TransactCommand(StrList)
                        If _ck Then _succCt += 1
                    Next

                    RetCheck = True : RetMsg = _succCt & " dari " & qArr.Count & " faktur retur penjualan telah di tambahkan ke database."
                Catch ex As Exception
                    logError(ex, True)
                    RetCheck = False
                    RetMsg = String.Join(Environment.NewLine,
                                         "Terjadi kesalahan saat melakukan proses import.",
                                         ex.Message,
                                         IIf(_succCt > 0, _succCt & " faktur telah tersimpan.", "")
                                         )
                End Try
            Else
                RetCheck = False : RetMsg = "Tidak dapat terhubung ke database."
            End If
        End Using

EndFunct:
        Return New KeyValuePair(Of Boolean, String)(RetCheck, RetMsg)
    End Function

    'IMPORT BELI
    Public Function GetImportBeli(DataJual As DataTable, IdType As Integer) As DataTable
        Select Case IdType
            Case 1 'HEADER
                Dim SelectedCol As String() = {"KodeFaktur", "Tgl", "KodeSupplier", "NamaSupplier", "AlamatSupplier", "KodeGudang", "NamaGudang", "Term", "JenisPajak"}
                Return New DataView(DataJual).ToTable(True, SelectedCol)

            Case 2 'BARANG
                Dim SelectedCol As String() = {"KodeFaktur", "KodeBarang", "NamaBarang", "HargaBeli", "Qty", "SatuanBeli", "JenisSatuan", "JumlahDiskon",
                                               "JumlahBeliNetto", "Disc1", "Disc2", "Disc3", "DiscRp"}
                Return New DataView(DataJual).ToTable(False, SelectedCol)

            Case Else
                Return Nothing
        End Select
    End Function

    Public Function DoImportPembelian(HeaderBeli As DataTable, DataBeli As DataTable, ByRef SucceedFaktur As List(Of String)) As KeyValuePair(Of Boolean, String)
        Dim RetCheck As Boolean = False
        Dim RetMsg As String = ""
        Dim q As String = ""
        Dim qArr As New List(Of List(Of String))

        Dim HeaderRows = HeaderBeli.Select("", "KodeFaktur ASC")
        Dim _succCt As Integer = 0

        For Each row As DataRow In HeaderRows
            Dim _arr As New List(Of String)

            Dim _subtotal As Decimal = 0 : Dim _diskon As Decimal = 0 : Dim _total As Decimal = 0
            Dim _pajak As Decimal = 0 : Dim _netto As Decimal = 0
            Dim _jenisPajak As Integer = 0
            Dim _kode As String = row.ItemArray(0)

            Dim _supplier As String = row.Item("KodeSupplier")
            Dim _gudang As String = row.Item("KodeGudang")

            Dim _expression = String.Format("KodeFaktur = '{0}'", _kode)
            Dim _ListBrg = DataBeli.Select(_expression)

            'INSERT SUPPLIER
            Dim _suppCk As Integer = 0
            Dim _kodeCk As Integer = 0
            Dim _gdgCk As Integer = 0
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    q = "SELECT COUNT(supplier_id) FROM data_supplier_master WHERE supplier_kode='{0}'"
                    _suppCk = CInt(x.ExecScalar(String.Format(q, _supplier)))
                    q = "SELECT COUNT(gudang_kode) FROM data_barang_gudang WHERE gudang_kode='{0}'"
                    _gdgCk = CInt(x.ExecScalar(String.Format(q, _gudang)))
                    q = "SELECT COUNT(faktur_kode) FROM data_pembelian_faktur WHERE faktur_kode='{0}' AND faktur_status < 9"
                    _kodeCk = CInt(x.ExecScalar(String.Format(q, _kode)))
                End If
            End Using

            If _kodeCk > 0 Then
                consoleWriteLine(_kode & " already exist")
                GoTo NextFaktur
            End If

            If _suppCk = 0 Then
                q = "INSERT INTO data_supplier_master SET {0}"
                Dim _fk = {"supplier_kode='" & _supplier & "'",
                           "supplier_nama='" & row.Item("NamaSupplier"),
                           "supplier_alamat='" & row.Item("AlamatSupplier")
                          }
                _arr.Add(String.Format(q, String.Join(",", _fk)))
                consoleWriteLine("ADD NEW SUPPLIER : " & _gudang)
            End If

            If _gdgCk = 0 Then
                q = "INSERT INTO data_barang_gudang(gudang_kode, gudang_nama, gudang_reg_date, gudang_reg_alias) " _
                    & "VALUE('{0}', '{1}', NOW(), 'Migrasi-{2}') ON DUPLICATE KEY UPDATE gudang_id=gudang_id"
                _arr.Add(String.Format(q, _gudang, row.Item("NamaGudang"), loggeduser.user_id))
                consoleWriteLine("ADD NEW GUDANG : " & _gudang)
            End If

            'GET JENIS PAJAK
            Select Case Trim(LCase(row.Item("JenisPajak").ToString.Replace("-", "")))
                Case "nonpajak" : _jenisPajak = 0
                Case "include", "pajak" : _jenisPajak = 1
                Case "exclude" : _jenisPajak = 2
                Case Else
                    RetCheck = False : RetMsg = "Input data tidak sesuai. Jenis pajak tidak sesuai dengan ketentuan."
                    GoTo EndFunct
            End Select

            For Each _brg As DataRow In _ListBrg
                Dim _kodebarang As String = _brg.ItemArray(1)
                Dim _hargajual As Decimal = _brg.Item("HargaJual") * _brg.Item("Qty")

                Dim _drp As Decimal = _hargajual - (_brg.Item("DiscRp") * _brg.Item("Qty"))

                _subtotal += _hargajual
                For Each dsk As Decimal In {_brg.Item("Disc1"), _brg.Item("Disc2"), _brg.Item("Disc3")}
                    If dsk <> 0 Then
                        _drp = _drp * (1 - dsk / 100)
                    End If
                Next
                _diskon += _hargajual - _drp


                q = "INSERT INTO data_pembelian_trans SET {0}"
                Dim _fb = {"trans_faktur='" & _kode & "'",
                           "trans_barang='" & _kodebarang & "'",
                           "trans_harga_beli=" & CDec(_brg.Item("HargaBeli")).ToString.Replace(",", "."),
                           "trans_qty='" & _brg.Item("Qty") & "'",
                           "trans_satuan='" & _brg.Item("SatuanBeli") & "'",
                           "trans_satuan_type='" & LCase(_brg.Item("JenisSatuan")) & "'",
                           "trans_disc1=" & Decimal.Parse(_brg.Item("Disc1")).ToString.Replace(",", "."),
                           "trans_disc2=" & Decimal.Parse(_brg.Item("Disc2")).ToString.Replace(",", "."),
                           "trans_disc3=" & Decimal.Parse(_brg.Item("Disc3")).ToString.Replace(",", "."),
                           "trans_disc_rupiah=" & Decimal.Parse(_brg.Item("DiscRp")).ToString.Replace(",", "."),
                           "trans_jumlah=" & _drp.ToString.Replace(",", "."),
                           "trans_status=1"
                          }
                _arr.Add(String.Format(q, String.Join(",", _fb)))
            Next

            'COUNT BIAYA
            _total = _subtotal - _diskon
            _netto = _total
            If _jenisPajak = 2 Then
                _pajak = _subtotal * 0.1 : _netto = _total + _pajak
            ElseIf _jenisPajak = 1 Then
                _pajak = _subtotal * (1 - 10 / 11)
            End If

            'INPUT HEADER JUAL
            q = "INSERT INTO data_pembelian_faktur SET {0}"
            Dim _fh = {"faktur_kode = '" & _kode & "'",
                       "faktur_tanggal_trans = '" & CDate(row.Item("Tgl")).ToString("yyyy-MM-dd") & "'",
                       "faktur_pajak_tanggal=faktur_tanggal_trans",
                       "faktur_gudang='" & _gudang & "'",
                       "faktur_supplier='" & _supplier & "'",
                       "faktur_term=" & row.Item("Term"),
                       "faktur_jumlah=" & _subtotal.ToString.Replace(",", "."),
                       "faktur_disc=" & _diskon.ToString.Replace(",", "."),
                       "faktur_total=" & _total.ToString.Replace(",", "."),
                       "faktur_ppn=" & _pajak.ToString.Replace(",", "."),
                       "faktur_ppn_jenis=" & _jenisPajak,
                       "faktur_netto=" & _netto.ToString.Replace(",", "."),
                       "faktur_total_netto=faktur_netto",
                       "faktur_status=1",
                       "faktur_reg_date=NOW()",
                       "faktur_reg_alias='Migrasi-" & loggeduser.user_id & "'"
                      }
            _arr.Add(String.Format(q, String.Join(",", _fh)))

            q = "CALL transPembelianFin('{0}','{1}')"
            _arr.Add(String.Format(q, _kode, loggeduser))

            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _ck As Boolean = False

                    Try
                        _ck = x.TransactCommand(_arr)
                        If _ck Then
                            _succCt += 1 : SucceedFaktur.Add(_kode)
                            consoleWriteLine(_kode & " added")
                        End If
                    Catch ex As Exception
                        logError(ex, True)
                        RetCheck = False
                        RetMsg = String.Join(Environment.NewLine,
                                             "Terjadi kesalahan saat melakukan proses import.",
                                             ex.Message,
                                             IIf(_succCt > 0, _succCt & " faktur telah tersimpan.", "")
                                             )
                        GoTo EndFunct
                    End Try
                Else
                    RetCheck = False : RetMsg = "Tidak dapat terhubung ke database."
                    GoTo EndFunct
                End If
            End Using
NextFaktur:
        Next
        RetCheck = True : RetMsg = _succCt & " dari " & HeaderBeli.Rows.Count & " faktur penjualan telah di tambahkan ke database."

EndFunct:
        Return New KeyValuePair(Of Boolean, String)(RetCheck, RetMsg)
    End Function

    'IMPORT RETUR BELI
    Public Function DoImportReturBeli(HeaderRetur As DataTable, DataRetur As DataTable) As KeyValuePair(Of Boolean, String)
        Dim RetCheck As Boolean = False
        Dim RetMsg As String = ""
        Dim q As String = ""
        Dim qArr As New List(Of List(Of String))

        Dim HeaderRows = HeaderRetur.Select("", "KodeBukti ASC")

        For Each row As DataRow In HeaderRows
            Dim _arr As New List(Of String)

            Dim _subtotal As Decimal = 0 : Dim _diskon As Decimal = 0 : Dim _total As Decimal = 0
            Dim _pajak As Decimal = 0 : Dim _netto As Decimal = 0
            Dim _jenisPajak As Integer = 0
            Dim _jenisBayar As Integer = 0
            Dim _kode As String = row.ItemArray(0)

            Dim _supplier As String = row.Item("KodeSupplier")
            Dim _gudang As String = row.Item("KodeGudang")

            Dim _expression = String.Format("KodeBukti = '{0}'", _kode)
            Dim _ListBrg = DataRetur.Select(_expression)

            'INSERT CUSTOMER
            Dim _suppCK As Integer = 0
            Dim _kodeCk As Integer = 0
            Dim _gdgCk As Integer = 0
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    q = "SELECT COUNT(supplier_id) FROM data_supplier_master WHERE supplier_kode='{0}'"
                    _suppCK = CInt(x.ExecScalar(String.Format(q, _supplier)))
                    q = "SELECT COUNT(faktur_kode_bukti) FROM data_pembelian_retur_faktur WHERE faktur_kode_bukti='{0}' AND faktur_status < 9"
                    _kodeCk = CInt(x.ExecScalar(String.Format(q, _kode)))
                    q = "SELECT COUNT(gudang_kode) FROM data_barang_gudang WHERE gudang_kode='{0}'"
                    _gdgCk = CInt(x.ExecScalar(String.Format(q, _gudang)))
                End If
            End Using

            If _kodeCk > 0 Then
                consoleWriteLine(_kode & " already exist")
                GoTo NextTrans
            End If

            'HMMMMM???
            If _suppCK = 0 Then
                q = "INSERT INTO data_supplier_master SET {0}"
                Dim _fk = {"supplier_kode='" & _supplier & "'",
                           "supplier_nama='" & row.Item("NamaSupplier") & "'",
                           "supplier_alamat='" & row.Item("AlamatSupplier") & "'"
                          }
                _arr.Add(String.Format(q, String.Join(",", _fk)))
                consoleWriteLine("ADD NEW SUPPLIER : " & _gudang)
            End If

            If _gdgCk = 0 Then
                q = "INSERT INTO data_barang_gudang(gudang_kode, gudang_nama, gudang_reg_date, gudang_reg_alias) " _
                    & "VALUE('{0}', '{1}', NOW(), 'Migrasi-{2}') ON DUPLICATE KEY UPDATE gudang_id=gudang_id"
                _arr.Add(String.Format(q, _gudang, row.Item("NamaGudang"), loggeduser.user_id))
                consoleWriteLine("ADD NEW GUDANG : " & _gudang)
            End If

            'GET JENIS PAJAK
            Select Case LCase(Trim(row.Item("JenisPajak")).Replace("-", ""))
                Case "nonpajak" : _jenisPajak = 0
                Case "include", "pajak" : _jenisPajak = 1
                Case "exclude" : _jenisPajak = 2
                Case Else
                    RetCheck = False : RetMsg = "Input data tidak sesuai. Jenis pajak tidak sesuai dengan ketentuan."
                    GoTo EndFunct
            End Select

            'GET JENIS PEMBAYARAN
            Select Case LCase(row.Item("JenisBayar"))
                Case "potong nota" : _jenisBayar = 1
                Case "tunai" : _jenisBayar = 2
                Case "titip" : _jenisBayar = 3
                Case Else
                    RetCheck = False : RetMsg = "Input data tidak sesuai. Jenis pembayaran tidak sesuai dengan ketentuan."
                    GoTo EndFunct
            End Select

            'GET DATA BARANG
            For Each _brg As DataRow In _ListBrg
                Dim _kodebarang As String = _brg.ItemArray(1)
                Dim _hargaretur As Decimal = _brg.Item("HargaRetur") * _brg.Item("Qty")
                Dim _hpp = 0

                _subtotal += _hargaretur
                _diskon += _brg.Item("JumlahDiskon")

                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        q = "SELECT getHPPAVG('{0}','{1}','{2}')"
                        _hpp = x.ExecScalar(String.Format(q, _kodebarang, CDate(row.Item("Tgl")).ToString("yyyy-MM-dd"), selectperiode.id))
                    End If
                End Using

                q = "INSERT INTO data_pembelian_retur_trans SET {0}"
                Dim _fb = {"trans_faktur='" & _kode & "'",
                           "trans_barang='" & _kodebarang & "'",
                           "trans_harga_retur=" & CDec(_brg.Item("HargaRetur")).ToString.Replace(",", "."),
                           "trans_qty='" & _brg.Item("Qty") & "'",
                           "trans_satuan='" & _brg.Item("SatuanJual") & "'",
                           "trans_satuan_type='" & LCase(_brg.Item("JenisSatuan")) & "'",
                           "trans_diskon=" & Decimal.Parse(_brg.Item("Diskon")).ToString.Replace(",", "."),
                           "trans_hpp=" & Decimal.Parse(_hpp).ToString.Replace(",", "."),
                           "trans_status=1"
                          }
                _arr.Add(String.Format(q, String.Join(",", _fb)))
            Next

            'COUNT BIAYA
            _total = _subtotal - _diskon
            _netto = _total
            If _jenisPajak = 2 Then
                _pajak = _subtotal * 0.1 : _netto = _total + _pajak
            ElseIf _jenisPajak = 1 Then
                _pajak = _subtotal * (1 - 10 / 11)
            End If

            'INPUT HEADER JUAL
            q = "INSERT INTO data_pembelian_retur_faktur SET {0}"
            Dim _fh = {"faktur_kode_bukti = '" & _kode & "'",
                       "faktur_tanggal_trans = '" & CDate(row.Item("Tgl")).ToString("yyyy-MM-dd") & "'",
                       "faktur_pajak_tanggal=faktur_tanggal_trans",
                       "faktur_gudang='" & _gudang & "'",
                       "faktur_supplier='" & _supplier & "'",
                       "faktur_jen_bayar='" & _jenisBayar & "'",
                       "faktur_kode_faktur='" & row.Item("KodeFaktur") & "'",
                       "faktur_kode_exfaktur='" & row.Item("KodeExFaktur") & "'",
                       "faktur_jumlah=" & _subtotal.ToString.Replace(",", "."),
                       "faktur_netto=" & _netto.ToString.Replace(",", "."),
                       "faktur_ppn_persen=" & _pajak.ToString.Replace(",", "."),
                       "faktur_ppn_jenis=" & _jenisPajak,
                       "faktur_status=1",
                       "faktur_reg_date=NOW()",
                       "faktur_reg_alias='Migrasi-" & loggeduser.user_id & "'"
                      }
            _arr.Add(String.Format(q, String.Join(",", _fh)))

            q = "CALL transReturBeliFin('{0}','{1}')"
            _arr.Add(String.Format(q, _kode, loggeduser.user_id))

            qArr.Add(_arr)
NextTrans:
        Next

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _ck As Boolean = False
                Dim _succCt As Integer = 0

                Try
                    For Each StrList As List(Of String) In qArr
                        _ck = x.TransactCommand(StrList)
                        If _ck Then _succCt += 1
                    Next

                    RetCheck = True : RetMsg = _succCt & " dari " & qArr.Count & " faktur retur penjualan telah di tambahkan ke database."
                Catch ex As Exception
                    logError(ex, True)
                    RetCheck = False
                    RetMsg = String.Join(Environment.NewLine,
                                         "Terjadi kesalahan saat melakukan proses import.",
                                         ex.Message,
                                         IIf(_succCt > 0, _succCt & " faktur telah tersimpan.", "")
                                         )
                End Try
            Else
                RetCheck = False : RetMsg = "Tidak dapat terhubung ke database."
            End If
        End Using

EndFunct:
        Return New KeyValuePair(Of Boolean, String)(RetCheck, RetMsg)
    End Function

    'IMPORT PEMBAYARAN HUTANG
    Public Function GetImportBayar(DataBayar As DataTable, IdType As Integer) As DataTable
        Select Case IdType
            Case 1 'Header
                Dim SelectedCol As String() = {"KodeBayar", "TanggalBayar"}
                Return New DataView(DataBayar).ToTable(False, SelectedCol)
            Case Else
                Return New DataTable
        End Select
    End Function
End Module
