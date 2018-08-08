Public Class fr_barang_detail
    Private gdstatus As Integer = 1
    Private act As String = "INSERT"

    Private Sub loadData(kode As String)
        readcommd("SELECT * FROM data_barang_master WHERE barang_kode='" & kode & "' ORDER BY barang_version DESC LIMIT 1")
        If rd.HasRows Then
            in_kode.Text = kode
            'Basic
            in_supplier.Text = rd.Item("barang_supplier")
            cb_supplier.SelectedValue = in_supplier.Text
            in_nama.Text = rd.Item("barang_nama")
            Try
                cb_jenis.SelectedValue = rd.Item("barang_jenis")
            Catch ex As Exception
                cb_jenis.SelectedValue = 0
            End Try
            Try
                cb_kategori.SelectedValue = rd.Item("barang_kategori")
            Catch ex As Exception
                'cb_kategori.SelectedIndex = 0
            End Try
            'satuan
            cb_sat_kecil.Text = rd.Item("barang_satuan_kecil")
            cb_sat_tengah.Text = rd.Item("barang_satuan_tengah")
            cb_sat_besar.Text = rd.Item("barang_satuan_besar")
            in_isi_tengah.Value = rd.Item("barang_satuan_tengah_jumlah")
            in_isi_besar.Value = rd.Item("barang_satuan_besar_jumlah")
            'harga
            in_harga_beli.Value = rd.Item("barang_harga_beli")
            in_harga_jual.Value = rd.Item("barang_harga_jual")
            in_harga_mt.Value = rd.Item("barang_harga_jual_mt")
            in_harga_horeka.Value = rd.Item("barang_harga_jual_horeka")
            in_harga_rita.Value = rd.Item("barang_harga_jual_rita")
            in_harga_disc.Value = rd.Item("barang_harga_jual_discount")
            in_beli_d1.Value = rd.Item("Barang_harga_beli_d1")
            in_beli_d2.Value = rd.Item("Barang_harga_beli_d2")
            in_beli_d3.Value = rd.Item("Barang_harga_beli_d3")
            in_beli_klaim.Value = rd.Item("Barang_harga_beli_klaim")
            in_jual_d1.Value = rd.Item("barang_harga_jual_d1")
            in_jual_d2.Value = rd.Item("barang_harga_jual_d2")
            in_jual_d3.Value = rd.Item("barang_harga_jual_d3")
            in_jual_d4.Value = rd.Item("barang_harga_jual_d4")
            in_jual_d5.Value = rd.Item("barang_harga_jual_d5")
            'other
            gdstatus = rd.Item("barang_status")
            in_status_kode.Text = setStatus(gdstatus)
        End If
        rd.Close()

        Dim q As String = "SELECT " _
                             & "reg.barang_reg_date,reg.barang_reg_alias, " _
                             & "upd.barang_reg_date as barang_upd_date, " _
                             & "upd.barang_reg_alias as barang_upd_alias " _
                         & "FROM (SELECT " _
                             & "barang_kode, barang_reg_date,barang_reg_alias, barang_version " _
                             & "FROM data_barang_master WHERE barang_kode='{0}' ORDER BY barang_version ASC LIMIT 1 " _
                         & ") reg LEFT JOIN (SELECT " _
                             & "barang_kode, barang_reg_date,barang_reg_alias, barang_version " _
                             & "FROM data_barang_master WHERE barang_kode='{0}' ORDER BY barang_version DESC LIMIT 1 " _
                         & ") upd ON reg.barang_kode=upd.barang_kode"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            txtRegdate.Text = rd.Item("barang_reg_date")
            txtRegAlias.Text = rd.Item("barang_reg_alias")
            txtUpdDate.Text = rd.Item("barang_upd_date")
            txtUpdAlias.Text = rd.Item("barang_upd_alias")
        End If
        rd.Close()

        'satuan
        lbl_satuan1.Text = cb_sat_kecil.Text
        lbl_satuan2.Text = cb_sat_tengah.Text

    End Sub

    Private Function setStatus(statcode As Integer) As String
        Dim x As String = "A"
        Select Case statcode
            Case 1
                x = "Aktif"
            Case 2
                x = "NonAktif"
            Case 9
                x = "Delete"
            Case Else
                x = "Err"
        End Select
        Return x
    End Function

    Private Sub writeLogAct(kode As String)
        Dim ver, dataid As String
        Dim q As String = "SELECT CONCAT_WS('/',barang_id,barang_kode,barang_version), barang_version FROM data_barang_master WHERE barang_kode ='" & kode & "' ORDER BY barang_version DESC LIMIT 1"

        readcommd(q)
        If rd.HasRows Then
            ver = rd.Item("barang_version")
            dataid = rd.Item(0)
        Else
            ver = "-1"
            dataid = "err"
        End If
        rd.Close()

        If ver = "0" Then
            act = "INSERT"
        ElseIf CInt(ver) > 0 And gdstatus <> 9 Then
            act = "UPDATE"
        ElseIf CInt(ver) < 0 Then
            act = "ERR"
        End If
        Console.Write(act & "-" & dataid)

        createLogAct(act, "data_barang_master", dataid)
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbarang.Click
        If MessageBox.Show("Tutup Form?", "Data Barang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbarang.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '---------------------------- numeric
    Private Sub in_stok_berat_Enter(sender As Object, e As EventArgs) Handles in_jual_d5.Enter, in_jual_d4.Enter, in_jual_d3.Enter, in_jual_d2.Enter, in_jual_d1.Enter, in_isi_tengah.Enter, in_isi_besar.Enter, in_harga_rita.Enter, in_harga_mt.Enter, in_harga_jual.Enter, in_harga_horeka.Enter, in_harga_disc.Enter, in_harga_beli.Enter, in_beli_klaim.Enter, in_beli_d3.Enter, in_beli_d2.Enter, in_beli_d1.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_stok_berat_Leave(sender As Object, e As EventArgs) Handles in_jual_d5.Leave, in_jual_d4.Leave, in_jual_d3.Leave, in_jual_d2.Leave, in_jual_d1.Leave, in_isi_tengah.Leave, in_isi_besar.Leave, in_harga_rita.Leave, in_harga_mt.Leave, in_harga_jual.Leave, in_harga_horeka.Leave, in_harga_disc.Leave, in_harga_beli.Leave, in_beli_klaim.Leave, in_beli_d3.Leave, in_beli_d2.Leave, in_beli_d1.Leave
        numericLostFocus(sender)
    End Sub

    '----------------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanbarang.PerformClick()
    End Sub

    Private Sub mn_status_switch_Click(sender As Object, e As EventArgs) Handles mn_status_switch.Click
        Select Case gdstatus
            Case 1
                gdstatus = 2
            Case 2
                gdstatus = 1
            Case 9
                gdstatus = 1
                act = "UPDATE"
            Case Else
                Exit Sub
        End Select
        in_status_kode.Text = setStatus(gdstatus)
    End Sub

    Private Sub mn_status_del_Click(sender As Object, e As EventArgs) Handles mn_status_del.Click
        If MessageBox.Show("Hapus Data Gudang?", "Data Gudang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            gdstatus = 9
            in_status_kode.Text = setStatus(gdstatus)
            act = "DELETE"
        End If
    End Sub

    '------------------- load
    Private Sub fr_barang_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_supplier
            .DataSource = getDataTablefromDB("SELECT supplier_nama as Text, supplier_kode as Value FROM(SELECT * FROM data_supplier_master ORDER BY supplier_kode ASC, supplier_version DESC) a GROUP BY supplier_kode")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_jenis
            .DataSource = jenisBarang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
        Dim cbsat As ComboBox() = {cb_sat_besar, cb_sat_kecil, cb_sat_tengah}
        For Each x As ComboBox In cbsat
            With x
                .DataSource = jenisSatuan()
                .DisplayMember = "Text"
                .ValueMember = "Value"
                .SelectedIndex = -1
            End With
        Next

        in_status_kode.Text = setStatus(gdstatus)

        op_con()
        If bt_simpanbarang.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadData(.Text)
            End With
        End If

        cb_supplier.Focus()
    End Sub

    'save
    Private Sub bt_simpanbarang_Click(sender As Object, e As EventArgs) Handles bt_simpanbarang.Click
        Dim data, dataCol As String()
        Dim querycheck As Boolean = False
        Dim query As String = "INSERT INTO data_barang_master({0}) SELECT {1} FROM data_barang_master WHERE barang_kode={2}"

        'DONE : TODO : (?) : GENERATE KODE GUDANG -> PREVENT DUPLICATE AND ACCIDENTALY OVERWRITE EXISTING DATA
        'TODO : (?) : ADD REFFERRAL CODE INPUT
        If Trim(in_nama.Text) = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_nama.Focus()
            Exit Sub
        End If
        If Trim(in_supplier.Text) = Nothing Then
            MessageBox.Show("Supplier belum di input")
            cb_supplier.Focus()
            Exit Sub
        End If
        If cb_jenis.SelectedValue = Nothing Then
            MessageBox.Show("Jenis barang belum di input")
            cb_jenis.DroppedDown = True
            cb_jenis.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        op_con()
        If MessageBox.Show("Simpan Data Barang?", "Data Barang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'WITH DATA-VERSION-ING  & USER ACT LOG
            If Trim(in_kode.Text) = Nothing Then
                Dim x As Integer = 0
                readcommd("SELECT SUBSTR(barang_kode,3,7) FROM data_barang_master GROUP BY barang_kode ORDER BY barang_kode DESC LIMIT 1")
                If rd.HasRows Then
                    x = CInt(rd.Item(0)) + 1
                Else
                    x = 1
                End If
                rd.Close()
                in_kode.Text = "BR" & x.ToString("D7")
            End If


            dataCol = {
                "barang_kode", "barang_nama", "barang_supplier", "barang_jenis", "barang_kategori",
                "barang_satuan_kecil", "barang_satuan_tengah", "barang_satuan_tengah_jumlah", "barang_satuan_besar",
                "barang_satuan_besar_jumlah", "barang_harga_beli", "barang_harga_jual", "barang_harga_beli_d1",
                "barang_harga_beli_d2", "barang_harga_beli_d3", "barang_harga_beli_klaim", "barang_harga_jual_mt",
                "barang_harga_jual_rita", "barang_harga_jual_horeka", "barang_harga_jual_discount", "barang_harga_jual_d1",
                "barang_harga_jual_d2", "barang_harga_jual_d3", "barang_harga_jual_d4", "barang_harga_jual_d5",
                "barang_keterangan", "barang_status", "barang_reg_date", "barang_reg_alias", "barang_version"
                }

            data = {
                "'" & in_kode.Text & "'",
                "'" & in_nama.Text & "'",
                "'" & in_supplier.Text & "'",
                "'" & cb_jenis.SelectedValue & "'",
                "''",
                "'" & cb_sat_kecil.Text & "'",
                "'" & cb_sat_tengah.Text & "'",
                "'" & in_isi_tengah.Value & "'",
                "'" & cb_sat_besar.Text & "'",
                "'" & in_isi_besar.Value & "'",
                "'" & in_harga_beli.Value & "'",
                "'" & in_harga_jual.Value & "'",
                "'" & in_beli_d1.Value & "'",
                "'" & in_beli_d2.Value & "'",
                "'" & in_beli_d3.Value & "'",
                "'" & in_beli_klaim.Value & "'",
                "'" & in_harga_mt.Value & "'",
                "'" & in_harga_rita.Value & "'",
                "'" & in_harga_horeka.Value & "'",
                "'" & in_harga_disc.Value & "'",
                "'" & in_jual_d1.Value & "'",
                "'" & in_jual_d2.Value & "'",
                "'" & in_jual_d3.Value & "'",
                "'" & in_jual_d4.Value & "'",
                "'" & in_jual_d5.Value & "'",
                "'" & in_ket.Text & "'",
                "'" & gdstatus & "'",
                "NOW()",
                "'" & loggeduser.user_id & "'",
                "MAX(barang_version)+1"
                }

            Dim q As String = String.Format(query, String.Join(",", dataCol), String.Join(",", data), "'" & in_kode.Text & "'")
            Console.WriteLine(q)
            querycheck = commnd(q)

            Me.Cursor = Cursors.Default

            If querycheck = False Then
                Exit Sub
            Else
                'DONE : TODO : WRITE LOG
                writeLogAct(in_kode.Text)
                MessageBox.Show("Data tersimpan", "Data Barang")
                frmbank.in_cari.Clear()
                populateDGVUserCon("barang", "", frmbarang.dgv_list)
                Me.Close()
                bt_simpanbarang.Text = "Update"
            End If
        End If
    End Sub

    'input
    Private Sub cb_supplier_commit(sender As Object, e As EventArgs) Handles cb_supplier.SelectionChangeCommitted, cb_supplier.Leave
        If cb_supplier.SelectedIndex > -1 Then
            in_supplier.Text = cb_supplier.SelectedValue
        ElseIf cb_supplier.Text = "" Then
            in_supplier.Clear()
        End If
    End Sub

    Private Sub bt_supplier_list_Click(sender As Object, e As EventArgs) Handles bt_supplier_list.Click
        Using search As New fr_search_dialog
            With search
                .query = "SELECT supplier_nama as kode, supplier_kode as nama FROM(SELECT * FROM data_supplier_master ORDER BY supplier_kode ASC, supplier_version DESC) a GROUP BY supplier_kode"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "supplier"
                If Trim(in_supplier.Text) <> Nothing Then
                    .returnkode = in_supplier.Text
                    .in_cari.Text = in_supplier.Text
                    '.bt_search.PerformClick()
                End If
                .ShowDialog()
                cb_supplier.SelectedValue = .returnkode
            End With
        End Using
    End Sub

    Private Sub cb_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_supplier.KeyDown
        keyshortenter(in_nama, e)
    End Sub

    Private Sub in_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama.KeyDown
        keyshortenter(cb_jenis, e)
    End Sub

    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(cb_kategori, e)
    End Sub

    Private Sub cb_kategori_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_kategori.KeyDown
        keyshortenter(cb_sat_kecil, e)
    End Sub

    Private Sub cb_sat_kecil_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_kecil.KeyDown
        keyshortenter(cb_sat_tengah, e)
    End Sub

    Private Sub cb_sat_tengah_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_tengah.KeyDown
        keyshortenter(in_isi_tengah, e)
    End Sub

    Private Sub in_isi_tengah_KeyDown(sender As Object, e As KeyEventArgs) Handles in_isi_tengah.KeyDown
        keyshortenter(cb_sat_besar, e)
    End Sub

    Private Sub cb_sat_besar_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_besar.KeyDown
        keyshortenter(in_isi_besar, e)
    End Sub

    Private Sub in_isi_besar_KeyDown(sender As Object, e As KeyEventArgs) Handles in_isi_besar.KeyDown
        keyshortenter(in_harga_beli, e)
    End Sub

    Private Sub cb_sat_kecil_Leave(sender As Object, e As EventArgs) Handles cb_sat_kecil.Leave, cb_sat_kecil.SelectionChangeCommitted
        lbl_satuan1.Text = cb_sat_kecil.Text
    End Sub

    Private Sub cb_sat_tengah_Leave(sender As Object, e As EventArgs) Handles cb_sat_tengah.Leave, cb_sat_tengah.SelectionChangeCommitted
        lbl_satuan2.Text = cb_sat_tengah.Text
    End Sub

    Private Sub in_harga_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyDown
        keyshortenter(in_harga_jual, e)
    End Sub

    Private Sub in_harga_jual_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_jual.KeyDown
        keyshortenter(in_harga_mt, e)
    End Sub

    Private Sub in_harga_mt_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_mt.KeyDown
        keyshortenter(in_harga_horeka, e)
    End Sub

    Private Sub in_harga_horeka_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_horeka.KeyDown
        keyshortenter(in_harga_rita, e)
    End Sub

    Private Sub in_harga_rita_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_rita.KeyDown
        keyshortenter(in_beli_d1, e)
    End Sub

    Private Sub in_beli_d1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_d1.KeyDown
        keyshortenter(in_beli_d2, e)
    End Sub

    Private Sub in_beli_d2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_d2.KeyDown
        keyshortenter(in_beli_d3, e)
    End Sub

    Private Sub in_beli_d3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_d3.KeyDown
        keyshortenter(in_beli_klaim, e)
    End Sub

    Private Sub in_beli_klaim_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_klaim.KeyDown
        keyshortenter(in_harga_disc, e)
    End Sub

    Private Sub in_harga_disc_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_disc.KeyDown
        keyshortenter(in_jual_d1, e)
    End Sub

    Private Sub in_jual_d1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d1.KeyDown
        keyshortenter(in_jual_d2, e)
    End Sub

    Private Sub in_jual_d2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d2.KeyDown
        keyshortenter(in_jual_d3, e)
    End Sub

    Private Sub in_jual_d3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d3.KeyDown
        keyshortenter(in_jual_d4, e)
    End Sub

    Private Sub in_jual_d4_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d4.KeyDown
        keyshortenter(in_jual_d5, e)
    End Sub

    Private Sub in_jual_d5_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d5.KeyDown
        keyshortenter(bt_simpanbarang, e)
    End Sub
End Class