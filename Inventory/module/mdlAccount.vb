Module mdlAccount
    Public Function creatGenLed(tipe As String, kode As String, tgl As Date) As Boolean
        Dim res As Boolean = False
        Dim qbeli As String = "SELECT CONCAT('BELI_',faktur_kode) as kode,'BELI' as jenis, faktur_kode as trans," _
                              & "faktur_tanggal_trans as tanggal, 'persediaan' as perkiraan, " _
                              & "if(faktur_ppn_jenis=1,faktur_jumlah-faktur_ppn,faktur_jumlah) as debet, 0 as kredit, 1 as j_index, " _
                              & "'beli' as ket  FROM data_pembelian_faktur " _
                              & "WHERE faktur_kode ='{0}' " _
                              & "UNION " _
                              & "SELECT CONCAT('BELI_',faktur_kode) as kode,'BELI' as jenis, faktur_kode as trans, " _
                              & "faktur_tanggal_trans as tanggal, 'ppn_masuk' as perkiraan, " _
                              & "faktur_ppn as debet, 0 as kredit, 2 as j_index, 'beli' as ket " _
                              & "FROM data_pembelian_faktur where faktur_ppn <> 0 " _
                              & "WHERE faktur_kode ='{0}' " _
                              & "UNION  " _
                              & "SELECT CONCAT('BELI_',faktur_kode) as kode,'BELI' as jenis, faktur_kode as trans, " _
                              & "faktur_tanggal_trans as tanggal, 'diskon_beli' as perkiraan, " _
                              & "0 as debet, faktur_disc as kredit, 3 as j_index, 'beli' as ket" _
                              & "FROM data_pembelian_faktur where faktur_disc <> 0 " _
                              & "WHERE faktur_kode ='{0}' " _
                              & "UNION " _
                              & "SELECT CONCAT('BELI_',faktur_kode) as kode,'BELI' as jenis, faktur_kode as trans, " _
                              & "faktur_tanggal_trans as tanggal, 'hutang' as perkiraan, " _
                              & "0 as debet, faktur_total as kredit, 4 as j_index, supplier_nama as ket " _
                              & "FROM data_pembelian_faktur " _
                              & "LEFT JOIN data_supplier_master ON supplier_kode = faktur_supplier " _
                              & "WHERE faktur_kode ='{0}' "


        Return res
    End Function
End Module
