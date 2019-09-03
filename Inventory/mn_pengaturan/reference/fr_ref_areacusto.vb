Public Class fr_ref_areacusto
    Private _RefType As String = ""
    Private _AllowInput As Boolean = False
    Public DoRefresh As Boolean = False

    Private _formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    Public Sub DoLoadNew(RefType As String, AllowInput As Boolean)
        DoLoadForm(InputState.Insert, RefType, AllowInput)
        Me.ShowDialog()
    End Sub

    Public Sub DoLoadEdit(RefType As String, IdRef As String, AllowInput As Boolean)
        DoLoadForm(InputState.Edit, RefType, AllowInput)
        DoLoadData(IdRef)
        Me.ShowDialog()
    End Sub

    Private Sub DoLoadForm(Formstate As InputState, RefType As String, AllowInput As Boolean)
        _formstate = Formstate
        Dim _cbJenis As String = ""
        If RefType = "areacusto" Then
            _cbJenis = "areacustokab"
        ElseIf RefType = "jeniscusto" Then
            _cbJenis = "hargajual_custo"
        End If
        If String.IsNullOrWhiteSpace(_cbJenis) Then GoTo NEENENENE
        With cb_op
            .DataSource = jenis(_cbJenis)
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With

NEENENENE:
        rb_active.Select()
        _RefType = RefType : _AllowInput = AllowInput
        FormSetup()
    End Sub

    Private Sub FormSetup()
        Dim _sel1 As String() = {"kategoribarang", "satuanbarang", "kabupaten"}
        Dim _sel2 As String() = {"areacusto", "jeniscusto"}
        Select Case _RefType
            Case "kategoribarang" : lbl_title.Text = "Kategori Barang"
            Case "satuanbarang" : lbl_title.Text = "Satuan Barang"
            Case "areacusto" : lbl_title.Text = "Kode Area Customer" : lbl_combo.Text = "Kabupaten"
            Case "kabupaten" : lbl_title.Text = "Kode Kabupaten"
            Case "jeniscusto" : lbl_title.Text = "Jenis Customer" : lbl_combo.Text = "Hrg. Jual"
        End Select
        Me.Text = lbl_title.Text
        If _formstate = InputState.Edit Then
            in_id.ReadOnly = True
        ElseIf _formstate = InputState.Insert And _RefType = "satuanbarang" Then
            in_id.ReadOnly = False : in_id.MaxLength = 3
        End If
        For Each txt As TextBox In {in_nama, in_ket}
            txt.ReadOnly = IIf(_AllowInput, False, True)
        Next
        For Each rb As RadioButton In {rb_active, rb_inactive}
            rb.Enabled = _AllowInput
        Next
        If _sel1.Contains(_RefType) Then
            lbl_combo.Visible = False : cb_op.Visible = False
            in_ket.Location = New Point(79, 54) : in_ket.Height = 71
            lbl_ket.Location = New Point(7, 57)
        Else
            lbl_combo.Visible = True : cb_op.Visible = True
            in_ket.Location = New Point(79, 79) : in_ket.Height = 46
            lbl_ket.Location = New Point(7, 83)
        End If
        cb_op.Enabled = _AllowInput
        bt_del.Visible = False
        bt_del.Enabled = _AllowInput
        bt_simpanbeli.Enabled = _AllowInput
        bt_simpanbeli.Text = IIf(_formstate = InputState.Insert, "Simpan", "Update")
    End Sub

    Private Sub DoLoadData(IdRef As String)
        Dim q As String = ""
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Select Case _RefType
                    Case "kategoribarang"
                        q = "SELECT kategori_kode, kategori_nama, IFNULL(kategori_keterangan,''), kategori_status, kategori_editable " _
                            & "FROM ref_barang_kategori WHERE kategori_kode='{0}'"
                    Case "satuanbarang"
                        q = "SELECT satuan_kode, satuan_nama, IFNULL(satuan_keterangan, ''), satuan_status, 1 " _
                            & "FROM ref_satuan WHERE satuan_kode='{0}'"
                    Case "areacusto"
                        q = "SELECT c_area_id, c_area_nama, IFNULL(c_area_ket, ''), c_area_status, 1, c_area_kode_kab " _
                            & "FROM data_customer_area WHERE c_area_id={0}"
                    Case "kabupaten"
                        q = "SELECT ref_kab_id, ref_kab_nama, IFNULL(ref_kab_ket, ''), ref_kab_status, 1 " _
                            & "FROM ref_area_kabupaten WHERE ref_kab_id={0}"
                    Case "jeniscusto"
                        q = "SELECT jenis_kode, jenis_nama, IFNULL(jenis_keterangan, ''), jenis_status, IF(jenis_kode='00', 0, 1), jenis_def_jual " _
                            & "FROM data_customer_jenis WHERE jenis_kode='{0}'"
                    Case Else : Exit Sub
                End Select
                Using rdx = x.ReadCommand(String.Format(q, IdRef))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_id.Text = rdx.Item(0)
                        in_nama.Text = rdx.Item(1)
                        in_ket.Text = rdx.Item(2)
                        Dim sts As Integer = rdx.Item(3)
                        Dim editable As Integer = rdx.Item(4)
                        If {"areacusto", "jeniscusto"}.Contains(_RefType) Then cb_op.SelectedValue = rdx.Item(5)

                        If sts = 1 Then : rb_active.Select()
                        Else : rb_inactive.Select()
                        End If
                        If editable = 0 Then _AllowInput = False
                        FormSetup()
                    Else
                        MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & "Data tidak dapat ditemukan.",
                                        Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'SAVE DATA
    Private Sub SaveData()
        Dim q As String = ""
        Dim qArr As New List(Of String)

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Select Case _RefType
                    Case "kategoribarang"
                        Dim fh = {"kategori_nama='" & in_nama.Text & "'",
                                  "kategori_keterangan='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                                  "kategori_status=" & IIf(rb_active.Checked, 1, 0)
                                 }
                        If _formstate = InputState.Insert Then
                            'GENERATE CODE
                            Dim i As Integer = 0 : Dim format As String = "D3"
                            q = "SELECT IFNULL(MAX(kategori_kode),0) FROM ref_barang_kategori"
                            Try
                                i = Integer.Parse(x.ExecScalar(q))
                                format = IIf((i + 1).ToString.Length > 3, "D" & (i + 1).ToString.Length, "D3")
                                in_id.Text = (i + 1).ToString(format)
                            Catch ex As Exception
                                logError(ex, True)
                                MessageBox.Show("Terjadi kesalahan saat melakukan proses penyimpanan." & Environment.NewLine & ex.Message,
                                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End Try
                            q = "INSERT INTO ref_barang_kategori SET kategori_kode='{0}', {1}"
                        Else
                            q = "UPDATE ref_barang_kategori SET {1} WHERE kategori_kode='{0}'"
                        End If
                        qArr.Add(String.Format(q, in_id.Text, String.Join(",", fh)))

                    Case "satuanbarang"
                        Dim fh = {"satuan_nama='" & in_nama.Text & "'",
                                  "satuan_keterangan='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                                  "satuan_status=" & IIf(rb_active.Checked, 1, 0)
                                 }
                        If _formstate = InputState.Insert Then
                            'CHECK INPUTED CODE
                            q = "SELECT COUNT(satuan_kode) FROM ref_satuan WHERE satuan_kode='{0}'"
                            Try
                                Dim i = Integer.Parse(x.ExecScalar(String.Format(q, in_id.Text)))
                                If i > 0 Then
                                    MessageBox.Show("Satuan barang sudah pernah diinput.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    in_id.Focus() : Exit Sub
                                End If
                            Catch ex As Exception
                                logError(ex, True)
                                MessageBox.Show("Terjadi kesalahan saat melakukan proses penyimpanan." & Environment.NewLine & ex.Message,
                                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End Try
                            q = "INSERT INTO ref_satuan SET satuan_kode='{0}', {1}"
                        Else
                            q = "UPDATE ref_satuan SET {1} WHERE satuan_kode='{0}'"
                        End If
                        qArr.Add(String.Format(q, in_id.Text, String.Join(",", fh)))

                    Case "areacusto"
                        Dim fh = {"c_area_nama='" & in_nama.Text & "'",
                                  "c_area_kode_kab=" & cb_op.SelectedValue,
                                  "c_area_ket='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                                  "c_area_status=" & IIf(rb_active.Checked, 1, 0)
                                 }
                        If _formstate = InputState.Insert Then
                            'GET NEXT ID
                            q = "SELECT AUTO_INCREMENT FROM information_schema.tables WHERE table_name = 'data_customer_area' AND table_schema = DATABASE()"
                            Try
                                in_id.Text = Integer.Parse(x.ExecScalar(q))
                            Catch ex As Exception
                                logError(ex, True)
                                MessageBox.Show("Terjadi kesalahan saat melakukan proses penyimpanan." & Environment.NewLine & ex.Message,
                                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End Try

                            q = "INSERT INTO data_customer_area SET {0}, c_area_reg_date=NOW(), c_area_reg_alias='{1}'"
                            qArr.Add(String.Format(q, String.Join(",", fh), loggeduser.user_id))
                        Else
                            q = "UPDATE data_customer_area SET {1}, c_area_upd_date=NOW(), c_area_upd_alias='{2}' WHERE c_area_id={0}"
                            qArr.Add(String.Format(q, in_id.Text, String.Join(",", fh), loggeduser.user_id))
                        End If

                    Case "kabupaten"
                        Dim fh = {"ref_kab_nama='" & in_nama.Text & "'",
                                  "ref_kab_ket='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                                  "ref_kab_status=" & IIf(rb_active.Checked, 1, 0)
                                 }
                        If _formstate = InputState.Insert Then
                            'GET NEXT ID
                            q = "SELECT AUTO_INCREMENT FROM information_schema.tables WHERE table_name = 'ref_area_kabupaten' AND table_schema = DATABASE()"
                            Try
                                in_id.Text = Integer.Parse(x.ExecScalar(q))
                            Catch ex As Exception
                                logError(ex, True)
                                MessageBox.Show("Terjadi kesalahan saat melakukan proses penyimpanan." & Environment.NewLine & ex.Message,
                                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End Try

                            q = "INSERT INTO ref_area_kabupaten SET {0}"
                            qArr.Add(String.Format(q, String.Join(",", fh)))
                        Else
                            q = "UPDATE ref_area_kabupaten SET {1} WHERE ref_kab_id={0}"
                            qArr.Add(String.Format(q, in_id.Text, String.Join(",", fh)))

                        End If

                    Case "jeniscusto"
                        Dim fh = {"jenis_nama='" & in_nama.Text & "'",
                                  "jenis_def_jual=" & cb_op.SelectedValue,
                                  "jenis_keterangan='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                                  "jenis_status=" & IIf(rb_active.Checked, 1, 0)
                                 }

                        If _formstate = InputState.Insert Then
                            'GENERATE CODE
                            Dim i As Integer = 0 : Dim format As String = "D2"
                            q = "SELECT IFNULL(MAX(jenis_kode),0) FROM data_customer_jenis"
                            Try
                                i = Integer.Parse(x.ExecScalar(q))
                                format = IIf((i + 1).ToString.Length > 2, "D" & (i + 1).ToString.Length, "D2")
                                in_id.Text = (i + 1).ToString(format)
                            Catch ex As Exception
                                logError(ex, True)
                                MessageBox.Show("Terjadi kesalahan saat melakukan proses penyimpanan." & Environment.NewLine & ex.Message,
                                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End Try
                            q = "INSERT INTO data_customer_jenis SET jenis_kode='{0}', {1}"
                        Else
                            q = "UPDATE data_customer_jenis SET {1} WHERE jenis_kode={0}"
                        End If
                        qArr.Add(String.Format(q, in_id.Text, String.Join(",", fh)))

                    Case Else : Exit Sub
                End Select

                Dim _InputType As String = IIf(_formstate = InputState.Insert, "INSERT", "UPDATE")
                If Not ConfirmEdit(in_id.Text, _InputType) Then Exit Sub

                Dim _ck = x.TransactCommand(qArr)
                If _ck Then
                    MessageBox.Show("Data tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefresh = True : Me.Close()
                Else
                    MessageBox.Show("Data tidak dapat tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'DELETE DATA
    Private Sub DeleteData()
        Dim q As String = ""
        Dim qArr As New List(Of String)

        If Not ConfirmEdit(in_id.Text, "DELETE") Then Exit Sub
        System.Threading.Thread.Sleep(5000)
        MessageBox.Show("OK")
    End Sub

    'KONFIRMASI AKUN
    Private Function ConfirmEdit(ID As String, InputType As String) As Boolean
        Using x As New fr_akun_confirmdialog
            x.doLoadConfirm(loggeduser.user_id)
            Dim _retID As Integer = 0
            If x.returnval.Key Then LogValidTrans(x.returnval.Value, loggeduser.user_id, "REF." & _RefType, InputType, in_id.Text, _retID)
            Return x.returnval.Key
        End Using
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

    'UI : CLOSE
    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        DoRefresh = False : Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    'UI : BUTTON
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If String.IsNullOrWhiteSpace(in_id.Text) And _RefType = "satuanbarang" Then
            MessageBox.Show("Kode satuan belum diinput.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_id.Focus() : Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _msgRes As DialogResult = Windows.Forms.DialogResult.Yes
        If _formstate = InputState.Edit Then _msgRes = MessageBox.Show("Ubah data referensi?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _msgRes = Windows.Forms.DialogResult.Yes Then SaveData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Async Sub bt_del_Click(sender As Object, e As EventArgs) Handles bt_del.Click
        Me.Cursor = Cursors.WaitCursor
        Dim _msgRes = MessageBox.Show("Hapus item referensi?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _msgRes = Windows.Forms.DialogResult.Yes Then
            'Disable any input
            Await Task.Run(Sub() DeleteData())
            're-enable any input
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'UI : INPUT
    Private Sub in_ket_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ket.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.A Then
            e.SuppressKeyPress = True : sender.SelectAll()
        End If
    End Sub
End Class