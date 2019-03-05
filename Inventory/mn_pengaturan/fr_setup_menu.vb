Public Class fr_setup_menu
    'FILL DGV
    Private Sub populateDGV_menu()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        setDoubleBuffered(dgv_menu, True)
        Dim q As String = "SELECT menu_id, menu_kode, menu_parent, menu_label, " _
                          & "(CASE menu_status WHEN 1 THEN 'AKTIF' WHEN 0 THEN 'INACTIVE' WHEN 9 THEN 'DELETE' ELSE 'ERROR' END) menu_status " _
                          & "FROM data_menu_master ORDER BY menu_kode ASC"
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using dt = x.GetDataTable(q)
                    dgv_menu.DataSource = dt
                End Using
            End If
        End Using
    End Sub

    'GET DATA
    Private Sub loadData(menuID As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = "SELECT menu_id, menu_kode, menu_parent, menu_label, menu_status " _
                          & "FROM data_menu_master WHERE menu_id='{0}'"
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, menuID))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_id.Text = rdx.Item(0)
                        in_menu_kode.Text = rdx.Item(1)
                        in_menu_parent.Text = rdx.Item(2)
                        in_menu_nama.Text = rdx.Item(3)
                        ck_enable.Checked = IIf(rdx.Item(4) = 1, True, False)
                    End If
                End Using
            End If
        End Using
    End Sub

    'SAVE DATA
    Private Sub saveData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = ""
        Dim queryCk As Boolean = False
        Dim rw As Integer = 0
        Using x = MainConnection
            x.Open()
            If String.IsNullOrWhiteSpace(in_id.Text) Then
                q = "INSERT data_menu_master(menu_kode,menu_parent,menu_label,menu_reg_date,menu_reg_alias) VALUE('{0}','{1}','{2}',NOW(),'{3}')"
                rw = x.ExecCommand(String.Format(q, in_menu_kode.Text, in_menu_parent.Text, in_menu_nama.Text, loggeduser.user_id))
            Else
                q = "UPDATE data_menu_master SET menu_kode='{0}', menu_parent='{1}', menu_label='{2}', menu_status='{5}', menu_upd_date=NOW(), " _
                    & "menu_upd_alias='{3}' WHERE menu_id='{4}'"
                rw = x.ExecCommand(String.Format(q, in_menu_kode.Text, in_menu_parent.Text, in_menu_nama.Text, loggeduser.user_id,
                                                 Trim(in_id.Text), IIf(ck_enable.Checked, 1, 0)))
            End If
        End Using

        If rw = 1 Then : queryCk = True : Else : queryCk = False : End If
        If queryCk Then
            MessageBox.Show("Data menu tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            populateDGV_menu()
            clearText()
        Else
            MessageBox.Show("Data menu tidak tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'DELETE DATA
    Private Sub deletData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = "UPDATE data_menu_master SET menu_status=9, menu_upd_date=NOW(), menu_upd_alias='{1}' WHERE menu_id='{0}'"
        Dim rw As Integer = 0
        Dim queryCk As Boolean = False
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                rw = x.ExecCommand(String.Format(q, in_id.Text, loggeduser.user_id))
            End If
        End Using
        If rw = 1 Then : queryCk = True : Else : queryCk = False : End If
        If queryCk Then
            MessageBox.Show("Data menu tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            populateDGV_menu()
            clearText()
        Else
            MessageBox.Show("Data menu tidak tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'CLEAR FORM
    Private Sub clearText()
        in_id.Clear()
        in_menu_kode.Clear()
        in_menu_nama.Clear()
        in_menu_parent.Clear()
        ck_enable.Checked = False
        bt_hapus_menu.Enabled = False
        bt_tambah_menu.Text = "Tambah"
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
    Private Sub bt_keluar_Click(sender As Object, e As EventArgs) Handles bt_keluar_menu.Click
        Me.Close()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'e.Cancel = True
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_keluar_menu.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    'LOAD
    Private Sub fr_setup_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateDGV_menu()
    End Sub

    'UI : BUTTON
    Private Sub bt_tambah_menu_Click(sender As Object, e As EventArgs) Handles bt_tambah_menu.Click
        Dim querycheck As Boolean = False

        If in_menu_kode.Text = Nothing Then
            MessageBox.Show("Kode menu belum di input")
            in_menu_kode.Focus()
            Exit Sub
        End If

        If in_menu_nama.Text = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_menu_nama.Focus()
            Exit Sub
        End If

        If in_id.Text = Nothing Then
            For Each row As DataGridViewRow In dgv_menu.Rows
                If in_menu_kode.Text = row.Cells(1).Value Then
                    MessageBox.Show("Kode menu sudah ada")
                    in_menu_kode.Focus()
                    Exit Sub
                End If
            Next
        End If

        saveData()
    End Sub

    Private Sub bt_hapus_menu_Click(sender As Object, e As EventArgs) Handles bt_hapus_menu.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then
            MessageBox.Show("ID menu kosong")
            in_menu_nama.Focus()
            Exit Sub
        End If
        deletData()
    End Sub

    Private Sub bt_batal_Click(sender As Object, e As EventArgs) Handles bt_batal.Click
        clearText()
        in_menu_kode.Focus()
    End Sub

    'UI : OTHER
    Private Sub in_menu_kode_TextChanged(sender As Object, e As EventArgs) Handles in_menu_kode.TextChanged
        If in_menu_kode.Text <> Nothing Then
            in_menu_parent.Text = sLeft(in_menu_kode.Text, 4)
        End If
    End Sub

    Private Sub dgv_menu_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_menu.CellDoubleClick
        loadData(dgv_menu.SelectedRows.Item(0).Cells(0).Value)
        bt_hapus_menu.Enabled = True
        bt_tambah_menu.Text = "Update"
    End Sub
End Class