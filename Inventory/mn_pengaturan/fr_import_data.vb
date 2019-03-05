Imports OfficeOpenXml
Public Class fr_import_data
    Private selectedimport As String = ""

    Private Sub addData(path As String, Optional hasheader As Boolean = True)
        Dim dt As New DataTable
        If cb_dataselect.SelectedValue = "trans_beli" Then
            hasheader = False
        End If
        dt = GetDataTablefromExcel(path, hasheader)

        If IsNothing(dt) = False Then
            If checkColumn(cb_dataselect.SelectedValue, dt) = True Then
                dgv_ckImport.DataSource = dt
            Else
                MessageBox.Show("Data tidak sesuai")
                dgv_ckImport.DataSource = Nothing
            End If
        End If

    End Sub

    Private Function importData(type As String) As Boolean
        Dim _retval As Boolean = False
        Dim q As String = ""
        Dim _colData As New List(Of String)
        Dim queryCk As Boolean = True
        Dim queryArr As New List(Of String)
        Dim _kditem As String = ""

        Select Case type
            Case "master_supplier"
                _colData.AddRange({"supplier_kode", "supplier_nama", "supplier_alamat", "supplier_telpon1", "supplier_telpon2", "supplier_fax", "supplier_cp",
                                   "supplier_email", "supplier_npwp", "supplier_rek_bg", "supplier_rek_bank", "supplier_term", "supplier_keterangan", "supplier_reg_date",
                                   "supplier_reg_alias"})
            Case "master_barang"
                _colData.AddRange({"barang_kode", "barang_nama", "barang_supplier", "barang_jenis", "barang_kategori", "barang_satuan_kecil", "barang_satuan_tengah",
                                   "barang_satuan_tengah_jumlah", "barang_satuan_besar", "barang_satuan_besar_jumlah", "barang_harga_beli", "barang_harga_beli_d1",
                                   "barang_harga_beli_d2", "barang_harga_beli_d3", "barang_harga_jual", "barang_harga_jual_mt", "barang_harga_jual_horeka",
                                   "barang_harga_jual_rita", "barang_harga_jual_d1", "barang_harga_jual_d2", "barang_harga_jual_d3", "barang_harga_jual_d4",
                                   "barang_harga_jual_d5", "barang_harga_jual_discount", "barang_pajak", "barang_reg_date", "barang_reg_alias"})
            Case "master_gudang"
                _colData.AddRange({"gudang_kode", "gudang_nama", "gudang_alamat", "gudang_ket", "gudang_reg_date", "gudang_reg_alias"})
            Case "master_sales"
                _colData.AddRange({"salesman_kode", "salesman_nama", "salesman_jenis", "salesman_alamat", "salesman_tanggal_masuk", "salesman_lahir_kota",
                                   "salesman_lahir_tanggal", "salesman_hp", "salesman_fax", "salesman_nik", "salesman_target", "salesman_bank_nama",
                                   "salesman_bank_rekening", "salesman_bank_atasnama", "salesman_reg_date", "salesman_reg_alias"})
            Case "master_customer"
                _colData.AddRange({"customer_kode", "customer_jenis", "customer_area", "customer_nama", "customer_alamat", "customer_alamat_blok",
                                   "customer_alamat_nomor", "customer_alamat_rt", "customer_alamat_rw", "customer_alamat_kelurahan", "customer_kecamatan",
                                   "customer_kabupaten", "customer_pasar", "customer_provinsi", "customer_kodepos", "customer_telpon", "customer_fax",
                                   "customer_cp", "customer_nik", "customer_npwp", "customer_tanggal_pkp", "customer_pajak_nama", "customer_pajak_jabatan",
                                   "customer_pajak_alamat", "customer_max_piutang", "customer_term", "customer_reg_date", "customer_reg_alias"})

            Case "trans_hutang"
                _colData.AddRange({"hutang_kode", "hutang_tgl", "hutang_tgl_jt", "hutang_supplier", "hutang_reg_date", "hutang_reg_alias"})
            Case Else
                Return False
                Exit Function
        End Select

        Dim _count As Integer = 0
        For Each row As DataGridViewRow In dgv_ckImport.Rows
            If row.Cells(0).Value = 1 Then
                Dim data, data2 As New List(Of String)
                For i = 1 To dgv_ckImport.Columns.Count - 1
                    Dim _val = row.Cells(i).Value
                    If type = "master_barang" And i = dgv_ckImport.Columns.Count - 1 Then _val = IIf(UCase(_val) = "PAJAK", 1, 0)
                    If type = "master_customer" And i = 2 Then _val = CInt(_val).ToString("D2")
                    data.Add("'" & mysqlQueryFriendlyStringFeed(IIf(IsDBNull(_val), "", _val)) & "'")
                    If type = "master_barang" And i = 3 Then
                        i += 1
                    ElseIf type = "trans_hutang" And i = 4 Then
                        Exit For
                    End If
                Next
                Select Case type
                    Case "master_supplier"
                        q = "INSERT INTO data_supplier_master({1}) VALUE({0},NOW(),'{2}')"
                        queryArr.Add(String.Format(q, String.Join(",", data), String.Join(",", _colData), loggeduser.user_id))

                    Case "master_barang"
                        q = "INSERT INTO data_barang_master({1}) VALUE({0},NOW(),'{2}')"
                        queryArr.Add(String.Format(q, String.Join(",", data), String.Join(",", _colData), loggeduser.user_id))

                        q = "INSERT INTO data_supplier_master SET supplier_kode='{0}', supplier_nama='{1}', supplier_reg_date=NOW(), supplier_reg_alias='{2}' " _
                             & "ON DUPLICATE KEY UPDATE supplier_kode=supplier_kode"
                        queryArr.Add(String.Format(q, row.Cells(3).Value, row.Cells(4).Value, loggeduser.user_id))

                        Dim _xdata() As String
                        Dim _xkode As String = row.Cells(1).Value
                        Dim _satkecil As String = row.Cells(7).Value
                        Dim _sattengah As String = row.Cells(8).Value
                        Dim _satbesar As String = row.Cells(10).Value
                        Dim _isitengah As Integer = row.Cells(9).Value
                        Dim _isibesar As Integer = row.Cells(11).Value
                        Dim _hargajual As Decimal = IIf(String.IsNullOrWhiteSpace(IIf(IsDBNull(row.Cells(16).Value), "", row.Cells(16).Value)), 0, row.Cells(16).Value)
                        Dim _hargajualmt As Decimal = IIf(String.IsNullOrWhiteSpace(IIf(IsDBNull(row.Cells(17).Value), "", row.Cells(17).Value)), 0, row.Cells(17).Value)
                        Dim _hargajualhoreka As Decimal = IIf(String.IsNullOrWhiteSpace(IIf(IsDBNull(row.Cells(18).Value), "", row.Cells(18).Value)), 0, row.Cells(18).Value)
                        Dim _hargajualritail As Decimal = IIf(String.IsNullOrWhiteSpace(IIf(IsDBNull(row.Cells(19).Value), "", row.Cells(19).Value)), 0, row.Cells(19).Value)
                        Dim _inputvalue(,) As String = {{"kecil", "1", _satkecil,
                                         _hargajual / (_isibesar * _isitengah),
                                         _hargajualmt / (_isibesar * _isitengah),
                                         _hargajualhoreka / (_isibesar * _isitengah),
                                         _hargajualritail / (_isibesar * _isitengah)
                                        },
                                        {
                                        "tengah", _isitengah, _sattengah,
                                         _hargajual / _isibesar,
                                         _hargajualmt / _isibesar,
                                         _hargajualhoreka / _isibesar,
                                         _hargajualritail / _isibesar
                                        },
                                        {
                                        "besar", _isibesar, _satbesar,
                                         _hargajual,
                                         _hargajualmt,
                                         _hargajualhoreka,
                                         _hargajualritail
                                        }
                                       }
                        For i = 0 To 2
                            q = "INSERT INTO data_barang_satuan SET b_satuan_barang='{0}',{1}"
                            _xdata = {
                                "b_satuan_jenis='" & _inputvalue(i, 0) & "'",
                                "b_satuan_isi='" & _inputvalue(i, 1) & "'",
                                "b_satuan_kodesatuan='" & _inputvalue(i, 2) & "'",
                                "b_satuan_hargajual='" & _inputvalue(i, 3).ToString.Replace(",", ".") & "'",
                                "b_satuan_hargajual_mt='" & _inputvalue(i, 4).ToString.Replace(",", ".") & "'",
                                "b_satuan_hargajual_horeka='" & _inputvalue(i, 5).ToString.Replace(",", ".") & "'",
                                "b_satuan_hargajual_rita='" & _inputvalue(i, 6).ToString.Replace(",", ".") & "'",
                                "b_satuan_status='1'",
                                "b_satuan_reg_date=NOW()",
                                "b_satuan_reg_alias='" & loggeduser.user_id & "'"
                                }
                            queryArr.Add(String.Format(q, _xkode, String.Join(",", _xdata)))

                            q = "INSERT INTO ref_satuan SET {0} ON DUPLICATE KEY UPDATE satuan_kode=satuan_kode"
                            _xdata = {
                                "satuan_kode='" & _inputvalue(i, 2) & "'",
                                "satuan_nama='" & _inputvalue(i, 2) & "'",
                                "satuan_keterangan='IMPORT DATA BARANG'",
                                "satuan_status=1",
                                "satuan_reg_date=NOW()",
                                "satuan_reg_alias='" & loggeduser.user_id & "'"
                                }
                            queryArr.Add(String.Format(q, String.Join(",", _xdata)))
                        Next


                    Case "master_gudang"
                        q = "INSERT INTO data_barang_gudang({1}) VALUE({0},NOW(),'{2}')"
                        queryArr.Add(String.Format(q, String.Join(",", data), String.Join(",", _colData), loggeduser.user_id))

                    Case "master_sales"
                        q = "INSERT INTO data_salesman_master({1}) VALUE({0},NOW(),'{2}')"
                        queryArr.Add(String.Format(q, String.Join(",", data), String.Join(",", _colData), loggeduser.user_id))

                    Case "master_customer"
                        q = "INSERT INTO data_customer_master({1}) VALUE({0},NOW(),'{2}')"
                        queryArr.Add(String.Format(q, String.Join(",", data), String.Join(",", _colData), loggeduser.user_id))

                        q = "UPDATE data_customer_master LEFT JOIN data_customer_jenis ON customer_jenis=jenis_kode " _
                            & "SET customer_kriteria_harga_jual=jenis_def_jual WHERE customer_kode='{0}'"
                        queryArr.Add(String.Format(q, row.Cells(1).Value))

                    Case "trans_hutang"
                        q = "INSERT INTO data_supplier_master SET supplier_kode='{0}', supplier_nama='{1}', supplier_reg_date=NOW(), supplier_reg_alias='{2}' " _
                            & "ON DUPLICATE KEY UPDATE supplier_kode=supplier_kode"
                        queryArr.Add(String.Format(q, row.Cells(4).Value, row.Cells(5).Value, loggeduser.user_id))

                        q = "INSERT INTO data_hutang_awal({1}) VALUE({0},NOW(),'{2}')"
                        queryArr.Add(String.Format(q, String.Join(",", data), String.Join(",", _colData), loggeduser.user_id))

                        q = "UPDATE data_hutang_trans SET h_trans_nilai={1} WHERE h_trans_jenis='sa' AND h_trans_kode_hutang='{0}' AND h_trans_status=1"
                        queryArr.Add(String.Format(q, row.Cells(1).Value, row.Cells(6).Value.ToString.Replace(",", ".")))

                        'data.Clear()
                        'data.AddRange({"'" & row.Cells(1).Value & "'", "''", "'" & row.Cells(4).Value & "'", "'SUPPLIER'",
                        '               "'" & IIf(CDate(row.Cells(2).Value) < currentperiode.tglawal, currentperiode.tglawal, CDate(row.Cells(2).Value)).ToString("yyyy-MM-dd") & "'",
                        '               "NOW()", "'" & loggeduser.user_id & "'"})
                        'q = "INSERT INTO data_jurnal_line(line_kode,line_type,line_ref,line_ref_type,line_tanggal,line_reg_date,line_reg_alias) VALUE({0})"

                End Select
            End If
        Next

        op_con()
        _retval = startTrans(queryArr)

        Return _retval
    End Function

    Private Function checkColumn(type As String, dt As DataTable) As Boolean
        Dim _columnCk As New List(Of String)

        Select Case type
            Case "master_supplier"
                _columnCk.AddRange({"KODE_SUPPLIER", "NAMA_SUPPLIER", "ALAMAT_SUPPLIER", "SUPPLIER_TELP1", "SUPPLIER_TELP2", "SUPPLIER_FAX", "CONTACT_PERSON",
                                     "SUPPLIER_EMAIL", "SUPPLIER_NPWP", "REK_BG", "REK_TF", "DEFAULT_TERM", "KETERANGAN"})
            Case "master_barang"
                _columnCk.AddRange({"KODE_ITEM", "NAMA_ITEM", "KODE_SUPPLIER", "NAMA_SUPPLIER", "KODE_JENIS", "KODE_KATEGORI", "SATUAN_KECIL", "SATUAN_TENGAH",
                                    "ISI_SATUAN_TENGAH", "SATUAN_BESAR", "ISI_SATUAN_BESAR", "HARGA_BELI", "HARGA_BELI_D1", "HARGA_BELI_D2", "HARGA_BELI_D3", "HARGA_JUAL",
                                    "HARGA_JUAL_MT", "HARGA_JUAL_HOREKA", "HARGA_JUAL_RITAIL", "HARGA_JUAL_D1", "HARGA_JUAL_D2", "HARGA_JUAL_D3", "HARGA_JUAL_D4",
                                    "HARGA_JUAL_D5", "HARGA_JUAL_DISCRP", "PAJAK"})
            Case "master_gudang"
                _columnCk.AddRange({"KODE_GUDANG", "NAMA_GUDANG", "ALAMAT_GUDANG", "KETERANGAN"})
            Case "master_sales"
                _columnCk.AddRange({"KODE_SALES", "NAMA_SALES", "KODE_JENIS", "ALAMAT_SALES", "TGL_MASUK", "LAHIR_KOTA", "LAHIR_TANGGAL", "NO_HP", "NO_FAX",
                                     "NIK", "JML_TARGET", "REK_BANK", "REK_NOMOR", "REK_ATASNAMA"})
            Case "master_customer"
                _columnCk.AddRange({"KODE_CUSTOMER", "KODE_JENIS", "KODE_AREA", "NAMA_CUSTOMER", "ALAMAT", "BLOK", "NOMOR", "RT", "RW", "KELURAHAN", "KECAMATAN",
                                     "KABUPATEN", "PASAR", "PROVINSI", "KODEPOS", "NO_TELP", "NO_FAX", "CONTACT_PERSON", "NIK", "NPWP", "TGL_PKP", "PAJAK_NAMA",
                                     "PAJAK_JABATAN", "PAJAK_ALAMAT", "MAX_PIUTANG", "DEFAULT_TERM"})
            Case "trans_beli_fk"
                _columnCk.AddRange({"FK", "NO_FAKTUR", "TGL_TRANSAKSI", "NO_FAKTUR_PAJAK", "TGL_PAJAK", "SURAT_JALAN", "KODE_SUPPLIER", "NAMA_SUPPLIER", "KODE_GUDANG",
                                     "NAMA_GUDANG", "JENIS_PPN", "TERM"})
            Case "trans_beli_il"
                _columnCk.AddRange({"IL", "NO_FAKTUR", "KODE_BARANG", "NAMA_BARANG", "HARGA_BELI", "QTY", "SATUAN", "JENIS_SATUAN", "DISC_RP", "DISC_1", "DISC_2",
                                      "DISC_3", "DISC_RP", "TOTAL"})
            Case "trans_hutang"
                _columnCk.AddRange({"KODE_HUTANG", "TGL_TRANSAKSI", "TGL_JATUHTEMPO", "KODE_SUPPLIER", "NAMA_SUPPLIER", "NILAI_HUTANG"})
            Case "trans_piutang"
                _columnCk.AddRange({"KODE_PIUTANG", "TGL_TRANSAKSI", "TGL_JATUHTEMPO", "KODE_CUSTOMER", "NAMA_CUSTOMER", "KODE_SALESMAN", "NAMA_SALESMAN", "NILAI_PIUTANG"})
            Case Else
                Return False
                Exit Function
        End Select

        If dt.Columns.Count <> _columnCk.Count Then
            Return False
            Exit Function
        End If

        For i = 0 To dt.Columns.Count - 1
            If dt.Columns(i).ColumnName.ToString <> _columnCk(i) Then
                Return False
                Exit Function
            End If
        Next

        Return True
    End Function

    Private Sub createTemplate(tipe As String, path As String)
        Dim _colheader, _colheader2 As New List(Of String)
        Select Case tipe
            Case "master_supplier"
                _colheader.AddRange({"KODE_SUPPLIER", "NAMA_SUPPLIER", "ALAMAT_SUPPLIER", "SUPPLIER_TELP1", "SUPPLIER_TELP2", "SUPPLIER_FAX", "CONTACT_PERSON",
                                     "SUPPLIER_EMAIL", "SUPPLIER_NPWP", "REK_BG", "REK_TF", "DEFAULT_TERM", "KETERANGAN"})
            Case "master_barang"
                _colheader.AddRange({"KODE_ITEM", "NAMA_ITEM", "KODE_SUPPLIER", "NAMA_SUPPLIER", "KODE_JENIS", "KODE_KATEGORI", "SATUAN_KECIL", "SATUAN_TENGAH",
                                    "ISI_SATUAN_TENGAH", "SATUAN_BESAR", "ISI_SATUAN_BESAR", "HARGA_BELI", "HARGA_BELI_D1", "HARGA_BELI_D2", "HARGA_BELI_D3", "HARGA_JUAL",
                                    "HARGA_JUAL_MT", "HARGA_JUAL_HOREKA", "HARGA_JUAL_RITAIL", "HARGA_JUAL_D1", "HARGA_JUAL_D2", "HARGA_JUAL_D3", "HARGA_JUAL_D4",
                                    "HARGA_JUAL_D5", "HARGA_JUAL_DISCRP", "PAJAK"})
            Case "master_gudang"
                _colheader.AddRange({"KODE_GUDANG", "NAMA_GUDANG", "ALAMAT_GUDANG", "KETERANGAN"})
            Case "master_sales"
                _colheader.AddRange({"KODE_SALES", "NAMA_SALES", "KODE_JENIS", "ALAMAT_SALES", "TGL_MASUK", "LAHIR_KOTA", "LAHIR_TANGGAL", "NO_HP", "NO_FAX",
                                     "NIK", "JML_TARGET", "REK_BANK", "REK_NOMOR", "REK_ATASNAMA"})
            Case "master_customer"
                _colheader.AddRange({"KODE_CUSTOMER", "KODE_JENIS", "KODE_AREA", "NAMA_CUSTOMER", "ALAMAT", "BLOK", "NOMOR", "RT", "RW", "KELURAHAN", "KECAMATAN",
                                     "KABUPATEN", "PASAR", "PROVINSI", "KODEPOS", "NO_TELP", "NO_FAX", "CONTACT_PERSON", "NIK", "NPWP", "TGL_PKP", "PAJAK_NAMA",
                                     "PAJAK_JABATAN", "PAJAK_ALAMAT", "MAX_PIUTANG", "DEFAULT_TERM"})
            Case "trans_beli"
                _colheader.AddRange({"FK", "NO_FAKTUR", "TGL_TRANSAKSI", "NO_FAKTUR_PAJAK", "TGL_PAJAK", "SURAT_JALAN", "KODE_SUPPLIER", "NAMA_SUPPLIER", "KODE_GUDANG",
                                     "NAMA_GUDANG", "JENIS_PPN", "TERM"})
                _colheader2.AddRange({"IL", "NO_FAKTUR", "KODE_BARANG", "NAMA_BARANG", "HARGA_BELI", "QTY", "SATUAN", "JENIS_SATUAN", "DISC_RP", "DISC_1", "DISC_2",
                                      "DISC_3", "DISC_RP", "TOTAL"})
            Case "trans_hutang"
                _colheader.AddRange({"KODE_HUTANG", "TGL_TRANSAKSI", "TGL_JATUHTEMPO", "KODE_SUPPLIER", "NAMA_SUPPLIER", "NILAI_HUTANG"})
            Case Else
                Exit Sub
        End Select

        Using xls As New ExcelPackage
            Dim wrksht As ExcelWorksheet = xls.Workbook.Worksheets.Add("ImportTemplate1")
            For i = 1 To _colheader.Count
                wrksht.Cells(1, i).Value = _colheader(i - 1)
            Next
            If _colheader2.Count > 0 Then
                For i = 1 To _colheader2.Count
                    wrksht.Cells(2, i).Value = _colheader2(i - 1)
                Next
            End If
            wrksht.Cells(1, 1, 1, _colheader.Count).AutoFitColumns()
            xls.SaveAs(New System.IO.FileInfo(Strings.Replace(path, ".xlsx", "") & ".xlsx"))
        End Using

    End Sub

    'DRAG FORM
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

    'CLOSE
    Private Sub fr_lap_filter_jual_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim _dialogres As Windows.Forms.DialogResult = MessageBox.Show("Tutup Form?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _dialogres = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_pesan_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            bt_cl.PerformClick()
        End If
    End Sub

    'LOAD
    Private Sub fr_lap_filter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_dataselect
            .DataSource = jenisImport()
            .ValueMember = "Value"
            .DisplayMember = "Text"
            selectedimport = .SelectedValue
        End With
    End Sub

    'BUTTON
    Private Sub bt_import_Click(sender As Object, e As EventArgs) Handles bt_openfile.Click
        Dim _opfiledialog As New OpenFileDialog
        _opfiledialog.Title = "Pilih file..."
        _opfiledialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        _opfiledialog.FilterIndex = 1
        If _opfiledialog.ShowDialog = DialogResult.OK Then
            If _opfiledialog.FileName <> Nothing Then
                addData(_opfiledialog.FileName)
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_import.Click
        Dim ckimport As Boolean = False
        Dim datatab As TabPage()
        Dim msg As String = "Import data {0}?"
        If cb_dataselect.SelectedValue = Nothing Then
            Exit Sub
        End If

        If dgv_ckImport.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk di import")
            Exit Sub
        End If

        Select Case cb_dataselect.SelectedValue
            Case "master_supplier"
                msg = String.Format(msg, "supplier")
                datatab = {pgsupplier}
            Case "master_barang"
                msg = String.Format(msg, "barang")
                datatab = {pgbarang, pgsupplier}
            Case "master_gudang"
                msg = String.Format(msg, "gudang")
                datatab = {pggudang}
            Case "master_sales"
                msg = String.Format(msg, "salesman")
                datatab = {pgsales}
            Case "master_customer"
                msg = String.Format(msg, "customer")
                datatab = {pgcusto}
            Case Else
                Exit Sub
        End Select


        If MessageBox.Show(msg, "Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ckimport = importData(cb_dataselect.SelectedValue)
            If ckimport = True Then
                MessageBox.Show("Import Success")
                doRefreshTab(datatab)
            Else
                MessageBox.Show("Import gagal")
            End If
        End If
    End Sub

    Private Sub lkLbl_template_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkLbl_template.LinkClicked
        Dim _svdialog As New SaveFileDialog
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Inventory\"
        Dim _filename As String = "templateimport{0}.xlsx"

        Select Case cb_dataselect.SelectedValue
            Case "master_supplier"
                _filename = String.Format(_filename, "supplier")
            Case "master_barang"
                _filename = String.Format(_filename, "barang")
            Case "master_gudang"
                _filename = String.Format(_filename, "gudang")
            Case "master_sales"
                _filename = String.Format(_filename, "sales")
            Case "master_customer"
                _filename = String.Format(_filename, "customer")
                'Case "trans_beli"
                '    _filename = String.Format(_filename, "beli")

            Case Else
                Exit Sub
        End Select

        _svdialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        _svdialog.FilterIndex = 1
        _svdialog.FileName = _svdialog.InitialDirectory & _filename
        _svdialog.RestoreDirectory = True
        If _svdialog.ShowDialog = DialogResult.OK Then
            If _svdialog.FileName <> Nothing Then
                createTemplate(cb_dataselect.SelectedValue, _svdialog.FileName)
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        If System.IO.File.Exists(_svdialog.FileName) = True Then
            MessageBox.Show("Template import data berhasil dibuat")
            Process.Start(_svdialog.FileName)
        Else
            MessageBox.Show("Pembuatan template import gagal")
        End If
    End Sub

    'DGV CHECKBOX
    Private Sub ck_faktur_all_CheckStateChanged(sender As Object, e As EventArgs) Handles ck_faktur_all.CheckedChanged
        If ck_faktur_all.CheckState = CheckState.Checked Then
            For Each rows As DataGridViewRow In dgv_ckImport.Rows
                rows.Cells(0).Value = 1
            Next
        ElseIf ck_faktur_all.CheckState = CheckState.Unchecked Then
            For Each rows As DataGridViewRow In dgv_ckImport.Rows
                rows.Cells(0).Value = 0
            Next
        End If
    End Sub

    Private Sub dgv_faktur_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ckImport.CellValueChanged
        If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
            Dim count As Integer = 0
            For Each rows As DataGridViewRow In dgv_ckImport.Rows
                If rows.Cells(0).Value = 1 Then
                    count += 1
                End If
            Next

            If count = 0 Then
                ck_faktur_all.CheckState = CheckState.Unchecked
            ElseIf count > 0 And dgv_ckImport.Rows.Count > count Then
                ck_faktur_all.CheckState = CheckState.Indeterminate
            ElseIf count > 0 And count = dgv_ckImport.Rows.Count Then
                ck_faktur_all.CheckState = CheckState.Checked
            End If
        End If
    End Sub

    Private Sub dgv_faktur_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_ckImport.CellMouseUp
        If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
            dgv_ckImport.EndEdit()
        End If
    End Sub

    'COMBOBOX
    Private Sub cb_dataselect_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_dataselect.SelectionChangeCommitted
        If dgv_ckImport.Rows.Count <> 0 And selectedimport <> cb_dataselect.SelectedValue Then
            If MessageBox.Show("Ubah import?", "Import Data", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                selectedimport = cb_dataselect.SelectedValue
                dgv_ckImport.DataSource = Nothing
            Else
                cb_dataselect.SelectedValue = selectedimport
            End If
        ElseIf dgv_ckImport.Rows.Count = 0 Then
            selectedimport = cb_dataselect.SelectedValue
        End If
    End Sub
End Class