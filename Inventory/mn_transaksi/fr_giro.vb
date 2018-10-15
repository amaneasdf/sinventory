Public Class fr_giro
    Public tipegiro As String = ""
    Private statuscair As Boolean = False
    Private datecairchange As Boolean = False
    Private statustolak As Boolean = False

    Private Sub loadData(kode As String, tipe As String)
        Dim q As String = ""
        op_con()

        Select Case tipe
            Case "OUT"
                q = "SELECT giro_no, giro_nilai, giro_tglcair, g_cair_tglcair," _
                    & "h_bayar_supplier, supplier_nama, giro_ref, giro_ket " _
                    & "FROM data_giro LEFT JOIN data_giro_cair ON giro_no=g_cair_nobg AND g_cair_status=1 " _
                    & "left join data_hutang_bayar ON giro_ref=h_bayar_bukti AND h_bayar_status=1 " _
                    & "LEFT JOIN data_supplier_master ON h_bayar_supplier=supplier_kode " _
                    & "WHERE giro_type='OUT' AND giro_status=1 AND giro_no='{0}'"
                q = String.Format(q, kode)

                readcommd(q)
                If rd.HasRows Then
                    in_nobg.Text = rd.Item("giro_no")
                    'bank
                    in_nilaibg.Text = commaThousand(rd.Item("giro_nilai"))
                    in_tgl_bg.Text = CDate(rd.Item("giro_tglcair"))
                    If IsDBNull(rd.Item("g_cair_tglcair")) = False Then
                        statuscair = True
                        date_tgl_cair.Value = rd.Item("g_cair_tglcair")
                        in_tgl_cair.Text = date_tgl_cair.Value.ToShortDateString
                        datecairchange = False
                    End If
                    in_ref.Text = rd.Item("h_bayar_supplier")
                    in_ref_n.Text = rd.Item("supplier_nama")
                    in_faktur.Text = rd.Item("giro_ref")
                    in_ket.Text = rd.Item("giro_ket")
                End If
                rd.Close()
            Case "IN"
                q = "SELECT giro_no, giro_nilai, giro_tglcair, g_cair_tglcair," _
                    & "p_bayar_custo, customer_nama, giro_ref, giro_ket " _
                    & "FROM data_giro LEFT JOIN data_giro_cair ON giro_no=g_cair_nobg AND g_cair_status=1 " _
                    & "left join data_piutang_bayar ON giro_ref=p_bayar_bukti AND p_bayar_status=1 " _
                    & "LEFT JOIN data_customer_master ON p_bayar_custo=customer_kode " _
                    & "WHERE giro_type='IN' AND giro_status=1 AND giro_no='{0}'"
                q = String.Format(q, kode)

                readcommd(q)
                If rd.HasRows Then
                    in_nobg.Text = rd.Item("giro_no")
                    'bank
                    in_nilaibg.Text = commaThousand(rd.Item("giro_nilai"))
                    in_tgl_bg.Text = CDate(rd.Item("giro_tglcair"))
                    If IsDBNull(rd.Item("g_cair_tglcair")) = False Then
                        statuscair = True
                        date_tgl_cair.Value = rd.Item("g_cair_tglcair")
                        in_tgl_cair.Text = date_tgl_cair.Value.ToShortDateString
                        datecairchange = False
                    End If
                    in_ref.Text = rd.Item("p_bayar_custo")
                    in_ref_n.Text = rd.Item("customer_nama")
                    in_faktur.Text = rd.Item("giro_ref")
                    in_ket.Text = rd.Item("giro_ket")
                End If
                rd.Close()
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub formSW(tipe As String)
        Select Case tipe
            Case "OUT"
                cb_akun.Visible = False
            Case Else
                cb_akun.Visible = True
        End Select
    End Sub
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
        If MessageBox.Show("Tutup Form?", "Detail Giro", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanbeli.PerformClick()
    End Sub

    'SAVE
    Private Sub saveData()
        op_con()
        Dim q As String = ""
        Dim data1 As String()
        Dim chkquery As Boolean = False
        Dim queryArr As New List(Of String)

        q = "UPDATE data_giro SET giro_ket='" & in_ket.Text & "', giro_upd_date=NOW(), giro_upd_alias='{2}' WHERE giro_no='{0}' AND giro_type='{1}'"
        q = String.Format(q, in_nobg.Text, tipegiro, loggeduser.user_id)
        chkquery = commnd(q)

        If in_tgl_cair.Text <> Nothing Then
            'PENCAIRAN
            If statuscair = True And datecairchange = True And MessageBox.Show("Giro " & in_nobg.Text & " sudah pernah diinputkan. Ganti tanggal pencairan?", "Pencairan Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            q = "INSERT INTO data_giro_cair SET g_cair_nobg='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
            data1 = {
                "g_cair_tglcair='" & date_tgl_cair.Value.ToString("yyyy-MM-dd") & "'",
                "g_cair_tujuan='" & IIf(tipegiro = "IN", cb_akun.SelectedValue, "") & "'",
                "g_cair_status='1'",
                "g_cair_reg_alias='" & loggeduser.user_id & "'",
                "g_cair_reg_date=NOW()"
                }
            chkquery = commnd(String.Format(q, in_nobg.Text, String.Join(",", data1)))

            '==========================================================================================================================
            'INPUT JURNAL
            '----------HEAD
            'q = "INSERT INTO data_jurnal_line SET line_kode='{0}', line_type='CAIRGIRO',{1},line_reg_date=NOW(),line_reg_alias='{2}' " _
            '    & "ON DUPLICATE KEY UPDATE {1},line_upd_date=NOW(),line_upd_alias='{2}'"
            'data1 = {
            '    "line_ref='" & in_faktur.Text & "'",
            '    "line_ref_type='GIROOUT'",
            '    "line_tanggal='" & date_tgl_cair.Value.ToString("yyyy-MM-dd") & "'",
            '    "line_status='1'"
            '    }
            'queryArr.Add(String.Format(q, in_nobg.Text, String.Join(",", data1), loggeduser.user_id))
            '==========================================================================================================================

            '==========================================================================================================================
            'BEGIN TRANSACTION
            'chkquery = startTrans(queryArr)
            '==========================================================================================================================

        End If

        If chkquery = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
        Else
            MessageBox.Show("Data tersimpan")
            doRefreshTab({pghutangbgo, pgpiutangbgcair})
            Me.Close()
        End If
    End Sub

    'load
    Public Sub do_load(tipe As String, kode As String)
        With cb_akun

        End With

        tipegiro = tipe

        formSW(tipe)
        loadData(kode, tipe)
    End Sub

    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If MessageBox.Show("Simpan data giro?", "Detail Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            saveData()
        End If
    End Sub

    'UI
    Private Sub date_tgl_cair_ValueChanged(sender As Object, e As EventArgs) Handles date_tgl_cair.ValueChanged
        If statuscair = True Then
            datecairchange = True
        End If
        in_tgl_cair.Text = date_tgl_cair.Value.ToShortDateString
    End Sub

    Private Sub cb_akun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_akun.KeyPress
        If e.KeyChar <> ControlChars.CrLf Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_akun_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_akun.KeyUp
        keyshortenter(bt_simpanbeli, e)
    End Sub
End Class