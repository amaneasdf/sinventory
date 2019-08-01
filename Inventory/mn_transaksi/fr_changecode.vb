Public Class fr_changecode
    Private ValType As String = "IN"
    Private CodeType As String = "FK"
    Public RetVal As New KeyValuePair(Of Boolean, String)
    Private pass_switch As Boolean = True

    'CHECKING USER PRIVILEDGE
    Public Function CheckUser(uid As String, pass As String, ValidationType As String) As Boolean
        Dim _col As String = ""
        Select Case LCase(ValidationType)
            Case "transaksi" : _col = "user_validasi_trans"
            Case Else : Return False : Exit Function
        End Select
        Dim q As String = "SELECT {2} FROM data_pengguna_alias  WHERE user_alias='{0}' AND user_pwd='{1}' AND user_status=1"

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim i As String = CStr(x.ExecScalar(String.Format(q, uid, computeHash(pass), _col)))
                If String.IsNullOrWhiteSpace(i) Then
                    MessageBox.Show("User atau password salah.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return False
                ElseIf i = 1 Then
                    Return True
                ElseIf i = 0 Then
                    MessageBox.Show("User tidak memiliki hak untuk melakukan validasi perubahan data.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                Else
                    MessageBox.Show("Terjadi kesalahan saat melakukan proses validasi.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
    End Function

    'CHECKING NEW CODE
    Private Function CodeCheck(NewCode As String) As Boolean
        Dim q As String = ""
        Dim _msg As String = ""
        Dim cAct As Integer = 0 : Dim cDel As Integer = 0
        Select Case ValType
            Case "transaksi" : _msg = "Nomor faktur"
        End Select

        If NewCode = in_kode_old.Text Then
            MessageBox.Show(String.Format("{0} baru sama dengan yang lama.", _msg), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False : Exit Function
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Select Case LCase(CodeType)
                    Case "jual"
                        q = "SELECT COUNT(CASE WHEN faktur_status!=9 THEN 1 END) ActiveCode, COUNT(CASE WHEN faktur_status=9 THEN 1 END) DeleteCode " _
                            & "FROM data_penjualan_faktur WHERE faktur_kode='{0}'"
                    Case Else : Return False : Exit Function
                End Select

                Using rdx = x.ReadCommand(String.Format(q, NewCode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        Select Case LCase(CodeType)
                            Case "jual"
                                cAct = rdx.Item(0) : cDel = rdx.Item(1)
                                If cAct = 1 Then 'WHEN THE CODE ALREADY TAKEN
                                    MessageBox.Show("Nomor faktur " & NewCode & " sudah pernah diinputkan", "Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    in_kode_new.Focus() : Return False : Exit Function
                                ElseIf cAct = 0 And cDel = 0 Then 'WHEN THE CODE IS AVAILABLE
                                    Return True : Exit Function
                                ElseIf cDel = 1 Then 'WHEN THE CODE IS ALREADY TAKEN BUT THE TRASACTION STATE IS 'DELETE'
                                    Return True : Exit Function
                                Else 'WHEN THERE IS DUPLICATION IN DATABASE ON THE CODE
                                    MessageBox.Show("Terjadi kesalahan dalam melakukan proses pengecekan kode." & Environment.NewLine & _
                                                    "Terdapat duplikasi kode pada database, kode faktur tidak dapat digunakan.",
                                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    errLog(New List(Of String) From {"Error : Duplicate primary code in database for sale transaction.",
                                                                     "Duplicated Code : " & NewCode
                                                                    }) : Return False : Exit Function
                                End If

                                'Case "returjual"

                            Case Else
                                Return False : Exit Function
                        End Select
                    Else
                        MessageBox.Show("Terjadi kesalahan dalam proses pengecekan kode.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False : Exit Function
                    End If
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
    End Function

    'GENERATE NEW CODE
    Private Function GenerateNewCode() As Boolean
        Dim q As String = ""
        Dim i As Integer = 0
        Dim _kode As String = "" : Dim format As String = ""
        Dim _transactdate As Date = Today

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Select Case LCase(CodeType)
                        Case "jual"
                            q = "SELECT faktur_tanggal_trans FROM data_penjualan_faktur WHERE faktur_kode='{0}' AND faktur_status=1"
                            _transactdate = CDate(x.ExecScalar(String.Format(q, in_kode_old.Text)))

                            q = "SELECT IFNULL(MAX(SUBSTRING(faktur_kode, 11)),0) FROM data_penjualan_faktur " _
                                & "WHERE faktur_kode LIKE 'SO{0:yyyyMMdd}%' AND SUBSTRING(faktur_kode,11) REGEXP '^[0-9]+$'"
                            i = CInt(x.ExecScalar(String.Format(q, _transactdate)))
                            format = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                            _kode = String.Format("SO{0:yyyyMMdd", _transactdate) & (i + 1).ToString(format)

                        Case Else : Return False : Exit Function
                    End Select
                Catch ex As Exception
                    logError(ex, True)
                End Try

                If String.IsNullOrWhiteSpace(_kode) Then
                    MessageBox.Show("Terjadi kesalahan saat membuat kode baru.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Else
                    in_kode_new.Text = _kode
                    Return True
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
    End Function

    'SAVING NEW CODE
    Private Sub SaveCode()
        Dim _kode1 As String = in_kode_new.Text
        Dim _kode2 As String = in_kode_old.Text
        Dim _ck As Boolean = False
        Dim _msg As String
        Select Case LCase(CodeType)
            Case "jual"
                _ck = SaveCode_jual(_kode1, _kode2) : _msg = "nomor faktur penjualan"
            Case Else : Exit Sub
        End Select

        If _ck Then
            'WRITE LOG PERUBAHAN
            MessageBox.Show(String.Format("Perubahan {0} sukses.", _msg), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            RetVal = New KeyValuePair(Of Boolean, String)(True, _kode1)
            Me.Close()
        Else
            MessageBox.Show(String.Format("Perubahan {0} gagal.", _msg), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function SaveCode_jual(NewCode As String, OldCode As String) As Boolean
        Dim q As String = ""
        Dim _qArr As New List(Of String)

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                For Each Str As String In {"UPDATE data_piutang_awal SET piutang_status=9 WHERE piutang_faktur='{0}'",
                                           "UPDATE data_piutang_trans SET p_trans_status=9 WHERE p_trans_kode_piutang='{0}' AND p_trans_jenis='jual'"}
                    _qArr.Add(String.Format(Str, OldCode))
                Next

                For Each Str As String In {"UPDATE data_stok_kartustok SET trans_faktur='{0}' WHERE trans_faktur='{1}' AND trans_jenis='so' AND trans_status=1",
                                           "UPDATE data_piutang_trans SET p_trans_kode_piutang='{0}' WHERE p_trans_kode_piutang='{1}' AND p_trans_status=1",
                                           "UPDATE data_jurnal_line SET line_kode='{0}' WHERE line_kode='{1}' AND line_type='JUAL'",
                                           "UPDATE data_penjualan_retur_faktur SET faktur_kode_faktur='{0}' WHERE faktur_kode_faktur='{1}' AND faktur_status=1",
                                           "UPDATE data_penjualan_trans SET trans_faktur='{0}' WHERE trans_faktur='{1}' AND trans_status=1",
                                           "UPDATE data_piutang_bayar_trans SET p_trans_kode_piutang='{0}' WHERE p_trans_kode_piutang='{1}' AND p_trans_status=1",
                                           "UPDATE data_draft_nota SET nota_faktur='{0}' WHERE nota_faktur='{1}' AND nota_status=1",
                                           "UPDATE data_tagihan_nota SET nota_faktur='{0}' WHERE nota_faktur='{1}' AND nota_status=1"
                                           }
                    _qArr.Add(String.Format(q, NewCode, OldCode))
                Next

                q = "UPDATE data_penjualan_faktur SET faktur_kode='{0}', faktur_upd_date=NOW(), faktur_upd_alias='{2}' WHERE faktur_kode='{1}' AND faktur_status=1"
                _qArr.Add(String.Format(q, NewCode, OldCode, in_user.Text))

                Return x.TransactCommand(_qArr)
            Else
                Return False
            End If
        End Using
    End Function

    'LOAD FORM
    Public Sub do_load(OldCode As String, Optional ValidationType As String = "transaksi", Optional DataType As String = "jual")
        ValType = ValidationType
        CodeType = DataType
        If FormSetup(ValidationType) Then
            in_kode_old.Text = OldCode
            ShowDialog()
        End If
    End Sub

    Private Function FormSetup(ValidationType As String) As Boolean
        in_pass.UseSystemPasswordChar = True

        Select Case LCase(ValidationType)
            Case "transaksi"
                lbl_title.Text = "Ubah No.Faktur"
            Case Else
                Return False : Exit Function
        End Select
        Me.Text = lbl_title.Text
        Return True
    End Function

    '------------drag form
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        'If MessageBox.Show("Batalkan?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        RetVal = New KeyValuePair(Of Boolean, String)(False, "Action_Canceled")
        Me.Close()
        'End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalbeli.PerformClick()
        End If
    End Sub

    'UI : TEXTBOX
    Private Sub in_kode_old_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode_old.KeyDown
        keyshortenter(in_kode_new, e)
    End Sub

    Private Sub in_kode_new_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode_new.KeyDown
        keyshortenter(in_user, e)
    End Sub

    Private Sub in_user_KeyDown(sender As Object, e As KeyEventArgs) Handles in_user.KeyDown
        keyshortenter(in_pass, e)
    End Sub

    Private Sub in_pass_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pass.KeyDown
        keyshortenter(bt_simpanbeli, e)
    End Sub

    'UI : BUTTON
    Private Sub bt_switch_Click(sender As Object, e As EventArgs) Handles bt_switch.Click
        With bt_switch
            If pass_switch = True Then
                .BackgroundImage = Global.Inventory.My.Resources.Resources.hide_password
                pass_switch = False
                in_pass.UseSystemPasswordChar = False
            Else
                .BackgroundImage = Global.Inventory.My.Resources.Resources.show_password
                pass_switch = True
                in_pass.UseSystemPasswordChar = True
            End If
        End With
        in_pass.Focus()
    End Sub

    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim _msg As String
        Select Case LCase(CodeType)
            Case "jual" : _msg = "nomor faktur penjualan"
            Case Else : Exit Sub
        End Select
        If Not MessageBox.Show(String.Format("Ubah {0}?", _msg), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then Exit Sub

        If in_user.Text = "" Then
            MessageBox.Show("Username belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_user.Focus()
            Exit Sub
        End If
        If in_pass.Text = "" Then
            MessageBox.Show("Password belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_pass.Focus()
            Exit Sub
        End If
        If CheckUser(in_user.Text, in_pass.Text, ValType) = False Then
            in_user.Focus()
            Exit Sub
        End If
        If ck_generate.Checked Then
            If Not GenerateNewCode() Then Exit Sub
        Else
            If String.IsNullOrWhiteSpace(in_kode_new.Text) Then
                MessageBox.Show(String.Format("Masukan {0} baru terlebih dahulu.", _msg), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                in_kode_new.Focus() : Exit Sub
            End If
            If Not CodeCheck(in_kode_new.Text) Then
                in_kode_new.Focus() : Exit Sub
            End If
        End If

        SaveCode()
    End Sub

    'UI : CHECKBOX
    Private Sub ck_generate_CheckedChanged(sender As Object, e As EventArgs) Handles ck_generate.CheckedChanged
        in_kode_new.Enabled = IIf(sender.Checked, False, True)
    End Sub
End Class