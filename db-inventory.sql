# SQL Manager for MySQL 5.4.3.43929
# ---------------------------------------
# Host     : localhost
# Port     : 3306
# Database : db-inventory


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;

SET FOREIGN_KEY_CHECKS=0;

CREATE DATABASE `db-inventory`
    CHARACTER SET 'latin1'
    COLLATE 'latin1_swedish_ci';

USE `db-inventory`;

#
# Structure for the `data_aba_master` table : 
#

CREATE TABLE `data_aba_master` (
  `aba_kode` VARCHAR(4) COLLATE latin1_swedish_ci NOT NULL,
  `aba_nama` VARCHAR(30) COLLATE latin1_swedish_ci NOT NULL,
  `aba_kota` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL,
  `aba_rek` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `aba_rek_nama` VARCHAR(30) COLLATE latin1_swedish_ci NOT NULL,
  `aba_saldo_awal` DOUBLE(20,2) NOT NULL DEFAULT 0.00,
  `aba_status` CHAR(20) COLLATE latin1_swedish_ci NOT NULL DEFAULT '0',
  `aba_reg_date` DATETIME DEFAULT '0000-00-00 00:00:00',
  `aba_reg_alias` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `aba_upd_date` DATETIME DEFAULT '0000-00-00 00:00:00',
  `aba_upd_alias` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY USING BTREE (`aba_kode`) COMMENT ''
)ENGINE=MyISAM
CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_barang_foto` table : 
#

CREATE TABLE `data_barang_foto` (
  `foto_id` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `foto_file` LONGBLOB NOT NULL,
  PRIMARY KEY USING BTREE (`foto_id`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=5720 ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_barang_gudang` table : 
#

CREATE TABLE `data_barang_gudang` (
  `gudang_id` INTEGER(5) NOT NULL AUTO_INCREMENT,
  `gudang_kode` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `gudang_nama` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL,
  `gudang_alamat` VARCHAR(200) COLLATE latin1_swedish_ci NOT NULL,
  `gudang_status` VARCHAR(1) COLLATE latin1_swedish_ci NOT NULL COMMENT '1:Aktif 2:NonAktif 9:Delete',
  `gudang_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `gudang_reg_ip` VARCHAR(15) COLLATE latin1_swedish_ci NOT NULL,
  `gudang_reg_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `gudang_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `gudang_upd_ip` VARCHAR(15) COLLATE latin1_swedish_ci NOT NULL,
  `gudang_upd_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`gudang_id`) COMMENT '',
  UNIQUE INDEX `gudang_kode` USING BTREE (`gudang_kode`) COMMENT ''
)ENGINE=MyISAM
AUTO_INCREMENT=5 AVG_ROW_LENGTH=80 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_barang_jenis` table : 
#

CREATE TABLE `data_barang_jenis` (
  `jenis_kode` INTEGER(2) NOT NULL AUTO_INCREMENT,
  `jenis_nama` VARCHAR(5) COLLATE latin1_swedish_ci NOT NULL,
  `jenis_keterangan` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL,
  `jenis_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `jenis_reg_alias` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `jenis_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `jenis_upd_alias` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`jenis_kode`) COMMENT '',
  UNIQUE INDEX `jenis_nama` USING BTREE (`jenis_nama`) COMMENT ''
)ENGINE=MyISAM
AUTO_INCREMENT=4 AVG_ROW_LENGTH=37 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_barang_master` table : 
#

CREATE TABLE `data_barang_master` (
  `barang_id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `barang_kode` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `barang_nama` VARCHAR(200) COLLATE utf8_general_ci NOT NULL,
  `barang_supplier` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `barang_jenis` VARCHAR(5) COLLATE utf8_general_ci NOT NULL,
  `barang_satuan_kecil` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `barang_satuan_tengah` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `barang_satuan_tengah_jumlah` INTEGER(4) NOT NULL,
  `barang_satuan_besar` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `barang_satuan_besar_jumlah` INTEGER(4) NOT NULL,
  `barang_logo` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `barang_keterangan` TEXT COLLATE utf8_general_ci NOT NULL,
  `barang_harga_beli` DOUBLE(20,2) NOT NULL,
  `barang_harga_beli_d1` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `barang_harga_beli_d2` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `barang_harga_beli_d3` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `barang_harga_beli_klaim` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `barang_harga_jual` DOUBLE(20,2) NOT NULL,
  `barang_harga_jual_d1` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `barang_harga_jual_d2` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `barang_harga_jual_d3` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `barang_harga_jual_d4` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `barang_harga_jual_d5` DECIMAL(5,2) NOT NULL DEFAULT 0.00,
  `barang_harga_jual_mt` DOUBLE(20,2) NOT NULL,
  `barang_harga_jual_horeka` DOUBLE(20,2) NOT NULL,
  `barang_harga_jual_rita` DOUBLE(20,2) NOT NULL,
  `barang_harga_jual_discount` DOUBLE(20,2) NOT NULL,
  `barang_stok_awal` INTEGER(10) NOT NULL,
  `barang_stok_minimal` INTEGER(11) NOT NULL DEFAULT 0,
  `barang_berat` DECIMAL(10,2) NOT NULL,
  `barang_status` CHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT '1',
  `barang_status_pajak` CHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT '1',
  `barang_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `barang_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `barang_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `barang_upd_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`barang_id`) COMMENT '',
  UNIQUE INDEX `barang_kode` USING BTREE (`barang_kode`) COMMENT '',
   INDEX `data_barang_master_idx2` USING BTREE (`barang_supplier`) COMMENT '',
   INDEX `data_barang_master_idx3` USING BTREE (`barang_harga_beli`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=1573 AVG_ROW_LENGTH=188 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_barang_mutasi` table : 
#

CREATE TABLE `data_barang_mutasi` (
  `faktur_kode` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_tanggal` DATE NOT NULL,
  `faktur_gudang` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_ket` VARCHAR(200) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_reg_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_upd_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`faktur_kode`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=5461 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_barang_mutasi_trans` table : 
#

CREATE TABLE `data_barang_mutasi_trans` (
  `trans_id` INTEGER(30) NOT NULL AUTO_INCREMENT,
  `trans_faktur` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL,
  `trans_barang_asal` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_qty_asal` INTEGER(11) NOT NULL DEFAULT 0,
  `trans_sat_asal` VARCHAR(3) COLLATE latin1_swedish_ci NOT NULL,
  `trans_barang_tujuan` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_qty_tujuan` INTEGER(11) NOT NULL DEFAULT 0,
  `trans_sat_tujuan` VARCHAR(3) COLLATE latin1_swedish_ci NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=3 AVG_ROW_LENGTH=8192 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_barang_stok` table : 
#

CREATE TABLE `data_barang_stok` (
  `stock_kode` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `stock_gudang` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `stock_barang` VARCHAR(15) COLLATE latin1_swedish_ci NOT NULL,
  `stock_hpp` DOUBLE(20,2) NOT NULL DEFAULT 0.00,
  `stock_awal` INTEGER(11) NOT NULL DEFAULT 0,
  `stock_beli` INTEGER(11) NOT NULL DEFAULT 0,
  `stock_jual` INTEGER(11) NOT NULL DEFAULT 0,
  `stock_return_beli` INTEGER(11) NOT NULL DEFAULT 0,
  `stock_return_jual` INTEGER(11) NOT NULL DEFAULT 0,
  `stock_in` INTEGER(11) NOT NULL DEFAULT 0,
  `stock_out` INTEGER(11) NOT NULL DEFAULT 0,
  `stock_sisa` INTEGER(11) NOT NULL DEFAULT 0,
  `stock_fisik` INTEGER(11) NOT NULL DEFAULT 0,
  `stock_status` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `stock_reg_date` DATETIME NOT NULL,
  `stock_reg_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`stock_kode`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=19 AVG_ROW_LENGTH=2340 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_barang_stok_mutasi` table : 
#

CREATE TABLE `data_barang_stok_mutasi` (
  `faktur_kode` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_tanggal` DATE NOT NULL,
  `faktur_gudang_asal` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_gudang_tujuan` VARCHAR(11) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_reg_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_upd_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`faktur_kode`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=5461 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_barang_stok_mutasi_trans` table : 
#

CREATE TABLE `data_barang_stok_mutasi_trans` (
  `trans_id` INTEGER(30) NOT NULL AUTO_INCREMENT,
  `trans_faktur` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL,
  `trans_barang` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_qty_besar` INTEGER(11) NOT NULL DEFAULT 0,
  `trans_qty_tengah` INTEGER(11) NOT NULL DEFAULT 0,
  `trans_qty_kecil` INTEGER(11) NOT NULL DEFAULT 0,
  `trans_qty_tot` INTEGER(11) NOT NULL DEFAULT 0,
  `trans_satuan_besar` VARCHAR(3) COLLATE latin1_swedish_ci NOT NULL,
  `trans_satuan_tengah` VARCHAR(3) COLLATE latin1_swedish_ci NOT NULL,
  `trans_satuan_kecil` VARCHAR(3) COLLATE latin1_swedish_ci NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT '',
   INDEX `trans_faktur` USING BTREE (`trans_faktur`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=5 AVG_ROW_LENGTH=5461 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_barang_stok_opname` table : 
#

CREATE TABLE `data_barang_stok_opname` (
  `faktur_bukti` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_tanggal` DATE NOT NULL,
  `faktur_gudang` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_reg_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `faktur_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_upd_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`faktur_bukti`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=5461 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_barang_stok_opname_trans` table : 
#

CREATE TABLE `data_barang_stok_opname_trans` (
  `trans_id` INTEGER(30) NOT NULL AUTO_INCREMENT,
  `trans_faktur` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL,
  `trans_barang` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_qty_sys` INTEGER(11) NOT NULL DEFAULT 0,
  `trans_qty_fisik` INTEGER(11) NOT NULL DEFAULT 0,
  `trans_satuan` VARCHAR(3) COLLATE latin1_swedish_ci NOT NULL,
  `trans_keterangan` VARCHAR(200) COLLATE latin1_swedish_ci NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT '',
   INDEX `trans_faktur_new` USING BTREE (`trans_faktur`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=3 AVG_ROW_LENGTH=8192 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_customer_hargajual` table : 
#

CREATE TABLE `data_customer_hargajual` (
  `hargajual_kode` VARCHAR(2) COLLATE latin1_swedish_ci NOT NULL,
  `hargajual_nama` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `hargajual_keterangan` VARCHAR(100) COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY USING BTREE (`hargajual_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=20 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_customer_jenis` table : 
#

CREATE TABLE `data_customer_jenis` (
  `jenis_kode` VARCHAR(2) COLLATE latin1_swedish_ci NOT NULL,
  `jenis_nama` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `Jenis_keterangan` VARCHAR(100) COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY USING BTREE (`jenis_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=25 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_customer_master` table : 
#

CREATE TABLE `data_customer_master` (
  `customer_kode` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `Customer_jenis` VARCHAR(2) COLLATE latin1_swedish_ci NOT NULL,
  `Customer_salesman` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `customer_nama` VARCHAR(30) COLLATE latin1_swedish_ci NOT NULL,
  `customer_alamat` VARCHAR(300) COLLATE latin1_swedish_ci NOT NULL,
  `customer_alamat_blok` VARCHAR(4) COLLATE latin1_swedish_ci NOT NULL,
  `customer_alamat_nomor` VARCHAR(4) COLLATE latin1_swedish_ci NOT NULL,
  `customer_alamat_rt` VARCHAR(4) COLLATE latin1_swedish_ci NOT NULL,
  `customer_alamat_rw` VARCHAR(4) COLLATE latin1_swedish_ci NOT NULL,
  `customer_alamat_kelurahan` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_kecamatan` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_kabupaten` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_pasar` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_provinsi` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_kodepos` INTEGER(5) NOT NULL,
  `customer_telpon` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_fax` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_cp` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_nik` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_npwp` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL,
  `customer_tanggal_pkp` DATE NOT NULL DEFAULT '0000-00-00',
  `customer_pajak_nama` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL,
  `customer_pajak_jabatan` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL,
  `customer_pajak_alamat` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL,
  `customer_kunjungan_hari` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_max_piutang` DOUBLE(20,0) NOT NULL DEFAULT 0,
  `Customer_kriteria_discount` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `Customer_kriteria_harga_jual` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `customer_term` INTEGER(2) NOT NULL DEFAULT 0,
  `customer_foto` BLOB NOT NULL,
  `customer_status` CHAR(1) COLLATE latin1_swedish_ci NOT NULL DEFAULT '1',
  `customer_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `customer_reg_alias` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `customer_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `customer_upd_alias` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`customer_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=212 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_customer_pasar` table : 
#

CREATE TABLE `data_customer_pasar` (
  `pasar_kode` VARCHAR(5) COLLATE latin1_swedish_ci NOT NULL,
  `pasar_nama` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL,
  `pasar_alamat` TEXT COLLATE latin1_swedish_ci NOT NULL,
  `pasar_kota` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `pasar_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `pasar_reg_alias` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `pasar_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `pasar_upd_alias` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`pasar_kode`) COMMENT ''
)ENGINE=MyISAM
CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_giro_master` table : 
#

CREATE TABLE `data_giro_master` (
  `giro_id` INTEGER(4) NOT NULL AUTO_INCREMENT,
  `giro_tanggal` DATE NOT NULL DEFAULT '1999-12-31',
  `giro_salesman` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `giro_customer` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `giro_rekening` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `giro_bank` VARCHAR(4) COLLATE latin1_swedish_ci NOT NULL,
  `giro_jumlah` DOUBLE(20,2) NOT NULL,
  `giro_tanggal_bg` DATE NOT NULL,
  `giro_status` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `giro_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `giro_reg_alias` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `giro_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `giro_upd_alias` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`giro_id`) COMMENT ''
)ENGINE=MyISAM
AUTO_INCREMENT=2 AVG_ROW_LENGTH=96 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_giro_transaksi` table : 
#

CREATE TABLE `data_giro_transaksi` (
  `trans_id` VARCHAR(15) COLLATE latin1_swedish_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `trans_jenis` VARCHAR(2) COLLATE latin1_swedish_ci NOT NULL,
  `trans_rekening` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_ob_jenis` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `trans_ob_rekening` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_jumlah` DOUBLE(20,2) NOT NULL DEFAULT 0.00,
  `trans_uraian` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_alias` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT ''
)ENGINE=MyISAM
CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_karyawan_foto` table : 
#

CREATE TABLE `data_karyawan_foto` (
  `foto_id` VARCHAR(5) COLLATE utf8_general_ci NOT NULL,
  `foto_file` LONGBLOB NOT NULL,
  PRIMARY KEY USING BTREE (`foto_id`) COMMENT ''
)ENGINE=MyISAM
ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_karyawan_jabatan` table : 
#

CREATE TABLE `data_karyawan_jabatan` (
  `jabatan_kode` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `jabatan_nama` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `jabatan_keterangan` TEXT COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`jabatan_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=27 ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_karyawan_master` table : 
#

CREATE TABLE `data_karyawan_master` (
  `karyawan_kode` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `karyawan_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `karyawan_nik` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `karyawan_nama` VARCHAR(60) COLLATE utf8_general_ci NOT NULL,
  `karyawan_lahir_kota` VARCHAR(60) COLLATE utf8_general_ci NOT NULL,
  `karyawan_lahir_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `karyawan_kelamin` VARCHAR(1) COLLATE utf8_general_ci NOT NULL,
  `karyawan_alamat` VARCHAR(200) COLLATE utf8_general_ci NOT NULL,
  `karyawan_kota` VARCHAR(4) COLLATE utf8_general_ci NOT NULL,
  `karyawan_kodepos` VARCHAR(5) COLLATE utf8_general_ci NOT NULL,
  `karyawan_telpon1` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `karyawan_telpon2` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `karyawan_email` VARCHAR(60) COLLATE utf8_general_ci NOT NULL,
  `karyawan_lulusan` VARCHAR(60) COLLATE utf8_general_ci NOT NULL,
  `karyawan_keterangan` TEXT COLLATE utf8_general_ci NOT NULL,
  `karyawan_tanggal_masuk` DATE NOT NULL DEFAULT '0000-00-00',
  `karyawan_jabatan` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `karyawan_status` TINYINT(1) NOT NULL,
  `karyawan_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `karyawan_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `karyawan_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `karyawan_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `karyawan_upd_ip` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `karyawan_upd_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`karyawan_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=112 ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_kas_trans` table : 
#

CREATE TABLE `data_kas_trans` (
  `trans_id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `trans_kantor` VARCHAR(3) COLLATE latin1_swedish_ci NOT NULL,
  `trans_kode` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `trans_jenis` VARCHAR(2) COLLATE latin1_swedish_ci NOT NULL,
  `trans_debet` DOUBLE(20,0) NOT NULL,
  `trans_kredit` DOUBLE(20,0) NOT NULL,
  `trans_keterangan` VARCHAR(200) COLLATE latin1_swedish_ci NOT NULL,
  `trans_status` INTEGER(1) NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_ip` VARCHAR(15) COLLATE latin1_swedish_ci NOT NULL,
  `trans_reg_alias` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `trans_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_upd_ip` VARCHAR(50) COLLATE latin1_swedish_ci NOT NULL,
  `trans_upd_alias` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT '',
  UNIQUE INDEX `trans_kode` USING BTREE (`trans_kode`) COMMENT ''
)ENGINE=MyISAM
AUTO_INCREMENT=1 AVG_ROW_LENGTH=87 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_kategori` table : 
#

CREATE TABLE `data_kategori` (
  `kategori_kode` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `kategori_nama` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `kategori_keterangan` TEXT COLLATE utf8_general_ci NOT NULL,
  `kategori_status` TINYINT(1) NOT NULL,
  PRIMARY KEY USING BTREE (`kategori_kode`) COMMENT ''
)ENGINE=MyISAM
ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_komisi` table : 
#

CREATE TABLE `data_komisi` (
  `komisi_id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `komisi_tanggal` DATE NOT NULL,
  `komisi_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `komisi_jenis` INTEGER(2) NOT NULL,
  `komisi_hitung` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `komisi_jumlah` INTEGER(4) NOT NULL,
  `komisi_jumlah_rp` DOUBLE(20,0) NOT NULL,
  `komisi_hasil` DOUBLE(20,0) NOT NULL,
  `komisi_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `komisi_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `komisi_reg_alias` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`komisi_id`) COMMENT '',
   INDEX `komisi_jenis` USING BTREE (`komisi_jenis`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=1 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_komisi_rupiah` table : 
#

CREATE TABLE `data_komisi_rupiah` (
  `komisi_id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `komisi_tanggal` DATE NOT NULL,
  `komisi_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `komisi_jenis` INTEGER(2) NOT NULL,
  `komisi_hitung` DOUBLE(20,0) NOT NULL,
  `komisi_jumlah` INTEGER(4) NOT NULL,
  `komisi_jumlah_rp` DOUBLE(20,0) NOT NULL,
  `komisi_hasil` DOUBLE(20,0) NOT NULL,
  `komisi_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `komisi_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `komisi_reg_alias` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`komisi_id`) COMMENT '',
   INDEX `komisi_jenis` USING BTREE (`komisi_jenis`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=65253 AVG_ROW_LENGTH=142 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_menu_master` table : 
#

CREATE TABLE `data_menu_master` (
  `menu_id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `menu_kode` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `menu_parent` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `menu_label` VARCHAR(60) COLLATE utf8_general_ci NOT NULL,
  `menu_status` TINYINT(1) NOT NULL DEFAULT 1,
  PRIMARY KEY USING BTREE (`menu_id`) COMMENT '',
  UNIQUE INDEX `menu_kode` USING BTREE (`menu_kode`) COMMENT ''
)ENGINE=MyISAM
AUTO_INCREMENT=210 AVG_ROW_LENGTH=73 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_pelanggan_master` table : 
#

CREATE TABLE `data_pelanggan_master` (
  `pelanggan_kode` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_jenis` VARCHAR(2) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_nama` VARCHAR(100) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_alamat` VARCHAR(200) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_kota` VARCHAR(4) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_kodepos` VARCHAR(5) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_telpon1` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_telpon2` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_fax` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_email` VARCHAR(60) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_keterangan` TEXT COLLATE utf8_general_ci NOT NULL,
  `pelanggan_harga` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_hutang` DOUBLE(20,0) NOT NULL,
  `pelanggan_status` TINYINT(1) NOT NULL,
  `pelanggan_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `pelanggan_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `pelanggan_upd_ip` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_upd_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`pelanggan_kode`) COMMENT '',
   INDEX `pelanggan_jenis` USING BTREE (`pelanggan_jenis`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=16384 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_pelunasan_supplier_trans` table : 
#

CREATE TABLE `data_pelunasan_supplier_trans` (
  `trans_id` INTEGER(30) NOT NULL AUTO_INCREMENT,
  `trans_kode` CHAR(15) COLLATE utf8_general_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `trans_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `trans_supplier` CHAR(10) COLLATE utf8_general_ci NOT NULL,
  `trans_faktur` CHAR(20) COLLATE utf8_general_ci NOT NULL,
  `trans_tagihan` DOUBLE(20,0) NOT NULL,
  `trans_jumlah` DOUBLE(20,0) NOT NULL,
  `trans_sisa` DOUBLE(20,0) NOT NULL,
  `trans_keterangan` VARCHAR(200) COLLATE utf8_general_ci NOT NULL,
  `trans_status` TINYINT(1) NOT NULL DEFAULT 1,
  `trans_kasir_nama` CHAR(30) COLLATE utf8_general_ci NOT NULL,
  `trans_kasir_nomor` CHAR(2) COLLATE utf8_general_ci NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `trans_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT '',
   INDEX `data_pelunasan_trans_idx1_new` USING BTREE (`trans_kode`) COMMENT '',
   INDEX `data_pelunasan_trans_idx2_new` USING BTREE (`trans_supplier`) COMMENT '',
   INDEX `data_pelunasan_trans_idx3_new` USING BTREE (`trans_tanggal`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=1 AVG_ROW_LENGTH=381 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_pelunasan_trans` table : 
#

CREATE TABLE `data_pelunasan_trans` (
  `trans_id` INTEGER(30) NOT NULL AUTO_INCREMENT,
  `trans_kode` CHAR(15) COLLATE utf8_general_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `trans_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `trans_pelanggan` CHAR(10) COLLATE utf8_general_ci NOT NULL,
  `trans_tagihan` DOUBLE(20,0) NOT NULL,
  `trans_jumlah` DOUBLE(20,0) NOT NULL,
  `trans_status` TINYINT(1) NOT NULL DEFAULT 1,
  `trans_kasir_nama` CHAR(30) COLLATE utf8_general_ci NOT NULL,
  `trans_kasir_nomor` CHAR(2) COLLATE utf8_general_ci NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `trans_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT '',
   INDEX `data_pelunasan_trans_idx1` USING BTREE (`trans_kode`) COMMENT '',
   INDEX `data_pelunasan_trans_idx2` USING BTREE (`trans_pelanggan`) COMMENT '',
   INDEX `data_pelunasan_trans_idx3` USING BTREE (`trans_tanggal`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=1 AVG_ROW_LENGTH=381 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_pembelian_faktur` table : 
#

CREATE TABLE `data_pembelian_faktur` (
  `faktur_kode` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `faktur_tanggal_trans` DATE NOT NULL DEFAULT '0000-00-00',
  `faktur_pajak_no` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `faktur_pajak_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `faktur_surat_jalan` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `faktur_gudang` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_supplier` CHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_term` INTEGER(3) NOT NULL,
  `faktur_jumlah` DOUBLE(20,2) NOT NULL,
  `faktur_disc` DOUBLE(20,2) NOT NULL DEFAULT 0.00,
  `faktur_total` DOUBLE(20,2) NOT NULL,
  `faktur_ppn_persen` DECIMAL(5,2) NOT NULL,
  `faktur_ppn_jenis` VARCHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT '0',
  `faktur_netto` DOUBLE(20,0) NOT NULL,
  `faktur_klaim` DECIMAL(5,2) NOT NULL,
  `faktur_total_netto` DOUBLE(20,2) NOT NULL,
  `faktur_status` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `faktur_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_upd_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_upd_ket` VARCHAR(200) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`faktur_kode`) COMMENT '',
   INDEX `data_pembelian_faktur_idx1` USING BTREE (`faktur_tanggal_trans`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=381 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_pembelian_retur_faktur` table : 
#

CREATE TABLE `data_pembelian_retur_faktur` (
  `faktur_kode_bukti` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `faktur_tanggal_trans` DATE NOT NULL DEFAULT '0000-00-00',
  `faktur_kode_faktur` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `faktur_kode_exfaktur` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `faktur_pajak_no` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `faktur_pajak_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `faktur_surat_jalan` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `faktur_gudang` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_supplier` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_sebab` CHAR(4) COLLATE utf8_general_ci NOT NULL,
  `faktur_jumlah` DOUBLE(20,2) NOT NULL,
  `faktur_ppn_jenis` VARCHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT '1',
  `faktur_ppn_persen` DECIMAL(5,2) NOT NULL,
  `faktur_netto` DOUBLE(20,2) NOT NULL,
  `faktur_status` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `faktur_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`faktur_kode_bukti`) COMMENT '',
   INDEX `data_pembelian_faktur_idx1_new` USING BTREE (`faktur_tanggal_trans`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=381 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_pembelian_retur_trans` table : 
#

CREATE TABLE `data_pembelian_retur_trans` (
  `trans_id` INTEGER(30) NOT NULL AUTO_INCREMENT,
  `trans_faktur` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `trans_barang` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `trans_qty` INTEGER(5) NOT NULL,
  `trans_satuan` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `trans_harga_retur` DOUBLE(20,2) NOT NULL,
  `trans_jumlah` DOUBLE(20,2) NOT NULL,
  `trans_jenis` VARCHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT 'C',
  `trans_status` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT '',
   INDEX `trans_produk_new` USING BTREE (`trans_barang`) COMMENT '',
   INDEX `data_pembelian_trans_idx1_new` USING BTREE (`trans_faktur`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=8 AVG_ROW_LENGTH=16384 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_pembelian_trans` table : 
#

CREATE TABLE `data_pembelian_trans` (
  `trans_id` INTEGER(30) NOT NULL AUTO_INCREMENT,
  `trans_faktur` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `trans_barang` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `trans_harga_beli` DOUBLE(20,2) NOT NULL,
  `trans_ppn` DOUBLE(20,2) NOT NULL DEFAULT 0.00,
  `trans_qty` INTEGER(5) NOT NULL,
  `trans_satuan` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `trans_disc1` DECIMAL(5,2) NOT NULL,
  `trans_disc2` DECIMAL(5,2) NOT NULL,
  `trans_disc3` DECIMAL(5,2) NOT NULL,
  `trans_disc_rupiah` DOUBLE(20,2) NOT NULL,
  `trans_jumlah` DOUBLE(20,2) NOT NULL,
  `trans_jenis` VARCHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT 'C',
  `trans_status` TINYINT(1) NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT '',
   INDEX `trans_produk` USING BTREE (`trans_barang`) COMMENT '',
   INDEX `data_pembelian_trans_idx1` USING BTREE (`trans_faktur`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=58 AVG_ROW_LENGTH=381 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_pengguna_alias` table : 
#

CREATE TABLE `data_pengguna_alias` (
  `user_kode` INTEGER(4) NOT NULL AUTO_INCREMENT,
  `user_alias` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `user_group` VARCHAR(2) COLLATE utf8_general_ci NOT NULL,
  `user_pwd` VARCHAR(60) COLLATE utf8_general_ci NOT NULL,
  `user_nama` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `user_karyawan` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `user_login_status` VARCHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT '0',
  `user_login_terakhir` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `user_login_device` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `user_status` VARCHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT '0' COMMENT '0. baru\r\n1. aktif\r\n2. blokir\r\n3. expired\r\n9. delete',
  `user_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `user_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `user_reg_alias` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `user_upd_date` DATETIME NOT NULL,
  `user_upd_ip` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `user_upd_alias` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `user_exp_date` DATE NOT NULL DEFAULT '2099-12-31',
  PRIMARY KEY USING BTREE (`user_kode`) COMMENT '',
  UNIQUE INDEX `user_alias` USING BTREE (`user_alias`) COMMENT ''
)ENGINE=MyISAM
AUTO_INCREMENT=20 AVG_ROW_LENGTH=134 ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_pengguna_group` table : 
#

CREATE TABLE `data_pengguna_group` (
  `group_kode` VARCHAR(2) COLLATE utf8_general_ci NOT NULL,
  `group_nama` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `group_akses` VARCHAR(1) COLLATE utf8_general_ci NOT NULL,
  `group_menu` TEXT COLLATE utf8_general_ci NOT NULL,
  `group_keterangan` TEXT COLLATE utf8_general_ci NOT NULL,
  `group_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `group_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `group_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `group_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `group_upd_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `group_upd_alias` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`group_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=80 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_pengguna_komputer` table : 
#

CREATE TABLE `data_pengguna_komputer` (
  `komp_nama` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `komp_mac` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `komp_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `komp_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `komp_status` TINYINT(1) NOT NULL DEFAULT 0,
  `komp_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `komp_valid_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `komp_login_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `komp_login_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `komp_exp_date` DATE NOT NULL DEFAULT '2099-12-31',
  PRIMARY KEY USING BTREE (`komp_mac`) COMMENT ''
)ENGINE=MyISAM
CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_penjualan_faktur` table : 
#

CREATE TABLE `data_penjualan_faktur` (
  `faktur_kode` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `faktur_tanggal_trans` DATE NOT NULL DEFAULT '0000-00-00',
  `faktur_jenis_jual` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `faktur_pajak_no` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `faktur_pajak_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `faktur_surat_jalan` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `faktur_gudang` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_customer` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_sales` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_term` INTEGER(3) NOT NULL,
  `faktur_catatan` VARCHAR(200) COLLATE utf8_general_ci NOT NULL,
  `faktur_jumlah` DOUBLE(20,2) NOT NULL,
  `faktur_disc_persen` DECIMAL(5,2) NOT NULL,
  `faktur_disc_rupiah` DOUBLE(20,2) NOT NULL,
  `faktur_total` DOUBLE(20,2) NOT NULL,
  `faktur_ppn_persen` DECIMAL(5,2) NOT NULL,
  `faktur_ppn_jenis` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `faktur_netto` DOUBLE(20,2) NOT NULL,
  `faktur_klaim` DOUBLE(20,2) NOT NULL,
  `faktur_total_netto` DOUBLE(20,2) NOT NULL,
  `faktur_status` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `faktur_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_upd_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`faktur_kode`) COMMENT '',
   INDEX `data_pembelian_faktur_idx1` USING BTREE (`faktur_tanggal_trans`) COMMENT '',
   INDEX `data_penjualan_faktur_idx1` USING BTREE (`faktur_customer`) COMMENT '',
   INDEX `data_penjualan_faktur_idx2` USING BTREE (`faktur_pajak_tanggal`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=381 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_penjualan_retur_faktur` table : 
#

CREATE TABLE `data_penjualan_retur_faktur` (
  `faktur_kode_bukti` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `faktur_tanggal_trans` DATE NOT NULL DEFAULT '0000-00-00',
  `faktur_kode_faktur` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `faktur_kode_exfaktur` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `faktur_pajak_no` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `faktur_pajak_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `faktur_surat_jalan` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `faktur_gudang` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_sales` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_custo` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `faktur_sebab` CHAR(4) COLLATE utf8_general_ci NOT NULL,
  `faktur_jumlah` DOUBLE(20,2) NOT NULL,
  `faktur_ppn_jenis` VARCHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT '1',
  `faktur_ppn_persen` DECIMAL(5,2) NOT NULL,
  `faktur_netto` DOUBLE(20,2) NOT NULL,
  `faktur_status` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `faktur_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `faktur_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`faktur_kode_bukti`) COMMENT '',
   INDEX `data_pembelian_faktur_idx1_new_new` USING BTREE (`faktur_tanggal_trans`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=381 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_penjualan_retur_trans` table : 
#

CREATE TABLE `data_penjualan_retur_trans` (
  `trans_id` INTEGER(30) NOT NULL AUTO_INCREMENT,
  `trans_faktur` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `trans_barang` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `trans_qty` INTEGER(5) NOT NULL,
  `trans_satuan` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `trans_harga_retur` DOUBLE(20,2) NOT NULL,
  `trans_jumlah` DOUBLE(20,2) NOT NULL,
  `trans_jenis` VARCHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT 'C',
  `trans_status` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT '',
   INDEX `trans_produk_new_new` USING BTREE (`trans_barang`) COMMENT '',
   INDEX `data_pembelian_trans_idx1_new_new` USING BTREE (`trans_faktur`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=7 AVG_ROW_LENGTH=16384 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_penjualan_trans` table : 
#

CREATE TABLE `data_penjualan_trans` (
  `trans_id` INTEGER(30) NOT NULL AUTO_INCREMENT,
  `trans_faktur` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `trans_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `trans_barang` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `trans_harga_beli` DOUBLE(20,2) NOT NULL,
  `trans_harga_jual` DOUBLE(20,2) NOT NULL,
  `trans_qty` INTEGER(5) NOT NULL,
  `trans_satuan` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `trans_disc1` DECIMAL(5,2) NOT NULL,
  `trans_disc2` DECIMAL(5,2) NOT NULL,
  `trans_disc3` DECIMAL(5,2) NOT NULL,
  `trans_disc4` DECIMAL(5,2) NOT NULL,
  `trans_disc5` DECIMAL(5,2) NOT NULL,
  `trans_disc_rupiah` DOUBLE(20,2) NOT NULL,
  `trans_jumlah` DOUBLE(20,2) NOT NULL,
  `trans_status` CHAR(1) COLLATE utf8_general_ci NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_id`) COMMENT '',
   INDEX `trans_produk` USING BTREE (`trans_barang`) COMMENT '',
   INDEX `data_penjualan_trans_idx1` USING BTREE (`trans_faktur`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=5 AVG_ROW_LENGTH=381 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_rak_master` table : 
#

CREATE TABLE `data_rak_master` (
  `rak_kode` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `rak_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `rak_nama` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `rak_tempat` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `rak_keterangan` TEXT COLLATE utf8_general_ci NOT NULL,
  `rak_status` TINYINT(1) NOT NULL,
  `rak_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `rak_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `rak_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `rak_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `rak_upd_ip` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `rak_upd_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`rak_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=66 ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_salesman_master` table : 
#

CREATE TABLE `data_salesman_master` (
  `salesman_kode` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `salesman_nama` VARCHAR(50) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_alamat` VARCHAR(200) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_tanggal_masuk` DATE DEFAULT NULL,
  `salesman_jenis` VARCHAR(10) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_lahir_kota` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_lahir_tanggal` DATE DEFAULT NULL,
  `salesman_hp` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_fax` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_nik` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_target` DOUBLE(20,0) DEFAULT NULL,
  `salesman_bank_nama` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_bank_rekening` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_bank_atasnama` VARCHAR(30) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_foto` BLOB,
  `salesman_status` CHAR(1) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_reg_date` DATETIME DEFAULT NULL,
  `salesman_reg_alias` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  `salesman_upd_date` DATETIME DEFAULT NULL,
  `salesman_upd_alias` VARCHAR(20) COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY USING BTREE (`salesman_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=112 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `data_stok_opname` table : 
#

CREATE TABLE `data_stok_opname` (
  `opname_kode` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `opname_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `opname_barang` VARCHAR(60) COLLATE utf8_general_ci NOT NULL,
  `opname_stok_aktif` INTEGER(10) NOT NULL,
  `opname_stok_koreksi` INTEGER(11) NOT NULL,
  `opname_sebab` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `opname_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `opname_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `opname_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`opname_kode`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=819 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_stok_trans` table : 
#

CREATE TABLE `data_stok_trans` (
  `trans_kode` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `trans_jenis` VARCHAR(2) COLLATE utf8_general_ci NOT NULL,
  `trans_produk` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `trans_harga` DOUBLE(20,0) NOT NULL,
  `trans_volume` INTEGER(4) NOT NULL,
  `trans_status` TINYINT(1) NOT NULL,
  `trans_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `trans_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `trans_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `trans_upd_ip` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `trans_upd_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_kode`) COMMENT ''
)ENGINE=MyISAM
ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `data_supplier_master` table : 
#

CREATE TABLE `data_supplier_master` (
  `supplier_kode` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `supplier_nama` VARCHAR(100) COLLATE utf8_general_ci NOT NULL,
  `supplier_alamat` VARCHAR(200) COLLATE utf8_general_ci NOT NULL,
  `supplier_telpon1` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `supplier_telpon2` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `supplier_fax` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `supplier_cp` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `supplier_email` VARCHAR(60) COLLATE utf8_general_ci NOT NULL,
  `supplier_npwp` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `supplier_rek_bg` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `supplier_rek_bank` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `supplier_term` INTEGER(2) NOT NULL,
  `supplier_keterangan` TEXT COLLATE utf8_general_ci NOT NULL,
  `supplier_status` VARCHAR(1) COLLATE utf8_general_ci NOT NULL,
  `supplier_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `supplier_reg_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `supplier_reg_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `supplier_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `supplier_upd_ip` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `supplier_upd_alias` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`supplier_kode`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=5461 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `kode_cucian` table : 
#

CREATE TABLE `kode_cucian` (
  `cucian_case` INTEGER(2) NOT NULL,
  `cucian_text` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `cucian_rupiah` DOUBLE(20,0) NOT NULL,
  PRIMARY KEY USING BTREE (`cucian_case`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=2340 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `kode_komponen` table : 
#

CREATE TABLE `kode_komponen` (
  `combo_id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `combo_komponen` VARCHAR(2) COLLATE utf8_general_ci NOT NULL,
  `combo_kode` VARCHAR(4) COLLATE utf8_general_ci NOT NULL,
  `combo_text` VARCHAR(100) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`combo_id`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=1189 AVG_ROW_LENGTH=77 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `kode_laporan` table : 
#

CREATE TABLE `kode_laporan` (
  `laporan_id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `laporan_jenis` INTEGER(3) NOT NULL,
  `laporan_kode` CHAR(3) COLLATE utf8_general_ci NOT NULL,
  `laporan_nama` VARCHAR(100) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`laporan_id`) COMMENT ''
)ENGINE=InnoDB
AUTO_INCREMENT=21 AVG_ROW_LENGTH=77 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `kode_lisensi` table : 
#

CREATE TABLE `kode_lisensi` (
  `lisensi_id` INTEGER(5) NOT NULL AUTO_INCREMENT,
  `lisensi_mesin` VARCHAR(200) COLLATE utf8_general_ci NOT NULL,
  `lisensi_generate` VARCHAR(100) COLLATE utf8_general_ci NOT NULL,
  `lisensi_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `lisensi_status` TINYINT(1) NOT NULL DEFAULT 0,
  `lisensi_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `lisensi_reg_ip` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `lisensi_reg_alias` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `lisensi_reg_komp` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `lisensi_reg_mac` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `lisensi_reg_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `lisensi_reg_kali` INTEGER(3) NOT NULL DEFAULT 1,
  PRIMARY KEY USING BTREE (`lisensi_id`) COMMENT ''
)ENGINE=MyISAM
AUTO_INCREMENT=96 AVG_ROW_LENGTH=124 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `kode_menu` table : 
#

CREATE TABLE `kode_menu` (
  `menu_id` INTEGER(11) NOT NULL AUTO_INCREMENT,
  `menu_group` VARCHAR(2) COLLATE utf8_general_ci NOT NULL,
  `menu_kode` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `menu_parent` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `menu_label` VARCHAR(60) COLLATE utf8_general_ci NOT NULL,
  `menu_set` TINYINT(1) NOT NULL DEFAULT 0,
  `menu_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `menu_reg_ip` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `menu_reg_alias` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`menu_id`) COMMENT ''
)ENGINE=MyISAM
AUTO_INCREMENT=6023 AVG_ROW_LENGTH=80 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `kode_transaksi` table : 
#

CREATE TABLE `kode_transaksi` (
  `trans_kode` VARCHAR(5) COLLATE utf8_general_ci NOT NULL,
  `trans_jenis` TINYINT(1) NOT NULL,
  `trans_subjenis` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `trans_nama` VARCHAR(40) COLLATE utf8_general_ci NOT NULL,
  `trans_debet` TINYINT(1) NOT NULL DEFAULT 0,
  `trans_kredit` TINYINT(1) NOT NULL DEFAULT 0,
  `trans_ob` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `trans_closing` TINYINT(1) NOT NULL DEFAULT 0,
  `trans_preview` TINYINT(1) NOT NULL DEFAULT 0,
  `trans_kode_ob` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`trans_kode`) COMMENT ''
)ENGINE=MyISAM
CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `log_aktivitas` table : 
#

CREATE TABLE `log_aktivitas` (
  `aktivitas_id` INTEGER(20) NOT NULL AUTO_INCREMENT,
  `aktivitas_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `aktivitas_jam` TIME NOT NULL DEFAULT '00:00:00',
  `aktivitas_user` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `aktivitas_kantor` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `aktivitas_ip` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `aktivitas_mac` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `aktivitas_komputer` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `aktivitas_versi` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `aktivitas_log` VARCHAR(300) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`aktivitas_id`) COMMENT ''
)ENGINE=MyISAM
AUTO_INCREMENT=34442 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `log_login` table : 
#

CREATE TABLE `log_login` (
  `log_reg` DATE NOT NULL,
  `log_user` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_nama` VARCHAR(40) COLLATE utf8_general_ci NOT NULL,
  `log_tanggal` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `log_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `log_komputer` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_mac` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_versi` VARCHAR(20) COLLATE utf8_general_ci NOT NULL
)ENGINE=InnoDB
AVG_ROW_LENGTH=150 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `log_stock` table : 
#

CREATE TABLE `log_stock` (
  `log_reg` DATE NOT NULL,
  `log_user` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_barang` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_gudang` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_nama` VARCHAR(40) COLLATE utf8_general_ci NOT NULL,
  `log_tanggal` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `log_ip` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `log_komputer` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_mac` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_ket` VARCHAR(40) COLLATE utf8_general_ci NOT NULL
)ENGINE=InnoDB
AVG_ROW_LENGTH=150 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `log_update` table : 
#

CREATE TABLE `log_update` (
  `log_alias` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_kantor` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `log_nama` VARCHAR(40) COLLATE utf8_general_ci NOT NULL,
  `log_tanggal` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `log_ipaddress` VARCHAR(15) COLLATE utf8_general_ci NOT NULL,
  `log_hostname` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_macaddress` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `log_version` VARCHAR(20) COLLATE utf8_general_ci NOT NULL
)ENGINE=InnoDB
CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `ref_bank` table : 
#

CREATE TABLE `ref_bank` (
  `Bank_kode` VARCHAR(4) COLLATE latin1_swedish_ci NOT NULL,
  `Bank_nama` VARCHAR(30) COLLATE latin1_swedish_ci DEFAULT NULL,
  PRIMARY KEY USING BTREE (`Bank_kode`) COMMENT ''
)ENGINE=MyISAM
CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `ref_kategori` table : 
#

CREATE TABLE `ref_kategori` (
  `kategori_kode` VARCHAR(5) COLLATE utf8_general_ci NOT NULL,
  `kategori_nama` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `kategori_keterangan` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`kategori_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=49 ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `ref_kategori_sub` table : 
#

CREATE TABLE `ref_kategori_sub` (
  `sub_kode` VARCHAR(5) COLLATE utf8_general_ci NOT NULL,
  `sub_kategori` VARCHAR(5) COLLATE utf8_general_ci NOT NULL,
  `sub_nama` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`sub_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=25 ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `ref_logo` table : 
#

CREATE TABLE `ref_logo` (
  `logo_kode` VARCHAR(3) COLLATE latin1_swedish_ci DEFAULT NULL,
  `logo_nama` VARCHAR(50) COLLATE latin1_swedish_ci DEFAULT NULL
)ENGINE=MyISAM
AVG_ROW_LENGTH=31 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `ref_pelanggan` table : 
#

CREATE TABLE `ref_pelanggan` (
  `pelanggan_kode` VARCHAR(5) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_nama` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `pelanggan_keterangan` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`pelanggan_kode`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=5461 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `ref_penyesuaian` table : 
#

CREATE TABLE `ref_penyesuaian` (
  `penyesuaian_kode` VARCHAR(5) COLLATE utf8_general_ci NOT NULL,
  `penyesuaian_nama` VARCHAR(30) COLLATE utf8_general_ci NOT NULL,
  `penyesuaian_keterangan` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`penyesuaian_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=48 ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `ref_satuan` table : 
#

CREATE TABLE `ref_satuan` (
  `satuan_kode` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `satuan_nama` VARCHAR(10) COLLATE utf8_general_ci NOT NULL,
  `satuan_keterangan` VARCHAR(100) COLLATE utf8_general_ci NOT NULL,
  `satuan_reg_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `satuan_reg_alias` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `satuan_upd_date` DATETIME NOT NULL DEFAULT '0000-00-00 00:00:00',
  `satuan_upd_alias` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY USING BTREE (`satuan_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=20 ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `set_app` table : 
#

CREATE TABLE `set_app` (
  `app_case` VARCHAR(50) COLLATE latin1_swedish_ci DEFAULT NULL,
  `app_text` TEXT COLLATE latin1_swedish_ci
)ENGINE=MyISAM
AVG_ROW_LENGTH=31 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `set_cetakan` table : 
#

CREATE TABLE `set_cetakan` (
  `cetakan_case` VARCHAR(50) COLLATE latin1_swedish_ci DEFAULT NULL,
  `cetakan_text` TEXT COLLATE latin1_swedish_ci
)ENGINE=MyISAM
AVG_ROW_LENGTH=26 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `set_warna` table : 
#

CREATE TABLE `set_warna` (
  `warna_case` VARCHAR(50) COLLATE utf8_general_ci DEFAULT NULL,
  `warna_text` VARCHAR(50) COLLATE latin7_general_ci NOT NULL
)ENGINE=MyISAM
AVG_ROW_LENGTH=41 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `setup_migrasi` table : 
#

CREATE TABLE `setup_migrasi` (
  `perk_kode` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `perk_parent` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `perk_nama` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL,
  `perk_jenis` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `perk_jurnal` CHAR(1) COLLATE latin1_swedish_ci NOT NULL DEFAULT '0',
  `perk_d_or_k` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `perk_saldo` DECIMAL(20,2) NOT NULL DEFAULT 0.00,
  `perk_keterangan` VARCHAR(200) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`perk_kode`) COMMENT '',
  UNIQUE INDEX `perk_kode_new` USING BTREE (`perk_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=26 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `setup_perkiraan` table : 
#

CREATE TABLE `setup_perkiraan` (
  `perk_kode` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `perk_parent` VARCHAR(20) COLLATE latin1_swedish_ci NOT NULL,
  `perk_nama` VARCHAR(100) COLLATE latin1_swedish_ci NOT NULL,
  `perk_jenis` VARCHAR(10) COLLATE latin1_swedish_ci NOT NULL,
  `perk_jurnal` CHAR(1) COLLATE latin1_swedish_ci NOT NULL DEFAULT '0',
  `perk_d_or_k` CHAR(1) COLLATE latin1_swedish_ci NOT NULL,
  `perk_keterangan` VARCHAR(200) COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY USING BTREE (`perk_kode`) COMMENT '',
  UNIQUE INDEX `perk_kode` USING BTREE (`perk_kode`) COMMENT ''
)ENGINE=MyISAM
AVG_ROW_LENGTH=26 CHARACTER SET 'latin1' COLLATE 'latin1_swedish_ci'
COMMENT=''
;

#
# Structure for the `temp_penjualan_laba` table : 
#

CREATE TABLE `temp_penjualan_laba` (
  `laba_tanggal` DATE NOT NULL DEFAULT '0000-00-00',
  `laba_kantor` VARCHAR(3) COLLATE utf8_general_ci NOT NULL,
  `laba_kode` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `laba_nama` VARCHAR(50) COLLATE utf8_general_ci NOT NULL,
  `laba_harga_pokok` DOUBLE(20,0) NOT NULL,
  `laba_harga_jual` DOUBLE(20,0) NOT NULL,
  `laba_volume` INTEGER(4) NOT NULL,
  `laba_discount` DOUBLE(20,0) NOT NULL,
  `laba_total_jual` DOUBLE(20,0) NOT NULL,
  `laba_total_pokok` DOUBLE(20,0) NOT NULL,
  `laba_akhir` DOUBLE(20,0) NOT NULL
)ENGINE=MyISAM
AVG_ROW_LENGTH=88 ROW_FORMAT=COMPACT CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Structure for the `x_menu` table : 
#

CREATE TABLE `x_menu` (
  `menu_kode` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `menu_parent` VARCHAR(20) COLLATE utf8_general_ci NOT NULL,
  `menu_label` VARCHAR(255) COLLATE utf8_general_ci NOT NULL,
  `menu_status` CHAR(1) COLLATE utf8_general_ci NOT NULL DEFAULT '1',
  PRIMARY KEY USING BTREE (`menu_kode`) COMMENT ''
)ENGINE=InnoDB
AVG_ROW_LENGTH=81 CHARACTER SET 'utf8' COLLATE 'utf8_general_ci'
COMMENT=''
;

#
# Definition for the `countQTYBesarToKecil` function : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' FUNCTION `countQTYBesarToKecil`(
        `kode` VARCHAR(20),
        `qty` INTEGER(11)
    )
    RETURNS INTEGER(11)
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	DECLARE _qtyout INTEGER(11);
    DECLARE isibesar INTEGER(10);
    DECLARE isitengah INTEGER(10);
    
    SELECT barang_satuan_besar_jumlah, barang_satuan_tengah_jumlah
    INTO isibesar, isitengah
    FROM data_barang_master WHERE barang_kode=kode;
    
    SET _qtyout = qty * isibesar * isitengah;
    
  	RETURN _qtyout;
END$$

DELIMITER ;

#
# Definition for the `countQTYJual` function : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' FUNCTION `countQTYJual`(
        `barang` VARCHAR(20),
        `qty` INTEGER(11),
        `satuan` VARCHAR(10)
    )
    RETURNS INTEGER(11)
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	DECLARE _qtyreturn INTEGER(11);
    DECLARE _isitengah INTEGER(11);
    DECLARE _isibesar INTEGER(11);
    DECLARE besar VARCHAR(10);
    DECLARE tengah VARCHAR(10);
    DECLARE kecil VARCHAR(10);
    
    SELECT barang_satuan_besar_jumlah, barang_satuan_tengah_jumlah
    INTO _isibesar, _isitengah
    FROM data_barang_master WHERE barang_kode=barang;
    
    SELECT (CASE
    	WHEN satuan = barang_satuan_besar THEN
        	qty * _isibesar * _isitengah
        WHEN satuan = barang_satuan_tengah THEN
        	qty * _isitengah
        WHEN satuan = barang_satuan_kecil THEN
        	qty
        ELSE
        	NULL
	END)AS hitung INTO _qtyreturn
    FROM data_barang_master WHERE barang_kode=barang;
    
  RETURN IFNULL(_qtyreturn,0);
END$$

DELIMITER ;

#
# Definition for the `countQTYSisaSTock` function : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' FUNCTION `countQTYSisaSTock`(
        `barang` VARCHAR(20),
        `gudang` VARCHAR(20)
    )
    RETURNS INTEGER(11)
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	DECLARE _returnSisa INTEGER(11);
    
    SELECT (stock_awal+stock_beli-stock_jual-stock_return_beli+stock_return_jual+stock_in-stock_out) as sisa
    INTO _returnSisa
    FROM data_barang_stok
    WHERE stock_barang=barang AND stock_gudang=gudang;
    
  RETURN _returnSisa;
END$$

DELIMITER ;

#
# Definition for the `getMenuJumlah` function : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' FUNCTION `getMenuJumlah`(
        `kode` VARCHAR(2)
    )
    RETURNS INTEGER(4)
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	DECLARE _jml INTEGER(4);
    
    SELECT COUNT(menu_group) into _jml FROM kode_menu
    WHERE menu_group = kode;
    
  	RETURN _jml;
END$$

DELIMITER ;

#
# Definition for the `getSUMBeliPergudang` function : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' FUNCTION `getSUMBeliPergudang`(
        `barang` VARCHAR(20),
        `gudang` VARCHAR(20)
    )
    RETURNS INTEGER(11)
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	DECLARE _qtybeli INTEGER(11);
    
    SELECT SUM(trans_qty) INTO _qtybeli FROM data_pembelian_trans a
    INNER JOIN `data_pembelian_faktur` b ON b.faktur_kode=a.trans_faktur
    WHERE a.`trans_barang`=barang AND b.faktur_gudang=gudang;
    
    SET _qtybeli = countQTYBesarToKecil(barang,_qtybeli);
    
  	RETURN IFNULL(_qtybeli,0);
END$$

DELIMITER ;

#
# Definition for the `getSUMJualPergudang` function : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' FUNCTION `getSUMJualPergudang`(
        `barang` VARCHAR(20),
        `gudang` VARCHAR(20)
    )
    RETURNS INTEGER(11)
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	DECLARE _qtyjual INTEGER(11);
    
    SELECT SUM(countQTYJual(trans_barang,trans_qty,trans_satuan))
    INTO _qtyjual
    FROM data_penjualan_trans a
	INNER JOIN `data_penjualan_faktur` b ON b.faktur_kode=a.trans_faktur
	WHERE a.`trans_barang`=barang AND b.faktur_gudang=gudang;
    -- kurang per periode
    
  	RETURN IFNULL(_qtyjual,0);
END$$

DELIMITER ;

#
# Definition for the `getSUMReturBeliPergudang` function : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' FUNCTION `getSUMReturBeliPergudang`(
        `barang` VARCHAR(20),
        `gudang` VARCHAR(20)
    )
    RETURNS INTEGER(11)
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	DECLARE _qtyreturn INTEGER(11);
    
    SELECT SUM(countQTYJual(trans_barang,trans_qty,trans_satuan))
    INTO _qtyreturn
    FROM data_pembelian_retur_trans a
    INNER JOIN data_pembelian_retur_faktur b ON b.`faktur_kode_bukti`=a.trans_faktur
    WHERE a.trans_barang=barang AND b.faktur_gudang=gudang;
    
  RETURN _qtyreturn;
END$$

DELIMITER ;

#
# Definition for the `ClearTransaksiAll` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `ClearTransaksiAll`()
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN

 TRUNCATE data_pembelian_trans;
 TRUNCATE data_pembelian_faktur;
 TRUNCATE data_pembelian_retur_trans;
 TRUNCATE data_pembelian_retur_faktur;
 
 TRUNCATE data_penjualan_trans;
 TRUNCATE data_penjualan_faktur;
 TRUNCATE data_penjualan_retur_trans;
 TRUNCATE data_penjualan_retur_faktur;
 
 TRUNCATE data_pelunasan_trans;
 TRUNCATE data_pelunasan_supplier_trans;
 TRUNCATE data_kas_trans;
 
 TRUNCATE data_stok_trans;
 TRUNCATE data_supplier_master;
 TRUNCATE data_stok_opname;
 
END$$

DELIMITER ;

#
# Definition for the `CreateMenu` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `CreateMenu`(
        IN `KodeGroup` CHAR(2)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN

 delete from kode_menu where menu_group = KodeGroup;

 insert into kode_menu
 select '', KodeGroup, menu_kode, menu_parent, 
 menu_label, 1, now(), '127.0.0.1', 'system'
 from data_menu_master;
 
 COMMIT;

END$$

DELIMITER ;

#
# Definition for the `DoMenuSinkron` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `DoMenuSinkron`()
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN

 UPDATE kode_menu as a, data_menu_master as b
 SET a.menu_label = CONCAT(SUBSTRING(b.menu_kode, 3, 20), '. ', b.menu_label)
 WHERE a.menu_kode = b.menu_kode;
 
END$$

DELIMITER ;

#
# Definition for the `getDataMaster` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `getDataMaster`(
        IN `tipe` VARCHAR(20)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	CASE
    WHEN tipe = 'barang' THEN
		SELECT 
        	barang_kode as kode,
            barang_nama as nama,
            barang_supplier as kodesupplier,
    		jenis_nama as jenis, 
            barang_satuan_kecil as satuankecil, 
            barang_satuan_tengah as satuantengah,
    		barang_satuan_tengah_jumlah as satuantengahisi, 
            barang_satuan_besar as satuanbesar,
    		barang_satuan_besar_jumlah as satuanbesarisi, 
            barang_harga_beli as hargabeli,
        	barang_harga_jual as hargajual, 
            barang_status_pajak as jenispajak
    	FROM `data_barang_master`
    	left join data_barang_jenis on jenis_kode=barang_jenis
    	order by barang_kode;
    WHEN tipe = 'gudang' THEN
    	SELECT
        	gudang_kode as kode,
            gudang_nama as nama,
            gudang_alamat as alamat,
        	gudang_status as `status`
    	FROM `data_barang_gudang`;
    WHEN tipe = 'supplier' THEN
    	SELECT
        	supplier_kode as kode,
            supplier_nama as nama,
    		supplier_alamat as alamat,
            supplier_telpon1 as telp,
            supplier_fax as fax,
    		supplier_cp as cp,
            supplier_npwp as npwp,
            supplier_term as term
    	FROM data_supplier_master;
    WHEN tipe = 'sales' THEN
    	SELECT
        	salesman_kode as kode,
            salesman_nama as nama,
            salesman_alamat as alamat,
    		salesman_hp as telp,
            salesman_target as target,
            salesman_tanggal_masuk as tglmasuk,
        	salesman_status as status
    	FROM data_salesman_master;
    WHEN tipe = 'custo' THEN
    	SELECT 
            customer_kode as kode,
            customer_nama as nama,
            customer_jenis as tipe,
            customer_status as status,
            customer_alamat as alamat,
            customer_kecamatan as kec,
            customer_kabupaten as kab,
            customer_pasar as pasar,
            customer_telpon as telp,
            customer_fax as fax,
            customer_term as term,
            customer_npwp as npwp,
            customer_nik as nik
 		FROM `data_customer_master`;
    WHEN tipe = 'giro' THEN
    	SELECT
        	giro_id as kode,
            giro_tanggal as tgl,
            salesman_nama as sales,
            customer_nama as custo,
    		giro_rekening as nobg,
            giro_bank as bank,
            giro_jumlah as jml,
            giro_tanggal_bg as tglbg
    	FROM data_giro_master
    	inner join data_salesman_master on salesman_kode=giro_salesman
    	INNER JOIN `data_customer_master` on customer_kode=giro_customer;
    WHEN tipe = 'perkiraan' THEN
    	SELECT
        	perk_kode as kode,
            perk_parent as parent,
            perk_nama as nama,
    		perk_d_or_k as posisi,
            perk_keterangan as ket
    	FROM `setup_perkiraan`;
    WHEN tipe = 'neracaawal' THEN
    	SELECT
        	perk_kode as kode,
            perk_parent as parent,
            perk_nama as nama,
    		perk_d_or_k as posisi,
            perk_saldo as saldo,
            perk_keterangan as ket
    	FROM `setup_migrasi`;
    WHEN tipe = 'user' THEN
    	SELECT
        	user_kode as kode,
            user_alias as userid,
            user_nama as nama,
            user_group as groupkode,
            group_nama as groupnama,
            user_status as status,
            user_login_status as loginstat
    	FROM data_pengguna_alias
        LEFT JOIN data_pengguna_group ON group_kode=user_group;
    WHEN tipe = 'group' THEN
    	SELECT
        	group_kode as kode,
            group_nama as nama,
    		group_keterangan as ket,
            getMenuJumlah(group_kode) as jml
    	FROM data_pengguna_group;
    END CASE;
END$$

DELIMITER ;

#
# Definition for the `getJenisBarang` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `getJenisBarang`()
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	SELECT jenis_kode AS kode, jenis_nama AS nama, jenis_keterangan AS ket
    FROM data_barang_jenis;
END$$

DELIMITER ;

#
# Definition for the `getMutasi` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `getMutasi`(
        IN `tipe` VARCHAR(10)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	CASE
    WHEN tipe = 'gudang' THEN
		SELECT faktur_kode as kode, faktur_tanggal as tanggal, a.gudang_nama gudang,
    	b.gudang_nama as gudang2, faktur_reg_alias as regby
		FROM data_barang_stok_mutasi
		INNER JOIN data_barang_gudang a ON a.gudang_kode=faktur_gudang_asal
		INNER JOIN data_barang_gudang b ON b.gudang_kode=faktur_gudang_tujuan;
    WHEN tipe = 'barang' THEN
    	SELECT faktur_kode as kode, faktur_tanggal as tanggal, a.gudang_nama gudang,
    	faktur_reg_alias as regby
		FROM data_barang_mutasi
		INNER JOIN data_barang_gudang a ON a.gudang_kode=faktur_gudang;
    END CASE;
    
END$$

DELIMITER ;

#
# Definition for the `GetPenjualanTerlaris` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `GetPenjualanTerlaris`(
        IN `TglAwal` DATE,
        IN `TglAkhir` DATE,
        IN `vKantor` VARCHAR(3)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN

 select trans_kantor, count(*) as Jumlah, trans_produk,
 GetProdukNama(trans_produk) as Nama
 from data_penjualan_trans
 where trans_status = 1 AND (trans_tanggal BETWEEN TglAwal AND TglAkhir)
 AND trans_kantor = vKantor
 group by trans_produk
 having (count(trans_produk) > 1)
 order by count(*) DESC;

END$$

DELIMITER ;

#
# Definition for the `getStok` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `getStok`(
        IN `tipe` VARCHAR(20)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	CASE
    WHEN tipe = 'stok' THEN
		SELECT stock_kode as kode, gudang_nama as gudang, barang_nama as barang,
    	stock_hpp as hpp, stock_awal as awal, stock_beli as beli, stock_jual as jual,
    	stock_return_beli as rbeli, stock_return_jual as rjual, stock_in as masuk, stock_out as keluar,
    	countQTYSisaSTock(stock_barang,stock_gudang) as total,
    	stock_fisik as op
    	FROM data_barang_stok
    	INNER JOIN data_barang_gudang ON stock_gudang=gudang_kode
    	INNER JOIN data_barang_master ON barang_kode=stock_barang
    	ORDER BY kode ASC;
    WHEN tipe = 'stockop' THEN
    	SELECT faktur_bukti as kode, faktur_tanggal as tanggal, gudang_nama as gudang,
        faktur_reg_alias as regby
        FROM `data_barang_stok_opname`
        INNER JOIN data_barang_gudang ON faktur_gudang=gudang_kode
        ORDER BY kode ASC;
    END CASE;
END$$

DELIMITER ;

#
# Definition for the `getTrans` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `getTrans`(
        IN `tipe` VARCHAR(20)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	CASE
    WHEN tipe = 'jual' THEN
    	SELECT faktur_kode as faktur, faktur_tanggal_trans as tanggal, gudang_nama as gudang,
    	salesman_nama as sales, customer_nama as custo, faktur_pajak_no as pajak, faktur_netto as netto, 
    	faktur_klaim as klaim, faktur_total_netto as total, faktur_term as term
    	FROM data_penjualan_faktur
    	inner join data_barang_gudang on gudang_kode=faktur_gudang
    	inner join `data_customer_master` on customer_kode=faktur_customer
    	inner join `data_salesman_master` on salesman_kode=faktur_sales
    	ORDER BY faktur DESC;
    WHEN tipe = 'beli' THEN
    	SELECT faktur_kode as faktur, faktur_tanggal_trans as tanggal, gudang_nama as gudang,
    	supplier_nama as supplier, faktur_pajak_no as pajak, faktur_netto as netto, faktur_klaim as klaim,
    	faktur_total_netto as total, faktur_term as term
    	FROM data_pembelian_faktur
    	inner join data_barang_gudang on gudang_kode=faktur_gudang
    	inner join `data_supplier_master` on supplier_kode=faktur_supplier
    	ORDER BY faktur DESC;
    WHEN tipe = 'returbeli' THEN
		SELECT faktur_kode_bukti as bukti, faktur_tanggal_trans as tanggal, gudang_nama as gudang,
    	faktur_kode_faktur as faktur, supplier_nama as supplier, faktur_jumlah as jumlah
    	FROM data_pembelian_retur_faktur
    	INNER JOIN data_barang_gudang ON gudang_kode=faktur_gudang
    	INNER JOIN `data_supplier_master` on supplier_kode=faktur_supplier
    	ORDER BY bukti DESC;
    WHEN tipe = 'returjual' THEN
    	SELECT faktur_kode_bukti as bukti, faktur_tanggal_trans as tanggal, gudang_nama as gudang,
    	faktur_kode_faktur as faktur, salesman_nama as sales, customer_nama as custo,
    	faktur_jumlah as jumlah
    	FROM data_penjualan_retur_faktur
    	INNER JOIN data_barang_gudang ON gudang_kode=faktur_gudang
    	INNER JOIN `data_salesman_master` on salesman_kode=faktur_sales
    	INNER JOIN data_customer_master on customer_kode = faktur_custo
    	ORDER BY bukti DESC;
    END CASE;
END$$

DELIMITER ;

#
# Definition for the `HitungKomisiRp` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `HitungKomisiRp`(
        IN `vTanggal` DATE,
        IN `vKantor` VARCHAR(3)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN

 DECLARE kode1 VARCHAR(20);
 DECLARE kode2 VARCHAR(20);
 DECLARE kode3 VARCHAR(20);
 DECLARE kode4 VARCHAR(20);
 DECLARE kode5 VARCHAR(20);
 DECLARE kode6 VARCHAR(20);
 DECLARE kode7 VARCHAR(20);

 DECLARE rupiah1 VARCHAR(20);
 DECLARE rupiah2 VARCHAR(20);
 DECLARE rupiah3 VARCHAR(20);
 DECLARE rupiah4 VARCHAR(20);
 DECLARE rupiah5 VARCHAR(20);
 DECLARE rupiah6 VARCHAR(20);
 DECLARE rupiah7 VARCHAR(20);

 DECLARE split1 VARCHAR(20);
 DECLARE split2 VARCHAR(20);
 DECLARE split3 VARCHAR(20);
 DECLARE split4 VARCHAR(20);
 DECLARE split5 VARCHAR(20);
 DECLARE split6 VARCHAR(20);
 DECLARE split7 VARCHAR(20);

 DECLARE JumlahVol1 VARCHAR(20);
 DECLARE JumlahVol2 VARCHAR(20);
 DECLARE JumlahVol3 VARCHAR(20);
 DECLARE JumlahVol4 VARCHAR(20);
 DECLARE JumlahVol5 VARCHAR(20);
 DECLARE JumlahVol6 VARCHAR(20);
 DECLARE JumlahVol7 VARCHAR(20);

 DECLARE JumlahRp1 VARCHAR(20);
 DECLARE JumlahRp2 VARCHAR(20);
 DECLARE JumlahRp3 VARCHAR(20);
 DECLARE JumlahRp4 VARCHAR(20);
 DECLARE JumlahRp5 VARCHAR(20);
 DECLARE JumlahRp6 VARCHAR(20);
 DECLARE JumlahRp7 VARCHAR(20);

 DECLARE HasilRp1 VARCHAR(20);
 DECLARE HasilRp2 VARCHAR(20);
 DECLARE HasilRp3 VARCHAR(20);
 DECLARE HasilRp4 VARCHAR(20);
 DECLARE HasilRp5 VARCHAR(20);
 DECLARE HasilRp6 VARCHAR(20);
 DECLARE HasilRp7 VARCHAR(20);

 SET vKantor = '01';

 #--Ambil Kode

 SELECT cucian_text, cucian_rupiah INTO kode1, rupiah1
 FROM kode_cucian WHERE cucian_case = 1;

 SELECT cucian_text, cucian_rupiah INTO kode2, rupiah2
 FROM kode_cucian WHERE cucian_case = 2;

 SELECT cucian_text, cucian_rupiah INTO kode3, rupiah3
 FROM kode_cucian WHERE cucian_case = 3;

 SELECT cucian_text, cucian_rupiah INTO kode4, rupiah4
 FROM kode_cucian WHERE cucian_case = 4;

 SELECT cucian_text, cucian_rupiah INTO kode5, rupiah5
 FROM kode_cucian WHERE cucian_case = 5;

 SELECT cucian_text, cucian_rupiah INTO kode6, rupiah6
 FROM kode_cucian WHERE cucian_case = 6;

 SELECT cucian_text, cucian_rupiah INTO kode7, rupiah7
 FROM kode_cucian WHERE cucian_case = 7;

 #--Hitung volume

 SELECT HitungCucianMobil(kode1, vTanggal, vKantor) INTO split1;
 SELECT HitungCucianMobil(kode2, vTanggal, vKantor) INTO split2;
 SELECT HitungCucianMobil(kode3, vTanggal, vKantor) INTO split3;
 SELECT HitungCucianMobil(kode4, vTanggal, vKantor) INTO split4;
 SELECT HitungCucianMobil(kode5, vTanggal, vKantor) INTO split5;
 SELECT HitungCucianMobil(kode6, vTanggal, vKantor) INTO split6;
 SELECT HitungCucianMobil(kode7, vTanggal, vKantor) INTO split7;

 SET JumlahVol1 = `SplitString`(split1, ':', 1);
 SET JumlahVol2 = `SplitString`(split2, ':', 1);
 SET JumlahVol3 = `SplitString`(split3, ':', 1);
 SET JumlahVol4 = `SplitString`(split4, ':', 1);
 SET JumlahVol5 = `SplitString`(split5, ':', 1);
 SET JumlahVol6 = `SplitString`(split6, ':', 1);
 SET JumlahVol7 = `SplitString`(split7, ':', 1);

 SET JumlahRp1 = `SplitString`(split1, ':', 2);
 SET JumlahRp2 = `SplitString`(split2, ':', 2);
 SET JumlahRp3 = `SplitString`(split3, ':', 2);
 SET JumlahRp4 = `SplitString`(split4, ':', 2);
 SET JumlahRp5 = `SplitString`(split5, ':', 2);
 SET JumlahRp6 = `SplitString`(split6, ':', 2);
 SET JumlahRp7 = `SplitString`(split7, ':', 2);

 SET HasilRp1 = rupiah1 * JumlahVol1;
 SET HasilRp2 = rupiah2 * JumlahVol2;
 SET HasilRp3 = rupiah3 * JumlahVol3;
 SET HasilRp4 = rupiah4 * JumlahVol4;
 SET HasilRp5 = rupiah5 * JumlahVol5;
 SET HasilRp6 = rupiah6 * JumlahVol6;
 SET HasilRp7 = rupiah7 * JumlahVol7;

 #--Input ke data_komisi_rupiah

 DELETE FROM data_komisi_rupiah WHERE komisi_tanggal = vTanggal;

 INSERT INTO `data_komisi_rupiah` VALUES (
 '', vTanggal, vKantor, 1, rupiah1, JumlahVol1, JumlahRp1, HasilRp1,
 NOW(), '192.168.0.1', 'system');

 INSERT INTO `data_komisi_rupiah` VALUES (
 '', vTanggal, vKantor, 2, rupiah2, JumlahVol2, JumlahRp2, HasilRp2,
 NOW(), '192.168.0.1', 'system');

 INSERT INTO `data_komisi_rupiah` VALUES (
 '', vTanggal, vKantor, 3, rupiah3, JumlahVol3, JumlahRp3, HasilRp3,
 NOW(), '192.168.0.1', 'system');

 INSERT INTO `data_komisi_rupiah` VALUES (
 '', vTanggal, vKantor, 4, rupiah4, JumlahVol4, JumlahRp4, HasilRp4,
 NOW(), '192.168.0.1', 'system');

 INSERT INTO `data_komisi_rupiah` VALUES (
 '', vTanggal, vKantor, 5, rupiah5, JumlahVol5, JumlahRp5, HasilRp5,
 NOW(), '192.168.0.1', 'system');

 INSERT INTO `data_komisi_rupiah` VALUES (
 '', vTanggal, vKantor, 6, rupiah6, JumlahVol6, JumlahRp6, HasilRp6,
 NOW(), '192.168.0.1', 'system');

 INSERT INTO `data_komisi_rupiah` VALUES (
 '', vTanggal, vKantor, 7, rupiah7, JumlahVol7, JumlahRp7, HasilRp7,
 NOW(), '192.168.0.1', 'system');

END$$

DELIMITER ;

#
# Definition for the `HitungLabaPenjualan` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `HitungLabaPenjualan`(
        IN `TglAwal` DATE,
        IN `TglAkhir` DATE,
        IN `vKantor` VARCHAR(3)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN

 SELECT trans_kode, trans_kantor, trans_produk,
 `GetProdukNama`(trans_produk) as NamaProduk,
 trans_tanggal, trans_harga_pokok, trans_harga,
 trans_volume, trans_discount, trans_total,
 trans_harga_pokok*trans_volume as TotalPokok,
 trans_total-(trans_harga_pokok*trans_volume) as Laba
 FROM data_penjualan_trans
 WHERE trans_status = 1 AND IF(vKantor<>'', trans_kantor=vKantor, 1=1)
 AND (trans_tanggal BETWEEN TglAwal AND TglAkhir);

END$$

DELIMITER ;

#
# Definition for the `insertSupplier` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `insertSupplier`(
        IN `kode` VARCHAR(5),
        IN `nama` VARCHAR(30),
        IN `alamat` VARCHAR(200),
        IN `telp` VARCHAR(20),
        IN `fax` VARCHAR(20),
        IN `cp` VARCHAR(20),
        IN `npwp` VARCHAR(50),
        IN `rek_bg` VARCHAR(20),
        IN `rek_bank` VARCHAR(20),
        IN `term` VARCHAR(2),
        IN `stts` VARCHAR(1),
        IN `foto` BLOB,
        IN `usr_alias` VARCHAR(20)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	DECLARE _regdate DATETIME;
    
    SELECT CURRENT_TIME into _regdate;
    
	insert into `data_supplier_master`
    VALUES(kode,nama,alamat,telp,fax,cp,npwp,rek_bg,rek_bank,term,foto,stts,_regdate,usr_alias,NULL,NULL);
END$$

DELIMITER ;

#
# Definition for the `MigrasiDataBarang` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `MigrasiDataBarang`()
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN

 truncate `db-obat`.data_barang_master;

 Insert Into `db-obat`.data_barang_master
 (barang_kode, barang_kantor, barang_nama, barang_satuan,
 barang_kategori, barang_harga_beli, barang_jual_a, 
 barang_jual_b, barang_jual_c, barang_jual_d, 
 barang_expired, barang_status, barang_reg_date, barang_reg_ip, barang_reg_alias)
 select barang_kode, barang_kantor, barang_nama, barang_satuan,
 barang_sub, barang_harga_beli, barang_harga_dasar, 
 barang_harga_jaringan, barang_harga_medis, barang_harga_umum, 
 NOW(), 1, NOW(), '0.0.0.0', 'migrasi'
 FRom data_barang_master;

END$$

DELIMITER ;

#
# Definition for the `SetPenjulaanHargaPokok` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `SetPenjulaanHargaPokok`()
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN

 UPDATE data_penjualan_trans
 SET trans_harga_pokok = GetProdukHargaBeli(trans_produk);

END$$

DELIMITER ;

#
# Definition for the `updateSupplier` procedure : 
#

DELIMITER $$

CREATE DEFINER = 'root'@'localhost' PROCEDURE `updateSupplier`(
        IN `kode` VARCHAR(5),
        IN `nama` VARCHAR(30),
        IN `alamat` VARCHAR(200),
        IN `telp` VARCHAR(20),
        IN `fax` VARCHAR(20),
        IN `cp` VARCHAR(20),
        IN `npwp` VARCHAR(50),
        IN `rek_bg` VARCHAR(20),
        IN `rek_bank` VARCHAR(20),
        IN `term` VARCHAR(2),
        IN `stts` VARCHAR(1),
        IN `usr_alias` VARCHAR(20)
    )
    NOT DETERMINISTIC
    CONTAINS SQL
    SQL SECURITY DEFINER
    COMMENT ''
BEGIN
	DECLARE _update DATETIME;
    
    SELECT CURRENT_TIME into _update;
    
    UPDATE `data_supplier_master`
    SET
    supplier_nama=nama,
    supplier_alamat=alamat,
    supplier_telpon=telp,
    supplier_fax=fax,
    supplier_cp=cp,
    supplier_rek_bg=rek_bg,
    supplier_rek_bank=rek_bank,
    supplier_term=term,
    supplier_status=stts,
    supplier_upd_date=_update,
    supplier_upd_allias=usr_alias
    WHERE supplier_kode=kode;

END$$

DELIMITER ;

#
# Definition for the `viewmutasi` view : 
#

CREATE ALGORITHM=UNDEFINED DEFINER='root'@'localhost' SQL SECURITY DEFINER VIEW `viewmutasi`
AS
select 
    `data_barang_stok_mutasi`.`faktur_kode` AS `kode`,
    `data_barang_stok_mutasi`.`faktur_tanggal` AS `tanggal`,
    `a`.`gudang_nama` AS `gudang`,
    `b`.`gudang_nama` AS `gudang2`,
    `data_barang_stok_mutasi`.`faktur_reg_alias` AS `regby` 
  from 
    ((`data_barang_stok_mutasi` join `data_barang_gudang` `a` on((`a`.`gudang_kode` = `data_barang_stok_mutasi`.`faktur_gudang_asal`))) join `data_barang_gudang` `b` on((`b`.`gudang_kode` = `data_barang_stok_mutasi`.`faktur_gudang_tujuan`)));

#
# Data for the `data_barang_foto` table  (LIMIT -497,500)
#

INSERT INTO `data_barang_foto` (`foto_id`, `foto_file`) VALUES

  ('01B000001',''),
  ('01B000272','');
COMMIT;

#
# Data for the `data_barang_gudang` table  (LIMIT -495,500)
#

INSERT INTO `data_barang_gudang` (`gudang_id`, `gudang_kode`, `gudang_nama`, `gudang_alamat`, `gudang_status`, `gudang_reg_date`, `gudang_reg_ip`, `gudang_reg_alias`, `gudang_upd_date`, `gudang_upd_ip`, `gudang_upd_alias`) VALUES

  (1,'01','GUDANG BAIK','disana sana','1','2018-04-30 10:46:38','192.168.10.192','dev','2018-04-30 10:51:32','192.168.10.192','dev'),
  (2,'01.001','gggg','asas','1','2018-04-30 10:53:06','192.168.10.192','dev','2018-04-30 10:55:03','192.168.10.192','dev'),
  (3,'02','GUDANG LAH','as','9','2018-04-30 10:53:28','192.168.10.192','dev','2018-04-30 10:53:58','192.168.10.192','dev'),
  (4,'03','GUDANG TIDAK BAIK','disitu','2','2018-05-03 11:46:00','192.168.10.61','dev','0000-00-00 00:00:00','','');
COMMIT;

#
# Data for the `data_barang_jenis` table  (LIMIT -496,500)
#

INSERT INTO `data_barang_jenis` (`jenis_kode`, `jenis_nama`, `jenis_keterangan`, `jenis_reg_date`, `jenis_reg_alias`, `jenis_upd_date`, `jenis_upd_alias`) VALUES

  (1,'SCH','Sha','2018-05-02 11:08:39','dev','2018-05-02 11:10:25','dev'),
  (2,'hhh','adasa','2018-05-02 11:10:36','dev','0000-00-00 00:00:00',''),
  (3,'hohoh','kakakakaka','2018-05-22 15:32:06','dev','0000-00-00 00:00:00','');
COMMIT;

#
# Data for the `data_barang_master` table  (LIMIT 1,500)
#

INSERT INTO `data_barang_master` (`barang_id`, `barang_kode`, `barang_nama`, `barang_supplier`, `barang_jenis`, `barang_satuan_kecil`, `barang_satuan_tengah`, `barang_satuan_tengah_jumlah`, `barang_satuan_besar`, `barang_satuan_besar_jumlah`, `barang_logo`, `barang_keterangan`, `barang_harga_beli`, `barang_harga_beli_d1`, `barang_harga_beli_d2`, `barang_harga_beli_d3`, `barang_harga_beli_klaim`, `barang_harga_jual`, `barang_harga_jual_d1`, `barang_harga_jual_d2`, `barang_harga_jual_d3`, `barang_harga_jual_d4`, `barang_harga_jual_d5`, `barang_harga_jual_mt`, `barang_harga_jual_horeka`, `barang_harga_jual_rita`, `barang_harga_jual_discount`, `barang_stok_awal`, `barang_stok_minimal`, `barang_berat`, `barang_status`, `barang_status_pajak`, `barang_reg_date`, `barang_reg_alias`, `barang_upd_date`, `barang_upd_alias`) VALUES

  (1,'01B000001','Actived  sirup (Kuning)','01.001','001','02','02',1,'03',12,'B','',100000.00,0.00,0.00,0.00,0.00,105000.00,0.00,0.00,0.00,0.00,0.00,110000.00,123200.00,124000.00,132000.00,0,0,0.00,'2','1','2016-02-03 16:31:49','migrasi','2018-05-16 08:17:26','dev'),
  (2,'01B000002','Actived plus cough sirup (Merah)','01.001','','02','',0,'',0,'B','',27000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27000.00,0.00,30000.00,30000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (3,'01B000003','Actived Plus Exp sirup (Hijau)','01.001','','02','',0,'',0,'B','',27000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27000.00,0.00,30000.00,30000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (4,'01B000004','Albendazol 400 mg 5x6''s','01.001','','13','',0,'',0,'B','',2440.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2440.00,0.00,2700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (5,'01B000005','Albothyl 10ml','01.001','','02','',0,'',0,'B','',30800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32340.00,36221.00,35574.00,35574.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (6,'01B000006','Albothyl 5 ml','01.001','','02','',0,'',0,'B','',19800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19800.00,0.00,22000.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (7,'01B000007','Alinamin F Tab 10x10''s','01.001','','13','',0,'',0,'B','',8333.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8333.00,0.00,9500.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (8,'01B000008','Alkohol 100ml 70 % Rama','01.001','','02','',0,'',0,'B','',2500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2500.00,0.00,3500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (9,'01B000009','Alkohol 70 % 100 ml Afi','01.001','','02','',0,'',0,'B','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,3850.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (10,'01B000010','Alkohol 70 % 1000 ml Afi','01.001','','02','',0,'',0,'B','',31000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31000.00,0.00,35000.00,36000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (11,'01B000011','Allerin Exp 60 ml','01.001','','02','',0,'',0,'B','',10400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10400.00,0.00,11800.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (12,'01B000012','Alleron Tab 20x10''s','01.001','','13','',0,'',0,'B','',11300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11300.00,0.00,12700.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (13,'01B000013','Alpara Sirup 60 ml','01.001','','02','',0,'',0,'B','',7200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7200.00,0.00,8000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (14,'01B000014','Alphara Tab 15x10''s','01.001','','13','',0,'',0,'B','',50000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,50000.00,50000.00,55000.00,62500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (15,'01B000015','Ambeven 10x10''s','01.001','','13','',0,'',0,'B','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,12700.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (16,'01B000016','Anacetin Sirup  (72)','01.001','','02','',0,'',0,'B','',4800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4800.00,0.00,5300.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (17,'01B000017','Anakonidin 30','01.001','','02','',0,'',0,'B','',5600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5600.00,0.00,6200.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (18,'01B000018','Anakonidin 60','01.001','','02','',0,'',0,'B','',9240.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9240.00,0.00,10300.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (19,'01B000019','Anakonidin OBH 30 ml','01.001','001','02','02',1,'03',20,'B','',5500.00,0.00,0.00,0.00,0.00,6500.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6200.00,0.00,0,0,0.00,'1','0','2016-02-03 16:31:49','migrasi','2018-05-21 12:04:53','dev'),
  (20,'01B000020','Anakonidin OBH 60 ml','01.001','','02','',0,'',0,'B','',9360.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9360.00,0.00,10300.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (21,'01B000021','Anaton sirup 60ml','01.001','','02','',0,'',0,'B','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3700.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (22,'01B000022','Antimo Anak 10''s','01.001','','11','',0,'',0,'B','',875.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,875.00,0.00,1000.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (23,'01B000023','Antimo Tab','01.001','','13','',0,'',0,'B','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,3900.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (24,'01B000024','Askamex tab','01.001','','13','',0,'',0,'B','',1300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1300.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (25,'01B000025','Asmasoho (25x4''s)','01.001','','13','',0,'',0,'B','',20000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21000.00,22050.00,22050.00,22050.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (26,'01B000026','Baby Cough Pacdin Sirup ','01.001','','02','',0,'',0,'B','',3060.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3060.00,0.00,3500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (27,'01B000027','Baby Cough Uni sirup','01.001','','02','',0,'',0,'B','',2900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2900.00,0.00,3200.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (28,'01B000028','Bantif Child Sirup 60 ml','01.001','','02','',0,'',0,'B','',9900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9900.00,0.00,11000.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (29,'01B000029','Benzolac Gel 2,5 % 5 gr','01.001','','17','',0,'',0,'B','',10890.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10890.00,0.00,12000.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (30,'01B000030','Benzolac Gel 5 % 5 gr','01.001','','17','',0,'',0,'B','',16000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16000.00,0.00,17600.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (31,'01B000031','Betadin feminim','01.001','','02','',0,'',0,'B','',16700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16700.00,0.00,18700.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (32,'01B000032','Betadin sabun Cair 60ml','01.001','','02','',0,'',0,'B','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,21300.00,21500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (33,'01B000033','Betadin salep 5gr','01.001','','17','',0,'',0,'B','',7384.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7384.00,0.00,8200.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (34,'01B000034','Betadin sol 15','01.001','','02','',0,'',0,'B','',7650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7650.00,0.00,8500.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (35,'01B000035','Betadin sol 30','01.001','','02','',0,'',0,'B','',13500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13500.00,0.00,14850.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (36,'01B000036','Betadin sol 5','01.001','','02','',0,'',0,'B','',2800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2800.00,0.00,3200.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (37,'01B000037','Betadin sol 60','01.001','','02','',0,'',0,'B','',23930.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23930.00,0.00,26500.00,26500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (38,'01B000038','Betadine Gargle 100 ml','01.001','','02','',0,'',0,'B','',8470.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8470.00,0.00,9300.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (39,'01B000039','Betadine Gargle 190ml','01.001','','02','',0,'',0,'B','',15620.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15620.00,0.00,17200.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (40,'01B000040','Bisolvon Antitusiv Sirup','01.001','','02','',0,'',0,'B','',23425.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23425.00,0.00,25800.00,26000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (41,'01B000041','Bisolvon elixir 60ml','01.001','','02','',0,'',0,'B','',24000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24000.00,0.00,26400.00,27000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (42,'01B000042','Bisolvon extra sir 60ml','01.001','','02','',0,'',0,'B','',26500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26500.00,0.00,29800.00,30000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (43,'01B000043','Bisolvon flu 60ml','01.001','','02','',0,'',0,'B','',26500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26500.00,0.00,29800.00,30000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (44,'01B000044','Bisolvon kids sir 60ml','01.001','','02','',0,'',0,'B','',23500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23500.00,0.00,26000.00,27500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (45,'01B000045','Bisolvon Solution ','01.001','','02','',0,'',0,'B','',61200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,61200.00,0.00,67300.00,67500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (46,'01B000046','Bisolvon Tab 10x4''s','01.001','','13','',0,'',0,'B','',5600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5600.00,0.00,6200.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (47,'01B000047','Bodrex extra','01.001','','13','',0,'',0,'B','',1600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1600.00,0.00,1800.00,1800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (48,'01B000048','Bodrex FB sirup','01.001','','02','',0,'',0,'B','',6675.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6675.00,0.00,7500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (49,'01B000049','Bodrex flu batuk','01.001','','13','',0,'',0,'B','',1313.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1313.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (50,'01B000050','Bodrex flu batuk berdahak','01.001','','13','',0,'',0,'B','',1250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1250.00,0.00,1400.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (51,'01B000051','Bodrex Gel','01.001','','17','',0,'',0,'B','',8000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8000.00,0.00,8800.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (52,'01B000052','Bodrex Migra','01.001','','13','',0,'',0,'B','',1500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1500.00,0.00,1700.00,1700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (53,'01B000053','Bodrex Tab 12x2x10','01.001','','13','',0,'',0,'B','',2600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2600.00,0.00,2900.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (54,'01B000054','Bodrexin flu batuk sirup','01.001','','13','',0,'',0,'B','',6125.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6125.00,0.00,7200.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (55,'01B000055','Bodrexin Tab 12x2x10','01.001','','13','',0,'',0,'B','',1400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1400.00,0.00,1600.00,1600.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (56,'01B000056','Bronchitin sirup','01.001','','02','',0,'',0,'B','',3900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3900.00,0.00,4300.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (57,'01B000057','Bronex Tab 10x10''s','01.001','','13','',0,'',0,'B','',9500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9500.00,0.00,11000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (58,'01B000058','Bufagan Exp Sir 60 ml','01.001','','02','',0,'',0,'B','',2874.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2874.00,0.00,3200.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (59,'01B000059','Bufakris Sirup ','01.001','','02','',0,'',0,'B','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,4000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (60,'01B000060','Bufantacid Forte Sirup','01.001','','02','',0,'',0,'B','',4800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4800.00,0.00,5500.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (61,'01B000061','Bufantacid Tab 10x10''s','01.001','','13','',0,'',0,'B','',13000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13000.00,0.00,14500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (62,'01B000062','Bye-bye fever anak 5''s','01.001','','09','',0,'',0,'B','',8300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8300.00,0.00,9200.00,9500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (63,'01B000063','Bye-bye fever baby 10''s','01.001','','09','',0,'',0,'B','',5810.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5810.00,0.00,6400.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (64,'01B000064','Callusol Liquid','01.001','','02','',0,'',0,'B','',24500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24500.00,0.00,27000.00,28000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (65,'01B000065','Calortusin Tab 10x10''s','01.001','','13','',0,'',0,'B','',21000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21000.00,0.00,23500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (66,'01B000066','Canesten 10 gr','01.001','','17','',0,'',0,'B','',32800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32800.00,0.00,36000.00,36000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (67,'01B000067','Canesten 5 gr','01.001','','17','',0,'',0,'B','',19000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19000.00,0.00,21000.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (68,'01B000068','Caporit Afi 12''s','01.001','','02','',0,'',0,'B','',1900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1900.00,0.00,2700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (69,'01B000069','Cendo Astenof TM 5 ml','01.001','','02','',0,'',0,'B','',21300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21300.00,0.00,23500.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (70,'01B000070','Cendo Augentonic TM  5 ml','01.001','','02','',0,'',0,'B','',25565.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,25565.00,0.00,28200.00,28500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (71,'01B000071','Cendo Catarlent TM 15ml','01.001','','02','',0,'',0,'B','',31160.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31160.00,0.00,34500.00,36000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (72,'01B000072','Citocetin Sirup','01.001','','02','',0,'',0,'B','',3450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3450.00,0.00,4000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (73,'01B000073','Coldrexin Sirup 60 ml','01.001','','02','',0,'',0,'B','',3850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3850.00,0.00,4400.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (74,'01B000074','Colfin sir','01.001','','02','',0,'',0,'B','',4900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4900.00,0.00,5500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (75,'01B000075','Combantrin  250','01.001','','13','',0,'',0,'B','',10350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10350.00,0.00,11500.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (76,'01B000076','Combantrin 125 mg','01.001','','13','',0,'',0,'B','',10350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10350.00,0.00,11500.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (77,'01B000077','Combantrin Jeruk ','01.001','','02','',0,'',0,'B','',12500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12500.00,0.00,13800.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (78,'01B000078','Combicitrin sirup 12''s','01.001','','02','',0,'',0,'B','',1000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1000.00,0.00,1100.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (79,'01B000079','Contrex tab','01.001','','13','',0,'',0,'B','',1250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1250.00,0.00,1400.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (80,'01B000080','Contrexin tab 25x4''s','01.001','','13','',0,'',0,'B','',600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,600.00,0.00,700.00,800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (81,'01B000081','Coparcetin Kids sirup 60 ml','01.001','','02','',0,'',0,'B','',4000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4000.00,0.00,4400.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (82,'01B000082','Coparcetin sirup 60 ml','01.001','','02','',0,'',0,'B','',4400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4400.00,0.00,4850.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (83,'01B000083','Coredryl Exp 100 ml','01.001','','02','',0,'',0,'B','',4600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4600.00,0.00,5100.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (84,'01B000084','Emflu Sirup ','01.001','','02','',0,'',0,'B','',9000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9000.00,0.00,9900.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (85,'01B000085','Erphamazol cream','01.001','','17','',0,'',0,'B','',3100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3100.00,0.00,3500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (86,'01B000086','Erphaphyllin Tab 1000','01.001','','06','',0,'',0,'B','',79500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,79500.00,0.00,87500.00,200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (87,'01B000087','Etaflusin Sirup','01.001','','13','',0,'',0,'B','',2850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2850.00,0.00,3500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (88,'01B000088','Etaflusin Tab 10x10''s','01.001','','13','',0,'',0,'B','',24000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24000.00,0.00,26500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (89,'01B000089','Farsifen Sirup','01.001','','02','',0,'',0,'B','',3475.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3475.00,0.00,3850.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (90,'01B000090','Fatigon 15x4''s','01.001','','13','',0,'',0,'B','',2430.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2430.00,0.00,2800.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (91,'01B000091','Faxiden gel 10 gr','01.001','','17','',0,'',0,'B','',5400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5400.00,0.00,6000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (92,'01B000092','Feminax','01.001','','13','',0,'',0,'B','',1600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1600.00,0.00,1800.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (93,'01B000093','Fenidryl Sirup 60 ml','01.001','','02','',0,'',0,'B','',2900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2900.00,0.00,3300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (94,'01B000094','Flucadex Sirup','01.001','','02','',0,'',0,'B','',5975.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5975.00,0.00,6600.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (95,'01B000095','Flucadex Tab 10x10''s','01.001','','13','',0,'',0,'B','',32800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32800.00,0.00,36000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (96,'01B000096','Fludane Forte Tab 10x10''s','01.001','','13','',0,'',0,'B','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (97,'01B000097','Fludane Plus Sirup 60 ml','01.001','','02','',0,'',0,'B','',13600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13600.00,0.00,17000.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (98,'01B000098','Fludane Plus Tab 10x10''s','01.001','','13','',0,'',0,'B','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,3500.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (99,'01B000099','Fludane sir','01.001','','02','',0,'',0,'B','',11200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11200.00,0.00,12300.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (100,'01B000100','Fludane Tab 10x10''s','01.001','','13','',0,'',0,'B','',2500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2500.00,0.00,2750.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (101,'01B000101','Flumin Capsul 10x10','01.001','','13','',0,'',0,'B','',2150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2150.00,0.00,2400.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (102,'01B000102','Flumin Plus Sirup 60 ml','01.001','','02','',0,'',0,'B','',4420.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4420.00,0.00,4900.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (103,'01B000103','Flutamol Tab 10x10''s','01.001','','13','',0,'',0,'B','',20500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20500.00,0.00,23500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (104,'01B000104','Flutop C Sirup 60 ml','01.001','','02','',0,'',0,'B','',3750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3750.00,0.00,4300.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (105,'01B000105','Folaxin Tab 10x10''s','01.001','','13','',0,'',0,'B','',20000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20000.00,0.00,22000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (106,'01B000106','Forumen ED','01.001','','02','',0,'',0,'B','',24100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24100.00,0.00,26500.00,27000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (107,'01B000107','Fresh TM','01.001','','02','',0,'',0,'B','',3350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3350.00,0.00,3700.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (108,'01B000108','Fumadryl Sirup ','01.001','','02','',0,'',0,'B','',2500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2500.00,0.00,3000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (109,'01B000109','Daktarin 5 gr','01.001','','17','',0,'',0,'B','',19600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19600.00,0.00,21800.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (110,'01B000110','Decolgen sirup','01.001','','02','',0,'',0,'B','',7600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7600.00,0.00,8700.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (111,'01B000111','Decolgen Tab','01.001','','17','',0,'',0,'B','',1237.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1237.00,0.00,1400.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (112,'01B000112','Decolsin Tab','01.001','','13','',0,'',0,'B','',2090.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2090.00,0.00,2300.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (113,'01B000113','Dehista 20x10''s','01.001','','13','',0,'',0,'B','',9300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9300.00,0.00,10500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (114,'01B000114','Dekorin Tab 20x10''s','01.001','','13','',0,'',0,'B','',2275.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2275.00,0.00,2500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (115,'01B000115','Demacolin sirup','01.001','','02','',0,'',0,'B','',7250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7250.00,0.00,8000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (116,'01B000116','Demacolin Tab 10x10''s','01.001','','13','',0,'',0,'B','',28500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28500.00,0.00,31500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (117,'01B000117','Dermifar Cream 5 gr','01.001','','17','',0,'',0,'B','',2700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2700.00,0.00,3000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (118,'01B000118','Dextral Sirup 60ml','01.001','','02','',0,'',0,'B','',5500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (119,'01B000119','Dextral Tab 15x10''s','01.001','','13','',0,'',0,'B','',44700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,44700.00,0.00,49500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (120,'01B000120','Dextrofort Sirup 60 ml','01.001','','02','',0,'',0,'B','',6900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6900.00,0.00,7600.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (121,'01B000121','Dextrometorphan Sirup IF','01.001','','02','',0,'',0,'B','',2900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2900.00,0.00,3500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (122,'01B000122','Dextrosin Sirup 60','01.001','','02','',0,'',0,'B','',11000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11000.00,0.00,12500.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (123,'01B000123','Dialet 2x10''s','01.001','','13','',0,'',0,'B','',1210.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1210.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (124,'01B000124','Dimenhidrinat KF 100''s','01.001','','02','',0,'',0,'B','',9600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9600.00,0.00,11000.00,200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (125,'01B000125','Domeryl Sirup 60 ml','01.001','','02','',0,'',0,'B','',6000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6000.00,0.00,6600.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (126,'01B000126','Dulcolax suppo Adult/Dewasa 5''s','01.001','','14','',0,'',0,'B','',16588.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16588.00,0.00,18300.00,18500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (127,'01B000127','Dulcolax suppo child/Anak 6''s','01.001','','14','',0,'',0,'B','',12350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12350.00,0.00,13600.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (128,'01B000128','Dulcolax Tab 20x10''s','01.001','','13','',0,'',0,'B','',9700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9700.00,0.00,10700.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (129,'01B000129','Dulcolax Tab 20x4''s','01.001','','13','',0,'',0,'B','',4500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4500.00,0.00,5000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (130,'01B000130','Ikadril DMP Sir','01.001','','02','',0,'',0,'B','',19250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19250.00,0.00,21200.00,21500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (131,'01B000131','Ikadril Flu  sirup','01.001','','02','',0,'',0,'B','',13500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13500.00,0.00,15500.00,16500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (132,'01B000132','Ikadril sirup','01.001','','02','',0,'',0,'B','',9900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9900.00,0.00,11000.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (133,'01B000133','Intunal F','01.001','','13','',0,'',0,'B','',2600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2600.00,0.00,2900.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (134,'01B000134','Intunal sirup 60 ml','01.001','','02','',0,'',0,'B','',9650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9650.00,0.00,10700.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (135,'01B000135','Inza','01.001','','13','',0,'',0,'B','',1500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1500.00,0.00,1700.00,1700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (136,'01B000136','Itrabat sirup','01.001','','02','',0,'',0,'B','',5800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5800.00,0.00,7000.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (137,'01B000137','GG Nova Kaleng','01.001','','06','',0,'',0,'B','',26500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26500.00,0.00,29500.00,100.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (138,'01B000138','Glusam Capsul 60''s (Ecer)','01.001','','15','',0,'',0,'B','',825.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,825.00,0.00,1000.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (139,'01B000139','Grafadon tab 10x10''s','01.001','','13','',0,'',0,'B','',12500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12500.00,0.00,13750.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (140,'01B000140','Grantusif Tab 10x10','01.001','','13','',0,'',0,'B','',24400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24400.00,0.00,27000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (141,'01B000141','Halmezin Sirup','01.001','','02','',0,'',0,'B','',22400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22400.00,0.00,25000.00,26000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (142,'01B000142','HICO Gel 15 gr','01.001','','17','',0,'',0,'B','',10550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10550.00,0.00,11600.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (143,'01B000143','Hufagrip Forte 10x10`s','01.001','001','13','13',1,'BOX',10,'B','',18500.00,0.00,0.00,0.00,0.00,19000.00,0.00,0.00,0.00,0.00,0.00,18500.00,19000.00,20350.00,20350.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','2018-06-01 08:40:30','dev'),
  (144,'01B000144','Hufagrip Hijau /BP','01.001','','02','',0,'',0,'B','',10870.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10870.00,0.00,12000.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (145,'01B000145','Hufagrip Kuning / Flu','01.001','','02','',0,'',0,'B','',10870.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10870.00,0.00,12000.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (146,'01B000146','Hufagrip Merah / TMP','01.001','','02','',0,'',0,'B','',8200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8200.00,0.00,9000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (147,'01B000147','Hufagrip pilek','01.001','','02','',0,'',0,'B','',8200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8200.00,0.00,9000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (148,'01B000148','Hufallerzine Sirup','01.001','','02','',0,'',0,'B','',2850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2850.00,0.00,3200.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (149,'01B000149','Hufaneuron 10x10','01.001','','13','',0,'',0,'B','',26500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26500.00,0.00,29000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (150,'01B000150','Lacoldin Tab 10x10','01.001','','13','',0,'',0,'B','',8800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8800.00,0.00,9700.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (151,'01B000151','Lafalos Cream 20 gr','01.001','','17','',0,'',0,'B','',9300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9300.00,0.00,10300.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (152,'01B000152','Lapifed DM sir 100 ml','01.001','','02','',0,'',0,'B','',23100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23100.00,0.00,25500.00,27000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (153,'01B000153','Lapifed Exp','01.001','','02','',0,'',0,'B','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,20800.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (154,'01B000154','Lapifed Sirup 60 ml','01.001','','02','',0,'',0,'B','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,20800.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (155,'01B000155','Lapisiv Sirup 100','01.001','','02','',0,'',0,'B','',14500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14500.00,0.00,16500.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (156,'01B000156','Lavarix Tab 2x10''s','01.001','','15','',0,'',0,'B','',2188.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2188.00,0.00,2400.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (157,'01B000157','Laxana Tab 10x10','01.001','','13','',0,'',0,'B','',22000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22000.00,0.00,26000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (158,'01B000158','Lespain Cream','01.001','','17','',0,'',0,'B','',4050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4050.00,0.00,4500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (159,'01B000159','Licodril DMP sirup','01.001','','02','',0,'',0,'B','',6000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6000.00,0.00,6600.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (160,'01B000160','Kalpanax Cream','01.001','','17','',0,'',0,'B','',5900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5900.00,0.00,6500.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (161,'01B000161','Ketoconazol Cream 10 gr KF','01.001','','17','',0,'',0,'B','',4675.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4675.00,0.00,5200.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (162,'01B000162','Ketoconazol Cream 5 gr Hexp','01.001','','17','',0,'',0,'B','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (163,'01B000163','Komix DT 3''s','01.001','','11','',0,'',0,'B','',1333.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1333.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (164,'01B000164','Komix MINT, JRK, OBH, JAHE 30''s','01.001','','11','',0,'',0,'B','',492.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,492.00,0.00,700.00,800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (165,'01B000165','Kompolax Sirup 60 ml','01.001','','02','',0,'',0,'B','',5700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5700.00,0.00,6300.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (166,'01B000166','Konidin Tab','01.001','','13','',0,'',0,'B','',1300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1300.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (167,'01B000167','Nalgestan 25x4''s','01.001','','13','',0,'',0,'B','',4000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4000.00,0.00,4500.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (168,'01B000168','Napacin','01.001','','13','',0,'',0,'B','',1450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1450.00,0.00,1600.00,1700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (169,'01B000169','Naspro','01.001','','13','',0,'',0,'B','',770.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,770.00,0.00,850.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (170,'01B000170','Neo Rheumacyl Neuro 10x10''s','01.001','','13','',0,'',0,'B','',6500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6500.00,0.00,7200.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (171,'01B000171','Neo Rheumacyl Tab 12x2x20 (Ecer)','01.001','','15','',0,'',0,'B','',6700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6700.00,0.00,7500.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (172,'01B000172','Neosanmag Fast 8x2''s','01.001','','13','',0,'',0,'B','',1700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1700.00,0.00,1900.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (173,'01B000173','Neozep Forte','01.001','','13','',0,'',0,'B','',1700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1700.00,0.00,1900.00,1900.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (174,'01B000174','New Astar Cream 15 gr','01.001','','17','',0,'',0,'B','',4650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4650.00,0.00,5200.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (175,'01B000175','Nosib Salep','01.001','','09','',0,'',0,'B','',5500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (176,'01B000176','Obh Tropica Plus anak 60 ml','01.001','','02','',0,'',0,'B','',9350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9350.00,0.00,10300.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (177,'01B000177','Omecough Sirup','01.001','','02','',0,'',0,'B','',3150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3150.00,0.00,3500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (178,'01B000178','Omevomid Sirup','01.001','','02','',0,'',0,'B','',2900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2900.00,0.00,3300.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (179,'01B000179','Oratifed plus Cough Sir (Merah)','01.001','','02','',0,'',0,'B','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,6000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (180,'01B000180','Oratifed plus Expect Sir (Hijau)','01.001','','02','',0,'',0,'B','',4400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4400.00,0.00,5000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (181,'01B000181','Orphen Tab 20x10''s','01.001','','13','',0,'',0,'B','',9200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9200.00,0.00,11000.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (182,'01B000182','Oskadon','01.001','','13','',0,'',0,'B','',1300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1300.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (183,'01B000183','Oskadon SP','01.001','','13','',0,'',0,'B','',1350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1350.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (184,'01B000184','Quantidex Sirup 60 ml','01.001','','02','',0,'',0,'B','',3800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3800.00,0.00,4300.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (185,'01B000185','Quantidex Tab 10x10''s','01.001','','13','',0,'',0,'B','',49000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,49000.00,0.00,8000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (186,'01B000186','Termorex 30ml','01.001','','02','',0,'',0,'B','',6400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6400.00,0.00,7000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (187,'01B000187','Termorex 60ml','01.001','','02','',0,'',0,'B','',10120.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10120.00,0.00,11200.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (188,'01B000188','Termorex plus 30ml','01.001','','02','',0,'',0,'B','',6400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6400.00,0.00,7000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (189,'01B000189','Termorex plus 60ml','01.001','','02','',0,'',0,'B','',10120.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10120.00,0.00,11200.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (190,'01B000190','Ternix Plus Sirup','01.001','','02','',0,'',0,'B','',3950.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3950.00,0.00,5000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (191,'01B000191','Ternix Sirup','01.001','','02','',0,'',0,'B','',3750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3750.00,0.00,4300.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (192,'01B000192','Terra F 10x10','01.001','','13','',0,'',0,'B','',21500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21500.00,0.00,23700.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (193,'01B000193','Thrombophop gel 10gr ','01.001','','17','',0,'',0,'B','',33000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33000.00,0.00,36300.00,36500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (194,'01B000194','Tremenza sirup','01.001','','02','',0,'',0,'B','',13393.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13393.00,0.00,15000.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (195,'01B000195','Triaminic Batuk pilek','01.001','','02','',0,'',0,'B','',36400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36400.00,0.00,40000.00,40000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (196,'01B000196','Triaminic Expectorant','01.001','','02','',0,'',0,'B','',36400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36400.00,0.00,40000.00,40000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (197,'01B000197','Triaminic Pilek','01.001','','02','',0,'',0,'B','',36400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36400.00,0.00,40000.00,40000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (198,'01B000198','Triolax Suppo','01.001','','14','',0,'',0,'B','',4800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4800.00,0.00,5300.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (199,'01B000199','Trolit 6''s','01.001','','11','',0,'',0,'B','',9170.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9170.00,0.00,10000.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (200,'01B000200','Tusselix sir 100ml','01.001','','02','',0,'',0,'B','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (201,'01B000201','Ultraflu 25x4''s','01.001','','13','',0,'',0,'B','',2200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2200.00,0.00,2400.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (202,'01B000202','Sanadril DMP 60 ml','01.001','','02','',0,'',0,'B','',9900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9900.00,0.00,10900.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (203,'01B000203','Sanadril Exp 60 ml','01.001','','02','',0,'',0,'B','',9200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9200.00,0.00,10300.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (204,'01B000204','Sanaflu','01.001','','13','',0,'',0,'B','',1450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1450.00,0.00,1600.00,1600.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (205,'01B000205','Sanbe Tears TM','01.001','','02','',0,'',0,'B','',19789.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19789.00,0.00,21800.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (206,'01B000206','Saridon','01.001','','13','',0,'',0,'B','',2900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2900.00,0.00,3200.00,3200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (207,'01B000207','Scabicid Cream','01.001','','17','',0,'',0,'B','',28500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28500.00,0.00,31300.00,31500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (208,'01B000208','Sdion merah','01.001','','02','',0,'',0,'B','',1166.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1166.00,0.00,1300.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (209,'01B000209','Siladex ATT 30  ml','01.001','','09','',0,'',0,'B','',5500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (210,'01B000210','Siladex ATT 60 ml','01.001','','02','',0,'',0,'B','',8800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8800.00,0.00,9700.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (211,'01B000211','Siladex Bp 60 ml','01.001','','02','',0,'',0,'B','',8800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8800.00,0.00,9700.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (212,'01B000212','Siladex Exp 30 ml','01.001','','02','',0,'',0,'B','',5500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (213,'01B000213','Siladex Flu 60 ml','01.001','','02','',0,'',0,'B','',8800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8800.00,0.00,9700.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (214,'01B000214','Siladex Sirup BP 30 ml','01.001','','02','',0,'',0,'B','',5500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (215,'01B000215','Solinfec Cream 5 gr','01.001','','17','',0,'',0,'B','',4400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4400.00,0.00,4900.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (216,'01B000216','Stopcold','01.001','','13','',0,'',0,'B','',2400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2400.00,0.00,2700.00,2700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (217,'01B000217','Superhoid 6''s','01.001','','14','',0,'',0,'B','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,3850.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (218,'01B000218','Veril Acne cr','01.001','','17','',0,'',0,'B','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,13500.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (219,'01B000219','Vick F44 anak 54 ml','01.001','','02','',0,'',0,'B','',9850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9850.00,0.00,10800.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (220,'01B000220','Vick F44 DT 54 ml','01.001','','02','',0,'',0,'B','',9850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9850.00,0.00,10800.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (221,'01B000221','Vick F44 Sachet 15''s','01.001','','11','',0,'',0,'B','',750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,750.00,0.00,825.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (222,'01B000222','Vick Vaporub 10 gr','01.001','','09','',0,'',0,'B','',5200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5200.00,0.00,5700.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (223,'01B000223','Vicks F44 anak 27ml','01.001','','02','',0,'',0,'B','',5375.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5375.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (224,'01B000224','Vicks F44 dws 27ml','01.001','','02','',0,'',0,'B','',5375.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5375.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (225,'01B000225','Vicks F44 dws 54ml','01.001','','02','',0,'',0,'B','',9825.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9825.00,0.00,10800.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (226,'01B000226','Viostin DS Kap 6x5''s (Tab) (Ecer)','01.001','','15','',0,'',0,'B','',5650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5650.00,0.00,6200.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (227,'01B000227','Voltaren Gel 5 gr','01.001','','17','',0,'',0,'B','',17300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17300.00,0.00,19000.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (228,'01B000228','Vick F 44 dws 100 ml','01.001','','02','',0,'',0,'B','',12575.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12575.00,0.00,13800.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (229,'01B000229','Woods ATT 100ml','01.001','','02','',0,'',0,'B','',21500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21500.00,0.00,23500.00,24000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (230,'01B000230','Woods ATT 60ml','01.001','','02','',0,'',0,'B','',13200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13200.00,0.00,14500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (231,'01B000231','Woods expec 100ml','01.001','','02','',0,'',0,'B','',21500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21500.00,0.00,23500.00,24000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (232,'01B000232','Woods expec 60ml','01.001','','02','',0,'',0,'B','',13200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13200.00,0.00,14500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (233,'01B000233','Remco Baby Cough Sirup 60 ml','01.001','','02','',0,'',0,'B','',3400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3400.00,0.00,3800.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (234,'01B000234','Rheumacyl cream putih','01.001','','17','',0,'',0,'B','',20000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20000.00,0.00,22000.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (235,'01B000235','Zenirex Sirup','01.001','','02','',0,'',0,'B','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,3900.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (236,'01B000236','Zolagel Cream','01.001','','17','',0,'',0,'B','',4500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4500.00,0.00,5500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (237,'01B000237','Panadol Extra 10x10''s','01.001','','13','',0,'',0,'B','',6100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6100.00,0.00,6700.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (238,'01B000238','Paracetin Sirup','01.001','','02','',0,'',0,'B','',5400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5400.00,0.00,6000.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (239,'01B000239','Paraflu Tab 10x10','01.001','','13','',0,'',0,'B','',16500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16500.00,0.00,18500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (240,'01B000240','Paramex ','01.001','','13','',0,'',0,'B','',1580.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1580.00,0.00,1800.00,1800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (241,'01B000241','Paramex flu &batuk','01.001','','13','',0,'',0,'B','',1550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1550.00,0.00,1800.00,1800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (242,'01B000242','Paratensa Sirup','01.001','','02','',0,'',0,'B','',3750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3750.00,0.00,4500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (243,'01B000243','Paratusin sirup','01.001','','02','',0,'',0,'B','',15400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15400.00,0.00,17000.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (244,'01B000244','Pasaba  Flu Sirup','01.001','','02','',0,'',0,'B','',3800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3800.00,0.00,4200.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (245,'01B000245','Pasaba Sirup','01.001','','02','',0,'',0,'B','',2350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2350.00,0.00,2900.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (246,'01B000246','Pectorin Sirup','01.001','','02','',0,'',0,'B','',6000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6000.00,0.00,7000.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (247,'01B000247','Phytovon 8 mg Tab 10x10','01.001','','13','',0,'',0,'B','',750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,750.00,0.00,1000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (248,'01B000248','Pim-Tra -Kol 60 ml','01.001','','02','',0,'',0,'B','',5900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5900.00,0.00,6500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (249,'01B000249','PK Afi 12''s','01.001','','09','',0,'',0,'B','',3600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3600.00,0.00,4200.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (250,'01B000250','Polamec Sirup 60 ml','01.001','','02','',0,'',0,'B','',4500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4500.00,0.00,5000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (251,'01B000251','Polamec Tab 10x10','01.001','','13','',0,'',0,'B','',9800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9800.00,0.00,11000.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (252,'01B000252','Poldan mig','01.001','','13','',0,'',0,'B','',2050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2050.00,0.00,2300.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (253,'01B000253','Povidon iodin 30 ml KF','01.001','','02','',0,'',0,'B','',4375.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4375.00,0.00,4800.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (254,'01B000254','Povidon Iodin 300 ml KF','01.001','','02','',0,'',0,'B','',14500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14500.00,0.00,16000.00,16500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (255,'01B000255','Povidon iodin 60 ml Kf','01.001','','02','',0,'',0,'B','',6370.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6370.00,0.00,7000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (256,'01B000256','Procold','01.001','','13','',0,'',0,'B','',2250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2250.00,0.00,2500.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (257,'01B000257','Prointi Sirup','01.001','','02','',0,'',0,'B','',3600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3600.00,0.00,4000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (258,'01B000258','Prometazin Sirup 60 ml','01.001','','02','',0,'',0,'B','',15180.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15180.00,0.00,16700.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (259,'01B000259','Proris Forte Sirup','01.001','','02','',0,'',0,'B','',21350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21350.00,0.00,24200.00,24500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (260,'01B000260','Proris sirup','01.001','','02','',0,'',0,'B','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,20500.00,20500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (261,'01B000261','Pyrantel 125 mg 25x4''s','01.001','','13','',0,'',0,'B','',1280.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1280.00,0.00,1500.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (262,'01B000262','Megatic Emulgel 20 gr','01.001','','17','',0,'',0,'B','',6600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6600.00,0.00,7300.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (263,'01B000263','Mexaquin Tab ','01.001','','13','',0,'',0,'B','',1200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1200.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (264,'01B000264','Mextril','01.001','','13','',0,'',0,'B','',1250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1250.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (265,'01B000265','Miconazol Cream KF','01.001','','17','',0,'',0,'B','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (266,'01B000266','Mixadin','01.001','','13','',0,'',0,'B','',1100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1100.00,0.00,1300.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (267,'01B000267','Mixagrip FB','01.001','','13','',0,'',0,'B','',1500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1500.00,0.00,1700.00,1700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (268,'01B000268','Mixagrip PL 6''s','01.001','','11','',0,'',0,'B','',1250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1250.00,0.00,1400.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (269,'01B000269','Mixagrip Tab ','01.001','','13','',0,'',0,'B','',1400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1400.00,0.00,1600.00,1600.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (270,'01B000270','Molexflu Sirup 60 ml','01.001','','02','',0,'',0,'B','',4200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4200.00,0.00,4700.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (271,'01B000271','Molexflu Tab 15x10','01.001','','13','',0,'',0,'B','',3050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3050.00,0.00,3500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (272,'01H000001','Acnes Sealing Gel','01.001','','17','',0,'',0,'H','',12700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12700.00,0.00,14500.00,15500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (273,'01H000002','Absolut FH 60 ml','01.001','','02','',0,'',0,'H','',14200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14200.00,0.00,15500.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (274,'01H000003','Acnes Facial Wash','01.001','','17','',0,'',0,'H','',12375.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12375.00,0.00,13600.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (275,'01H000004','Adem Sari (Rtg) 24''s','01.001','','11','',0,'',0,'H','',1450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1450.00,0.00,1600.00,1600.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (276,'01H000005','Akita Tab 10x10','01.001','','13','',0,'',0,'H','',1750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1750.00,0.00,2000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (277,'01H000006','Akurat TP','01.001','','13','',0,'',0,'H','',8250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8250.00,0.00,10000.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (278,'01H000007','Alangsari 6''s','01.001','','11','',0,'',0,'H','',1000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1000.00,0.00,1200.00,1200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (279,'01H000008','Alkohol 70 % 100 ml Molex ayus','01.001','','02','',0,'',0,'H','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,3850.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (280,'01H000009','Alphamol Tab 15x10''s','01.001','','13','',0,'',0,'H','',1950.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1950.00,0.00,2150.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (281,'01H000010','Amor Test Pack','01.001','','09','',0,'',0,'H','',6600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6600.00,0.00,7500.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (282,'01H000011','Anelat Tab (10x10''s)','01.001','','13','',0,'',0,'H','',11100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11100.00,0.00,12500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (283,'01H000012','Anlene Activit Vanilla/plain/coklat 250 gr','01.001','','05','',0,'',0,'H','',32000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32000.00,0.00,35500.00,35500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (284,'01H000013','Anlene Gold Plain/Coklat/vanila 600 gr','01.001','','05','',0,'',0,'H','',79000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,79000.00,0.00,87000.00,87000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (285,'01H000014','Anlene Gold Plain/Coklat/vanila250 gr','01.001','','05','',0,'',0,'H','',36000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36000.00,0.00,39500.00,39500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (286,'01H000015','Anlene Total 200 plain/coklt/Van','01.001','','05','',0,'',0,'H','',36000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36000.00,0.00,39500.00,39500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (287,'01H000016','Antangin Cair Junior','01.001','','11','',0,'',0,'H','',1050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1050.00,0.00,1300.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (288,'01H000017','Antangin JRG Cair 2x10''s','01.001','','11','',0,'',0,'H','',1650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1650.00,0.00,1800.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (289,'01H000018','Antangin JRG Tab 20x4''s','01.001','','13','',0,'',0,'H','',1650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1650.00,0.00,1800.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (290,'01H000019','Antangin Permen ','01.001','','11','',0,'',0,'H','',1100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1100.00,0.00,1300.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (291,'01H000020','Antasida Doen Erella 1000''s','01.001','','06','',0,'',0,'H','',42776.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,42776.00,0.00,47000.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (292,'01H000021','Antasida Doen erella 10x10''s','01.001','','13','',0,'',0,'H','',7750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7750.00,0.00,9000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (293,'01H000022','Antasida Doen Suspensi KF','01.001','','02','',0,'',0,'H','',3850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3850.00,0.00,4300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (294,'01H000023','Antasida Doen Suspensi Samparindo','01.001','','02','',0,'',0,'H','',2900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2900.00,0.00,3200.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (295,'01H000024','Antasida Sirup Rama','01.001','','02','',0,'',0,'H','',2700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2700.00,0.00,3000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (296,'01H000025','Apialys Drop','01.001','','02','',0,'',0,'H','',33000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33000.00,0.00,36300.00,37000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (297,'01H000026','Apialys sirup 100 ml','01.001','','02','',0,'',0,'H','',27500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27500.00,0.00,30300.00,31000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (298,'01H000027','Appeton Weight Gain 450 gr (Susu)','01.001','','07','',0,'',0,'H','',230000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,230000.00,0.00,253000.00,253000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (299,'01H000028','Appeton With Lysine 60 ml','01.001','','02','',0,'',0,'H','',82500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,82500.00,0.00,91000.00,91000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (300,'01H000029','Apple Botol Susu 4 OZ','01.001','','09','',0,'',0,'H','',11550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11550.00,0.00,12800.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (301,'01H000030','Apple Botol Susu 8Oz','01.001','','09','',0,'',0,'H','',14300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14300.00,0.00,15800.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (302,'01H000031','Apple Empeng','01.001','','09','',0,'',0,'H','',9075.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9075.00,0.00,10000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (303,'01H000032','Apple Sambung ASI Bocek','01.001','','09','',0,'',0,'H','',16000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16000.00,0.00,17600.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (304,'01H000033','Apple Sambung Puting','01.001','','09','',0,'',0,'H','',12100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12100.00,0.00,13300.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (305,'01H000034','Apple sedotan Ingus','01.001','','09','',0,'',0,'H','',10450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10450.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (306,'01H000035','Apple Sikat botol','01.001','','09','',0,'',0,'H','',18975.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18975.00,0.00,20900.00,21000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (307,'01H000036','Apple Sikat Lidah','01.001','','09','',0,'',0,'H','',10500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10500.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (308,'01H000037','Asepso','01.001','','09','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (309,'01H000038','Asifit 30''s','01.001','','02','',0,'',0,'H','',56400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,56400.00,0.00,62600.00,63000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (310,'01H000039','Aspilet Tab 10x10','01.001','','13','',0,'',0,'H','',5850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5850.00,0.00,6500.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (311,'01H000040','Asthin Force 18''s','01.001','','15','',0,'',0,'H','',7150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7150.00,0.00,7800.00,7800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (312,'01H000041','Atmacid Tab 10x10''s','01.001','','13','',0,'',0,'H','',1550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1550.00,0.00,1700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (313,'01H000042','Balpirik Kayu Putih/kerik','01.001','','02','',0,'',0,'H','',4670.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4670.00,0.00,5200.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (314,'01H000043','Balpirik Merah','01.001','','09','',0,'',0,'H','',4875.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4875.00,0.00,5400.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (315,'01H000044','Balsem Badak 20 gr','01.001','','09','',0,'',0,'H','',4458.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4458.00,0.00,5000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (316,'01H000045','Balsem Geliga 10 gr','01.001','','09','',0,'',0,'H','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (317,'01H000046','Balsem Geliga 20 gr','01.001','','09','',0,'',0,'H','',5850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5850.00,0.00,6500.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (318,'01H000047','Balsem Geliga 40 gr','01.001','','09','',0,'',0,'H','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,12600.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (319,'01H000048','Balsem K3 20 gr','01.001','','02','',0,'',0,'H','',6000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6000.00,0.00,6600.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (320,'01H000049','Balsem K3 36gr','01.001','','02','',0,'',0,'H','',10300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10300.00,0.00,11400.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (321,'01H000050','Balsem Lang 20 gr','01.001','','09','',0,'',0,'H','',5700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5700.00,0.00,6300.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (322,'01H000051','Balsem Lang 40 gr','01.001','','09','',0,'',0,'H','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,12700.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (323,'01H000052','Balsem Lion Head 20 gr','01.001','','09','',0,'',0,'H','',6500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6500.00,0.00,7100.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (324,'01H000053','Balsem Rheumason Hijau','01.001','','09','',0,'',0,'H','',3833.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3833.00,0.00,4200.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (325,'01H000054','Balsem Tiger/Macan putih','01.001','','02','',0,'',0,'H','',15500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15500.00,0.00,17000.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (326,'01H000055','Balsem Tjingtjau 20 gr','01.001','','09','',0,'',0,'H','',8833.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8833.00,0.00,9700.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (327,'01H000056','Balsem Tjingtjau 40 gr ','01.001','','09','',0,'',0,'H','',13125.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13125.00,0.00,14500.00,14500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (328,'01H000057','Batugin Elixir 120','01.001','','09','',0,'',0,'H','',18200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18200.00,0.00,20000.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (329,'01H000058','Batugin Elixir 300','01.001','','09','',0,'',0,'H','',32000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32000.00,0.00,35200.00,35500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (330,'01H000059','Bebita Salisil Talk','01.001','','02','',0,'',0,'H','',2400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2400.00,0.00,2700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (331,'01H000060','Becombion Sirup','01.001','','02','',0,'',0,'H','',48000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,48000.00,0.00,52800.00,53000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (332,'01H000061','Bedak Bayi Nellco','01.001','','02','',0,'',0,'H','',2700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2700.00,0.00,3000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (333,'01H000062','Bedak Marcks Creme/putih','01.001','','09','',0,'',0,'H','',8075.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8075.00,0.00,9000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (334,'01H000063','Berlosid sirup','01.001','','02','',0,'',0,'H','',4700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4700.00,0.00,5200.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (335,'01H000064','Bersih Darah KB/Capsida','01.001','','02','',0,'',0,'H','',8750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8750.00,0.00,9600.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (336,'01H000065','Betadin Sabun Cair 100 ml','01.001','','02','',0,'',0,'H','',27000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27000.00,0.00,29700.00,30000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (337,'01H000066','Bigen Semir','01.001','','11','',0,'',0,'H','',12500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12500.00,0.00,14000.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (338,'01H000067','Bintangin (Bintang 7 Masuk angin)','01.001','','11','',0,'',0,'H','',1555.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1555.00,0.00,1700.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (339,'01H000068','Bio curliv 5x6''s','01.001','','13','',0,'',0,'H','',38600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,38600.00,0.00,42500.00,43000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (340,'01H000069','Biogesic sirup 60 ml','01.001','','02','',0,'',0,'H','',19250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19250.00,0.00,21200.00,21500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (341,'01H000070','Biogesic Tab 10x10','01.001','','13','',0,'',0,'H','',1670.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1670.00,0.00,1900.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (342,'01H000071','Biolysin kids All Variant','01.001','','02','',0,'',0,'H','',8650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8650.00,0.00,9500.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (343,'01H000072','Biolysin sir 60 ml','01.001','','02','',0,'',0,'H','',7400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7400.00,0.00,9700.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (344,'01H000073','Biolysin smart sir 60 ml','01.001','','02','',0,'',0,'H','',9700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9700.00,0.00,10900.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (345,'01H000074','Biolysin Tab 10x10','01.001','','13','',0,'',0,'H','',24800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24800.00,0.00,30500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (346,'01H000075','Bioprost 3x10''s','01.001','','13','',0,'',0,'H','',33300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33300.00,0.00,36700.00,37000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (347,'01H000076','Bioralit 25''s','01.001','','11','',0,'',0,'H','',550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,550.00,0.00,600.00,700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (348,'01H000077','Biovision Capsul 3x10''s','01.001','','13','',0,'',0,'H','',21400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21400.00,0.00,24000.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (349,'01H000078','Braito TM Original','01.001','','02','',0,'',0,'H','',6200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6200.00,0.00,7000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (350,'01H000079','Caladin Bedak 100','01.001','','02','',0,'',0,'H','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,12700.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (351,'01H000080','Caladin Lotio 60','01.001','','02','',0,'',0,'H','',10500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10500.00,0.00,11500.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (352,'01H000081','Caladin Lotio 95','01.001','','02','',0,'',0,'H','',15500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15500.00,0.00,17000.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (353,'01H000082','Caladin Powder 60 gr','01.001','','02','',0,'',0,'H','',7500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7500.00,0.00,8200.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (354,'01H000083','Caladine Powder Active 60 gr','01.001','','02','',0,'',0,'H','',6500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6500.00,0.00,7200.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (355,'01H000084','Calcifar plus Tab 10x10''s','01.001','','13','',0,'',0,'H','',12900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12900.00,0.00,14500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (356,'01H000085','Calcifar Tab 10x10''s','01.001','','13','',0,'',0,'H','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,12700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (357,'01H000086','Calcusol 30''s','01.001','','02','',0,'',0,'H','',22500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22500.00,0.00,25000.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (358,'01H000087','Calcusol 50''s','01.001','','02','',0,'',0,'H','',37500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,37500.00,0.00,41300.00,41500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (359,'01H000088','Carsida Sirup','01.001','','02','',0,'',0,'H','',4400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4400.00,0.00,4850.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (360,'01H000089','Carsida Tab 10x10''s','01.001','','13','',0,'',0,'H','',17600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17600.00,0.00,19500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (361,'01H000090','Cavicur Tab 10x10''s','01.001','','13','',0,'',0,'H','',39600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,39600.00,0.00,45000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (362,'01H000091','Caviplex Drop','01.001','','02','',0,'',0,'H','',2800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2800.00,0.00,3200.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (363,'01H000092','Caviplex Sirup','01.001','','02','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (364,'01H000093','Caviplex Tab 10x10''s','01.001','','13','',0,'',0,'H','',30000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,30000.00,0.00,33000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (365,'01H000094','CDR Eff','01.001','','17','',0,'',0,'H','',31800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31800.00,0.00,35000.00,35500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (366,'01H000095','Cdr Fortos','01.001','','17','',0,'',0,'H','',31500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31500.00,0.00,34700.00,35000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (367,'01H000096','Cendo Lyteers  TM 15 cc','01.001','','02','',0,'',0,'H','',22900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22900.00,0.00,25200.00,26000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (368,'01H000097','Cendo Protagenta MD ','01.001','','13','',0,'',0,'H','',36500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36500.00,0.00,41500.00,42000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (369,'01H000098','Cerebrofort gold Jrk/strw 100','01.001','','02','',0,'',0,'H','',13500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13500.00,0.00,15000.00,15500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (370,'01H000099','Cerebrofort Gold Jrk/strw 200 ml','01.001','','02','',0,'',0,'H','',26750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26750.00,0.00,29500.00,30000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (371,'01H000100','Cerebrofovit Excel','01.001','','05','',0,'',0,'H','',13600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13600.00,0.00,15000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (372,'01H000101','Chi Wa cing','01.001','','11','',0,'',0,'H','',1500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1500.00,0.00,1700.00,1700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (373,'01H000102','Chili Plester Besar','01.001','','09','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (374,'01H000103','Chili Plester Kecil','01.001','','09','',0,'',0,'H','',1400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1400.00,0.00,1600.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (375,'01H000104','Copal Balm 25 gr','01.001','','09','',0,'',0,'H','',11800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11800.00,0.00,13000.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (376,'01H000105','Cotton bud Cinderalla  60','01.001','','09','',0,'',0,'H','',1600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1600.00,0.00,1800.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (377,'01H000106','Cotton bud Cinderalla 50','01.001','','09','',0,'',0,'H','',1300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1300.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (378,'01H000107','Cotton Bud Cinderella 100','01.001','','09','',0,'',0,'H','',2600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2600.00,0.00,3000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (379,'01H000108','Counterpain 15 gr','01.001','','17','',0,'',0,'H','',19800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19800.00,0.00,21000.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (380,'01H000109','Counterpain 30 gr','01.001','','17','',0,'',0,'H','',30910.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,30910.00,0.00,34000.00,34000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (381,'01H000110','Counterpain 5 gr','01.001','','17','',0,'',0,'H','',8000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8000.00,0.00,8800.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (382,'01H000111','Counterpain 60 gr','01.001','','17','',0,'',0,'H','',52700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,52700.00,0.00,58000.00,58000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (383,'01H000112','Counterpain cool 15 gr','01.001','','17','',0,'',0,'H','',18810.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18810.00,0.00,20800.00,21000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (384,'01H000113','Counterpain cool 30gr','01.001','','17','',0,'',0,'H','',32900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32900.00,0.00,36200.00,36500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (385,'01H000114','Ctm Pim 24''s','01.001','','13','',0,'',0,'H','',550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,550.00,0.00,700.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (386,'01H000115','Cuka Apel Tahesta','01.001','','02','',0,'',0,'H','',28000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28000.00,0.00,31000.00,31000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (387,'01H000116','Curbion Kids Emuls','01.001','','02','',0,'',0,'H','',4350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4350.00,0.00,5000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (388,'01H000117','Curcuma Grow Emulsion 200 ml','01.001','','02','',0,'',0,'H','',18350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18350.00,0.00,20500.00,21000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (389,'01H000118','Curcuma imuns 60 ml','01.001','','02','',0,'',0,'H','',13300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13300.00,0.00,14700.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (390,'01H000119','Curcuma Plus Sharpy 60 jrk/strw','01.001','','02','',0,'',0,'H','',9600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9600.00,0.00,10600.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (391,'01H000120','Curcuma Plus Sirup 60 ml','01.001','','02','',0,'',0,'H','',8600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8600.00,0.00,9800.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (392,'01H000121','Curcuma Tab 10x10''s','01.001','','13','',0,'',0,'H','',7100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7100.00,0.00,7800.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (393,'01H000122','Curvit 120 ml Sirup','01.001','','02','',0,'',0,'H','',27000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27000.00,0.00,29700.00,30000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (394,'01H000123','Curvit 60 ml sirup','01.001','','02','',0,'',0,'H','',21560.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21560.00,0.00,23700.00,24000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (395,'01H000124','Curvit CL emulsion ','01.001','','02','',0,'',0,'H','',42900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,42900.00,0.00,47500.00,48000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (396,'01H000125','Elkana CL sirup','01.001','','02','',0,'',0,'H','',45000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,45000.00,0.00,49500.00,50000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (397,'01H000126','Elkana Sirup 60 ml','01.001','','02','',0,'',0,'H','',20250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20250.00,0.00,22500.00,22500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (398,'01H000127','Elkana Tab 10x10''s','01.001','','13','',0,'',0,'H','',6930.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6930.00,0.00,7700.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (399,'01H000128','Em Capsul 12''s','01.001','','05','',0,'',0,'H','',8500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8500.00,0.00,9500.00,9500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (400,'01H000129','Enatin Blister 9''s','01.001','','13','',0,'',0,'H','',11440.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11440.00,0.00,12500.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (401,'01H000130','Enervon C 30''s','01.001','','02','',0,'',0,'H','',28500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28500.00,0.00,31300.00,31500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (402,'01H000131','Enervon C 4''s','01.001','','13','',0,'',0,'H','',3800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3800.00,0.00,4200.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (403,'01H000132','Enkasari','01.001','','02','',0,'',0,'H','',15400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15400.00,0.00,17000.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (404,'01H000133','Entrasol Active 160 Cokl/Van','01.001','','05','',0,'',0,'H','',24400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24400.00,0.00,26800.00,27000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (405,'01H000134','Entrasol Gold 185 Cokl/Van','01.001','','05','',0,'',0,'H','',28875.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28875.00,0.00,31800.00,32000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (406,'01H000135','Entrostop herbal anak 6''s','01.001','','11','',0,'',0,'H','',1210.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1210.00,0.00,1400.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (407,'01H000136','Entrostop Tab 2x12''s','01.001','','13','',0,'',0,'H','',4400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4400.00,0.00,5000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (408,'01H000137','Envios Sirup ','01.001','','02','',0,'',0,'H','',3225.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3225.00,0.00,3700.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (409,'01H000138','Enzimfort 10x10''s','01.001','','13','',0,'',0,'H','',13200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13200.00,0.00,14500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (410,'01H000139','Enzyplex tab','01.001','','13','',0,'',0,'H','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,3500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (411,'01H000140','Erlamol 10x10','01.001','','03','',0,'',0,'H','',8800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8800.00,0.00,10000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (412,'01H000141','Ester C 12x4''s','01.001','','13','',0,'',0,'H','',4675.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4675.00,0.00,5200.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (413,'01H000142','Ester C 30''s','01.001','','02','',0,'',0,'H','',34100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34100.00,0.00,37500.00,38000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (414,'01H000143','Etabion Tab 10x10''s','01.001','','13','',0,'',0,'H','',16000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16000.00,0.00,19000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (415,'01H000144','Ever  E 250 12''s','01.001','','05','',0,'',0,'H','',22600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22600.00,0.00,25000.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (416,'01H000145','Ever E  250 Botol','01.001','','02','',0,'',0,'H','',53500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,53500.00,0.00,58850.00,59000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (417,'01H000146','Ever E 250 isi 6','01.001','','13','',0,'',0,'H','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,12800.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (418,'01H000147','Extra joss kuning','01.001','','11','',0,'',0,'H','',625.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,625.00,0.00,700.00,700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (419,'01H000148','Fasidol Forte sirup','01.001','','02','',0,'',0,'H','',3700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3700.00,0.00,4200.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (420,'01H000149','Fasidol Sirup','01.001','','02','',0,'',0,'H','',2850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2850.00,0.00,3300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (421,'01H000150','Fasidol Tab 10x10','01.001','','13','',0,'',0,'H','',12300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12300.00,0.00,13500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (422,'01H000151','Fatigon C Plus 15x4','01.001','','13','',0,'',0,'H','',4050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4050.00,0.00,4500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (423,'01H000152','Fatigon spirit 6x5''s','01.001','','13','',0,'',0,'H','',4851.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4851.00,0.00,5500.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (424,'01H000153','Fatigon Viro tab 6x5''s','01.001','','13','',0,'',0,'H','',3600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3600.00,0.00,4000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (425,'01H000154','Feminax Lancar Haid','01.001','','11','',0,'',0,'H','',1600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1600.00,0.00,1800.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (426,'01H000155','Fevrin drop','01.001','','02','',0,'',0,'H','',17200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17200.00,0.00,19000.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (427,'01H000156','Fevrin Sirup 60 ml','01.001','','02','',0,'',0,'H','',11200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11200.00,0.00,14000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (428,'01H000157','Fevrin Tab 10x10','01.001','','13','',0,'',0,'H','',3950.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3950.00,0.00,4500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (429,'01H000158','Firdaus Oil','01.001','','02','',0,'',0,'H','',41000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,41000.00,0.00,45100.00,45500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (430,'01H000159','Fitkom Gummi Calcium','01.001','','05','',0,'',0,'H','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16500.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (431,'01H000160','Fitkom Gummi Fruit & Vegget','01.001','','05','',0,'',0,'H','',17500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17500.00,0.00,20500.00,20500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (432,'01H000161','Fitkom Gummy Buah','01.001','','02','',0,'',0,'H','',13800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13800.00,0.00,15200.00,15500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (433,'01H000162','Fitkom Tab Anggur/Straw/Jeruk','01.001','','02','',0,'',0,'H','',12200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12200.00,0.00,13500.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (434,'01H000163','Folavit 10x10','01.001','','13','',0,'',0,'H','',7500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7500.00,0.00,8250.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (435,'01H000164','Fondazen 10x10''s','01.001','','13','',0,'',0,'H','',17400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17400.00,0.00,19200.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (436,'01H000165','Foot Care 30 gr','01.001','','17','',0,'',0,'H','',15700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15700.00,0.00,17300.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (437,'01H000166','Fora De Cologne','01.001','','02','',0,'',0,'H','',9000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9000.00,0.00,10000.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (438,'01H000167','Fora Kemiri','01.001','','02','',0,'',0,'H','',6300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6300.00,0.00,7000.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (439,'01H000168','Fora Urang Aring','01.001','','02','',0,'',0,'H','',6300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6300.00,0.00,7000.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (440,'01H000169','Formula Pasta Gigi 75 gr','01.001','','17','',0,'',0,'H','',2700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2700.00,0.00,3000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (441,'01H000170','Fruit 18 JR','01.001','','02','',0,'',0,'H','',99000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,99000.00,0.00,114000.00,115000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (442,'01H000171','Fungiderm 5gr','01.001','','17','',0,'',0,'H','',10200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10200.00,0.00,11300.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (443,'01H000172','Daktarin 10 gr','01.001','','17','',0,'',0,'H','',33600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33600.00,0.00,36500.00,37000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (444,'01H000173','Daktarin Diapers 10 gr','01.001','','17','',0,'',0,'H','',50500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,50500.00,0.00,56000.00,56000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (445,'01H000174','Dapyrin Tab 20x10''s','01.001','','13','',0,'',0,'H','',28500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28500.00,0.00,32000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (446,'01H000175','Darial','01.001','','11','',0,'',0,'H','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,3500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (447,'01H000176','Darsi 12''s','01.001','','05','',0,'',0,'H','',8500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8500.00,0.00,9500.00,9500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (448,'01H000177','Decadryl sir 120ml','01.001','','02','',0,'',0,'H','',13300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13300.00,0.00,14700.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (449,'01H000178','Decadryl sir 60ml','01.001','','02','',0,'',0,'H','',10500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10500.00,0.00,11600.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (450,'01H000179','Decubal Cream','01.001','','17','',0,'',0,'H','',19800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19800.00,0.00,22000.00,23000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (451,'01H000180','Degirol tab 25x4','01.001','','13','',0,'',0,'H','',2600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2600.00,0.00,3000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (452,'01H000181','Dermatix Ultra 7 gr','01.001','','17','',0,'',0,'H','',130800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,130800.00,0.00,143800.00,144000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (453,'01H000182','Dettol Cair 100','01.001','','02','',0,'',0,'H','',11250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11250.00,0.00,12500.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (454,'01H000183','Dettol Cair 250','01.001','','02','',0,'',0,'H','',26500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26500.00,0.00,29500.00,29500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (455,'01H000184','Dettol Cair 50','01.001','','02','',0,'',0,'H','',4850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4850.00,0.00,5500.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (456,'01H000185','Dettol Sabun 110  gr','01.001','','09','',0,'',0,'H','',3865.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3865.00,0.00,4300.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (457,'01H000186','Dettol Sabun 70 gr','01.001','','09','',0,'',0,'H','',2650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2650.00,0.00,3000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (458,'01H000187','Dettol Talk 75 gr','01.001','','02','',0,'',0,'H','',9100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9100.00,0.00,10000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (459,'01H000188','Dexanta Tab 10x10''s','01.001','','13','',0,'',0,'H','',16700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16700.00,0.00,18500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (460,'01H000189','Diabetasol 180 gr Cokl/Vanila','01.001','','05','',0,'',0,'H','',38000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,38000.00,0.00,41800.00,42000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (461,'01H000190','Diabetasol 600 gr Cokl/Vanila','01.001','','05','',0,'',0,'H','',125500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,125500.00,0.00,138000.00,138000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (462,'01H000191','Diabetasol Zero Calori 25''s','01.001','','05','',0,'',0,'H','',13700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13700.00,0.00,15000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (463,'01H000192','Diapet','01.001','','13','',0,'',0,'H','',1525.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1525.00,0.00,1700.00,1800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (464,'01H000193','Die da yo cing','01.001','','02','',0,'',0,'H','',18000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18000.00,0.00,19800.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (465,'01H000194','Dragon Gosok H1','01.001','','09','',0,'',0,'H','',5600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5600.00,0.00,6200.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (466,'01H000195','Dragon Gosok H2','01.001','','09','',0,'',0,'H','',4300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4300.00,0.00,4700.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (467,'01H000196','Dragon Gosok HSB ','01.001','','09','',0,'',0,'H','',17500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17500.00,0.00,19300.00,19500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (468,'01H000197','Dumocalcin 3x10''s','01.001','','13','',0,'',0,'H','',4600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4600.00,0.00,5000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (469,'01H000198','Durol Tonik ','01.001','','02','',0,'',0,'H','',16850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16850.00,0.00,19000.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (470,'01H000199','Ichtyol Zk  Afi 12''s','01.001','','09','',0,'',0,'H','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (471,'01H000200','Ichtyol zk Cito 24''s','01.001','','02','',0,'',0,'H','',3850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3850.00,0.00,4200.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (472,'01H000201','Igastrum New Formula Sirup','01.001','','02','',0,'',0,'H','',31350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31350.00,0.00,34500.00,35000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (473,'01H000202','Igastrum Sirup (Kuning)','01.001','','02','',0,'',0,'H','',14850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14850.00,0.00,16500.00,16500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (474,'01H000203','Imboost Force Sirup 60 ml','01.001','','02','',0,'',0,'H','',53600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,53600.00,0.00,59000.00,60000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (475,'01H000204','Imboost Sirup 60 ml','01.001','','02','',0,'',0,'H','',29600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29600.00,0.00,32500.00,33000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (476,'01H000205','Imboost Tab 5x10','01.001','','13','',0,'',0,'H','',29600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29600.00,0.00,32700.00,33000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (477,'01H000206','Imunos Sirup','01.001','','02','',0,'',0,'H','',52250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,52250.00,0.00,57500.00,57500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (478,'01H000207','imunos Tab 5x4','01.001','','15','',0,'',0,'H','',5363.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5363.00,0.00,5900.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (479,'01H000208','Insto 7,5ml','01.001','','02','',0,'',0,'H','',9200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9200.00,0.00,10200.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (480,'01H000209','Insto Moisturiser 7,5 ml','01.001','','02','',0,'',0,'H','',9200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9200.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (481,'01H000210','Inzana','01.001','','13','',0,'',0,'H','',700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,700.00,0.00,800.00,800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (482,'01H000211','Inzana Masuk Angin Cair','01.001','','11','',0,'',0,'H','',750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,750.00,0.00,900.00,900.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (483,'01H000212','Itramol Sirup','01.001','','02','',0,'',0,'H','',2400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2400.00,0.00,2900.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (484,'01H000213','Gandapura Lang Besar (60 ml)','01.001','','02','',0,'',0,'H','',9000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9000.00,0.00,10000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (485,'01H000214','Gandapura Lang Kecil (30 ml)','01.001','','02','',0,'',0,'H','',5200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5200.00,0.00,5800.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (486,'01H000215','Garam Lososa 250 gr','01.001','','09','',0,'',0,'H','',10450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10450.00,0.00,11500.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (487,'01H000216','Garam Lososa 500 gr','01.001','','09','',0,'',0,'H','',19250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19250.00,0.00,21500.00,21500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (488,'01H000217','Garcia Capsul','01.001','','02','',0,'',0,'H','',88500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,88500.00,0.00,97500.00,98000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (489,'01H000218','Gasero','01.001','','11','',0,'',0,'H','',1400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1400.00,0.00,1600.00,1600.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (490,'01H000219','Gastran Tab 25x4','01.001','','13','',0,'',0,'H','',1780.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1780.00,0.00,2000.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (491,'01H000220','Gastrucid Sirup 24''s','01.001','','02','',0,'',0,'H','',4355.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4355.00,0.00,4800.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (492,'01H000221','Gastrucid Tab 10x10','01.001','','13','',0,'',0,'H','',18500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18500.00,0.00,20500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (493,'01H000222','Geliga  cream 30 gr','01.001','','09','',0,'',0,'H','',10500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10500.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (494,'01H000223','Gentian Violet cito 24''s','01.001','','02','',0,'',0,'H','',2150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2150.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (495,'01H000224','Giovan ASF 100 ml ( Biru)','01.001','','02','',0,'',0,'H','',8100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8100.00,0.00,9000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (496,'01H000225','Giovan PK 100 ml ( Pink)','01.001','','02','',0,'',0,'H','',8100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8100.00,0.00,9000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (497,'01H000226','Glukosa Strip ET 25''s','01.001','','05','',0,'',0,'H','',70000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,70000.00,0.00,77000.00,80000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (498,'01H000227','Glukosamin IF 30''s','01.001','','15','',0,'',0,'H','',2150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2150.00,0.00,2400.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (499,'01H000228','Glyderm Cream','01.001','','17','',0,'',0,'H','',118800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,118800.00,0.00,130700.00,132000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (500,'01H000229','Gom Cito 24''s','01.001','','02','',0,'',0,'H','',2150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2150.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00','');
COMMIT;

#
# Data for the `data_barang_master` table  (LIMIT 501,500)
#

INSERT INTO `data_barang_master` (`barang_id`, `barang_kode`, `barang_nama`, `barang_supplier`, `barang_jenis`, `barang_satuan_kecil`, `barang_satuan_tengah`, `barang_satuan_tengah_jumlah`, `barang_satuan_besar`, `barang_satuan_besar_jumlah`, `barang_logo`, `barang_keterangan`, `barang_harga_beli`, `barang_harga_beli_d1`, `barang_harga_beli_d2`, `barang_harga_beli_d3`, `barang_harga_beli_klaim`, `barang_harga_jual`, `barang_harga_jual_d1`, `barang_harga_jual_d2`, `barang_harga_jual_d3`, `barang_harga_jual_d4`, `barang_harga_jual_d5`, `barang_harga_jual_mt`, `barang_harga_jual_horeka`, `barang_harga_jual_rita`, `barang_harga_jual_discount`, `barang_stok_awal`, `barang_stok_minimal`, `barang_berat`, `barang_status`, `barang_status_pajak`, `barang_reg_date`, `barang_reg_alias`, `barang_upd_date`, `barang_upd_alias`) VALUES

  (501,'01H000230','GPU 30 Ml (Kecil)','01.001','','02','',0,'',0,'H','',5875.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5875.00,0.00,6500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (502,'01H000231','GPU 60 ml (Besar)','01.001','','02','',0,'',0,'H','',10800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10800.00,0.00,12000.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (503,'01H000232','Guanistrep Sirup','01.001','','02','',0,'',0,'H','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,3650.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (504,'01H000233','Haiping Capsul','01.001','','11','',0,'',0,'H','',12375.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12375.00,0.00,13600.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (505,'01H000234','Haiping Serbuk','01.001','','11','',0,'',0,'H','',3125.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3125.00,0.00,3500.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (506,'01H000235','Hansaplast Koyo 10''s','01.001','','11','',0,'',0,'H','',5150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5150.00,0.00,5700.00,5700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (507,'01H000236','Hemaviton Action 10x5''s','01.001','','13','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (508,'01H000237','Hemaviton Jreng 10''s','01.001','','11','',0,'',0,'H','',550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,550.00,0.00,600.00,600.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (509,'01H000238','Hemaviton Stamina 10x5''s ','01.001','','13','',0,'',0,'H','',4500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4500.00,0.00,5000.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (510,'01H000239','Hemorid Capsul 3x10','01.001','','13','',0,'',0,'H','',7200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7200.00,0.00,8000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (511,'01H000240','Herbamon','01.001','','13','',0,'',0,'H','',8500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8500.00,0.00,9400.00,9500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (512,'01H000241','Herocyn 150 Gr','01.001','','02','',0,'',0,'H','',11000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11000.00,0.00,12100.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (513,'01H000242','Herocyn 75 Gr','01.001','','02','',0,'',0,'H','',7000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7000.00,0.00,7700.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (514,'01H000243','Herocyn Baby 100','01.001','','02','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (515,'01H000244','Hexos Permen','01.001','','11','',0,'',0,'H','',1200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1200.00,0.00,1300.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (516,'01H000245','Hi Bone 30''s','01.001','','02','',0,'',0,'H','',92400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,92400.00,0.00,101700.00,102000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (517,'01H000246','Hofungsan Kupu','01.001','','02','',0,'',0,'H','',2450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2450.00,0.00,3000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (518,'01H000247','Hormoviton Capsul ','01.001','','13','',0,'',0,'H','',5250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5250.00,0.00,5800.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (519,'01H000248','Hot In Cream','01.001','','09','',0,'',0,'H','',14600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14600.00,0.00,16000.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (520,'01H000249','Hot In Cream (Sak)','01.001','','11','',0,'',0,'H','',800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,800.00,0.00,900.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (521,'01H000250','Hufabion Tab 10x10''s','01.001','','13','',0,'',0,'H','',18200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18200.00,0.00,20000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (522,'01H000251','Hufagesic Drop','01.001','','02','',0,'',0,'H','',6350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6350.00,0.00,7000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (523,'01H000252','Hufagesic Tab 1000''s','01.001','','06','',0,'',0,'H','',66300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,66300.00,0.00,73000.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (524,'01H000253','Hufagesic Tab 10x10''s','01.001','','13','',0,'',0,'H','',12200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12200.00,0.00,13500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (525,'01H000254','Hufalysin plus /Kuning','01.001','','02','',0,'',0,'H','',9100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9100.00,0.00,10200.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (526,'01H000255','Hufalysin Sirup ijo','01.001','','02','',0,'',0,'H','',7250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7250.00,0.00,8000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (527,'01H000256','Hufamag Plus Sirup','01.001','','02','',0,'',0,'H','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (528,'01H000257','Hufamag Plus Tab (Kaleng)','01.001','','06','',0,'',0,'H','',40300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,40300.00,0.00,44700.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (529,'01H000258','Hufamag Plus Tab 10x10''s','01.001','','13','',0,'',0,'H','',17000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17000.00,0.00,18700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (530,'01H000259','Hufanaceae Sirup','01.001','','02','',0,'',0,'H','',5300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5300.00,0.00,5900.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (531,'01H000260','Hufavicee 10x10''s','01.001','','13','',0,'',0,'H','',5960.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5960.00,0.00,6600.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (532,'01H000261','Huki Botol  Super Deluxer 4 OZ','01.001','','02','',0,'',0,'H','',18500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18500.00,0.00,20350.00,20500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (533,'01H000262','Huki Botol  Super Deluxer 8 OZ','01.001','','02','',0,'',0,'H','',19500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19500.00,0.00,21500.00,21500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (534,'01H000263','Huki Botol 140 Wide neck','01.001','','09','',0,'',0,'H','',32000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32000.00,0.00,35500.00,35500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (535,'01H000264','Huki botol Shaped 60 ml','01.001','','09','',0,'',0,'H','',17300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17300.00,0.00,19000.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (536,'01H000265','Huki Botol Standar  8 OZ','01.001','','02','',0,'',0,'H','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,20500.00,21000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (537,'01H000266','Huki Botol Standar 4 OZ','01.001','','02','',0,'',0,'H','',17325.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17325.00,0.00,19000.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (538,'01H000267','Huki botol Standar Tapered 60 ml','01.001','','09','',0,'',0,'H','',15750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15750.00,0.00,17300.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (539,'01H000268','Huki Botol Standar Tapered4 OZ','01.001','','09','',0,'',0,'H','',15750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15750.00,0.00,17300.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (540,'01H000269','Huki Cotton Bud 100''s','01.001','','11','',0,'',0,'H','',3800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3800.00,0.00,4200.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (541,'01H000270','Huki Cotton Bud 50''s','01.001','','11','',0,'',0,'H','',2250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2250.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (542,'01H000271','Huki Cotton Bud Baby EF 100''s','01.001','','11','',0,'',0,'H','',4300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4300.00,0.00,4800.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (543,'01H000272','HUKI Cotton Bud Pot 50''s','01.001','','09','',0,'',0,'H','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,3850.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (544,'01H000273','HUKI Cotton Bud Pot 80''s','01.001','','09','',0,'',0,'H','',4800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4800.00,0.00,5300.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (545,'01H000274','Huki Dot Silicone S/M/L (Dus)','01.001','','09','',0,'',0,'H','',9500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9500.00,0.00,10500.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (546,'01H000275','Huki Empeng Silicon ','01.001','','09','',0,'',0,'H','',15500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15500.00,0.00,17000.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (547,'01H000276','Huki Sikat Botol','01.001','','09','',0,'',0,'H','',25000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,25000.00,0.00,27500.00,27500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (548,'01H000277','Huki Sikat Lidah','01.001','','09','',0,'',0,'H','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16500.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (549,'01H000278','Jamu anik Kapsul 10''s','01.001','','13','',0,'',0,'H','',1250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1250.00,0.00,1400.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (550,'01H000279','Jamu Buyung Upik','01.001','','11','',0,'',0,'H','',550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,550.00,0.00,700.00,700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (551,'01H000280','Jamu Sariawan Tab','01.001','','13','',0,'',0,'H','',1050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1050.00,0.00,1200.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (552,'01H000281','Jesscool 20''s ','01.001','','11','',0,'',0,'H','',1575.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1575.00,0.00,1800.00,1800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (553,'01H000282','JF Sulfur hijau  65 gr','01.001','','09','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (554,'01H000283','JF Sulfur ijo  90 gr','01.001','','09','',0,'',0,'H','',7370.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7370.00,0.00,8100.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (555,'01H000284','JF Sulfur kuning  65 gr','01.001','','09','',0,'',0,'H','',5170.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5170.00,0.00,5700.00,5700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (556,'01H000285','JF Sulfur kuning  90 gr','01.001','','09','',0,'',0,'H','',7370.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7370.00,0.00,8500.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (557,'01H000286','Joint Herbal 3x10''s','01.001','','13','',0,'',0,'H','',20200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20200.00,0.00,22200.00,22500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (558,'01H000287','Jamu Anik serbuk','01.001','','11','',0,'',0,'H','',1100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1100.00,0.00,1200.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (559,'01H000288','L Bio','01.001','','11','',0,'',0,'H','',5370.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5370.00,0.00,5900.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (560,'01H000289','Lactacyd Baby/biru 150 ml','01.001','','02','',0,'',0,'H','',46350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,46350.00,0.00,51000.00,52000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (561,'01H000290','Lactacyd baby/biru 60 ml','01.001','','02','',0,'',0,'H','',19800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19800.00,0.00,21800.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (562,'01H000291','Lactacyd FH /pink 60 ml','01.001','','02','',0,'',0,'H','',19250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19250.00,0.00,21500.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (563,'01H000292','Lactamil Lactasi 200','01.001','','05','',0,'',0,'H','',34100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34100.00,0.00,37500.00,37500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (564,'01H000293','Lactamil Pregnasis 200 gr','01.001','','05','',0,'',0,'H','',34100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34100.00,0.00,37500.00,37500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (565,'01H000294','Lactamil pregnasis 400 gr','01.001','','05','',0,'',0,'H','',64000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,64000.00,0.00,70500.00,70500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (566,'01H000295','Lacto B 40''s','01.001','','11','',0,'',0,'H','',4050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4050.00,0.00,4500.00,4800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (567,'01H000296','Lafalos Plus Cream','01.001','','17','',0,'',0,'H','',13800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13800.00,0.00,15200.00,15500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (568,'01H000297','Lambucid Tab 20x10','01.001','','13','',0,'',0,'H','',33500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33500.00,0.00,36800.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (569,'01H000298','Lanamol Tab 10x10''s','01.001','','13','',0,'',0,'H','',1500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1500.00,0.00,1700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (570,'01H000299','Lanaya Anti Acne gel','01.001','','17','',0,'',0,'H','',17850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17850.00,0.00,20000.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (571,'01H000300','Lanaya Serum Vit C/ Whitening','01.001','','17','',0,'',0,'H','',49500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,49500.00,0.00,57500.00,58000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (572,'01H000301','Lancar ASI 5x6''s','01.001','','13','',0,'',0,'H','',5900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5900.00,0.00,6500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (573,'01H000302','Lang Inhaler','01.001','','09','',0,'',0,'H','',4800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4800.00,0.00,5300.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (574,'01H000303','Larutan Badak Jumbo','01.001','','02','',0,'',0,'H','',4750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4750.00,0.00,5300.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (575,'01H000304','Larutan K3 botol','01.001','','02','',0,'',0,'H','',2330.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2330.00,0.00,2600.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (576,'01H000305','Larutan K3 Jumbo','01.001','','02','',0,'',0,'H','',4600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4600.00,0.00,5000.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (577,'01H000306','Larutan K3 Kaleng','01.001','','06','',0,'',0,'H','',4000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4000.00,0.00,4500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (578,'01H000307','Lasegar Cap Badak Botol','01.001','','02','',0,'',0,'H','',2150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2150.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (579,'01H000308','Lasegar Cap Badak Kaleng','01.001','','06','',0,'',0,'H','',4100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4100.00,0.00,4500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (580,'01H000309','Laserin 30','01.001','','02','',0,'',0,'H','',2950.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2950.00,0.00,3500.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (581,'01H000310','Laserin 60 ml','01.001','','02','',0,'',0,'H','',6100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6100.00,0.00,6700.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (582,'01H000311','Laserin Dewasa 110 ml','01.001','','02','',0,'',0,'H','',11000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11000.00,0.00,12100.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (583,'01H000312','Laserin Madu 30','01.001','','02','',0,'',0,'H','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,4000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (584,'01H000313','Laserin Madu 60 ml','01.001','','02','',0,'',0,'H','',7100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7100.00,0.00,7800.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (585,'01H000314','Laxing','01.001','','13','',0,'',0,'H','',2200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2200.00,0.00,2500.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (586,'01H000315','Lelap','01.001','','13','',0,'',0,'H','',5850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5850.00,0.00,6500.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (587,'01H000316','Lexacrol Forte Sirup','01.001','','02','',0,'',0,'H','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,15000.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (588,'01H000317','Lexacrol Tab 15x10','01.001','','13','',0,'',0,'H','',51330.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,51330.00,0.00,56500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (589,'01H000318','Licokalk 1000''s (Kaleng)','01.001','','06','',0,'',0,'H','',67650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,67650.00,0.00,74500.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (590,'01H000319','Licokalk 500 mg 10x10''s','01.001','','13','',0,'',0,'H','',12700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12700.00,0.00,14000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (591,'01H000320','Linustop Strip','01.001','','13','',0,'',0,'H','',2650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2650.00,0.00,3000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (592,'01H000321','Listerin  Frest Burstt 80 ml','01.001','','02','',0,'',0,'H','',7050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7050.00,0.00,7800.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (593,'01H000322','Listerin Coolmint 80 ml','01.001','','02','',0,'',0,'H','',7050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7050.00,0.00,7800.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (594,'01H000323','Listerin Fresh Citrus 80 ml','01.001','','02','',0,'',0,'H','',7050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7050.00,0.00,7800.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (595,'01H000324','Listerine Coolmint 250','01.001','','02','',0,'',0,'H','',16720.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16720.00,0.00,18500.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (596,'01H000325','Livron Bplex  10x10''s','01.001','','13','',0,'',0,'H','',22000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22000.00,0.00,24500.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (597,'01H000326','Lotte TM 12''s','01.001','','02','',0,'',0,'H','',3625.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3625.00,0.00,4000.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (598,'01H000327','Lykurmin 100 ml','01.001','','02','',0,'',0,'H','',33000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33000.00,0.00,36300.00,36500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (599,'01H000328','LytaminSirup','01.001','','02','',0,'',0,'H','',3872.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3872.00,0.00,4300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (600,'01H000329','Kalpanax Cair ','01.001','','02','',0,'',0,'H','',2300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2300.00,0.00,2600.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (601,'01H000330','Kamilosan Oint','01.001','','17','',0,'',0,'H','',36000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36000.00,0.00,39700.00,40000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (602,'01H000331','Kanna 15gr','01.001','','17','',0,'',0,'H','',6400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6400.00,0.00,7300.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (603,'01H000332','Kanna 30gr','01.001','','17','',0,'',0,'H','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,15000.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (604,'01H000333','Kaotin suspensi','01.001','','02','',0,'',0,'H','',3150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3150.00,0.00,3500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (605,'01H000334','Kapas Potong Astra 40 gr','01.001','','09','',0,'',0,'H','',2700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2700.00,0.00,3000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (606,'01H000335','Kapas Potong Cinderella 60 gr','01.001','','11','',0,'',0,'H','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,4500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (607,'01H000336','Kapas Potong rona 40 gr','01.001','','09','',0,'',0,'H','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,3700.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (608,'01H000337','Kapsul Kosong OO','01.001','','09','',0,'',0,'H','',182.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,182.00,0.00,200.00,200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (609,'01H000338','Kapsul Stamina LT','01.001','','11','',0,'',0,'H','',26000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26000.00,0.00,28800.00,29000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (610,'01H000339','Kapsul Tuntas','01.001','','05','',0,'',0,'H','',4750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4750.00,0.00,5500.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (611,'01H000340','Kasa DRC 16x16','01.001','','09','',0,'',0,'H','',10000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10000.00,0.00,11000.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (612,'01H000341','Kejibeling Balatif','01.001','','13','',0,'',0,'H','',22500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22500.00,0.00,27500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (613,'01H000342','Keling Capsul 10x10','01.001','','13','',0,'',0,'H','',5800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5800.00,0.00,6500.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (614,'01H000343','Kertas Puyer besar 500''s','01.001','','11','',0,'',0,'H','',8000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8000.00,0.00,9000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (615,'01H000344','Kertas Puyer Kecil  500''s','01.001','','11','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,7000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (616,'01H000345','Kiranti Datang Bulan','01.001','','02','',0,'',0,'H','',3700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3700.00,0.00,4000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (617,'01H000346','Kiranti Datang Bulan juice','01.001','','02','',0,'',0,'H','',4500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4500.00,0.00,5000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (618,'01H000347','Komix Kid','01.001','','11','',0,'',0,'H','',533.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,533.00,0.00,700.00,800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (619,'01H000348','Kondom Durex Extrasafe 3''s','01.001','','09','',0,'',0,'H','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,13200.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (620,'01H000349','Kondom Durex Strawberry 3''s','01.001','','09','',0,'',0,'H','',12500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12500.00,0.00,13800.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (621,'01H000350','Kondom Durex Together 3''s','01.001','','09','',0,'',0,'H','',9100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9100.00,0.00,10000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (622,'01H000351','Kondom Fiesta 3''s','01.001','','11','',0,'',0,'H','',0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (623,'01H000352','Kondom Fiesta Allnight 3''s','01.001','','05','',0,'',0,'H','',6500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6500.00,0.00,7200.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (624,'01H000353','Kondom Sutra 12''s Merah','01.001','','09','',0,'',0,'H','',11000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11000.00,0.00,12500.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (625,'01H000354','Kondom Sutra 3'' Hitam','01.001','','09','',0,'',0,'H','',3800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3800.00,0.00,4300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (626,'01H000355','Kondom Sutra 3'' merah','01.001','','09','',0,'',0,'H','',3100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3100.00,0.00,3400.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (627,'01H000356','Kondom Sutra Hitam 12''s','01.001','','05','',0,'',0,'H','',15800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15800.00,0.00,17500.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (628,'01H000357','Konicare Baby Diapers 60','01.001','','17','',0,'',0,'H','',15500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15500.00,0.00,17000.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (629,'01H000358','Konicare Gel Pengurang Gatal 30','01.001','','02','',0,'',0,'H','',6050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6050.00,0.00,6700.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (630,'01H000359','Konicare Gel Pengurang Gatal 60','01.001','','02','',0,'',0,'H','',9200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9200.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (631,'01H000360','Konvermex 250 mg Tab','01.001','','13','',0,'',0,'H','',6400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6400.00,0.00,7500.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (632,'01H000361','Konvermex Sirup','01.001','','02','',0,'',0,'H','',9500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9500.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (633,'01H000362','KoolFever 12''s anak (Anak)','01.001','','13','',0,'',0,'H','',4700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4700.00,0.00,5200.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (634,'01H000363','KoolFever 12''s bayi (Pink)','01.001','','11','',0,'',0,'H','',4350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4350.00,0.00,4800.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (635,'01H000364','Kopi Stamina LT','01.001','','11','',0,'',0,'H','',24000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24000.00,0.00,26400.00,27000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (636,'01H000365','Kotak P3K','01.001','','05','',0,'',0,'H','',12500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12500.00,0.00,13800.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (637,'01H000366','Koyo Cabe 20''s','01.001','','11','',0,'',0,'H','',6250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6250.00,0.00,6900.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (638,'01H000367','Kunyit Asam  sirih SM','01.001','','11','',0,'',0,'H','',1500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1500.00,0.00,1700.00,1700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (639,'01H000368','Kunyit Asam SM','01.001','','11','',0,'',0,'H','',1200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1200.00,0.00,1600.00,1600.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (640,'01H000369','Kuturap Salep','01.001','','02','',0,'',0,'H','',3375.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3375.00,0.00,3700.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (641,'01H000370','Nano permen','01.001','','11','',0,'',0,'H','',1300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1300.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (642,'01H000371','Natur E dus 16''s','01.001','','13','',0,'',0,'H','',15200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15200.00,0.00,16700.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (643,'01H000372','Natur Slim','01.001','','11','',0,'',0,'H','',8850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8850.00,0.00,9800.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (644,'01H000373','Nefromex Tab 5x10''s','01.001','','13','',0,'',0,'H','',3150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3150.00,0.00,3500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (645,'01H000374','Neo Kaolana sirup 120 ml','01.001','','02','',0,'',0,'H','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,12500.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (646,'01H000375','Neo Kaominal Sirup','01.001','','02','',0,'',0,'H','',5100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5100.00,0.00,5600.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (647,'01H000376','Nephrisol 185 gr Cokl/Vanila','01.001','','05','',0,'',0,'H','',42350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,42350.00,0.00,46500.00,46500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (648,'01H000377','Nephrolit 25x4''s','01.001','','13','',0,'',0,'H','',1900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1900.00,0.00,2300.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (649,'01H000378','Neurobion 5000 Tab 25x10''s','01.001','','13','',0,'',0,'H','',22900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22900.00,0.00,25200.00,25500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (650,'01H000379','Neurobion Tab 25x10''s','01.001','','13','',0,'',0,'H','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,13200.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (651,'01H000380','Neurodex Tab 20x10''s','01.001','','13','',0,'',0,'H','',52000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,52000.00,0.00,57500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (652,'01H000381','Neurosanbe 10x10''s','01.001','','13','',0,'',0,'H','',10340.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10340.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (653,'01H000382','Neurovit E Tab 6x10''s ','01.001','','13','',0,'',0,'H','',9240.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9240.00,0.00,10300.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (654,'01H000383','New diatabs','01.001','','13','',0,'',0,'H','',1950.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1950.00,0.00,2200.00,2200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (655,'01H000384','Nitasan Capsul','01.001','','05','',0,'',0,'H','',8400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8400.00,0.00,9500.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (656,'01H000385','Norit lang','01.001','','17','',0,'',0,'H','',8200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8200.00,0.00,9000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (657,'01H000386','Nourish-E 400 ui','01.001','','02','',0,'',0,'H','',93500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,93500.00,0.00,103000.00,103000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (658,'01H000387','Nouriskin Acne Gel 10 gr','01.001','','17','',0,'',0,'H','',28300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28300.00,0.00,31500.00,31500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (659,'01H000388','Nouriskin Facial Foam 100','01.001','','09','',0,'',0,'H','',28300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28300.00,0.00,31500.00,31500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (660,'01H000389','Nouriskin kuning 15''s','01.001','','05','',0,'',0,'H','',119900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,119900.00,0.00,132000.00,132000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (661,'01H000390','Nouriskin Kuning 30''s','01.001','','05','',0,'',0,'H','',185900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,185900.00,0.00,204500.00,204500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (662,'01H000391','Nouriskin Ultimate 15''s','01.001','','05','',0,'',0,'H','',132000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,132000.00,0.00,145500.00,145500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (663,'01H000392','Nouriskin Ultimate 30''s','01.001','','05','',0,'',0,'H','',209000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,209000.00,0.00,230000.00,230000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (664,'01H000393','Novabion Tab 10x10','01.001','','13','',0,'',0,'H','',15800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15800.00,0.00,17500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (665,'01H000394','Novagesic Tab 10x10''s','01.001','','13','',0,'',0,'H','',10000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10000.00,0.00,11000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (666,'01H000395','Novakal Tab 10x10''s','01.001','','13','',0,'',0,'H','',9800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9800.00,0.00,11000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (667,'01H000396','Nufadol Sirup 24''s','01.001','','02','',0,'',0,'H','',3060.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3060.00,0.00,3500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (668,'01H000397','Nurest Tab','01.001','','15','',0,'',0,'H','',3650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3650.00,0.00,4000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (669,'01H000398','Nutrifar 5000 Tab 10x10''s','01.001','','13','',0,'',0,'H','',39700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,39700.00,0.00,45000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (670,'01H000399','Nutrifar Tab 10x10''s','01.001','','13','',0,'',0,'H','',26400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26400.00,0.00,29000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (671,'01H000400','OB Herbal 100 ml','01.001','','02','',0,'',0,'H','',12100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12100.00,0.00,13300.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (672,'01H000401','OB Herbal 60ml','01.001','','02','',0,'',0,'H','',8750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8750.00,0.00,9600.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (673,'01H000402','OB Herbal Junior 60ml','01.001','','02','',0,'',0,'H','',8750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8750.00,0.00,9600.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (674,'01H000403','Obat Batuk Ibu dan Anak  75 ml','01.001','','02','',0,'',0,'H','',16750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16750.00,0.00,18500.00,18500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (675,'01H000404','Obat batuk Ibu dan Anak 150ml','01.001','','02','',0,'',0,'H','',30100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,30100.00,0.00,33000.00,33000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (676,'01H000405','Obat gigi Kaka Tua','01.001','','02','',0,'',0,'H','',7630.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7630.00,0.00,8500.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (677,'01H000406','Obh Combi anak 60 ml All Variant','01.001','','02','',0,'',0,'H','',8750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8750.00,0.00,9700.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (678,'01H000407','Obh combi berdahak mentol 100ml','01.001','','02','',0,'',0,'H','',7350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7350.00,0.00,8000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (679,'01H000408','Obh Combi plus dewasa 100ml','01.001','','02','',0,'',0,'H','',12400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12400.00,0.00,13700.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (680,'01H000409','Obh Combi plus dewasa 60ml','01.001','','02','',0,'',0,'H','',9200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9200.00,0.00,10200.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (681,'01H000410','OBH Itrasal','01.001','','02','',0,'',0,'H','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3650.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (682,'01H000411','OBH Jeruk nipis Berlico','01.001','','02','',0,'',0,'H','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,3600.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (683,'01H000412','OBH Nellco Spec Anak 100 ml','01.001','','02','',0,'',0,'H','',9000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9000.00,0.00,9900.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (684,'01H000413','OBH Nellco Spec Anak 55 ml','01.001','','02','',0,'',0,'H','',7400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7400.00,0.00,8200.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (685,'01H000414','Obh nellco special 100ml','01.001','','02','',0,'',0,'H','',16700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16700.00,0.00,18500.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (686,'01H000415','Obh nellco special 55ml','01.001','','02','',0,'',0,'H','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,13500.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (687,'01H000416','Obh Tropica Expect 60 ml','01.001','','02','',0,'',0,'H','',8250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8250.00,0.00,9000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (688,'01H000417','Obh Tropica Extra 60ml','01.001','','02','',0,'',0,'H','',7850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7850.00,0.00,8500.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (689,'01H000418','OBH Tropica Plus Mentol 60 ml','01.001','','02','',0,'',0,'H','',7576.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7576.00,0.00,8300.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (690,'01H000419','Obimin AF 3x10''s','01.001','','13','',0,'',0,'H','',11600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11600.00,0.00,13500.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (691,'01H000420','OBP Itrasal','01.001','','02','',0,'',0,'H','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3650.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (692,'01H000421','Octedine Sol','01.001','','02','',0,'',0,'H','',44600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,44600.00,0.00,49000.00,50000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (693,'01H000422','Omegavit 10x10''s','01.001','','13','',0,'',0,'H','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (694,'01H000423','Omegdiar Sirup','01.001','','02','',0,'',0,'H','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (695,'01H000424','Omegdiar Tab 10x10''s','01.001','','13','',0,'',0,'H','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (696,'01H000425','Omeproz 30''s Capsul','01.001','','02','',0,'',0,'H','',115500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,115500.00,0.00,127000.00,127000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (697,'01H000426','Omevita sirup','01.001','','02','',0,'',0,'H','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (698,'01H000427','Opidiar Sirup','01.001','','02','',0,'',0,'H','',13750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13750.00,0.00,15500.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (699,'01H000428','Opinaceae sirup','01.001','','02','',0,'',0,'H','',41800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,41800.00,0.00,46000.00,46000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (700,'01H000429','Oskadon SP Cream','01.001','','02','',0,'',0,'H','',8000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8000.00,0.00,8800.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (701,'01H000430','Tempra Drop 15 ml','01.001','','02','',0,'',0,'H','',37000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,37000.00,0.00,40700.00,41000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (702,'01H000431','Tempra Sirup 30 ml','01.001','','02','',0,'',0,'H','',15600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15600.00,0.00,17300.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (703,'01H000432','Tempra Sirup 60 ml','01.001','','02','',0,'',0,'H','',29480.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29480.00,0.00,32500.00,32500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (704,'01H000433','Termagon 500 mg 10x10','01.001','','13','',0,'',0,'H','',14870.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14870.00,0.00,17000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (705,'01H000434','Termagon elixir ','01.001','','02','',0,'',0,'H','',3900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3900.00,0.00,4300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (706,'01H000435','Termagon forte Tab 10x10 ','01.001','','13','',0,'',0,'H','',16720.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16720.00,0.00,18500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (707,'01H000436','Thermolyte Plus 3x10''s','01.001','','13','',0,'',0,'H','',55000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,55000.00,0.00,60000.00,60000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (708,'01H000437','Thrombophop Oint 15 gr','01.001','','17','',0,'',0,'H','',38500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,38500.00,0.00,42500.00,43000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (709,'01H000438','Thymcal Sirup 60 ml','01.001','','02','',0,'',0,'H','',5650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5650.00,0.00,7000.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (710,'01H000439','Tialysin Kalk Sirup','01.001','','02','',0,'',0,'H','',2900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2900.00,0.00,3300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (711,'01H000440','Tialysin Plus Sirup','01.001','','02','',0,'',0,'H','',3100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3100.00,0.00,3500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (712,'01H000441','Tisu super magic','01.001','','09','',0,'',0,'H','',5500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (713,'01H000442','Tolak Angin Anak','01.001','','11','',0,'',0,'H','',1300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1300.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (714,'01H000443','Tolak Angin cair 24''s','01.001','','11','',0,'',0,'H','',1800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1800.00,0.00,2000.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (715,'01H000444','Tolak Angin Flu 12''s','01.001','','11','',0,'',0,'H','',1700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1700.00,0.00,1900.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (716,'01H000445','Tolak angin permen 20''s','01.001','','11','',0,'',0,'H','',1100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1100.00,0.00,1200.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (717,'01H000446','Tolak Angin Tab','01.001','','11','',0,'',0,'H','',875.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,875.00,0.00,1000.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (718,'01H000447','Tonikum Bayer 100 ml (K)','01.001','','02','',0,'',0,'H','',12100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12100.00,0.00,13500.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (719,'01H000448','Tonikum bayer B (330 ml)','01.001','','02','',0,'',0,'H','',24000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24000.00,0.00,26400.00,26500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (720,'01H000449','Top Lady','01.001','','11','',0,'',0,'H','',4300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4300.00,0.00,4800.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (721,'01H000450','Transpulmin Balsem 20 gr','01.001','','17','',0,'',0,'H','',40487.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,40487.00,0.00,44500.00,45000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (722,'01H000451','Trifamol Tab 10x10','01.001','','13','',0,'',0,'H','',16500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16500.00,0.00,18200.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (723,'01H000452','Trimakalk Tab 10x10','01.001','','13','',0,'',0,'H','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,14000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (724,'01H000453','Triocid tab','01.001','','13','',0,'',0,'H','',12200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12200.00,0.00,13500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (725,'01H000454','Tropicana Slim  Diabetic 25''s','01.001','','05','',0,'',0,'H','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,20600.00,21000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (726,'01H000455','Tropicana Slim Diabetic 50''s','01.001','','05','',0,'',0,'H','',33000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33000.00,0.00,36300.00,36500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (727,'01H000456','Tropicana Slim Sachet 25''s','01.001','','05','',0,'',0,'H','',17600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17600.00,0.00,19500.00,19500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (728,'01H000457','Truvit sirup','01.001','','02','',0,'',0,'H','',5750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5750.00,0.00,6300.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (729,'01H000458','Ultilox Forte sirup','01.001','','02','',0,'',0,'H','',34500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34500.00,0.00,38000.00,38000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (730,'01H000459','Ultracap','01.001','','13','',0,'',0,'H','',2050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2050.00,0.00,2300.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (731,'01H000460','Ultrasilin','01.001','','17','',0,'',0,'H','',6000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6000.00,0.00,6700.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (732,'01H000461','Upixon sirup','01.001','','02','',0,'',0,'H','',10700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10700.00,0.00,11800.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (733,'01H000462','Sensitif TestPack','01.001','','09','',0,'',0,'H','',18150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18150.00,0.00,20000.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (734,'01H000463','Sabun hijau Afi 100 gr','01.001','','09','',0,'',0,'H','',3400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3400.00,0.00,3800.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (735,'01H000464','Saccorit','01.001','','09','',0,'',0,'H','',6050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6050.00,0.00,6700.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (736,'01H000465','Safe Care','01.001','','02','',0,'',0,'H','',13600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13600.00,0.00,15000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (737,'01H000466','Sakarin Trifa ','01.001','','06','',0,'',0,'H','',17000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17000.00,0.00,19000.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (738,'01H000467','Sakatonik ABC All variant','01.001','','02','',0,'',0,'H','',10000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10000.00,0.00,11000.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (739,'01H000468','Sakatonik liver 110ml','01.001','','02','',0,'',0,'H','',8000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8000.00,0.00,8800.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (740,'01H000469','Sakatonik liver 300ml','01.001','','02','',0,'',0,'H','',18500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18500.00,0.00,20500.00,21000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (741,'01H000470','Salep 19 Hijau','01.001','','09','',0,'',0,'H','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (742,'01H000471','Salep 2-4 Nufa 12''s','01.001','','09','',0,'',0,'H','',2000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2000.00,0.00,2200.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (743,'01H000472','Salep 8 Dewa','01.001','','02','',0,'',0,'H','',1750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1750.00,0.00,2000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (744,'01H000473','Salep 88','01.001','','02','',0,'',0,'H','',5850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5850.00,0.00,6500.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (745,'01H000474','Salep Levertraan Cito 24''s','01.001','','09','',0,'',0,'H','',2850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2850.00,0.00,3200.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (746,'01H000475','Salicyl Talk Afi 100 gr','01.001','','02','',0,'',0,'H','',1500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1500.00,0.00,2300.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (747,'01H000476','Salisil fresh 60 gr KF','01.001','','02','',0,'',0,'H','',8415.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8415.00,0.00,9300.00,9500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (748,'01H000477','Salisil Menthol Ika','01.001','','02','',0,'',0,'H','',6600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6600.00,0.00,7300.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (749,'01H000478','Salisil Spirtus Afi','01.001','','02','',0,'',0,'H','',1500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1500.00,0.00,1700.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (750,'01H000479','Salisil spirtus Gajah','01.001','','02','',0,'',0,'H','',2416.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2416.00,0.00,2800.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (751,'01H000480','Salisil talk gajah pink','01.001','','02','',0,'',0,'H','',3917.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3917.00,0.00,4300.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (752,'01H000481','Salisil Talk Ika','01.001','','02','',0,'',0,'H','',5940.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5940.00,0.00,6500.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (753,'01H000482','Salisil Talk KF 2 %','01.001','','02','',0,'',0,'H','',4900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4900.00,0.00,5500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (754,'01H000483','Salisil talk menthol gajah 100gr','01.001','','02','',0,'',0,'H','',5400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5400.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (755,'01H000484','Salisil Talk Nellco 60 gr','01.001','','02','',0,'',0,'H','',3580.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3580.00,0.00,4000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (756,'01H000485','Salisil Talk Nellco 60 gr Menthol','01.001','','02','',0,'',0,'H','',3475.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3475.00,0.00,3900.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (757,'01H000486','Salonpas Cair','01.001','','17','',0,'',0,'H','',14300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14300.00,0.00,16000.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (758,'01H000487','Salonpas gel B (30 gr)','01.001','','17','',0,'',0,'H','',14580.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14580.00,0.00,16000.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (759,'01H000488','Salonpas gel K (15 gr)','01.001','','17','',0,'',0,'H','',9700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9700.00,0.00,10700.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (760,'01H000489','Salonpas Hijau 12''s','01.001','','11','',0,'',0,'H','',5600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5600.00,0.00,6200.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (761,'01H000490','Salonpas Hijau 10''s','01.001','','11','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (762,'01H000491','Salonpas Hot 10''s','01.001','','11','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (763,'01H000492','Salonpas Pain Relief','01.001','','09','',0,'',0,'H','',19400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19400.00,0.00,21300.00,21500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (764,'01H000493','Sambung Puting susu Pipi','01.001','','09','',0,'',0,'H','',11000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11000.00,0.00,12100.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (765,'01H000494','Sangobion Capsul','01.001','','13','',0,'',0,'H','',9231.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9231.00,0.00,10300.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (766,'01H000495','Sangobion Capsul 10x4','01.001','','13','',0,'',0,'H','',3700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3700.00,0.00,4000.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (767,'01H000496','Sangobion kids 100ml','01.001','','02','',0,'',0,'H','',24200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24200.00,0.00,26700.00,27000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (768,'01H000497','Sanmag Sirup','01.001','','02','',0,'',0,'H','',23650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23650.00,0.00,26000.00,26000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (769,'01H000498','Sanmol Drop','01.001','','02','',0,'',0,'H','',14745.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14745.00,0.00,16200.00,16500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (770,'01H000499','Sanmol Sirup 60 ml','01.001','','02','',0,'',0,'H','',10900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10900.00,0.00,12000.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (771,'01H000500','Sanmol tab','01.001','','13','',0,'',0,'H','',1012.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1012.00,0.00,1200.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (772,'01H000501','Sariawan Kuldon','01.001','','13','',0,'',0,'H','',1650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1650.00,0.00,1800.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (773,'01H000502','Scott Capsul isi 100''s','01.001','','02','',0,'',0,'H','',47000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,47000.00,0.00,51700.00,52000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (774,'01H000503','Scott Chew Blaccurant','01.001','','05','',0,'',0,'H','',13100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13100.00,0.00,14500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (775,'01H000504','Scott Chew Vit C20','01.001','','05','',0,'',0,'H','',13100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13100.00,0.00,14500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (776,'01H000505','Scott Emulsion DHA 400 cc','01.001','','02','',0,'',0,'H','',34500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34500.00,0.00,38000.00,38000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (777,'01H000506','Scott Emulsion Vita 200 ml (K)','01.001','','02','',0,'',0,'H','',22100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22100.00,0.00,24300.00,24500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (778,'01H000507','Scott Emulsion Vita 400 ml (Bsr)','01.001','','02','',0,'',0,'H','',34500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34500.00,0.00,38000.00,38000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (779,'01H000508','SeaHorse Ghensen','01.001','','02','',0,'',0,'H','',16250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16250.00,0.00,18000.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (780,'01H000509','seltifort Kids','01.001','','02','',0,'',0,'H','',3250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3250.00,0.00,3600.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (781,'01H000510','Sensodyne Freshwhite 50 gr','01.001','','17','',0,'',0,'H','',7000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7000.00,0.00,7700.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (782,'01H000511','Sevenseas Kids 100 ml','01.001','','02','',0,'',0,'H','',33000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33000.00,0.00,36300.00,36500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (783,'01H000512','SGM Ananda 1 150gr','01.001','','05','',0,'',0,'H','',13600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13600.00,0.00,15000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (784,'01H000513','SGM Ananda 1 400','01.001','','05','',0,'',0,'H','',34400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34400.00,0.00,37800.00,38000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (785,'01H000514','SGM Ananda 2 150gr','01.001','','05','',0,'',0,'H','',13600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13600.00,0.00,15000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (786,'01H000515','SGM BBLR 200 gr','01.001','','05','',0,'',0,'H','',31100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31100.00,0.00,34200.00,34500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (787,'01H000516','SGM BBLR 400 gr','01.001','','05','',0,'',0,'H','',59200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,59200.00,0.00,65200.00,65500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (788,'01H000517','SGM Bunda Hamil 150 gr all variant','01.001','','05','',0,'',0,'H','',17400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17400.00,0.00,19300.00,19500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (789,'01H000518','SGM Explore buah dan sayur 3 150gr','01.001','','05','',0,'',0,'H','',16500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16500.00,0.00,18200.00,18500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (790,'01H000519','SGM Explore madu 3 150gr','01.001','','05','',0,'',0,'H','',13000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13000.00,0.00,14300.00,14500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (791,'01H000520','SGM LLM 200 gr','01.001','','05','',0,'',0,'H','',29000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29000.00,0.00,31900.00,32000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (792,'01H000521','SGM LLM 400 gr','01.001','','05','',0,'',0,'H','',54900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,54900.00,0.00,60500.00,61000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (793,'01H000522','Siladex Exp 60','01.001','','02','',0,'',0,'H','',8800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8800.00,0.00,9700.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (794,'01H000523','Sparta X','01.001','','13','',0,'',0,'H','',23100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23100.00,0.00,25500.00,26000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (795,'01H000524','Stimuno Kapsul','01.001','','13','',0,'',0,'H','',21500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21500.00,0.00,23600.00,24000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (796,'01H000525','Stimuno sir 100ml','01.001','','02','',0,'',0,'H','',28800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28800.00,0.00,31700.00,32000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (797,'01H000526','Stimuno sir 60ml','01.001','','02','',0,'',0,'H','',18800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18800.00,0.00,20700.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (798,'01H000527','Stop X 30gr','01.001','','17','',0,'',0,'H','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,20500.00,20500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (799,'01H000528','Strongpas 10''s','01.001','','13','',0,'',0,'H','',1425.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1425.00,0.00,1600.00,1600.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (800,'01H000529','Sulfas Ferrosus (R) KF 1000''s','01.001','','06','',0,'',0,'H','',69091.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,69091.00,0.00,76000.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (801,'01H000530','Supradyn Eff','01.001','','17','',0,'',0,'H','',31500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31500.00,0.00,34600.00,35000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (802,'01H000531','Supravit Tab 10x10''s','01.001','','13','',0,'',0,'H','',2761.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2761.00,0.00,3000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (803,'01H000532','Supravit tab Btl','01.001','','02','',0,'',0,'H','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,20600.00,21000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (804,'01H000533','Synbio capsul 30''s','01.001','','04','',0,'',0,'H','',3483.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3483.00,0.00,3850.00,4200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (805,'01H000534','Vegeblend JR','01.001','','02','',0,'',0,'H','',108900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,108900.00,0.00,119800.00,120000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (806,'01H000535','Vegeta herbal6''s','01.001','','11','',0,'',0,'H','',1925.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1925.00,0.00,2200.00,2300.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (807,'01H000536','Vegeta Original','01.001','','11','',0,'',0,'H','',1275.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1275.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (808,'01H000537','Venaron Tab 5x4''s','01.001','','13','',0,'',0,'H','',10000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10000.00,0.00,11000.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (809,'01H000538','Veril Face Wash','01.001','','02','',0,'',0,'H','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,13500.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (810,'01H000539','Vermox 500 mg Tab','01.001','','13','',0,'',0,'H','',18250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18250.00,0.00,20000.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (811,'01H000540','Vesperum Drop','01.001','','02','',0,'',0,'H','',9150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9150.00,0.00,10000.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (812,'01H000541','Vick Vaporub 20 gr','01.001','','02','',0,'',0,'H','',10125.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10125.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (813,'01H000542','Vick Vaporub 50 gr','01.001','','02','',0,'',0,'H','',19350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19350.00,0.00,21500.00,21500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (814,'01H000543','Vicks INH','01.001','','09','',0,'',0,'H','',9400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9400.00,0.00,10500.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (815,'01H000544','Vidoran Plus Curcuma Lysine','01.001','','02','',0,'',0,'H','',11100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11100.00,0.00,12200.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (816,'01H000545','vidoran smart plus  30''s  jeruk/straw','01.001','','02','',0,'',0,'H','',9900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9900.00,0.00,11000.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (817,'01H000546','Vidoran Smart Plus Sirup','01.001','','02','',0,'',0,'H','',13200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13200.00,0.00,14500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (818,'01H000547','Vidoran Total Care','01.001','','02','',0,'',0,'H','',20000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20000.00,0.00,22000.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (819,'01H000548','Vigel 30 gr','01.001','','09','',0,'',0,'H','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,13000.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (820,'01H000549','Vipro G 5x2''s','01.001','','13','',0,'',0,'H','',6050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6050.00,0.00,6700.00,6700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (821,'01H000550','Virugon Zalf','01.001','','17','',0,'',0,'H','',10000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10000.00,0.00,11000.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (822,'01H000551','Visine extra TM','01.001','','02','',0,'',0,'H','',11120.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11120.00,0.00,12300.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (823,'01H000552','Visine TM 6ml','01.001','','02','',0,'',0,'H','',10000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10000.00,0.00,11000.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (824,'01H000553','Vit A IPI','01.001','','02','',0,'',0,'H','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3600.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (825,'01H000554','Vit B 1 IPI','01.001','','02','',0,'',0,'H','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3600.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (826,'01H000555','Vit B com IPI','01.001','','02','',0,'',0,'H','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3600.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (827,'01H000556','Vit B Complex Afi','01.001','','06','',0,'',0,'H','',18000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18000.00,0.00,20000.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (828,'01H000557','Vit B1 50 mg Afi','01.001','','06','',0,'',0,'H','',35000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,35000.00,0.00,38500.00,40000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (829,'01H000558','Vit B12 10 Mcg Afi','01.001','','06','',0,'',0,'H','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,15500.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (830,'01H000559','Vit B12 IPI','01.001','','02','',0,'',0,'H','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3600.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (831,'01H000560','Vit B6 10  mg Afi','01.001','','06','',0,'',0,'H','',17000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17000.00,0.00,19000.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (832,'01H000561','Vit C IPI','01.001','','02','',0,'',0,'H','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3600.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (833,'01H000562','Vitacimin 50x2''s','01.001','','13','',0,'',0,'H','',1250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1250.00,0.00,1400.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (834,'01H000563','Vital TT','01.001','','02','',0,'',0,'H','',11875.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11875.00,0.00,13000.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (835,'01H000564','Vitalong C 25x4','01.001','','13','',0,'',0,'H','',3950.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3950.00,0.00,4500.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (836,'01H000565','Vitamin C 25 mg MEF','01.001','','06','',0,'',0,'H','',19500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19500.00,0.00,21500.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (837,'01H000566','Vitazym Tab 10x10''s','01.001','','13','',0,'',0,'H','',48700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,48700.00,0.00,53500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (838,'01H000567','Voltaren Gel 10 gr','01.001','','02','',0,'',0,'H','',30600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,30600.00,0.00,33700.00,34000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (839,'01H000568','Voltaren Gel 20 gr','01.001','','09','',0,'',0,'H','',44300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,44300.00,0.00,48700.00,49000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (840,'01H000569','Vidoran Guard','01.001','','02','',0,'',0,'H','',10100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10100.00,0.00,11200.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (841,'01H000570','Vitonal Forte Capsul 10x10','01.001','','13','',0,'',0,'H','',5120.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5120.00,0.00,5600.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (842,'01H000571','Vipalbumin Capsul 30''s','01.001','','02','',0,'',0,'H','',181500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,181500.00,0.00,200000.00,200000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (843,'01H000572','Vegeblend Adult','01.001','','02','',0,'',0,'H','',110000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,110000.00,0.00,121000.00,121000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (844,'01H000573','Venaron Tab 10x10''s','01.001','','13','',0,'',0,'H','',24700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24700.00,0.00,27200.00,27500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (845,'01H000574','Visorel Tab','01.001','','05','',0,'',0,'H','',74250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,74250.00,0.00,84000.00,87000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (846,'01H000575','Waisan 12''s','01.001','','11','',0,'',0,'H','',3750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3750.00,0.00,4700.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (847,'01H000576','Wicold Sirup 60 ml','01.001','','02','',0,'',0,'H','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,3600.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (848,'01H000577','Wood Herbal 60','01.001','','02','',0,'',0,'H','',13200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13200.00,0.00,14500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (849,'01H000578','Wybert Sirup 60 ml','01.001','','02','',0,'',0,'H','',9350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9350.00,0.00,10300.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (850,'01H000579','Ramabion Tab 10x10','01.001','','13','',0,'',0,'H','',19000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19000.00,0.00,20900.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (851,'01H000580','Ramolit 25','01.001','','12','',0,'',0,'H','',400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,400.00,0.00,550.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (852,'01H000581','Rapet Wangi','01.001','','05','',0,'',0,'H','',4750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4750.00,0.00,5500.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (853,'01H000582','Redoxon DA','01.001','','17','',0,'',0,'H','',32000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32000.00,0.00,35200.00,35500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (854,'01H000583','Redoxon Eff 15''s','01.001','','17','',0,'',0,'H','',41150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,41150.00,0.00,45300.00,45500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (855,'01H000584','Renalyte 200 ml','01.001','','02','',0,'',0,'H','',13750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13750.00,0.00,15500.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (856,'01H000585','Renovit Tab Strip','01.001','','13','',0,'',0,'H','',8536.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8536.00,0.00,9400.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (857,'01H000586','Resik V Godogan Sirih','01.001','','02','',0,'',0,'H','',13000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13000.00,0.00,14300.00,14500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (858,'01H000587','Resik V Manjakani','01.001','','02','',0,'',0,'H','',6500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6500.00,0.00,7200.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (859,'01H000588','Resik V Ramuan Madura','01.001','','02','',0,'',0,'H','',6500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6500.00,0.00,7200.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (860,'01H000589','Resik V Sirih Mawar','01.001','','02','',0,'',0,'H','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,3500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (861,'01H000590','Resik V Spa Frangipani','01.001','','02','',0,'',0,'H','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,4000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (862,'01H000591','Rheumaycl Cr hijau','01.001','','17','',0,'',0,'H','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,13200.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (863,'01H000592','Rheumaycl Cr merah','01.001','','17','',0,'',0,'H','',10833.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10833.00,0.00,12000.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (864,'01H000593','Rivanol 100 ml Afi','01.001','','02','',0,'',0,'H','',1700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1700.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (865,'01H000594','Rivanol 300 ml Afi','01.001','','02','',0,'',0,'H','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3650.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (866,'01H000595','Rodeca Lotio 60','01.001','','02','',0,'',0,'H','',7656.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7656.00,0.00,8500.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (867,'01H000596','Rohto Cool Tm','01.001','','02','',0,'',0,'H','',11200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11200.00,0.00,12500.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (868,'01H000597','Rohto TM','01.001','','02','',0,'',0,'H','',8050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8050.00,0.00,9000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (869,'01H000598','Xon-Ce 50x2''s','01.001','','13','',0,'',0,'H','',1100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1100.00,0.00,1300.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (870,'01H000599','Y rins','01.001','','02','',0,'',0,'H','',24500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24500.00,0.00,27000.00,28000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (871,'01H000600','Yungsan Capsul','01.001','','02','',0,'',0,'H','',7000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7000.00,0.00,8000.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (872,'01H000601','Zetamol Sirup 60 ml','01.001','','02','',0,'',0,'H','',2768.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2768.00,0.00,3100.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (873,'01H000602','Zevit Grow15x8''s','01.001','','13','',0,'',0,'H','',10250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10250.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (874,'01H000603','Zinkid Sirup','01.001','','02','',0,'',0,'H','',27500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27500.00,0.00,30250.00,30500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (875,'01H000604','Pacdin Biosepta 15 ml','01.001','','02','',0,'',0,'H','',1870.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1870.00,0.00,2100.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (876,'01H000605','Pacdin Biosepta 8 ml','01.001','','02','',0,'',0,'H','',1371.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1371.00,0.00,1700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (877,'01H000606','Pacdin vitcur','01.001','','02','',0,'',0,'H','',2950.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2950.00,0.00,3300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (878,'01H000607','Pacetik Sirup','01.001','','02','',0,'',0,'H','',3100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3100.00,0.00,3500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (879,'01H000608','Pagoda Pastiles','01.001','','09','',0,'',0,'H','',2150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2150.00,0.00,2400.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (880,'01H000609','Pagoda salep','01.001','','09','',0,'',0,'H','',3625.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3625.00,0.00,4000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (881,'01H000610','Pamol Forte Tab','01.001','','13','',0,'',0,'H','',3630.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3630.00,0.00,4000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (882,'01H000611','Pamol Sirup 60 ','01.001','','02','',0,'',0,'H','',12700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12700.00,0.00,14000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (883,'01H000612','Pan Enteral Susu 10''s','01.001','','11','',0,'',0,'H','',12320.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12320.00,0.00,13500.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (884,'01H000613','Panacool Kompres','01.001','','11','',0,'',0,'H','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,13200.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (885,'01H000614','Panadol anak tablet 10x10','01.001','','13','',0,'',0,'H','',8000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8000.00,0.00,8800.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (886,'01H000615','Panadol sirup 30ml','01.001','','02','',0,'',0,'H','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16500.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (887,'01H000616','Panadol sirup 60ml','01.001','','02','',0,'',0,'H','',27600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27600.00,0.00,30500.00,31000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (888,'01H000617','Panadol Tab biru','01.001','','13','',0,'',0,'H','',5600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5600.00,0.00,6200.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (889,'01H000618','Panadol Tab hijau/flu','01.001','','13','',0,'',0,'H','',7600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7600.00,0.00,8500.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (890,'01H000619','Pandas','01.001','','02','',0,'',0,'H','',1916.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1916.00,0.00,2500.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (891,'01H000620','Panviton Capsul 5x10''s','01.001','','13','',0,'',0,'H','',21500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21500.00,0.00,25000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (892,'01H000621','Paracetamol 500 mg 10x10 KF','01.001','','13','',0,'',0,'H','',10500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10500.00,0.00,12000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (893,'01H000622','Param kocok Air Mancur B/75 ml','01.001','','02','',0,'',0,'H','',8833.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8833.00,0.00,10700.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (894,'01H000623','Param kocok Air Mancur K/25 ml','01.001','','02','',0,'',0,'H','',4833.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4833.00,0.00,5500.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (895,'01H000624','Param pusaka jago','01.001','','11','',0,'',0,'H','',1025.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1025.00,0.00,1200.00,1300.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (896,'01H000625','Pedialyte Sol 500 ml','01.001','','02','',0,'',0,'H','',26500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26500.00,0.00,29000.00,29000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (897,'01H000626','Peditox 50 ml','01.001','','02','',0,'',0,'H','',4670.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4670.00,0.00,5200.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (898,'01H000627','Peptisol Vanila 150 gr','01.001','','05','',0,'',0,'H','',42900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,42900.00,0.00,47200.00,48000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (899,'01H000628','Permen strepsil','01.001','','09','',0,'',0,'H','',4800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4800.00,0.00,5300.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (900,'01H000629','Pharmaton Formula 10x5''s (Ecer)','01.001','','15','',0,'',0,'H','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,16500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (901,'01H000630','Pharolit 60''s','01.001','','11','',0,'',0,'H','',880.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,880.00,0.00,1000.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (902,'01H000631','Phisohex Phacial Wash','01.001','','02','',0,'',0,'H','',15472.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15472.00,0.00,17000.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (903,'01H000632','Pigeon Baby Liquid Soap 100 ml','01.001','','09','',0,'',0,'H','',7920.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7920.00,0.00,8800.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (904,'01H000633','Pigeon Baby Liquid Soap 200 ml','01.001','','09','',0,'',0,'H','',15180.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15180.00,0.00,16700.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (905,'01H000634','Pigeon baby Oil 100 ml','01.001','','09','',0,'',0,'H','',13640.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13640.00,0.00,15000.00,15500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (906,'01H000635','Pigeon Baby Powder 100 gr All Variant','01.001','','09','',0,'',0,'H','',5830.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5830.00,0.00,6500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (907,'01H000636','Pigeon Baby Shampoo 100 ml','01.001','','09','',0,'',0,'H','',7600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7600.00,0.00,8400.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (908,'01H000637','Pigeon Baby Shampoo 200 ml','01.001','','09','',0,'',0,'H','',14190.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14190.00,0.00,15700.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (909,'01H000638','Pigeon Bedak Compact baby','01.001','','09','',0,'',0,'H','',17000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17000.00,0.00,18700.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (910,'01H000639','Pigeon Botol Standar 120 ml','01.001','','09','',0,'',0,'H','',20625.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20625.00,0.00,22700.00,23000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (911,'01H000640','Pigeon Botol Standar 240 ml','01.001','','09','',0,'',0,'H','',20900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20900.00,0.00,23000.00,24000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (912,'01H000641','Pigeon Botol Standar 50 ml','01.001','','09','',0,'',0,'H','',17325.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17325.00,0.00,19000.00,19500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (913,'01H000642','Pigeon Empeng Stoples 12''s','01.001','','09','',0,'',0,'H','',5100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5100.00,0.00,5600.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (914,'01H000643','Pigeon Nipple Cover','01.001','','09','',0,'',0,'H','',4200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4200.00,0.00,4600.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (915,'01H000644','Pigeon Silicon Nipple 18''s S/M/L','01.001','','09','',0,'',0,'H','',4620.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4620.00,0.00,5500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (916,'01H000645','Pigeon Silicone Nipple 18''s Eco Mix','01.001','','09','',0,'',0,'H','',6160.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6160.00,0.00,7000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (917,'01H000646','Pigeon silicone Step 1','01.001','','09','',0,'',0,'H','',19580.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19580.00,0.00,21500.00,21500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (918,'01H000647','Pil Tuntas','01.001','','13','',0,'',0,'H','',4750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4750.00,0.00,5300.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (919,'01H000648','Pilkita','01.001','','13','',0,'',0,'H','',1020.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1020.00,0.00,1100.00,1200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (920,'01H000649','Plantacid Forte 10x10''s','01.001','','13','',0,'',0,'H','',9130.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9130.00,0.00,10000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (921,'01H000650','Plantacid Forte sirup 100 ml','01.001','','02','',0,'',0,'H','',29700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29700.00,0.00,32700.00,33000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (922,'01H000651','Plantacid Sirup 100 ml','01.001','','02','',0,'',0,'H','',6000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6000.00,0.00,7500.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (923,'01H000652','Plester Fancy 10''s','01.001','','11','',0,'',0,'H','',1650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1650.00,0.00,1800.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (924,'01H000653','Policrol Forte Gel 100 ml','01.001','','02','',0,'',0,'H','',24750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24750.00,0.00,27500.00,29000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (925,'01H000654','Polident 15 gr','01.001','','17','',0,'',0,'H','',12500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12500.00,0.00,13800.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (926,'01H000655','Polident 60 gr','01.001','','17','',0,'',0,'H','',32000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32000.00,0.00,35200.00,35500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (927,'01H000656','Polisilane Sirup 100','01.001','','02','',0,'',0,'H','',17000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17000.00,0.00,18700.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (928,'01H000657','Polisilane Tab 5x8''s','01.001','','13','',0,'',0,'H','',6000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6000.00,0.00,6600.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (929,'01H000658','Praxion Sirup 125 mg','01.001','','02','',0,'',0,'H','',16900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16900.00,0.00,20500.00,21000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (930,'01H000659','Prenagen Lactasi 200 gr','01.001','','05','',0,'',0,'H','',36250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36250.00,0.00,40000.00,40000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (931,'01H000660','Prenagen Mommy 200 gr Cokl/Vanil','01.001','','05','',0,'',0,'H','',36650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36650.00,0.00,40500.00,40500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (932,'01H000661','Prenagen Mommy Emesis 200 gr ','01.001','','05','',0,'',0,'H','',38600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,38600.00,0.00,42500.00,42500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (933,'01H000662','Probio c Spray','01.001','','02','',0,'',0,'H','',55000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,55000.00,0.00,60500.00,61000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (934,'01H000663','Produgen Gold 245 P/V','01.001','','05','',0,'',0,'H','',27170.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27170.00,0.00,30000.00,30000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (935,'01H000664','Prolacta DHA Baby','01.001','','13','',0,'',0,'H','',48500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,48500.00,0.00,53500.00,53500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (936,'01H000665','Prolacta DHA Mother 6x10','01.001','','13','',0,'',0,'H','',35383.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,35383.00,0.00,39000.00,39000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (937,'01H000666','Prolipid Capsul 6x10''s','01.001','','13','',0,'',0,'H','',47700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,47700.00,0.00,54000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (938,'01H000667','Promag 4x3x12 (Ecer)','01.001','','15','',0,'',0,'H','',4500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4500.00,0.00,5000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (939,'01H000668','Prome Exp 60 ml','01.001','','02','',0,'',0,'H','',14850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14850.00,0.00,16500.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (940,'01H000669','Prorhoid 3x10''s','01.001','','13','',0,'',0,'H','',9020.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9020.00,0.00,10000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (941,'01H000670','Protecal Deff sac','01.001','','11','',0,'',0,'H','',2266.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2266.00,0.00,2500.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (942,'01H000671','Protecal Deff tube','01.001','','17','',0,'',0,'H','',23000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23000.00,0.00,25300.00,25500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (943,'01H000672','Protecal Osteo (Sak)','01.001','','11','',0,'',0,'H','',2420.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2420.00,0.00,2700.00,2700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (944,'01H000673','Protecal Osteo (Tube)','01.001','','17','',0,'',0,'H','',24200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24200.00,0.00,26700.00,27000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (945,'01H000674','Protecal solid sac','01.001','','11','',0,'',0,'H','',2250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2250.00,0.00,2500.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (946,'01H000675','Protecal solid tube','01.001','','17','',0,'',0,'H','',23000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23000.00,0.00,25300.00,25500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (947,'01H000676','Prozos Capsul','01.001','','05','',0,'',0,'H','',23000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23000.00,0.00,25300.00,26000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (948,'01H000677','Puyer 16','01.001','','11','',0,'',0,'H','',3750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3750.00,0.00,4800.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (949,'01H000678','Puyer 19','01.001','','11','',0,'',0,'H','',3750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3750.00,0.00,4800.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (950,'01H000679','Puyer Kupu- kupu Plus','01.001','','11','',0,'',0,'H','',1500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1500.00,0.00,1700.00,1700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (951,'01H000680','Puyer kupu-kupu 12''s','01.001','','11','',0,'',0,'H','',1500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1500.00,0.00,1700.00,1700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (952,'01H000681','Puyer Pedang','01.001','','11','',0,'',0,'H','',213.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,213.00,0.00,250.00,300.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (953,'01H000682','Madu Rasa 12''s','01.001','','11','',0,'',0,'H','',700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,700.00,0.00,800.00,800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (954,'01H000683','Madu Syamil anak','01.001','','02','',0,'',0,'H','',12500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12500.00,0.00,15000.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (955,'01H000684','Madu Tj 150 gr orig/kurma','01.001','','02','',0,'',0,'H','',14000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14000.00,0.00,15500.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (956,'01H000685','Madu Tj Sachet Jeruk/Straw 12''s','01.001','','11','',0,'',0,'H','',650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,650.00,0.00,800.00,800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (957,'01H000686','Magasida Sirup','01.001','','02','',0,'',0,'H','',28600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28600.00,0.00,31500.00,31500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (958,'01H000687','Magasida Tab 10x10''s','01.001','','13','',0,'',0,'H','',6700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6700.00,0.00,7400.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (959,'01H000688','Magstral sirup','01.001','','02','',0,'',0,'H','',22000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22000.00,0.00,24500.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (960,'01H000689','Mastin Capsul 12''s','01.001','','05','',0,'',0,'H','',8500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8500.00,0.00,9500.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (961,'01H000690','Mastin Capsul 60''s','01.001','','02','',0,'',0,'H','',38500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,38500.00,0.00,45000.00,50000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (962,'01H000691','Maximus 500 3x10''s','01.001','','13','',0,'',0,'H','',14400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14400.00,0.00,16300.00,16500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (963,'01H000692','MBK Putih 12''s','01.001','','11','',0,'',0,'H','',1350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1350.00,0.00,1500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (964,'01H000693','medicated oil 12ml','01.001','','02','',0,'',0,'H','',12300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12300.00,0.00,13500.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (965,'01H000694','Medicated oil 20ml','01.001','','02','',0,'',0,'H','',15800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15800.00,0.00,17500.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (966,'01H000695','Mensana 6''s','01.001','','10','',0,'',0,'H','',1475.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1475.00,0.00,1700.00,1700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (967,'01H000696','Merit ','01.001','','11','',0,'',0,'H','',10500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10500.00,0.00,11700.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (968,'01H000697','Merit Plus','01.001','','09','',0,'',0,'H','',17300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17300.00,0.00,19000.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (969,'01H000698','Methioson 30''s','01.001','','02','',0,'',0,'H','',31350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31350.00,0.00,34500.00,36000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (970,'01H000699','Microlax tube','01.001','','09','',0,'',0,'H','',16250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16250.00,0.00,17800.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (971,'01H000700','Mikorex Cair','01.001','','02','',0,'',0,'H','',1700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1700.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (972,'01H000701','Mikorex Salep','01.001','','02','',0,'',0,'H','',2375.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2375.00,0.00,2600.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (973,'01H000702','Minol 5 ml','01.001','','09','',0,'',0,'H','',3150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3150.00,0.00,3500.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (974,'01H000703','Minyak Angin Beruang 18 gr','01.001','','02','',0,'',0,'H','',14700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14700.00,0.00,16300.00,16500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (975,'01H000704','Minyak Angin Beruang 8 gr','01.001','','02','',0,'',0,'H','',9583.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9583.00,0.00,10600.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (976,'01H000705','Minyak angin Lang  12 ml','01.001','','02','',0,'',0,'H','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,13200.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (977,'01H000706','Minyak angin Lang  6 ml','01.001','','02','',0,'',0,'H','',6200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6200.00,0.00,6800.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (978,'01H000707','Minyak Angin Lang 3 ml','01.001','','02','',0,'',0,'H','',4200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4200.00,0.00,4600.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (979,'01H000708','Minyak A. Fresh Care Hot','01.001','','02','',0,'',0,'H','',9250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9250.00,0.00,10500.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (980,'01H000709','Minyak A. Fresh Care Original','01.001','','02','',0,'',0,'H','',9250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9250.00,0.00,10500.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (981,'01H000710','Minyak A. Fresh Care original + Gantungan','01.001','','09','',0,'',0,'H','',16400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16400.00,0.00,18000.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (982,'01H000711','Minyak A. Fresh Care Original 5 ml','01.001','','02','',0,'',0,'H','',5500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (983,'01H000712','Minyak A. FreshCare Frutty','01.001','','02','',0,'',0,'H','',9250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9250.00,0.00,10500.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (984,'01H000713','Minyak A. FreshCare GreenTea','01.001','','02','',0,'',0,'H','',9250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9250.00,0.00,10500.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (985,'01H000714','Minyak A. FreshCare Sportty','01.001','','09','',0,'',0,'H','',9250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9250.00,0.00,10500.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (986,'01H000715','Minyak A. FreshCare Teens','01.001','','09','',0,'',0,'H','',15334.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15334.00,0.00,17000.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (987,'01H000716','Minyak Ikan 500''s','01.001','','11','',0,'',0,'H','',1200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1200.00,0.00,1500.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (988,'01H000717','Minyak Ikan Tunghai (Sak)','01.001','','11','',0,'',0,'H','',30000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,30000.00,0.00,38000.00,40000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (989,'01H000718','Minyak Kapak 10','01.001','','02','',0,'',0,'H','',10300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10300.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (990,'01H000719','Minyak Kapak 14','01.001','','02','',0,'',0,'H','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16500.00,16500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (991,'01H000720','Minyak Kapak 28','01.001','','02','',0,'',0,'H','',25250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,25250.00,0.00,27800.00,28000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (992,'01H000721','Minyak Kapak 3','01.001','','02','',0,'',0,'H','',3870.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3870.00,0.00,4300.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (993,'01H000722','Minyak Kapak 5 ml','01.001','','02','',0,'',0,'H','',6580.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6580.00,0.00,7300.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (994,'01H000723','Minyak Kapak 56 ml','01.001','','02','',0,'',0,'H','',44200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,44200.00,0.00,48600.00,49000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (995,'01H000724','Minyak Otot Geliga 30','01.001','','02','',0,'',0,'H','',9400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9400.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (996,'01H000725','Minyak Otot Geliga 60','01.001','','02','',0,'',0,'H','',17700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17700.00,0.00,19500.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (997,'01H000726','Minyak Tawon cc','01.001','','02','',0,'',0,'H','',10500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10500.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (998,'01H000727','Minyak tawon dd','01.001','','02','',0,'',0,'H','',14300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14300.00,0.00,15800.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (999,'01H000728','Minyak tawon EE','01.001','','02','',0,'',0,'H','',23200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23200.00,0.00,25500.00,26000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1000,'01H000729','Minyak Telon Cito 100 ml','01.001','','02','',0,'',0,'H','',11000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11000.00,0.00,12100.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00','');
COMMIT;

#
# Data for the `data_barang_master` table  (LIMIT 1001,500)
#

INSERT INTO `data_barang_master` (`barang_id`, `barang_kode`, `barang_nama`, `barang_supplier`, `barang_jenis`, `barang_satuan_kecil`, `barang_satuan_tengah`, `barang_satuan_tengah_jumlah`, `barang_satuan_besar`, `barang_satuan_besar_jumlah`, `barang_logo`, `barang_keterangan`, `barang_harga_beli`, `barang_harga_beli_d1`, `barang_harga_beli_d2`, `barang_harga_beli_d3`, `barang_harga_beli_klaim`, `barang_harga_jual`, `barang_harga_jual_d1`, `barang_harga_jual_d2`, `barang_harga_jual_d3`, `barang_harga_jual_d4`, `barang_harga_jual_d5`, `barang_harga_jual_mt`, `barang_harga_jual_horeka`, `barang_harga_jual_rita`, `barang_harga_jual_discount`, `barang_stok_awal`, `barang_stok_minimal`, `barang_berat`, `barang_status`, `barang_status_pajak`, `barang_reg_date`, `barang_reg_alias`, `barang_upd_date`, `barang_upd_alias`) VALUES

  (1001,'01H000730','Minyak Telon Cito 60 ml','01.001','','02','',0,'',0,'H','',7200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7200.00,0.00,8000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1002,'01H000731','Minyak Telon dragon 30 ml','01.001','','02','',0,'',0,'H','',5200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5200.00,0.00,5800.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1003,'01H000732','Minyak telon dragon 60 ml','01.001','','02','',0,'',0,'H','',9750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9750.00,0.00,10700.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1004,'01H000733','Minyak Telon Gajah 30','01.001','','02','',0,'',0,'H','',5500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1005,'01H000734','Minyak Telon Gajah 60','01.001','','02','',0,'',0,'H','',11400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11400.00,0.00,12500.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1006,'01H000735','Minyak Telon Konicare 60 ml','01.001','','02','',0,'',0,'H','',0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1007,'01H000736','Minyak Telon Konicare Plus 60 ml','01.001','','02','',0,'',0,'H','',19800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19800.00,0.00,21800.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1008,'01H000737','Minyak Telon Lang  30 ml','01.001','','02','',0,'',0,'H','',6500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6500.00,0.00,7200.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1009,'01H000738','Minyak Telon Lang 100 ml','01.001','','02','',0,'',0,'H','',19250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19250.00,0.00,21200.00,21500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1010,'01H000739','Minyak Telon Lang 60ml','01.001','','02','',0,'',0,'H','',12400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12400.00,0.00,13600.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1011,'01H000740','Minyak Telon Ny Menner 30 ml','01.001','','02','',0,'',0,'H','',7600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7600.00,0.00,8500.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1012,'01H000741','Minyak Telon Ny Menner 60 ml','01.001','','02','',0,'',0,'H','',14500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14500.00,0.00,16000.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1013,'01H000742','Mipi 30 ml','01.001','','02','',0,'',0,'H','',11000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11000.00,0.00,12100.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1014,'01H000743','Mipi 60 ml','01.001','','02','',0,'',0,'H','',18150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18150.00,0.00,20000.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1015,'01H000744','Mipi Roll on ','01.001','','09','',0,'',0,'H','',12650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12650.00,0.00,14000.00,14000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1016,'01H000745','Mirasic Forte Tab 10x10''s','01.001','','13','',0,'',0,'H','',17250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17250.00,0.00,19000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1017,'01H000746','Mirasic Sirup','01.001','','02','',0,'',0,'H','',3470.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3470.00,0.00,3800.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1018,'01H000747','Mirasic Tab 10x10''s','01.001','','13','',0,'',0,'H','',15500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15500.00,0.00,17000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1019,'01H000748','Mkp Dragon 100','01.001','','02','',0,'',0,'H','',16875.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16875.00,0.00,18500.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1020,'01H000749','MKP Dragon 15','01.001','','02','',0,'',0,'H','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1021,'01H000750','Mkp Dragon 30','01.001','','02','',0,'',0,'H','',5400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5400.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1022,'01H000751','Mkp Dragon 60','01.001','','02','',0,'',0,'H','',10600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10600.00,0.00,11700.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1023,'01H000752','MKP Gajah 30','01.001','','02','',0,'',0,'H','',6830.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6830.00,0.00,7500.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1024,'01H000753','MKp Gajah 60','01.001','','02','',0,'',0,'H','',13000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13000.00,0.00,14300.00,14500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1025,'01H000754','MKP Konicare 60 ml','01.001','','02','',0,'',0,'H','',15525.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15525.00,0.00,17200.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1026,'01H000755','MKP lang  120 ml','01.001','','02','',0,'',0,'H','',25400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,25400.00,0.00,28000.00,28000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1027,'01H000756','MKp Lang 15 ml','01.001','','02','',0,'',0,'H','',3750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3750.00,0.00,4100.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1028,'01H000757','MKP lang 30 ml','01.001','','02','',0,'',0,'H','',7000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7000.00,0.00,7700.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1029,'01H000758','MKP Lang 60 ml','01.001','','02','',0,'',0,'H','',13300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13300.00,0.00,14700.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1030,'01H000759','MKP Tresnojoyo 30 ml','01.001','','02','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1031,'01H000760','MKP Tresnojoyo 60 ml','01.001','','02','',0,'',0,'H','',9000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9000.00,0.00,10000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1032,'01H000761','Molagit Tab 15x10','01.001','','13','',0,'',0,'H','',3700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3700.00,0.00,4000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1033,'01H000762','Molakrim 30 gr','01.001','','17','',0,'',0,'H','',8500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8500.00,0.00,9500.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1034,'01H000763','Momilen Baby Drop 10 ml','01.001','','02','',0,'',0,'H','',10437.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10437.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1035,'01H000764','Momilen Baby Gold Sirup 60 ml','01.001','','02','',0,'',0,'H','',11100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11100.00,0.00,12300.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1036,'01H000765','Momilen Baby Lisine 60 ml','01.001','','02','',0,'',0,'H','',7300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7300.00,0.00,8000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1037,'01H000766','Momilen Diaper Rash 15 gr','01.001','','17','',0,'',0,'H','',9800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9800.00,0.00,10800.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1038,'01H000767','Momilen Diaper Rash 30 gr','01.001','','17','',0,'',0,'H','',17600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17600.00,0.00,19400.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1039,'01H000768','Momilen Nursing cream 15 gr','01.001','','17','',0,'',0,'H','',17700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17700.00,0.00,19500.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1040,'01H000769','Momilen Nursing cream 5 gr','01.001','','17','',0,'',0,'H','',9900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9900.00,0.00,11000.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1041,'01H000770','Momilen Pregnancy & Lactasi Tab 5x10','01.001','','13','',0,'',0,'H','',8360.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8360.00,0.00,9200.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1042,'01H000771','Momilen Pregnancy Tab 5x10','01.001','','13','',0,'',0,'H','',8360.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8360.00,0.00,9200.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1043,'01H000772','Momilen Tummy 30 gr','01.001','','17','',0,'',0,'H','',31350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31350.00,0.00,34500.00,36500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1044,'01H000773','Monalisa Jumbo','01.001','','11','',0,'',0,'H','',21645.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21645.00,0.00,23800.00,24000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1045,'01H000774','Monalisa Maternity','01.001','','11','',0,'',0,'H','',9576.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9576.00,0.00,10500.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1046,'01H000775','Mulsanol Sirup 60 ml','01.001','','02','',0,'',0,'H','',3850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3850.00,0.00,4300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1047,'01H000776','My Baby HB Wash 100','01.001','','02','',0,'',0,'H','',6700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6700.00,0.00,7500.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1048,'01H000777','My Baby Kayu Putih plus 60 ml','01.001','','02','',0,'',0,'H','',12900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12900.00,0.00,14300.00,14500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1049,'01H000778','My Baby Liquid soap 100 ml','01.001','','02','',0,'',0,'H','',6800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6800.00,0.00,7500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1050,'01H000779','My Baby Milk Soap','01.001','','02','',0,'',0,'H','',6800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6800.00,0.00,7500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1051,'01H000780','My Baby Powder 100 All Variant','01.001','','02','',0,'',0,'H','',4800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4800.00,0.00,5300.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1052,'01H000781','My Baby Powder 150 All Variant','01.001','','02','',0,'',0,'H','',6550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6550.00,0.00,7200.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1053,'01H000782','My Baby Shampo 100 ml','01.001','','02','',0,'',0,'H','',6900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6900.00,0.00,7600.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1054,'01H000783','My Baby Soap ','01.001','','09','',0,'',0,'H','',2450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2450.00,0.00,2700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1055,'01H000784','My Baby Telon 60 ml','01.001','','02','',0,'',0,'H','',10000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10000.00,0.00,11000.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1056,'01H000785','My Baby Telon Plus  90 ml','01.001','','02','',0,'',0,'H','',17250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17250.00,0.00,19000.00,19500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1057,'01H000786','My Baby Telon Plus 60 ml','01.001','','02','',0,'',0,'H','',12750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12750.00,0.00,14000.00,14500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1058,'01H000787','Mylanta Sir 150','01.001','','02','',0,'',0,'H','',27650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27650.00,0.00,31000.00,31000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1059,'01H000788','Mylanta Sir 50 ','01.001','','02','',0,'',0,'H','',9300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9300.00,0.00,10300.00,10500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1060,'01H000789','Mylanta Tab 10x10''s','01.001','','13','',0,'',0,'H','',4625.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4625.00,0.00,5300.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1061,'01H000790','Myloxan Sirup 150 ml','01.001','','02','',0,'',0,'H','',11000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11000.00,0.00,12200.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1062,'01H000791','Myloxan Tab 10x10''s','01.001','','13','',0,'',0,'H','',16500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16500.00,0.00,18500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1063,'01M000001','Abu Injeksi','01.001','002','18','',0,'',0,'M','',461.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,461.00,0.00,520.00,550.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1064,'01M000002','Acetylsistein Capsul 10x10''s','01.001','','13','',0,'',0,'M','',10175.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10175.00,0.00,11200.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1065,'01M000003','Acifar Cream 5 gr','01.001','','17','',0,'',0,'M','',4050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4050.00,0.00,4500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1066,'01M000004','Acyclovir  200 mg 10x10 if','01.001','','13','',0,'',0,'M','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,4300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1067,'01M000005','Acyclovir 400 mg 10x10''s KF','01.001','','13','',0,'',0,'M','',5140.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5140.00,0.00,5850.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1068,'01M000006','Acyclovir Cream INF (24'')','01.001','','17','',0,'',0,'M','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1069,'01M000007','Acyclovir Cream KF (24'')','01.001','','17','',0,'',0,'M','',3150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3150.00,0.00,3400.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1070,'01M000008','Adrome Tab 10x10''s','01.001','','13','',0,'',0,'M','',41800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,41800.00,0.00,46000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1071,'01M000009','Alletrol TM','01.001','','02','',0,'',0,'M','',9332.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9332.00,0.00,10300.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1072,'01M000010','Alletrol ZM','01.001','','17','',0,'',0,'M','',8350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8350.00,0.00,9300.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1073,'01M000011','Allopurinol Tab INF 10x10''s','01.001','','13','',0,'',0,'M','',13200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13200.00,0.00,14500.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1074,'01M000012','Alofar 100 mg Tab 10x10''s','01.001','','13','',0,'',0,'M','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1075,'01M000013','Alofar 300 mg Tab 10x10''s','01.001','','13','',0,'',0,'M','',30000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,30000.00,0.00,33000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1076,'01M000014','Aludona Tab 10x10','01.001','','13','',0,'',0,'M','',5844.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5844.00,0.00,6500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1077,'01M000015','Ambroxol 15 mg/5 ml Sirup INF ','01.001','','02','',0,'',0,'M','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3700.00,4500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1078,'01M000016','Ambroxol 30 mg Tab INF 10x10''s','01.001','','13','',0,'',0,'M','',12500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12500.00,0.00,14000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1079,'01M000017','Aminophylin Inj Phapros 30''s','01.001','','01','',0,'',0,'M','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1080,'01M000018','Aminophylin Tab IF 100''s','01.001','','15','',0,'',0,'M','',113.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,113.00,0.00,150.00,200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1081,'01M000019','Aminophyllin Inj Ethica 24''s','01.001','','01','',0,'',0,'M','',4750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4750.00,0.00,5300.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1082,'01M000020','Amlodipin  10 mg 5x10''s KF','01.001','','13','',0,'',0,'M','',10156.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10156.00,0.00,13500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1083,'01M000021','Amlodipin 10 mg IF 3x10''s','01.001','','13','',0,'',0,'M','',12700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12700.00,0.00,14000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1084,'01M000022','Amlodipin 5 mg 5x10''s KF','01.001','','13','',0,'',0,'M','',9600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9600.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1085,'01M000023','Amlodipin 5 mg Berno 3x10''s','01.001','','13','',0,'',0,'M','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1086,'01M000024','Amlodipin 5 mg Dexa 5x10''s','01.001','','13','',0,'',0,'M','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1087,'01M000025','Amlodipin 5 mg Hexp (3x10''s)','01.001','','13','',0,'',0,'M','',6240.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6240.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1088,'01M000026','Amlodipin 5 mg If  (3x10)','01.001','','13','',0,'',0,'M','',9111.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9111.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1089,'01M000027','Amostera 500 mg','01.001','','13','',0,'',0,'M','',35500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,35500.00,0.00,40000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1090,'01M000028','Amoxsan Forte Sirup 60 ml','01.001','','02','',0,'',0,'M','',31000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31000.00,0.00,34000.00,38000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1091,'01M000029','Amoxsan sirup 60 ml','01.001','','02','',0,'',0,'M','',21681.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21681.00,0.00,24000.00,27000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1092,'01M000030','Amoxycillin 500 mg  Hexp 10x10''s','01.001','','13','',0,'',0,'M','',32600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32600.00,0.00,35800.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1093,'01M000031','Amoxycillin 500 mg  KF 10x10''s','01.001','','13','',0,'',0,'M','',37000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,37000.00,0.00,41000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1094,'01M000032','Ampicillin 500 mg 10x10''s errita','01.001','','13','',0,'',0,'M','',36000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36000.00,0.00,40000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1095,'01M000033','Ampicillin 500 mg 10x10''s KF','01.001','','13','',0,'',0,'M','',40000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,40000.00,0.00,44000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1096,'01M000034','Anastan Tab 10x10''s','01.001','','13','',0,'',0,'M','',18750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18750.00,0.00,21000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1097,'01M000035','Andalan Harmonis Inj (20)','01.001','','18','',0,'',0,'M','',6250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6250.00,0.00,6900.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1098,'01M000036','Andalan inj 3 bln  3 ml','01.001','','18','',0,'',0,'M','',6150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6150.00,0.00,6800.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1099,'01M000037','Andalan Inj 3 bln 1 ml','01.001','','18','',0,'',0,'M','',6150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6150.00,0.00,6800.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1100,'01M000038','Andalan laktasi (30 stp)','01.001','','13','',0,'',0,'M','',9900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9900.00,0.00,10900.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1101,'01M000039','Andalan pil 30''s','01.001','','13','',0,'',0,'M','',4000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4000.00,0.00,4500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1102,'01M000040','Andalan Pil Fe','01.001','','13','',0,'',0,'M','',8000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8000.00,0.00,9000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1103,'01M000041','Antalgin Tab Inf','01.001','','13','',0,'',0,'M','',14800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14800.00,0.00,17000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1104,'01M000042','Antalgin Tab Nova (1000''s)','01.001','','06','',0,'',0,'M','',77600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,77600.00,0.00,86000.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1105,'01M000043','Antalgin Zenith 1000''s','01.001','','06','',0,'',0,'M','',106300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,106300.00,0.00,117000.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1106,'01M000044','Antihemorroid Suppo 10''s','01.001','','14','',0,'',0,'M','',2000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2000.00,0.00,2200.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1107,'01M000045','Aqua Pro Injectio Berno 10 cc','01.001','','01','',0,'',0,'M','',1980.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1980.00,0.00,2200.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1108,'01M000046','Aqua Pro Injectio GMP 20 ml','01.001','','18','',0,'',0,'M','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,4500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1109,'01M000047','Armacort Cream 5 gr','01.001','','17','',0,'',0,'M','',4650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4650.00,0.00,5100.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1110,'01M000048','Asam Mefenamat 500 Afi 10x10''s','01.001','','13','',0,'',0,'M','',13500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13500.00,0.00,16000.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1111,'01M000049','Astherin Sirup 100 ml','01.001','','02','',0,'',0,'M','',6875.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6875.00,0.00,7600.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1112,'01M000050','Astherin Tab 10x10''s','01.001','','13','',0,'',0,'M','',1893.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1893.00,0.00,2100.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1113,'01M000051','ATS INJ 1500 UI','01.001','','01','',0,'',0,'M','',123300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,123300.00,0.00,136000.00,150000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1114,'01M000052','Bactoderm Cream','01.001','','17','',0,'',0,'M','',39200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,39200.00,0.00,43500.00,45000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1115,'01M000053','Bactoprim comb sirup','01.001','','02','',0,'',0,'M','',6270.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6270.00,0.00,6900.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1116,'01M000054','Benodon Inj 10''s','01.001','','18','',0,'',0,'M','',7300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7300.00,0.00,8100.00,9500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1117,'01M000055','Benoson Cream 5 gr ','01.001','','17','',0,'',0,'M','',9800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9800.00,0.00,10800.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1118,'01M000056','Benoson N Cream','01.001','','17','',0,'',0,'M','',12100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12100.00,0.00,13500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1119,'01M000057','Berotec Inhaler','01.001','','09','',0,'',0,'M','',122661.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,122661.00,0.00,135000.00,135000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1120,'01M000058','Betametason Cream FM','01.001','','17','',0,'',0,'M','',2300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2300.00,0.00,2600.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1121,'01M000059','Betametason Cream Kf','01.001','','17','',0,'',0,'M','',2250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2250.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1122,'01M000060','Betason Cream ','01.001','','17','',0,'',0,'M','',7250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7250.00,0.00,8000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1123,'01M000061','Betason N Cream','01.001','','17','',0,'',0,'M','',8900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8900.00,0.00,10000.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1124,'01M000062','Bevalex Cream','01.001','','17','',0,'',0,'M','',6535.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6535.00,0.00,7200.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1125,'01M000063','Bintamox 500 10x10''s','01.001','','13','',0,'',0,'M','',39000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,39000.00,0.00,47000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1126,'01M000064','Bioplacenton Tube','01.001','','17','',0,'',0,'M','',10120.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10120.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1127,'01M000065','Bioplan gel','01.001','','17','',0,'',0,'M','',7780.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7780.00,0.00,8600.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1128,'01M000066','Biothicol sirup 125 mg','01.001','','02','',0,'',0,'M','',19800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19800.00,0.00,21800.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1129,'01M000067','Bisoprolol Fumarate Tab Dexa 3x10''s','01.001','','13','',0,'',0,'M','',9300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9300.00,0.00,10300.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1130,'01M000068','Broadamox 500 mg 10x10''s','01.001','','13','',0,'',0,'M','',42500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,42500.00,0.00,47000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1131,'01M000069','Broadamox Sirup','01.001','','02','',0,'',0,'M','',3740.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3740.00,0.00,4200.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1132,'01M000070','Bronsolvan tab 10x10','01.001','','13','',0,'',0,'M','',33000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33000.00,0.00,36500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1133,'01M000071','Bufacaryl Tab 10x10''s','01.001','','13','',0,'',0,'M','',12400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12400.00,0.00,14500.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1134,'01M000072','Bufacomb In Oral Base','01.001','','17','',0,'',0,'M','',12540.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12540.00,0.00,14000.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1135,'01M000073','Bufacort N Cream ','01.001','','17','',0,'',0,'M','',4000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4000.00,0.00,4400.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1136,'01M000074','Captopril 12,5 mg Dexa 10x10''s','01.001','','13','',0,'',0,'M','',7200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7200.00,0.00,9000.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1137,'01M000075','Captopril 12,5 mg INF 10x10''s','01.001','','13','',0,'',0,'M','',8200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8200.00,0.00,9000.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1138,'01M000076','Captopril 25 mg Dexa 10x10''s','01.001','','13','',0,'',0,'M','',9800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9800.00,0.00,13500.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1139,'01M000077','Captopril 25 mg IF 10x10''s','01.001','','13','',0,'',0,'M','',8500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8500.00,0.00,13500.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1140,'01M000078','Captopril 25 mg KF 10x10''s','01.001','','13','',0,'',0,'M','',13800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13800.00,0.00,15300.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1141,'01M000079','Captopril 25 Phapros ','01.001','','13','',0,'',0,'M','',9000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9000.00,0.00,13500.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1142,'01M000080','Carbidu 0,5 20x10''s','01.001','','13','',0,'',0,'M','',19800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19800.00,0.00,21800.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1143,'01M000081','Carbidu 0,75 20x10''s','01.001','','13','',0,'',0,'M','',22000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22000.00,0.00,24200.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1144,'01M000082','Cataflam 25 mg 5x10''s','01.001','','15','',0,'',0,'M','',2250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2250.00,0.00,2500.00,2700.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1145,'01M000083','Cataflam 50 5x10''s','01.001','','15','',0,'',0,'M','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5000.00,0.00,5500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1146,'01M000084','Catapres Inj 10''s','01.001','','01','',0,'',0,'M','',43300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,43300.00,0.00,47700.00,54000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1147,'01M000085','Cazetin Drops 15 ml','01.001','','02','',0,'',0,'M','',17200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17200.00,0.00,19000.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1148,'01M000086','Cedocard 5 mg ','01.001','','13','',0,'',0,'M','',9170.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9170.00,0.00,10200.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1149,'01M000087','Cefadroxil 500 mg Hexp 10x10''s','01.001','','13','',0,'',0,'M','',63000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,63000.00,0.00,77000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1150,'01M000088','Cefadroxil 500 mg IF 5x10''s','01.001','','13','',0,'',0,'M','',8392.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8392.00,0.00,9300.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1151,'01M000089','Cefat Sirup 60 ml','01.001','','02','',0,'',0,'M','',41580.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,41580.00,0.00,45800.00,50000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1152,'01M000090','Cefixim 100 mg Hexp 5x10','01.001','','13','',0,'',0,'M','',12000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12000.00,0.00,15000.00,22500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1153,'01M000091','Cefixim 100 mg IF 3x10''s','01.001','','13','',0,'',0,'M','',23922.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23922.00,0.00,26500.00,28500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1154,'01M000092','Cefixim sirup Hexp','01.001','','02','',0,'',0,'M','',21750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21750.00,0.00,24000.00,26500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1155,'01M000093','Ceftriaxon Inj Hj 2 Vials','01.001','','05','',0,'',0,'M','',8600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8600.00,0.00,10000.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1156,'01M000094','Cendo Albuvit 10 % TM','01.001','','02','',0,'',0,'M','',11200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11200.00,0.00,12500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1157,'01M000095','Cendo Carpine 1 % TM','01.001','','02','',0,'',0,'M','',17050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17050.00,0.00,19000.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1158,'01M000096','Cendo Catarlent TM 5ml','01.001','','17','',0,'',0,'M','',23000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23000.00,0.00,25300.00,26000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1159,'01M000097','Cendo Cenfresh MD','01.001','','13','',0,'',0,'M','',23500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23500.00,0.00,25900.00,27000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1160,'01M000098','Cendo Corthon TM 5ml','01.001','','02','',0,'',0,'M','',22300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22300.00,0.00,27300.00,27500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1161,'01M000099','Cendo Genta TM 0,3 %','01.001','','02','',0,'',0,'M','',23925.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23925.00,0.00,26500.00,27000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1162,'01M000100','Cendo Hyalub 5 ml TM','01.001','','02','',0,'',0,'M','',58375.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,58375.00,0.00,64500.00,65000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1163,'01M000101','Cendo Midriatyl 0,5 % TM 5 ml','01.001','','02','',0,'',0,'M','',29380.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29380.00,0.00,32500.00,33000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1164,'01M000102','Cendo Midriatyl 1 % TM 5 ml','01.001','','17','',0,'',0,'M','',40150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,40150.00,0.00,44500.00,45500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1165,'01M000103','Cendo Polydex TM 5 ml','01.001','','02','',0,'',0,'M','',35750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,35750.00,0.00,39700.00,40000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1166,'01M000104','Cendo Timol 0,5 % 5 ml','01.001','','02','',0,'',0,'M','',52525.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,52525.00,0.00,58000.00,59000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1167,'01M000105','Cendo Tobroson TM MD ','01.001','','13','',0,'',0,'M','',29500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29500.00,0.00,32500.00,33000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1168,'01M000106','Cendo TobrosonTM  5 ml','01.001','','02','',0,'',0,'M','',47000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,47000.00,0.00,51800.00,52000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1169,'01M000107','Cendo Vitrolenta MD','01.001','','13','',0,'',0,'M','',24200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,24200.00,0.00,26800.00,27500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1170,'01M000108','Cendo Xitrol TM 5 ml','01.001','','02','',0,'',0,'M','',27225.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27225.00,0.00,30000.00,30000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1171,'01M000109','Cendo Xitrol TM MD','01.001','','13','',0,'',0,'M','',25500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,25500.00,0.00,28000.00,28000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1172,'01M000110','Cetirizine Hexp','01.001','','13','',0,'',0,'M','',2200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2200.00,0.00,3500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1173,'01M000111','Cetirizine IF 5x10''s','01.001','','13','',0,'',0,'M','',3132.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3132.00,0.00,3500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1174,'01M000112','Cetirizine KF 5x10''s','01.001','','13','',0,'',0,'M','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3700.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1175,'01M000113','Cetirizine Landson 10x10''s','01.001','','13','',0,'',0,'M','',2600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2600.00,0.00,3500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1176,'01M000114','Cetirizine Novell  5x10''s','01.001','','13','',0,'',0,'M','',2612.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2612.00,0.00,3500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1177,'01M000115','Chloramphecort H cream 10 gr','01.001','','17','',0,'',0,'M','',8950.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8950.00,0.00,10000.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1178,'01M000116','Chloramphenicol caps IF 12x10''s','01.001','','13','',0,'',0,'M','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3700.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1179,'01M000117','Cimetidine 200 mg KF 10x10''s','01.001','','13','',0,'',0,'M','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,12800.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1180,'01M000118','Cindala Gel','01.001','','17','',0,'',0,'M','',20000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20000.00,0.00,22500.00,23000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1181,'01M000119','Cinolon Cr 10 gr','01.001','','17','',0,'',0,'M','',14751.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14751.00,0.00,16300.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1182,'01M000120','Cinolon N 10 gr','01.001','','17','',0,'',0,'M','',17000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17000.00,0.00,18700.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1183,'01M000121','Ciprofloxacin 10x10''s IF','01.001','','13','',0,'',0,'M','',28500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28500.00,0.00,31500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1184,'01M000122','Ciprofloxacin 10x10''s Sanbe','01.001','','13','',0,'',0,'M','',31000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31000.00,0.00,34000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1185,'01M000123','Ciprofloxacin 500 hj 10x10','01.001','','13','',0,'',0,'M','',36300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36300.00,0.00,40000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1186,'01M000124','Citicolin Inj 250 5''s','01.001','','01','',0,'',0,'M','',14300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14300.00,0.00,16000.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1187,'01M000125','Citoprim Sirup','01.001','','02','',0,'',0,'M','',3100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3100.00,0.00,3500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1188,'01M000126','Clindamycin 150 mg Novell 5x10''s','01.001','','13','',0,'',0,'M','',4750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4750.00,0.00,5600.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1189,'01M000127','Clindamycin 300 mg Novell 5x10''s','01.001','','13','',0,'',0,'M','',35000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,35000.00,0.00,39500.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1190,'01M000128','Clonaderm Cream 5 gr','01.001','','17','',0,'',0,'M','',5300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5300.00,0.00,5900.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1191,'01M000129','Clonidin 0,15 10x10''s INF','01.001','','13','',0,'',0,'M','',20500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20500.00,0.00,23000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1192,'01M000130','Colipred Cream 5 gr','01.001','','17','',0,'',0,'M','',3500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3500.00,0.00,3900.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1193,'01M000131','Comtusi Sirup 60 ml','01.001','','02','',0,'',0,'M','',33900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33900.00,0.00,37300.00,38000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1194,'01M000132','CTM Zenith Kalengan','01.001','','06','',0,'',0,'M','',15700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15700.00,0.00,17500.00,100.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1195,'01M000133','Cyanocobalamin Inj GMP','01.001','','18','',0,'',0,'M','',5100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5100.00,0.00,6000.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1196,'01M000134','Cyclogeston Inj 20''s','01.001','','18','',0,'',0,'M','',6250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6250.00,0.00,6900.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1197,'01M000135','Cyclovem Inj 20''s','01.001','','18','',0,'',0,'M','',8624.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8624.00,0.00,9500.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1198,'01M000136','Elomox Cream','01.001','','17','',0,'',0,'M','',5750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5750.00,0.00,6500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1199,'01M000137','Eltazon Tab 10x10''s','01.001','','13','',0,'',0,'M','',12700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12700.00,0.00,14000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1200,'01M000138','Enbatic Salep Kulit','01.001','','17','',0,'',0,'M','',5800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5800.00,0.00,6800.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1201,'01M000139','Enbatic Serbuk Tabur 36''s','01.001','','11','',0,'',0,'M','',2150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2150.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1202,'01M000140','Erlamycetin Plus TM','01.001','','02','',0,'',0,'M','',7000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7000.00,0.00,7800.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1203,'01M000141','Erlamycetin TT','01.001','','02','',0,'',0,'M','',3850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3850.00,0.00,4500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1204,'01M000142','Erlamycetin Zm','01.001','','17','',0,'',0,'M','',4200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4200.00,0.00,4700.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1205,'01M000143','Ermethason 0,5 10x10''s','01.001','','13','',0,'',0,'M','',6450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6450.00,0.00,7500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1206,'01M000144','Erphaflam 5x10''s','01.001','','13','',0,'',0,'M','',9750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9750.00,0.00,12000.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1207,'01M000145','Estalex Tab 5x10''s','01.001','','13','',0,'',0,'M','',34650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34650.00,0.00,38500.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1208,'01M000146','Etaflox Tab 10x10''s','01.001','','13','',0,'',0,'M','',34500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34500.00,0.00,38000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1209,'01M000147','Etamox Sirup','01.001','','02','',0,'',0,'M','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,3600.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1210,'01M000148','Etamox Tab 10x10''s','01.001','','13','',0,'',0,'M','',35000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,35000.00,0.00,40000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1211,'01M000149','Etamoxul Sir ','01.001','','02','',0,'',0,'M','',3400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3400.00,0.00,3750.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1212,'01M000150','Etamoxul Tab 10x10''s','01.001','','13','',0,'',0,'M','',19000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19000.00,0.00,21000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1213,'01M000151','Etaphenin Forte 10x10','01.001','','13','',0,'',0,'M','',16000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16000.00,0.00,18500.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1214,'01M000152','Ethylchlorid Kaca','01.001','','02','',0,'',0,'M','',110000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,110000.00,0.00,121000.00,125000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1215,'01M000153','Exluton Tab','01.001','','13','',0,'',0,'M','',17800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17800.00,0.00,19600.00,20500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1216,'01M000154','Famotidin 20 mg IF (5x10''s)','01.001','','13','',0,'',0,'M','',950.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,950.00,0.00,1400.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1217,'01M000155','Famotidin 40 mg IF (5x10''s)','01.001','','13','',0,'',0,'M','',1800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1800.00,0.00,2000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1218,'01M000156','Fargetik Tab 10x10''s','01.001','','13','',0,'',0,'M','',17000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17000.00,0.00,19000.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1219,'01M000157','Fargoxin 0,25 10x10','01.001','','13','',0,'',0,'M','',13000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13000.00,0.00,18000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1220,'01M000158','Farizol Suspensi','01.001','','02','',0,'',0,'M','',4000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4000.00,0.00,4400.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1221,'01M000159','Farizol Tab 10x10','01.001','','13','',0,'',0,'M','',20000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20000.00,0.00,22000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1222,'01M000160','Farmalat Tab 10x10','01.001','','13','',0,'',0,'M','',21000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21000.00,0.00,24000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1223,'01M000161','Farmoten 25 10x10''s','01.001','','13','',0,'',0,'M','',17800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17800.00,0.00,24000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1224,'01M000162','Farsifen 400 mg 10x10''s','01.001','','13','',0,'',0,'M','',26150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26150.00,0.00,28800.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1225,'01M000163','Farsycol Cream 5 gr','01.001','','17','',0,'',0,'M','',2700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2700.00,0.00,3000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1226,'01M000164','Fasiprim Sirup','01.001','','02','',0,'',0,'M','',3400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3400.00,0.00,3750.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1227,'01M000165','Favolar 100','01.001','','13','',0,'',0,'M','',25000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,25000.00,0.00,27500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1228,'01M000166','Faxiden 20 mg 10x10','01.001','','13','',0,'',0,'M','',15300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15300.00,0.00,16800.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1229,'01M000167','Fenocin 125 mg Tab 45x12''s','01.001','','13','',0,'',0,'M','',3150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3150.00,0.00,3500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1230,'01M000168','Fenofibrate 100 mg Hexp 3x10','01.001','','13','',0,'',0,'M','',22000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,22000.00,0.00,24200.00,27500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1231,'01M000169','Fg Troches 12x10''s','01.001','','13','',0,'',0,'M','',9400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9400.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1232,'01M000170','Fishqua Capsul','01.001','','02','',0,'',0,'M','',73300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,73300.00,0.00,80700.00,81000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1233,'01M000171','Flasicox 15 mg 5x10''s','01.001','','13','',0,'',0,'M','',6550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6550.00,0.00,7500.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1234,'01M000172','Fucilex Cream','01.001','','17','',0,'',0,'M','',10600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10600.00,0.00,12000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1235,'01M000173','Furosemide 40 mg Tab 10x10''s INF','01.001','','13','',0,'',0,'M','',10200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10200.00,0.00,11500.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1236,'01M000174','Furosemide 40 mg Tab 20x10''s KF','01.001','','13','',0,'',0,'M','',10200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10200.00,0.00,11500.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1237,'01M000175','Furosemide Inj 25''s','01.001','','01','',0,'',0,'M','',2100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2100.00,0.00,2300.00,2600.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1238,'01M000176','Fuson cream','01.001','','17','',0,'',0,'M','',39700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,39700.00,0.00,43700.00,44000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1239,'01M000177','Daktarin Oral Gel','01.001','','17','',0,'',0,'M','',57000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,57000.00,0.00,63000.00,68000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1240,'01M000178','Danasone 0,5 mg Tab 20x10''s','01.001','','13','',0,'',0,'M','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1241,'01M000179','Daryantull 10''s','01.001','','13','',0,'',0,'M','',14850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14850.00,0.00,16300.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1242,'01M000180','Denomix Cream','01.001','','17','',0,'',0,'M','',9560.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9560.00,0.00,10500.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1243,'01M000181','Depo Neo Inj 20''s','01.001','','18','',0,'',0,'M','',6185.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6185.00,0.00,6900.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1244,'01M000182','Dexa M 0,75 15x10''s','01.001','','13','',0,'',0,'M','',1000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1000.00,0.00,1100.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1245,'01M000183','Dexametason Inj  IF 100''s','01.001','','01','',0,'',0,'M','',2000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2000.00,0.00,2200.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1246,'01M000184','Dexametason Inj Phap 100''s','01.001','','01','',0,'',0,'M','',2000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2000.00,0.00,2200.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1247,'01M000185','Dexclosan Tab 10x10''s','01.001','','13','',0,'',0,'M','',13000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13000.00,0.00,14500.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1248,'01M000186','Dexigen Cream 5 gr','01.001','','17','',0,'',0,'M','',5800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5800.00,0.00,6500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1249,'01M000187','Dextamin Plus Tab ','01.001','','13','',0,'',0,'M','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16500.00,16500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1250,'01M000188','Dexteem Plus Tab 10x10','01.001','','13','',0,'',0,'M','',21750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21750.00,0.00,24000.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1251,'01M000189','Dexymox Forte 10x10','01.001','','13','',0,'',0,'M','',41000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,41000.00,0.00,45500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1252,'01M000190','Diane Tab','01.001','','05','',0,'',0,'M','',88600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,88600.00,0.00,100500.00,101000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1253,'01M000191','Digoxin Tab 10x10''s INF','01.001','','13','',0,'',0,'M','',14300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14300.00,0.00,16000.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1254,'01M000192','Digoxin Tab 10x10''s Yarindo','01.001','','13','',0,'',0,'M','',14300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14300.00,0.00,16000.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1255,'01M000193','Diltiazem 30 mg Kf 10x10''s','01.001','','13','',0,'',0,'M','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1256,'01M000194','Dionicol 500 mg 10x10''s','01.001','','13','',0,'',0,'M','',49600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,49600.00,0.00,54500.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1257,'01M000195','Dionicol Sirup 125 mg /5 ml','01.001','','02','',0,'',0,'M','',4000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4000.00,0.00,4500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1258,'01M000196','Dolodon 500 mg 10x10','01.001','','13','',0,'',0,'M','',21700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21700.00,0.00,24000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1259,'01M000197','Domperidom Tab IF 10x10''s ','01.001','','13','',0,'',0,'M','',4032.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4032.00,0.00,4500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1260,'01M000198','Doxycicline 100 mg 10x10''s','01.001','','13','',0,'',0,'M','',2530.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2530.00,0.00,2800.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1261,'01M000199','Dramamine 10x10','01.001','','13','',0,'',0,'M','',13200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13200.00,0.00,14500.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1262,'01M000200','Dumin Rectal 125 mg/ml','01.001','','14','',0,'',0,'M','',11700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11700.00,0.00,13000.00,14500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1263,'01M000201','Dumin Rectal 250 mg/ml','01.001','','14','',0,'',0,'M','',16300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16300.00,0.00,18000.00,21000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1264,'01M000202','Dumocycline 250 mg (25x20''s)','01.001','','04','',0,'',0,'M','',427.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,427.00,0.00,500.00,500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1265,'01M000203','Imodium Tab','01.001','','15','',0,'',0,'M','',6880.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6880.00,0.00,7600.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1266,'01M000204','Inamid Tab 10x10''s','01.001','','13','',0,'',0,'M','',12800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12800.00,0.00,14000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1267,'01M000205','Incidal OD 5x10''s (Ecer)','01.001','','04','',0,'',0,'M','',2300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2300.00,0.00,2500.00,2800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1268,'01M000206','Indoson Cream','01.001','','17','',0,'',0,'M','',3800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3800.00,0.00,4200.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1269,'01M000207','Inerson Cream','01.001','','17','',0,'',0,'M','',21500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21500.00,0.00,25000.00,27500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1270,'01M000208','Inflason 20x10''s','01.001','','13','',0,'',0,'M','',29500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29500.00,0.00,32500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1271,'01M000209','Inpepsa Sirup 100 ml','01.001','','02','',0,'',0,'M','',50600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,50600.00,0.00,55700.00,56000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1272,'01M000210','Interbi Cream 5 gr','01.001','','17','',0,'',0,'M','',23700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23700.00,0.00,26000.00,28500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1273,'01M000211','Interhistin Tab 10x10''s','01.001','','13','',0,'',0,'M','',46500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,46500.00,0.00,57000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1274,'01M000212','Invalgin Tab 10x10','01.001','','13','',0,'',0,'M','',17300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17300.00,0.00,19500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1275,'01M000213','ISDN IF','01.001','','13','',0,'',0,'M','',9300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9300.00,0.00,11000.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1276,'01M000214','Gabiten Tab 10x10''s','01.001','','13','',0,'',0,'M','',26400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26400.00,0.00,29000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1277,'01M000215','Gasela tab 10x10','01.001','','13','',0,'',0,'M','',16300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16300.00,0.00,19000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1278,'01M000216','Gemfibrozil 300 Phapros 10x10''s','01.001','','13','',0,'',0,'M','',30000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,30000.00,0.00,33000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1279,'01M000217','Genalten Cream','01.001','','17','',0,'',0,'M','',2300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2300.00,0.00,2700.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1280,'01M000218','Genoint SK ','01.001','','17','',0,'',0,'M','',3550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3550.00,0.00,4000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1281,'01M000219','Genoint Tm ','01.001','','02','',0,'',0,'M','',6300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6300.00,0.00,7000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1282,'01M000220','Gentamycin TM 0,3 % Inf (10''s)','01.001','','02','',0,'',0,'M','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3700.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1283,'01M000221','Glibenclamid 5 mg INF 10x10''s','01.001','','13','',0,'',0,'M','',8500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8500.00,0.00,9500.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1284,'01M000222','Glibenclamid 5 mg KF 10x10''s','01.001','','13','',0,'',0,'M','',7200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7200.00,0.00,9500.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1285,'01M000223','Glimepiride 1 mg Dexa 5x10''s','01.001','','13','',0,'',0,'M','',6100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6100.00,0.00,6800.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1286,'01M000224','Glimepiride 1 mg Nulab 5x10','01.001','','13','',0,'',0,'M','',6100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6100.00,0.00,6800.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1287,'01M000225','Glimepiride 2 mg Dexa 5x10''s','01.001','','13','',0,'',0,'M','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,13000.00,14500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1288,'01M000226','Glimepiride 2 mg Hexp 5x10''s','01.001','','13','',0,'',0,'M','',10750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10750.00,0.00,12000.00,14500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1289,'01M000227','Glimepiride 2 mg Nulab 5x10','01.001','','13','',0,'',0,'M','',8600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8600.00,0.00,12000.00,14500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1290,'01M000228','Glimepiride 3 mg Nulab 5x10','01.001','','13','',0,'',0,'M','',11800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11800.00,0.00,14000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1291,'01M000229','Glimepiride 4 mg Dexa 5x10''s','01.001','','13','',0,'',0,'M','',20850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20850.00,0.00,23000.00,24000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1292,'01M000230','Gludepatic 500 mg 10x10','01.001','','13','',0,'',0,'M','',18000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18000.00,0.00,25000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1293,'01M000231','Glukosa 5 % (20''s)','01.001','','02','',0,'',0,'M','',5200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5200.00,0.00,5800.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1294,'01M000232','Grafachlor Tab 10x10','01.001','','13','',0,'',0,'M','',10900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10900.00,0.00,13500.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1295,'01M000233','Grafazol 500 mgTab 10x10''s','01.001','','13','',0,'',0,'M','',21000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21000.00,0.00,23500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1296,'01M000234','Grathazon Tab 20x10''s','01.001','','13','',0,'',0,'M','',18200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18200.00,0.00,20000.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1297,'01M000235','Gratheos 50 mg 5x10','01.001','','13','',0,'',0,'M','',8300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8300.00,0.00,10000.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1298,'01M000236','Griseofulvin 125 Mg 10x10','01.001','','13','',0,'',0,'M','',2400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2400.00,0.00,2700.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1299,'01M000237','Griseofulvin 500 mg Prafa 10x10''s','01.001','','13','',0,'',0,'M','',10400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10400.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1300,'01M000238','Haemocaint Oint','01.001','','17','',0,'',0,'M','',54450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,54450.00,0.00,62000.00,63000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1301,'01M000239','Helixim Sirup 100 mg/5 ml','01.001','','02','',0,'',0,'M','',10000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10000.00,0.00,11500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1302,'01M000240','Heltiskin Cream ','01.001','','17','',0,'',0,'M','',16500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16500.00,0.00,18200.00,19000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1303,'01M000241','Histigo Tab 5x10''s','01.001','','13','',0,'',0,'M','',21850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21850.00,0.00,24000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1304,'01M000242','Homoclomin Tab 10x10','01.001','','13','',0,'',0,'M','',21900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21900.00,0.00,24000.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1305,'01M000243','Hufabetamin Sirup','01.001','','02','',0,'',0,'M','',3550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3550.00,0.00,4000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1306,'01M000244','Hufacid Sirup ','01.001','','02','',0,'',0,'M','',3183.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3183.00,0.00,3500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1307,'01M000245','Hufadexon 0,5 mg 1000''s','01.001','','06','',0,'',0,'M','',31000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31000.00,0.00,35000.00,100.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1308,'01M000246','Hufadexon 0,5 mg 20x10''s','01.001','','13','',0,'',0,'M','',680.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,680.00,0.00,750.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1309,'01M000247','Hufadine Tab 10x10','01.001','','13','',0,'',0,'M','',19800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19800.00,0.00,22000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1310,'01M000248','Hufadon Sirup','01.001','','02','',0,'',0,'M','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1311,'01M000249','Hufadon Tab 10x10''s','01.001','','13','',0,'',0,'M','',15000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15000.00,0.00,16500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1312,'01M000250','Hufaflox Tab 10x10','01.001','','13','',0,'',0,'M','',34250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34250.00,0.00,38000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1313,'01M000251','Hufafural sirup','01.001','','02','',0,'',0,'M','',6765.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6765.00,0.00,7500.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1314,'01M000252','Hufamycetin Sirup','01.001','','02','',0,'',0,'M','',4650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4650.00,0.00,5200.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1315,'01M000253','Hufamycetin Tab 10x10''s','01.001','','13','',0,'',0,'M','',33650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33650.00,0.00,37000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1316,'01M000254','Hufanoxil 500 mg 10x10''s','01.001','','13','',0,'',0,'M','',34750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34750.00,0.00,40000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1317,'01M000255','Hufanoxil Sirup','01.001','','02','',0,'',0,'M','',3100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3100.00,0.00,3500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1318,'01M000256','Hufathicol 500 mg Tab 10x10''s','01.001','','13','',0,'',0,'M','',47000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,47000.00,0.00,53000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1319,'01M000257','Hufaxicam 7,5 mg 2x10''s','01.001','','13','',0,'',0,'M','',7000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7000.00,0.00,8000.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1320,'01M000258','Hufaxol Sirup','01.001','','02','',0,'',0,'M','',3150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3150.00,0.00,3500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1321,'01M000259','Hufralgin Tab 10x10','01.001','','13','',0,'',0,'M','',26000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26000.00,0.00,29000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1322,'01M000260','Huki Dot Silicon S/M/L(Toples)','01.001','','09','',0,'',0,'M','',4300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4300.00,0.00,5000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1323,'01M000261','Hydrocortison 2,5 % INF (24''s)','01.001','','17','',0,'',0,'M','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1324,'01M000262','Hydrocortison 2,5 % KF (24''s)','01.001','','17','',0,'',0,'M','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,3300.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1325,'01M000263','Lanadexon Tab ','01.001','','13','',0,'',0,'M','',9900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9900.00,0.00,12500.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1326,'01M000264','Lanzoprazol 30 mg IF 2x10''s','01.001','','13','',0,'',0,'M','',13500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13500.00,0.00,15000.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1327,'01M000265','Lanzoprazol Novell 2x10','01.001','','13','',0,'',0,'M','',11900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11900.00,0.00,13000.00,16000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1328,'01M000266','Lasal Exp sirup 2 mg','01.001','','02','',0,'',0,'M','',34000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34000.00,0.00,37400.00,39000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1329,'01M000267','Lasal Sirup 2 mg','01.001','','02','',0,'',0,'M','',20400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20400.00,0.00,22500.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1330,'01M000268','Latibet 10x10','01.001','','13','',0,'',0,'M','',12250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12250.00,0.00,13500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1331,'01M000269','Laxoberon Drop','01.001','','02','',0,'',0,'M','',60300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,60300.00,0.00,66300.00,67000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1332,'01M000270','Lerzin 10 mg 5x10''s','01.001','','13','',0,'',0,'M','',17500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17500.00,0.00,19500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1333,'01M000271','Lerzin sirup','01.001','','02','',0,'',0,'M','',4200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4200.00,0.00,4700.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1334,'01M000272','Levofloxacin 500 mg 5x10''s','01.001','','16','',0,'',0,'M','',1154.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1154.00,0.00,1500.00,1800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1335,'01M000273','Lexahist 20x10''s','01.001','','13','',0,'',0,'M','',950.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,950.00,0.00,1100.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1336,'01M000274','Licodexon 0,5 mg 1000''s','01.001','','06','',0,'',0,'M','',32500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32500.00,0.00,35750.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1337,'01M000275','Licodexon 0,5 mg 20x10''s','01.001','','13','',0,'',0,'M','',16000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16000.00,0.00,17600.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1338,'01M000276','Licofel 20 mg 10x10''s','01.001','','13','',0,'',0,'M','',17750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17750.00,0.00,20000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1339,'01M000277','Lidocain Hcl Inj Berno (100)','01.001','','01','',0,'',0,'M','',1100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1100.00,0.00,1300.00,1400.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1340,'01M000278','Lidocain Hcl Inj Phapros (100)','01.001','','01','',0,'',0,'M','',840.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,840.00,0.00,1300.00,1400.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1341,'01M000279','Lincomycin 500 IF 5x12''s','01.001','','13','',0,'',0,'M','',38960.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,38960.00,0.00,43000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1342,'01M000280','Lincomycin 500 phapros 5x10','01.001','','13','',0,'',0,'M','',6500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6500.00,0.00,7200.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1343,'01M000281','Lokev 50 5x10''s','01.001','','13','',0,'',0,'M','',18550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18550.00,0.00,22000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1344,'01M000282','Loratadin IF 5x10''s','01.001','','13','',0,'',0,'M','',3330.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3330.00,0.00,3700.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1345,'01M000283','Lostacef 500 5x10''s','01.001','','13','',0,'',0,'M','',34900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34900.00,0.00,38500.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1346,'01M000284','Lostacef Sir 125 mg /5 ml','01.001','','02','',0,'',0,'M','',6525.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6525.00,0.00,7200.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1347,'01M000285','Lostacef Sir 250 mg /5 ml','01.001','','02','',0,'',0,'M','',10000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10000.00,0.00,11000.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1348,'01M000286','Kaditic Tab 5x10''s','01.001','','13','',0,'',0,'M','',11100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11100.00,0.00,12500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1349,'01M000287','Kalcinol N 10 gr','01.001','','17','',0,'',0,'M','',10200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10200.00,0.00,12300.00,12500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1350,'01M000288','Kalcinol N 5 gr','01.001','','17','',0,'',0,'M','',6700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6700.00,0.00,7500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1351,'01M000289','Kalmetason 20x10 Tab','01.001','','13','',0,'',0,'M','',771.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,771.00,0.00,850.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1352,'01M000290','Kalmicetin Capsul 10x10''s','01.001','','13','',0,'',0,'M','',4770.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4770.00,0.00,6000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1353,'01M000291','Kalmicetin Sirup 60 ml','01.001','','02','',0,'',0,'M','',8380.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8380.00,0.00,9300.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1354,'01M000292','Kaltrofen Suppo 10''s','01.001','','14','',0,'',0,'M','',12100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12100.00,0.00,13500.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1355,'01M000293','Kandistatin Drop','01.001','','02','',0,'',0,'M','',36500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36500.00,0.00,40150.00,41000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1356,'01M000294','Kemoren Tab 10x10','01.001','','15','',0,'',0,'M','',12300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12300.00,0.00,13500.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1357,'01M000295','Kemosillin Tab 10x10','01.001','','13','',0,'',0,'M','',32500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32500.00,0.00,38000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1358,'01M000296','Ketoconazol Tab Dexa 5x10''s','01.001','','13','',0,'',0,'M','',18500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18500.00,0.00,20500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1359,'01M000297','Ketoconazol Tab Kf 5x10''s','01.001','','13','',0,'',0,'M','',20500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20500.00,0.00,22500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1360,'01M000298','Ketomed SS','01.001','','02','',0,'',0,'M','',34800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34800.00,0.00,38500.00,39000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1361,'01M000299','Ketoprofen Inj Berno 100 mg/2 ml','01.001','','01','',0,'',0,'M','',6780.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6780.00,0.00,7500.00,8500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1362,'01M000300','Ketorolac Inj 10 mg 10''s','01.001','','01','',0,'',0,'M','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,4500.00,5200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1363,'01M000301','Kloderma cream 5 gr','01.001','','17','',0,'',0,'M','',18480.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18480.00,0.00,21000.00,23000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1364,'01M000302','Na. Diclofenac 25mg 5x10'' KF','01.001','','13','',0,'',0,'M','',1677.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1677.00,0.00,1850.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1365,'01M000303','Na. Diclofenac 50 mg 5x10''s KF','01.001','','13','',0,'',0,'M','',2177.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2177.00,0.00,2400.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1366,'01M000304','Na. Diclofenac 50 mg Novel 5x10','01.001','','13','',0,'',0,'M','',2176.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2176.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1367,'01M000305','Nacl Widatra 20''s','01.001','','02','',0,'',0,'M','',4700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4700.00,0.00,5400.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1368,'01M000306','Nebacetin Ointment','01.001','','17','',0,'',0,'M','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,21000.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1369,'01M000307','Nebacetin Serbuk','01.001','','02','',0,'',0,'M','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,22600.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1370,'01M000308','Neocenta Gel 15 gr','01.001','','17','',0,'',0,'M','',8400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8400.00,0.00,9300.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1371,'01M000309','Nestacort 2,5 % Cream 5 gr','01.001','','17','',0,'',0,'M','',4350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4350.00,0.00,4800.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1372,'01M000310','Neuralgin Rheuma 10x10''s','01.001','','13','',0,'',0,'M','',4180.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4180.00,0.00,4600.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1373,'01M000311','Neuralgin RX Tab 10x10''s','01.001','','13','',0,'',0,'M','',39500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,39500.00,0.00,43500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1374,'01M000312','Neurobion 5000 inj 20''s','01.001','','01','',0,'',0,'M','',7267.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7267.00,0.00,8000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1375,'01M000313','Neuromec Tab 10x10','01.001','','13','',0,'',0,'M','',29000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29000.00,0.00,32000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1376,'01M000314','Neuropyron V 10x10''s','01.001','','13','',0,'',0,'M','',5400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5400.00,0.00,6000.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1377,'01M000315','Neurosanbe Inj 10''s','01.001','','01','',0,'',0,'M','',47850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,47850.00,0.00,53000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1378,'01M000316','Neurotropic Inj','01.001','','18','',0,'',0,'M','',5852.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5852.00,0.00,6500.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1379,'01M000317','Nifedipin Tab KF 10x10''s','01.001','','13','',0,'',0,'M','',12900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12900.00,0.00,15000.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1380,'01M000318','Nipe Drop','01.001','','02','',0,'',0,'M','',49715.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,49715.00,0.00,54700.00,57000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1381,'01M000319','Nisagon Cream 5 gr','01.001','','17','',0,'',0,'M','',3700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3700.00,0.00,4100.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1382,'01M000320','Nistatin Tab ','01.001','','13','',0,'',0,'M','',6400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6400.00,0.00,7100.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1383,'01M000321','Nistatin Vaginal Tab 10x10','01.001','','08','',0,'',0,'M','',500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,500.00,0.00,600.00,1000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1384,'01M000322','Nizoral Tab 3x10''s','01.001','','16','',0,'',0,'M','',13900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13900.00,0.00,15300.00,15500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1385,'01M000323','Novalgin Inj 5''s','01.001','','01','',0,'',0,'M','',47400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,47400.00,0.00,53000.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1386,'01M000324','Nufadex 0,5 mg 10x10','01.001','','13','',0,'',0,'M','',11500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11500.00,0.00,13000.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1387,'01M000325','Nufadex 0,75 10x10''s','01.001','','13','',0,'',0,'M','',15400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15400.00,0.00,17000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1388,'01M000326','Nufapolar cream 5 gr','01.001','','17','',0,'',0,'M','',11583.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11583.00,0.00,12700.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1389,'01M000327','Nufapolar N cream 5 gr','01.001','','17','',0,'',0,'M','',3875.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3875.00,0.00,4300.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1390,'01M000328','Ofloxacin 400 tab 5x10''s','01.001','','13','',0,'',0,'M','',8721.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8721.00,0.00,9600.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1391,'01M000329','Omedrinat 50 mg 10x10''s','01.001','','13','',0,'',0,'M','',16000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16000.00,0.00,22000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1392,'01M000330','Omegtamine 30x10''s','01.001','','13','',0,'',0,'M','',1353.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1353.00,0.00,1600.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1393,'01M000331','Omegtrim Adult 10x10','01.001','','13','',0,'',0,'M','',1653.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1653.00,0.00,18500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1394,'01M000332','Omegtrim sir ','01.001','','02','',0,'',0,'M','',2780.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2780.00,0.00,3100.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1395,'01M000333','Omegzol Tab 10x10','01.001','','13','',0,'',0,'M','',5400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5400.00,0.00,6000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1396,'01M000334','Omelegar sir','01.001','','02','',0,'',0,'M','',3740.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3740.00,0.00,4200.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1397,'01M000335','Omelegar Tab 10x10','01.001','','13','',0,'',0,'M','',18700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,18700.00,0.00,21000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1398,'01M000336','Omeprazol 20 mg IF 3x10''s','01.001','','13','',0,'',0,'M','',4080.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4080.00,0.00,4500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1399,'01M000337','Omeprazol 20 mg KF 3x10''s','01.001','','13','',0,'',0,'M','',4083.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4083.00,0.00,4500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1400,'01M000338','Omeprazol 20 mg Novell 3x10''s','01.001','','13','',0,'',0,'M','',4083.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4083.00,0.00,4500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1401,'01M000339','Omeproksil 500 10x10''s','01.001','','13','',0,'',0,'M','',33000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33000.00,0.00,37000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1402,'01M000340','Omestan Sirup','01.001','','02','',0,'',0,'M','',5110.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5110.00,0.00,6000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1403,'01M000341','Opimox 500 mg Tab10x10','01.001','','15','',0,'',0,'M','',242000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,242000.00,0.00,267000.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1404,'01M000342','Opistan 10x10''s','01.001','','13','',0,'',0,'M','',23500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,23500.00,0.00,26000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1405,'01M000343','Orsaderm Cream 5 gr','01.001','','17','',0,'',0,'M','',2400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2400.00,0.00,2800.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1406,'01M000344','Otolin TT','01.001','','02','',0,'',0,'M','',21300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21300.00,0.00,23500.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1407,'01M000345','Otopain TT','01.001','','02','',0,'',0,'M','',33400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33400.00,0.00,36800.00,40000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1408,'01M000346','Ottoryl 25 mg 10x10''s','01.001','','13','',0,'',0,'M','',1600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1600.00,0.00,1800.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1409,'01M000347','Oxicobal 500 mcg 10x10''s','01.001','','13','',0,'',0,'M','',3470.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3470.00,0.00,4000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1410,'01M000348','Oxoferin Sol','01.001','','02','',0,'',0,'M','',71500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,71500.00,0.00,78500.00,80000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1411,'01M000349','Oxytetra SK IF','01.001','','17','',0,'',0,'M','',2000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2000.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1412,'01M000350','Oxytetra SK KF','01.001','','17','',0,'',0,'M','',2000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2000.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1413,'01M000351','Oxytetra SM IF','01.001','','17','',0,'',0,'M','',2800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2800.00,0.00,3200.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1414,'01M000352','Oxytetra SM Kf','01.001','','17','',0,'',0,'M','',2800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2800.00,0.00,3200.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1415,'01M000353','Teosal Capsul 10x10''s','01.001','','13','',0,'',0,'M','',14000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14000.00,0.00,16500.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1416,'01M000354','Teramycin Inj 10''s','01.001','','18','',0,'',0,'M','',9420.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9420.00,0.00,10500.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1417,'01M000355','Terikortin Cream 5 gr','01.001','','17','',0,'',0,'M','',4050.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4050.00,0.00,4500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1418,'01M000356','Terracortil Zk','01.001','','17','',0,'',0,'M','',15200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15200.00,0.00,17300.00,18000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1419,'01M000357','Terramycin ZM','01.001','','17','',0,'',0,'M','',9420.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9420.00,0.00,10500.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1420,'01M000358','Thrombo Aspilet 5x30''s','01.001','','13','',0,'',0,'M','',17500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17500.00,0.00,19300.00,20000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1421,'01M000359','Topcort cream','01.001','','17','',0,'',0,'M','',21100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21100.00,0.00,23300.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1422,'01M000360','Tremenza Tab 10x10''s','01.001','','13','',0,'',0,'M','',9185.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9185.00,0.00,10500.00,11500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1423,'01M000361','Triclovem Inj','01.001','','18','',0,'',0,'M','',7172.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7172.00,0.00,7900.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1424,'01M000362','Trifacyclin Cream','01.001','','17','',0,'',0,'M','',4250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4250.00,0.00,4700.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1425,'01M000363','Trifastan 10x10','01.001','','13','',0,'',0,'M','',17650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17650.00,0.00,19500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1426,'01M000364','Trimeta Sirup','01.001','','02','',0,'',0,'M','',3088.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3088.00,0.00,3400.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1427,'01M000365','Ultraproct N Suppo','01.001','','14','',0,'',0,'M','',14670.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14670.00,0.00,16500.00,17500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1428,'01M000366','Salbutamol 2 mg IF 10x10''s','01.001','','13','',0,'',0,'M','',8400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8400.00,0.00,10000.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1429,'01M000367','Salbutamol 2 mg KF 10x10''s','01.001','','13','',0,'',0,'M','',8400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8400.00,0.00,10000.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1430,'01M000368','Salbutamol 4 mg  IF 10x10''s','01.001','','13','',0,'',0,'M','',9750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9750.00,0.00,12000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1431,'01M000369','Salbutamol 4 mg KF 10x10''s','01.001','','13','',0,'',0,'M','',9750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9750.00,0.00,12000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1432,'01M000370','Salticin Cream','01.001','','17','',0,'',0,'M','',14100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14100.00,0.00,15500.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1433,'01M000371','Scabimit Cream','01.001','','17','',0,'',0,'M','',29700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29700.00,0.00,33000.00,34000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1434,'01M000372','Scanderma PlusCream 10 gr','01.001','','17','',0,'',0,'M','',28000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28000.00,0.00,30800.00,31000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1435,'01M000373','Scopma Plus Tab 10x10''s','01.001','','13','',0,'',0,'M','',62000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,62000.00,0.00,68500.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1436,'01M000374','Scopma Tab 10x10''s','01.001','','13','',0,'',0,'M','',58300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,58300.00,0.00,64200.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1437,'01M000375','SD ifars 10x10','01.001','','13','',0,'',0,'M','',30000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,30000.00,0.00,33000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1438,'01M000376','SD Imfars (10x10)','01.001','','13','',0,'',0,'M','',30000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,30000.00,0.00,33000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1439,'01M000377','Selvim 10 mg 5x10''s','01.001','','13','',0,'',0,'M','',2850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2850.00,0.00,3500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1440,'01M000378','Seremig 10 mg 10x10','01.001','','13','',0,'',0,'M','',5925.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5925.00,0.00,6700.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1441,'01M000379','Simvastatin 10 mg 5x10''s KF','01.001','','13','',0,'',0,'M','',3847.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3847.00,0.00,5700.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1442,'01M000380','Simvastatin 10 mg Hexp','01.001','','13','',0,'',0,'M','',3000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3000.00,0.00,5000.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1443,'01M000381','Simvastatin 20 mg 5x10''s KF','01.001','','13','',0,'',0,'M','',10260.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10260.00,0.00,11300.00,13000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1444,'01M000382','Sohobion Inj (10)','01.001','','01','',0,'',0,'M','',4675.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4675.00,0.00,5200.00,5800.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1445,'01M000383','Solinfec Tab 5x10''s','01.001','','13','',0,'',0,'M','',28200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28200.00,0.00,31000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1446,'01M000384','Solpenox sirup','01.001','','02','',0,'',0,'M','',3750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3750.00,0.00,4200.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1447,'01M000385','Spasmal Tab 20x10''s','01.001','','13','',0,'',0,'M','',66000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,66000.00,0.00,81000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1448,'01M000386','Spironolacton 25 mg Dx 10x10','01.001','','13','',0,'',0,'M','',3117.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3117.00,0.00,3500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1449,'01M000387','Stanza Tab','01.001','','13','',0,'',0,'M','',2250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2250.00,0.00,2500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1450,'01M000388','Supertetra 20x6''s','01.001','','04','',0,'',0,'M','',4800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4800.00,0.00,5300.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1451,'01M000389','Suprabiotic 500 mg 10x10''s','01.001','','13','',0,'',0,'M','',35900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,35900.00,0.00,39500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1452,'01M000390','Synalten Cream 5 gr','01.001','','17','',0,'',0,'M','',3400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3400.00,0.00,3800.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1453,'01M000391','Synarcus Cream','01.001','','17','',0,'',0,'M','',2650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2650.00,0.00,3000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1454,'01M000392','Vagistin Ovula 10''s','01.001','','08','',0,'',0,'M','',14400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14400.00,0.00,15800.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1455,'01M000393','Vanguin Plus Cream','01.001','','17','',0,'',0,'M','',3360.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3360.00,0.00,3700.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1456,'01M000394','Vectrine 300 2x10''s','01.001','','13','',0,'',0,'M','',39750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,39750.00,0.00,43700.00,44000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1457,'01M000395','Ventolin Inhaler','01.001','','02','',0,'',0,'M','',89700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,89700.00,0.00,100000.00,105000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1458,'01M000396','Ventolin Nebules 4x5''s','01.001','','13','',0,'',0,'M','',42700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,42700.00,0.00,48000.00,51000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1459,'01M000397','Vertivom Injeksi 10''s','01.001','','01','',0,'',0,'M','',4400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4400.00,0.00,4850.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1460,'01M000398','Vialop Tab 10x10','01.001','','13','',0,'',0,'M','',9000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9000.00,0.00,9900.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1461,'01M000399','Vicilin Inj','01.001','','18','',0,'',0,'M','',7500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7500.00,0.00,8300.00,9500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1462,'01M000400','Visancort Cream','01.001','','17','',0,'',0,'M','',8085.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8085.00,0.00,9000.00,10000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1463,'01M000401','Vit A 20.000 KF 100''s','01.001','','06','',0,'',0,'M','',27100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27100.00,0.00,29800.00,30000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1464,'01M000402','Vit B com inj GMP (Vial)','01.001','','18','',0,'',0,'M','',6600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6600.00,0.00,7300.00,8300.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1465,'01M000403','Vit B12 Inj /Cyanocobalamin GMP','01.001','','18','',0,'',0,'M','',5450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5450.00,0.00,6000.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1466,'01M000404','Vit K 10 mg KF 500''s','01.001','','15','',0,'',0,'M','',32700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,32700.00,0.00,36000.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1467,'01M000405','Vitacid Cream 0,025 %','01.001','','17','',0,'',0,'M','',20900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20900.00,0.00,23000.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1468,'01M000406','Vitacid Cream 0,05 % ','01.001','','17','',0,'',0,'M','',30700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,30700.00,0.00,33800.00,35000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1469,'01M000407','Vitaquin Cream','01.001','','17','',0,'',0,'M','',54725.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,54725.00,0.00,60700.00,61000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1470,'01M000408','Voltadex Tab 50 mg 5x10','01.001','','13','',0,'',0,'M','',14000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14000.00,0.00,15500.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1471,'01M000409','Voltadex Gel 20 gr','01.001','','17','',0,'',0,'M','',20400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20400.00,0.00,22500.00,25000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1472,'01M000410','Voltaren Tab 50 mg 5x10','01.001','','15','',0,'',0,'M','',5480.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5480.00,0.00,6000.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1473,'01M000411','Vosea Sirup','01.001','','02','',0,'',0,'M','',3350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3350.00,0.00,3700.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1474,'01M000412','Vosea Tab 10x10''s','01.001','','13','',0,'',0,'M','',12300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12300.00,0.00,13500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1475,'01M000413','Vitalgin','01.001','','13','',0,'',0,'M','',27750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27750.00,0.00,30500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1476,'01M000414','Wiros 10x10','01.001','','13','',0,'',0,'M','',16500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16500.00,0.00,18700.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1477,'01M000415','Radin Tab 5x6''s','01.001','','13','',0,'',0,'M','',11000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11000.00,0.00,12500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1478,'01M000416','Ranitidin 150 mg Berno 10x10''s','01.001','','13','',0,'',0,'M','',14000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14000.00,0.00,17000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1479,'01M000417','Ranitidin Dexa 10x10''s','01.001','','13','',0,'',0,'M','',15500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15500.00,0.00,17000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1480,'01M000418','Ranitidin Errela 10x10','01.001','','13','',0,'',0,'M','',15500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15500.00,0.00,17000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1481,'01M000419','Ranitidin Inj IF 25''s','01.001','','01','',0,'',0,'M','',2580.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2580.00,0.00,2900.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1482,'01M000420','Ranitidin Inj Soho 5''s','01.001','','01','',0,'',0,'M','',2300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2300.00,0.00,2600.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1483,'01M000421','Reco TM','01.001','','02','',0,'',0,'M','',5750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5750.00,0.00,6500.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1484,'01M000422','Reco TT','01.001','','02','',0,'',0,'M','',5750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5750.00,0.00,6500.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1485,'01M000423','Recodryl inj 10''s (Vial)','01.001','','18','',0,'',0,'M','',4700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4700.00,0.00,6000.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1486,'01M000424','Refaquin 15gr','01.001','','17','',0,'',0,'M','',56800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,56800.00,0.00,63000.00,63500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1487,'01M000425','Renabetic Tab','01.001','','13','',0,'',0,'M','',9250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9250.00,0.00,11000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1488,'01M000426','Renadinac 50 mg 10x10''s','01.001','','13','',0,'',0,'M','',21200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21200.00,0.00,23500.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1489,'01M000427','Rhemafar 4 mg Tab 10x10''s','01.001','','13','',0,'',0,'M','',38000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,38000.00,0.00,47000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1490,'01M000428','RL Widatra 20''s','01.001','','02','',0,'',0,'M','',5200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5200.00,0.00,5700.00,0.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1491,'01M000429','Roverton Tab 10x10''s','01.001','','13','',0,'',0,'M','',19250.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19250.00,0.00,21500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1492,'01M000430','Ryamicin Sirup','01.001','','02','',0,'',0,'M','',3800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3800.00,0.00,4200.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1493,'01M000431','Yekaprim Sirup','01.001','','02','',0,'',0,'M','',3100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3100.00,0.00,3500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1494,'01M000432','Yusimox 250 mg Sirup','01.001','','02','',0,'',0,'M','',5160.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5160.00,0.00,5700.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1495,'01M000433','Yusimox 500 mg Tab 10x10''s','01.001','','13','',0,'',0,'M','',36000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36000.00,0.00,40000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1496,'01M000434','Yusimox Sirup 125 mg','01.001','','02','',0,'',0,'M','',3325.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3325.00,0.00,3650.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1497,'01M000435','Zantifar 150 mg 5x10''s','01.001','','13','',0,'',0,'M','',2100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2100.00,0.00,2400.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1498,'01M000436','Zemoxil Sirup','01.001','','02','',0,'',0,'M','',3400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3400.00,0.00,4100.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1499,'01M000437','Zendalat Tab 10x10''s','01.001','','13','',0,'',0,'M','',2280.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2280.00,0.00,2500.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1500,'01M000438','Zenichlor Sirup','01.001','','02','',0,'',0,'M','',5345.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5345.00,0.00,5900.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00','');
COMMIT;

#
# Data for the `data_barang_master` table  (LIMIT 1071,500)
#

INSERT INTO `data_barang_master` (`barang_id`, `barang_kode`, `barang_nama`, `barang_supplier`, `barang_jenis`, `barang_satuan_kecil`, `barang_satuan_tengah`, `barang_satuan_tengah_jumlah`, `barang_satuan_besar`, `barang_satuan_besar_jumlah`, `barang_logo`, `barang_keterangan`, `barang_harga_beli`, `barang_harga_beli_d1`, `barang_harga_beli_d2`, `barang_harga_beli_d3`, `barang_harga_beli_klaim`, `barang_harga_jual`, `barang_harga_jual_d1`, `barang_harga_jual_d2`, `barang_harga_jual_d3`, `barang_harga_jual_d4`, `barang_harga_jual_d5`, `barang_harga_jual_mt`, `barang_harga_jual_horeka`, `barang_harga_jual_rita`, `barang_harga_jual_discount`, `barang_stok_awal`, `barang_stok_minimal`, `barang_berat`, `barang_status`, `barang_status_pajak`, `barang_reg_date`, `barang_reg_alias`, `barang_upd_date`, `barang_upd_alias`) VALUES

  (1501,'01M000439','Zensoderm cream 10 gr','01.001','','17','',0,'',0,'M','',3300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3300.00,0.00,3800.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1502,'01M000440','Zidalev 500 mg (2x10''s)','01.001','','15','',0,'',0,'M','',963.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,963.00,0.00,1800.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1503,'01M000441','Zink Tab Dispersibel 20 IF 10x10','01.001','','13','',0,'',0,'M','',4750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4750.00,0.00,5300.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1504,'01M000442','Zink Tab Dispersibel KF 10x10','01.001','','13','',0,'',0,'M','',4750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4750.00,0.00,5300.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1505,'01M000443','Zoralin Cream 10 gr','01.001','','17','',0,'',0,'M','',14150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,14150.00,0.00,16500.00,17000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1506,'01M000444','Zoralin Tab 10x10','01.001','','13','',0,'',0,'M','',11825.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,11825.00,0.00,14000.00,15000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1507,'01M000445','Zultrop Sirup','01.001','','02','',0,'',0,'M','',3168.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3168.00,0.00,3500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1508,'01M000446','Pabanox Cream','01.001','','17','',0,'',0,'M','',39500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,39500.00,0.00,43500.00,44000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1509,'01M000447','Parasol Cream','01.001','','02','',0,'',0,'M','',33700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33700.00,0.00,37000.00,38000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1510,'01M000448','Parasol SPF Lotio','01.001','','02','',0,'',0,'M','',76900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,76900.00,0.00,84500.00,87000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1511,'01M000449','Pehatrim Forte 10x10''s','01.001','','13','',0,'',0,'M','',27500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,27500.00,0.00,30000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1512,'01M000450','Pehatrim Tab 10x10''s','01.001','','13','',0,'',0,'M','',21000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,21000.00,0.00,23500.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1513,'01M000451','Phenobiotic Sirup','01.001','','02','',0,'',0,'M','',4550.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4550.00,0.00,5000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1514,'01M000452','Phytomenadion Inj 30''s','01.001','','01','',0,'',0,'M','',1740.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1740.00,0.00,2000.00,2300.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1515,'01M000453','Piracetam 400 mg dexa 10x10','01.001','','13','',0,'',0,'M','',31600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,31600.00,0.00,39700.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1516,'01M000454','Piracetam inj 3 gr Dexa 4''s','01.001','','01','',0,'',0,'M','',17100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17100.00,0.00,19000.00,22000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1517,'01M000455','Pirocam 20 mg  5x10''s','01.001','','13','',0,'',0,'M','',8500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,8500.00,0.00,10000.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1518,'01M000456','Piroxicam 10 mg KF 10x10','01.001','','13','',0,'',0,'M','',9700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9700.00,0.00,11000.00,2000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1519,'01M000457','Piroxicam 20 mg KF','01.001','','13','',0,'',0,'M','',10500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10500.00,0.00,12000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1520,'01M000458','Planotab 20''s','01.001','','13','',0,'',0,'M','',2900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2900.00,0.00,3200.00,4000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1521,'01M000459','Polofar Plus Tab 10x10''s','01.001','','13','',0,'',0,'M','',15500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15500.00,0.00,17000.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1522,'01M000460','Ponstan 500 10x10''s (Ecer)','01.001','','15','',0,'',0,'M','',2151.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2151.00,0.00,2400.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1523,'01M000461','Ponstelax 500 mg Tab 10x10''s','01.001','','13','',0,'',0,'M','',45350.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,45350.00,0.00,50000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1524,'01M000462','Pratifar 20 mg5x10','01.001','','13','',0,'',0,'M','',10650.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10650.00,0.00,12500.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1525,'01M000463','Pratifar 40 mg5x10','01.001','','13','',0,'',0,'M','',15300.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,15300.00,0.00,17000.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1526,'01M000464','Prednison Kf','01.001','','06','',0,'',0,'M','',62500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,62500.00,0.00,68750.00,200.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1527,'01M000465','Primadex Forte 10x10','01.001','','13','',0,'',0,'M','',34500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,34500.00,0.00,38500.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1528,'01M000466','Prodermis Cream 5 gr','01.001','','17','',0,'',0,'M','',3450.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3450.00,0.00,3800.00,6000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1529,'01M000467','Pronicy Tab 10x10''s','01.001','','13','',0,'',0,'M','',19600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,19600.00,0.00,22000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1530,'01M000468','Propanolol 40 mg KF','01.001','','13','',0,'',0,'M','',1210.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1210.00,0.00,1400.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1531,'01M000469','Propepsa sir','01.001','','02','',0,'',0,'M','',46000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,46000.00,0.00,50600.00,53000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1532,'01M000470','Proris Suppo (10)','01.001','','14','',0,'',0,'M','',5170.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5170.00,0.00,5700.00,6500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1533,'01M000471','Protofen Suppo','01.001','','14','',0,'',0,'M','',9488.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9488.00,0.00,10500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1534,'01M000472','Piracetam 1 gr Inj Dexa 10''s','01.001','','01','',0,'',0,'M','',5500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6200.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1535,'01M000473','Pyravit sirup 110 ml','01.001','','02','',0,'',0,'M','',29150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,29150.00,0.00,32000.00,35000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1536,'01M000474','Madecassol oint','01.001','','17','',0,'',0,'M','',101750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,101750.00,0.00,112000.00,115000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1537,'01M000475','Mecobalamin 500 NV 10x10''s','01.001','','13','',0,'',0,'M','',6160.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,6160.00,0.00,8000.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1538,'01M000476','Mecodiar 2 mg Tab 10x6''s','01.001','','13','',0,'',0,'M','',7800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7800.00,0.00,10000.00,3000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1539,'01M000477','Mediklin Gel ','01.001','','17','',0,'',0,'M','',20800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,20800.00,0.00,23000.00,24000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1540,'01M000478','Mediklin TR Gel ','01.001','','17','',0,'',0,'M','',36600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36600.00,0.00,40500.00,41000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1541,'01M000479','Melanox Cream','01.001','','17','',0,'',0,'M','',26400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,26400.00,0.00,29500.00,29500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1542,'01M000480','Meloxicam 15 mg FM (5x10)','01.001','','13','',0,'',0,'M','',5700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5700.00,0.00,6300.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1543,'01M000481','Meloxicam 15 mg Otto (5x10)','01.001','','13','',0,'',0,'M','',4800.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4800.00,0.00,9000.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1544,'01M000482','Meloxicam 7,5 Dexa 5x10','01.001','','13','',0,'',0,'M','',3200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3200.00,0.00,3600.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1545,'01M000483','Meloxicam 7,5 Mg FM (5x10''s)','01.001','','13','',0,'',0,'M','',4900.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,4900.00,0.00,5500.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1546,'01M000484','Meloxicam 7,5 Mg Inf (5x10''s)','01.001','','13','',0,'',0,'M','',5600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5600.00,0.00,6500.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1547,'01M000485','Meloxicam15 Mg Inf (5x10''s)','01.001','','13','',0,'',0,'M','',9000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9000.00,0.00,9900.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1548,'01M000486','Mercotin Drop','01.001','','02','',0,'',0,'M','',63000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,63000.00,0.00,69500.00,70000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1549,'01M000487','Metformin 500 Dexa 10x10''s','01.001','','13','',0,'',0,'M','',17100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17100.00,0.00,19000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1550,'01M000488','Metformin 500 Hexp 10x10''s','01.001','','13','',0,'',0,'M','',13750.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,13750.00,0.00,19000.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1551,'01M000489','Methylprednisolon 4 mg Tab IF 10x10''s','01.001','','13','',0,'',0,'M','',44000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,44000.00,0.00,49000.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1552,'01M000490','Methylprednisolon 4 mg Tab NV 10x10''s','01.001','','13','',0,'',0,'M','',33000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,33000.00,0.00,43000.00,5500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1553,'01M000491','Methylprednisolon 8 mg Tab NV 10x10''s','01.001','','13','',0,'',0,'M','',58500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,58500.00,0.00,65000.00,8000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1554,'01M000492','Mexon Tab 10x10','01.001','','13','',0,'',0,'M','',16000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,16000.00,0.00,17800.00,3500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1555,'01M000493','Microgynon 25x28''s','01.001','','13','',0,'',0,'M','',10000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,10000.00,0.00,11500.00,12000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1556,'01M000494','Mikrodiol','01.001','','13','',0,'',0,'M','',7150.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,7150.00,0.00,7900.00,9000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1557,'01M000495','Mionalgin 10x10''s','01.001','','13','',0,'',0,'M','',28400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,28400.00,0.00,31300.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1558,'01M000496','Miratrim sirup','01.001','','02','',0,'',0,'M','',3850.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3850.00,0.00,4300.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1559,'01M000497','Molacort 0,5 mg Tab 10x10''s','01.001','','13','',0,'',0,'M','',9500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9500.00,0.00,11000.00,1500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1560,'01M000498','Molacort 0,75 mg Tab 20x10''s','01.001','','13','',0,'',0,'M','',17000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,17000.00,0.00,18700.00,2500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1561,'01M000499','Molason Cream 5 gr','01.001','','17','',0,'',0,'M','',2700.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,2700.00,0.00,3000.00,5000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1562,'01M000500','Moxigra 500 mg 10x10','01.001','','13','',0,'',0,'M','',36000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,36000.00,0.00,40000.00,7000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1563,'01M000501','Myco Z Cream','01.001','','17','',0,'',0,'M','',67600.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,67600.00,0.00,74500.00,75000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1564,'01M000502','Mycoderm Cream','01.001','','17','',0,'',0,'M','',12100.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,12100.00,0.00,13300.00,13500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1565,'01M000503','Mycoral cream','01.001','','17','',0,'',0,'M','',9000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,9000.00,0.00,10300.00,11000.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1566,'01M000504','Mycoral Tab 5x10''s (Ecer)','01.001','','15','',0,'',0,'M','',3400.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,3400.00,0.00,4200.00,4300.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1567,'01M000505','Mytaderm cream','01.001','','17','',0,'',0,'M','',5500.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5500.00,0.00,6000.00,7500.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1568,'01H000792','test barang','01.001','001','01','',0,'',0,'H','',5000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,5760.00,6336.00,12960.00,6336.00,0,0,0.00,'1','1','2016-02-03 16:31:49','migrasi','0000-00-00 00:00:00',''),
  (1571,'01B000272','adfad','01.001','001','02','',0,'',0,'B','asdfas',120000.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,120000.00,120000.00,120000.00,0.00,100,100,0.00,'1','1','2018-01-25 12:21:12','admin','0000-00-00 00:00:00',''),
  (1572,'KPK212','Kecap Pahit 12Lt ABBAB','001','1','02','02',1,'03',10,'','',10000.00,0.00,0.00,0.00,0.00,12000.00,0.00,0.00,0.00,0.00,0.00,12300.00,12900.00,12500.00,1000.00,0,10,0.00,'2','0','2018-05-04 16:45:02','dev','2018-05-31 11:27:29','dev');
COMMIT;

#
# Data for the `data_barang_mutasi` table  (LIMIT -498,500)
#

INSERT INTO `data_barang_mutasi` (`faktur_kode`, `faktur_tanggal`, `faktur_gudang`, `faktur_ket`, `faktur_reg_date`, `faktur_reg_alias`, `faktur_upd_date`, `faktur_upd_alias`) VALUES

  ('MB201805300001','2018-05-30','01','TEST','2018-05-30 10:49:02','dev','2018-05-30 10:54:23','dev');
COMMIT;

#
# Data for the `data_barang_mutasi_trans` table  (LIMIT -498,500)
#

INSERT INTO `data_barang_mutasi_trans` (`trans_id`, `trans_faktur`, `trans_tanggal`, `trans_barang_asal`, `trans_qty_asal`, `trans_sat_asal`, `trans_barang_tujuan`, `trans_qty_tujuan`, `trans_sat_tujuan`, `trans_reg_date`, `trans_reg_alias`) VALUES

  (2,'MB201805300001','2018-05-30','KPK212',20,'02','01B000001',20,'02','2018-05-30 10:54:23','dev');
COMMIT;

#
# Data for the `data_barang_stok` table  (LIMIT -492,500)
#

INSERT INTO `data_barang_stok` (`stock_kode`, `stock_gudang`, `stock_barang`, `stock_hpp`, `stock_awal`, `stock_beli`, `stock_jual`, `stock_return_beli`, `stock_return_jual`, `stock_in`, `stock_out`, `stock_sisa`, `stock_fisik`, `stock_status`, `stock_reg_date`, `stock_reg_alias`) VALUES

  (12,'01','01B000001',0.00,0,624,0,0,0,20,10,634,630,'','2018-05-21 09:26:47','dev'),
  (13,'01.001','01B000001',0.00,0,2040,0,0,0,10,22,2028,0,'','2018-05-21 10:31:24','dev'),
  (14,'01.001','01B000019',0.00,200,200,0,20,0,0,0,0,0,'','2018-05-21 10:31:24','dev'),
  (15,'02','01B000001',0.00,0,0,0,0,0,20,0,20,0,'','2018-05-28 11:39:26','dev'),
  (16,'01','KPK212',0.00,0,1100,100,200,10,0,0,810,0,'','2018-05-31 11:39:28','dev'),
  (17,'01','01B000143',0.00,0,2100,100,5,0,0,10,1985,0,'','2018-06-01 08:41:12','dev'),
  (18,'03','01B000143',0.00,0,0,0,0,0,10,0,10,0,'','2018-06-01 13:24:11','dev');
COMMIT;

#
# Data for the `data_barang_stok_mutasi` table  (LIMIT -496,500)
#

INSERT INTO `data_barang_stok_mutasi` (`faktur_kode`, `faktur_tanggal`, `faktur_gudang_asal`, `faktur_gudang_tujuan`, `faktur_reg_date`, `faktur_reg_alias`, `faktur_upd_date`, `faktur_upd_alias`) VALUES

  ('MG201805280001','2018-05-28','01','01.001','2018-05-28 11:10:10','dev','2018-05-28 11:45:43','dev'),
  ('MG201805280002','2018-05-28','01.001','02','2018-05-28 11:39:26','dev','0000-00-00 00:00:00',''),
  ('MG201806010001','2018-06-01','01','03','2018-06-01 13:24:11','dev','0000-00-00 00:00:00','');
COMMIT;

#
# Data for the `data_barang_stok_mutasi_trans` table  (LIMIT -496,500)
#

INSERT INTO `data_barang_stok_mutasi_trans` (`trans_id`, `trans_faktur`, `trans_tanggal`, `trans_barang`, `trans_qty_besar`, `trans_qty_tengah`, `trans_qty_kecil`, `trans_qty_tot`, `trans_satuan_besar`, `trans_satuan_tengah`, `trans_satuan_kecil`, `trans_reg_date`, `trans_reg_alias`) VALUES

  (2,'MG201805280002','2018-05-28','01B000001',0,0,20,20,'03','02','02','2018-05-28 11:39:26','dev'),
  (3,'MG201805280001','2018-05-28','01B000001',0,0,10,10,'03','02','02','2018-05-28 11:45:43','dev'),
  (4,'MG201806010001','2018-06-01','01B000143',0,0,10,10,'BOX','13','13','2018-06-01 13:24:11','dev');
COMMIT;

#
# Data for the `data_barang_stok_opname` table  (LIMIT -498,500)
#

INSERT INTO `data_barang_stok_opname` (`faktur_bukti`, `faktur_tanggal`, `faktur_gudang`, `faktur_reg_date`, `faktur_reg_alias`, `faktur_upd_date`, `faktur_upd_alias`) VALUES

  ('9012390123','2018-05-31','01','2018-05-31 09:13:59','dev','2018-05-31 09:47:59','dev');
COMMIT;

#
# Data for the `data_barang_stok_opname_trans` table  (LIMIT -498,500)
#

INSERT INTO `data_barang_stok_opname_trans` (`trans_id`, `trans_faktur`, `trans_tanggal`, `trans_barang`, `trans_qty_sys`, `trans_qty_fisik`, `trans_satuan`, `trans_keterangan`, `trans_reg_date`, `trans_reg_alias`) VALUES

  (2,'9012390123','2018-05-31','01B000001',634,630,'02','Rusak','2018-05-31 09:47:59','dev');
COMMIT;

#
# Data for the `data_customer_hargajual` table  (LIMIT -495,500)
#

INSERT INTO `data_customer_hargajual` (`hargajual_kode`, `hargajual_nama`, `hargajual_keterangan`) VALUES

  ('1','Normal',NULL),
  ('2','MT',NULL),
  ('3','Horeka',NULL),
  ('4','Retail',NULL);
COMMIT;

#
# Data for the `data_customer_jenis` table  (LIMIT -496,500)
#

INSERT INTO `data_customer_jenis` (`jenis_kode`, `jenis_nama`, `Jenis_keterangan`) VALUES

  ('01','retail','Retail'),
  ('02','horeka','Modern Horeka'),
  ('03','grosir','Grosir');
COMMIT;

#
# Data for the `data_customer_master` table  (LIMIT -498,500)
#

INSERT INTO `data_customer_master` (`customer_kode`, `Customer_jenis`, `Customer_salesman`, `customer_nama`, `customer_alamat`, `customer_alamat_blok`, `customer_alamat_nomor`, `customer_alamat_rt`, `customer_alamat_rw`, `customer_alamat_kelurahan`, `customer_kecamatan`, `customer_kabupaten`, `customer_pasar`, `customer_provinsi`, `customer_kodepos`, `customer_telpon`, `customer_fax`, `customer_cp`, `customer_nik`, `customer_npwp`, `customer_tanggal_pkp`, `customer_pajak_nama`, `customer_pajak_jabatan`, `customer_pajak_alamat`, `customer_kunjungan_hari`, `customer_max_piutang`, `Customer_kriteria_discount`, `Customer_kriteria_harga_jual`, `customer_term`, `customer_foto`, `customer_status`, `customer_reg_date`, `customer_reg_alias`, `customer_upd_date`, `customer_upd_alias`) VALUES

  ('12121','2','1212','Huston Ltd','GGGGGG','12','1','12','12','92','1212','12','knl','asas',12131,'00899828','92828201','John Doe','9929292920','8282738491','2018-05-30','Great Washingaton','OB','Disana jauh','sabtua',909090,'1','4',999,'','1','2018-05-03 11:33:15','dev','2018-05-03 12:00:47','dev');
COMMIT;

#
# Data for the `data_giro_master` table  (LIMIT -498,500)
#

INSERT INTO `data_giro_master` (`giro_id`, `giro_tanggal`, `giro_salesman`, `giro_customer`, `giro_rekening`, `giro_bank`, `giro_jumlah`, `giro_tanggal_bg`, `giro_status`, `giro_reg_date`, `giro_reg_alias`, `giro_upd_date`, `giro_upd_alias`) VALUES

  (1,'2018-05-01','1212','12121','qwqwqw','asas',21212120.00,'2018-05-04','1','2018-05-02 16:18:04','dev','2018-05-03 11:39:26','dev');
COMMIT;

#
# Data for the `data_karyawan_jabatan` table  (LIMIT -492,500)
#

INSERT INTO `data_karyawan_jabatan` (`jabatan_kode`, `jabatan_nama`, `jabatan_keterangan`) VALUES

  ('1','KOMISARIS 1','PEMEGANG SAHAM'),
  ('2','KOMISARIS 2','PEMEGANG SAHAM'),
  ('3','DIREKTUR UTAMA',' '),
  ('4','DIREKTUR OPERASIONAL',' '),
  ('5','MANAGER',' '),
  ('6','BAGIAN GUDANG',' '),
  ('7','KASIR',' ');
COMMIT;

#
# Data for the `data_karyawan_master` table  (LIMIT -497,500)
#

INSERT INTO `data_karyawan_master` (`karyawan_kode`, `karyawan_kantor`, `karyawan_nik`, `karyawan_nama`, `karyawan_lahir_kota`, `karyawan_lahir_tanggal`, `karyawan_kelamin`, `karyawan_alamat`, `karyawan_kota`, `karyawan_kodepos`, `karyawan_telpon1`, `karyawan_telpon2`, `karyawan_email`, `karyawan_lulusan`, `karyawan_keterangan`, `karyawan_tanggal_masuk`, `karyawan_jabatan`, `karyawan_status`, `karyawan_reg_date`, `karyawan_reg_ip`, `karyawan_reg_alias`, `karyawan_upd_date`, `karyawan_upd_ip`, `karyawan_upd_alias`) VALUES

  ('001','01','','AGUS ABUD','0395','2014-09-05','1','CILILITAN BESAR NO.1','0395','13640','085710175332','','','SMP','','2014-09-08','7',1,'0000-00-00 00:00:00','','','2014-09-27 10:24:48','192.168.1.4','admin'),
  ('002','01','','RANI','0108','2014-09-05','2','UKI CAWANG','0108','13640','083893702306','','','SMA','','2013-10-20','7',1,'0000-00-00 00:00:00','','','2014-09-12 11:46:33','192.168.1.2','admin');
COMMIT;

#
# Data for the `data_komisi_rupiah` table  (LIMIT -384,500)
#

INSERT INTO `data_komisi_rupiah` (`komisi_id`, `komisi_tanggal`, `komisi_kantor`, `komisi_jenis`, `komisi_hitung`, `komisi_jumlah`, `komisi_jumlah_rp`, `komisi_hasil`, `komisi_reg_date`, `komisi_reg_ip`, `komisi_reg_alias`) VALUES

  (175,'2014-09-12','01',1,10000,4,112000,40000,'2014-09-12 11:39:55','192.168.0.1','system'),
  (176,'2014-09-12','01',2,6000,0,0,0,'2014-09-12 11:39:55','192.168.0.1','system'),
  (177,'2014-09-12','01',3,20000,0,0,0,'2014-09-12 11:39:55','192.168.0.1','system'),
  (178,'2014-09-12','01',4,5000,1,12000,5000,'2014-09-12 11:39:55','192.168.0.1','system'),
  (179,'2014-09-12','01',5,6000,0,0,0,'2014-09-12 11:39:55','192.168.0.1','system'),
  (180,'2014-09-12','01',6,9000,0,0,0,'2014-09-12 11:39:55','192.168.0.1','system'),
  (355,'2014-09-24','01',1,10000,7,196000,70000,'2014-09-24 13:48:25','192.168.0.1','system'),
  (356,'2014-09-24','01',2,6000,1,15000,6000,'2014-09-24 13:48:25','192.168.0.1','system'),
  (357,'2014-09-24','01',3,20000,1,50000,20000,'2014-09-24 13:48:25','192.168.0.1','system'),
  (358,'2014-09-24','01',4,5000,1,12000,5000,'2014-09-24 13:48:25','192.168.0.1','system'),
  (359,'2014-09-24','01',5,6000,0,0,0,'2014-09-24 13:48:25','192.168.0.1','system'),
  (360,'2014-09-24','01',6,9000,1,25000,9000,'2014-09-24 13:48:25','192.168.0.1','system'),
  (607,'2014-09-25','01',1,10000,7,196000,70000,'2014-09-25 23:03:14','192.168.0.1','system'),
  (608,'2014-09-25','01',2,6000,1,15000,6000,'2014-09-25 23:03:14','192.168.0.1','system'),
  (609,'2014-09-25','01',3,20000,1,50000,20000,'2014-09-25 23:03:14','192.168.0.1','system'),
  (610,'2014-09-25','01',4,5000,2,24000,10000,'2014-09-25 23:03:14','192.168.0.1','system'),
  (611,'2014-09-25','01',5,6000,1,15000,6000,'2014-09-25 23:03:14','192.168.0.1','system'),
  (612,'2014-09-25','01',6,9000,0,0,0,'2014-09-25 23:03:14','192.168.0.1','system'),
  (1963,'2014-09-26','01',1,10000,23,644000,230000,'2014-09-26 20:16:05','192.168.0.1','system'),
  (1964,'2014-09-26','01',2,6000,0,0,0,'2014-09-26 20:16:05','192.168.0.1','system'),
  (1965,'2014-09-26','01',3,20000,0,0,0,'2014-09-26 20:16:05','192.168.0.1','system'),
  (1966,'2014-09-26','01',4,5000,70,840000,350000,'2014-09-26 20:16:05','192.168.0.1','system'),
  (1967,'2014-09-26','01',5,6000,1,15000,6000,'2014-09-26 20:16:05','192.168.0.1','system'),
  (1968,'2014-09-26','01',6,9000,0,0,0,'2014-09-26 20:16:05','192.168.0.1','system'),
  (2239,'2014-09-27','01',1,10000,4,112000,40000,'2014-09-27 23:09:51','192.168.0.1','system'),
  (2240,'2014-09-27','01',2,6000,0,0,0,'2014-09-27 23:09:51','192.168.0.1','system'),
  (2241,'2014-09-27','01',3,20000,1,50000,20000,'2014-09-27 23:09:51','192.168.0.1','system'),
  (2242,'2014-09-27','01',4,5000,5,60000,25000,'2014-09-27 23:09:51','192.168.0.1','system'),
  (2243,'2014-09-27','01',5,6000,0,0,0,'2014-09-27 23:09:51','192.168.0.1','system'),
  (2244,'2014-09-27','01',6,9000,0,0,0,'2014-09-27 23:09:51','192.168.0.1','system'),
  (5299,'2014-09-28','01',1,10000,58,1624000,580000,'2014-09-28 23:15:18','192.168.0.1','system'),
  (5300,'2014-09-28','01',2,6000,0,0,0,'2014-09-28 23:15:18','192.168.0.1','system'),
  (5301,'2014-09-28','01',3,20000,0,0,0,'2014-09-28 23:15:18','192.168.0.1','system'),
  (5302,'2014-09-28','01',4,5000,166,1992000,830000,'2014-09-28 23:15:18','192.168.0.1','system'),
  (5303,'2014-09-28','01',5,6000,3,45000,18000,'2014-09-28 23:15:18','192.168.0.1','system'),
  (5304,'2014-09-28','01',6,9000,0,0,0,'2014-09-28 23:15:18','192.168.0.1','system'),
  (7375,'2014-09-29','01',1,10000,43,1204000,430000,'2014-09-29 23:03:34','192.168.0.1','system'),
  (7376,'2014-09-29','01',2,6000,0,0,0,'2014-09-29 23:03:34','192.168.0.1','system'),
  (7377,'2014-09-29','01',3,20000,0,0,0,'2014-09-29 23:03:34','192.168.0.1','system'),
  (7378,'2014-09-29','01',4,5000,97,1164000,485000,'2014-09-29 23:03:34','192.168.0.1','system'),
  (7379,'2014-09-29','01',5,6000,1,15000,6000,'2014-09-29 23:03:34','192.168.0.1','system'),
  (7380,'2014-09-29','01',6,9000,0,0,0,'2014-09-29 23:03:34','192.168.0.1','system'),
  (9067,'2014-09-30','01',1,10000,32,896000,320000,'2014-09-30 22:44:14','192.168.0.1','system'),
  (9068,'2014-09-30','01',2,6000,0,0,0,'2014-09-30 22:44:14','192.168.0.1','system'),
  (9069,'2014-09-30','01',3,20000,0,0,0,'2014-09-30 22:44:14','192.168.0.1','system'),
  (9070,'2014-09-30','01',4,5000,81,972000,405000,'2014-09-30 22:44:14','192.168.0.1','system'),
  (9071,'2014-09-30','01',5,6000,0,0,0,'2014-09-30 22:44:14','192.168.0.1','system'),
  (9072,'2014-09-30','01',6,9000,0,0,0,'2014-09-30 22:44:14','192.168.0.1','system'),
  (10339,'2014-10-01','01',1,10000,15,420000,150000,'2014-10-01 22:51:46','192.168.0.1','system'),
  (10340,'2014-10-01','01',2,6000,0,0,0,'2014-10-01 22:51:46','192.168.0.1','system'),
  (10341,'2014-10-01','01',3,20000,0,0,0,'2014-10-01 22:51:46','192.168.0.1','system'),
  (10342,'2014-10-01','01',4,5000,70,840000,350000,'2014-10-01 22:51:46','192.168.0.1','system'),
  (10343,'2014-10-01','01',5,6000,1,15000,6000,'2014-10-01 22:51:46','192.168.0.1','system'),
  (10344,'2014-10-01','01',6,9000,0,0,0,'2014-10-01 22:51:46','192.168.0.1','system'),
  (12259,'2014-10-02','01',1,10000,38,1064000,380000,'2014-10-02 23:16:27','192.168.0.1','system'),
  (12260,'2014-10-02','01',2,6000,0,0,0,'2014-10-02 23:16:27','192.168.0.1','system'),
  (12261,'2014-10-02','01',3,20000,0,0,0,'2014-10-02 23:16:27','192.168.0.1','system'),
  (12262,'2014-10-02','01',4,5000,95,1140000,475000,'2014-10-02 23:16:27','192.168.0.1','system'),
  (12263,'2014-10-02','01',5,6000,1,15000,6000,'2014-10-02 23:16:27','192.168.0.1','system'),
  (12264,'2014-10-02','01',6,9000,0,0,0,'2014-10-02 23:16:27','192.168.0.1','system'),
  (14191,'2014-10-03','01',1,10000,31,868000,310000,'2014-10-03 22:52:57','192.168.0.1','system'),
  (14192,'2014-10-03','01',2,6000,0,0,0,'2014-10-03 22:52:57','192.168.0.1','system'),
  (14193,'2014-10-03','01',3,20000,0,0,0,'2014-10-03 22:52:57','192.168.0.1','system'),
  (14194,'2014-10-03','01',4,5000,102,1224000,510000,'2014-10-03 22:52:57','192.168.0.1','system'),
  (14195,'2014-10-03','01',5,6000,1,15000,6000,'2014-10-03 22:52:57','192.168.0.1','system'),
  (14196,'2014-10-03','01',6,9000,0,0,0,'2014-10-03 22:52:57','192.168.0.1','system'),
  (17143,'2014-10-04','01',1,10000,60,1680000,600000,'2014-10-04 23:25:16','192.168.0.1','system'),
  (17144,'2014-10-04','01',2,6000,0,0,0,'2014-10-04 23:25:16','192.168.0.1','system'),
  (17145,'2014-10-04','01',3,20000,0,0,0,'2014-10-04 23:25:16','192.168.0.1','system'),
  (17146,'2014-10-04','01',4,5000,145,1740000,725000,'2014-10-04 23:25:16','192.168.0.1','system'),
  (17147,'2014-10-04','01',5,6000,2,30000,12000,'2014-10-04 23:25:16','192.168.0.1','system'),
  (17148,'2014-10-04','01',6,9000,0,0,0,'2014-10-04 23:25:16','192.168.0.1','system'),
  (20467,'2014-10-05','01',1,10000,64,1792000,640000,'2014-10-05 22:42:17','192.168.0.1','system'),
  (20468,'2014-10-05','01',2,6000,0,0,0,'2014-10-05 22:42:17','192.168.0.1','system'),
  (20469,'2014-10-05','01',3,20000,0,0,0,'2014-10-05 22:42:17','192.168.0.1','system'),
  (20470,'2014-10-05','01',4,5000,165,1980000,825000,'2014-10-05 22:42:17','192.168.0.1','system'),
  (20471,'2014-10-05','01',5,6000,4,60000,24000,'2014-10-05 22:42:17','192.168.0.1','system'),
  (20472,'2014-10-05','01',6,9000,0,0,0,'2014-10-05 22:42:17','192.168.0.1','system'),
  (22291,'2014-10-06','01',1,10000,45,1260000,450000,'2014-10-06 22:49:00','192.168.0.1','system'),
  (22292,'2014-10-06','01',2,6000,0,0,0,'2014-10-06 22:49:00','192.168.0.1','system'),
  (22293,'2014-10-06','01',3,20000,0,0,0,'2014-10-06 22:49:00','192.168.0.1','system'),
  (22294,'2014-10-06','01',4,5000,83,996000,415000,'2014-10-06 22:49:00','192.168.0.1','system'),
  (22295,'2014-10-06','01',5,6000,1,15000,6000,'2014-10-06 22:49:00','192.168.0.1','system'),
  (22296,'2014-10-06','01',6,9000,0,0,0,'2014-10-06 22:49:00','192.168.0.1','system'),
  (24511,'2014-10-07','01',1,10000,40,1120000,400000,'2014-10-07 22:51:48','192.168.0.1','system'),
  (24512,'2014-10-07','01',2,6000,1,15000,6000,'2014-10-07 22:51:48','192.168.0.1','system'),
  (24513,'2014-10-07','01',3,20000,0,0,0,'2014-10-07 22:51:48','192.168.0.1','system'),
  (24514,'2014-10-07','01',4,5000,112,1344000,560000,'2014-10-07 22:51:48','192.168.0.1','system'),
  (24515,'2014-10-07','01',5,6000,0,0,0,'2014-10-07 22:51:48','192.168.0.1','system'),
  (24516,'2014-10-07','01',6,9000,0,0,0,'2014-10-07 22:51:48','192.168.0.1','system'),
  (26467,'2014-10-08','01',1,10000,25,700000,250000,'2014-10-08 23:17:00','192.168.0.1','system'),
  (26468,'2014-10-08','01',2,6000,0,0,0,'2014-10-08 23:17:00','192.168.0.1','system'),
  (26469,'2014-10-08','01',3,20000,0,0,0,'2014-10-08 23:17:00','192.168.0.1','system'),
  (26470,'2014-10-08','01',4,5000,116,1392000,580000,'2014-10-08 23:17:00','192.168.0.1','system'),
  (26471,'2014-10-08','01',5,6000,0,0,0,'2014-10-08 23:17:00','192.168.0.1','system'),
  (26472,'2014-10-08','01',6,9000,0,0,0,'2014-10-08 23:17:00','192.168.0.1','system'),
  (28339,'2014-10-09','01',1,10000,31,868000,310000,'2014-10-09 22:58:41','192.168.0.1','system'),
  (28340,'2014-10-09','01',2,6000,0,0,0,'2014-10-09 22:58:41','192.168.0.1','system'),
  (28341,'2014-10-09','01',3,20000,1,50000,20000,'2014-10-09 22:58:41','192.168.0.1','system'),
  (28342,'2014-10-09','01',4,5000,95,1140000,475000,'2014-10-09 22:58:41','192.168.0.1','system'),
  (28343,'2014-10-09','01',5,6000,1,15000,6000,'2014-10-09 22:58:41','192.168.0.1','system'),
  (28344,'2014-10-09','01',6,9000,0,0,0,'2014-10-09 22:58:41','192.168.0.1','system'),
  (30163,'2014-10-10','01',1,10000,52,1456000,520000,'2014-10-10 23:08:36','192.168.0.1','system'),
  (30164,'2014-10-10','01',2,6000,0,0,0,'2014-10-10 23:08:36','192.168.0.1','system'),
  (30165,'2014-10-10','01',3,20000,0,0,0,'2014-10-10 23:08:36','192.168.0.1','system'),
  (30166,'2014-10-10','01',4,5000,73,876000,365000,'2014-10-10 23:08:36','192.168.0.1','system'),
  (30167,'2014-10-10','01',5,6000,1,15000,6000,'2014-10-10 23:08:36','192.168.0.1','system'),
  (30168,'2014-10-10','01',6,9000,0,0,0,'2014-10-10 23:08:36','192.168.0.1','system'),
  (65246,'2014-10-11','01',1,10000,0,0,0,'2014-10-11 01:06:49','192.168.0.1','system'),
  (65247,'2014-10-11','01',2,6000,0,0,0,'2014-10-11 01:06:49','192.168.0.1','system'),
  (65248,'2014-10-11','01',3,20000,0,0,0,'2014-10-11 01:06:49','192.168.0.1','system'),
  (65249,'2014-10-11','01',4,5000,0,0,0,'2014-10-11 01:06:49','192.168.0.1','system'),
  (65250,'2014-10-11','01',5,6000,0,0,0,'2014-10-11 01:06:49','192.168.0.1','system'),
  (65251,'2014-10-11','01',6,9000,0,0,0,'2014-10-11 01:06:49','192.168.0.1','system'),
  (65252,'2014-10-11','01',7,15000,1,40000,15000,'2014-10-11 01:06:49','192.168.0.1','system');
COMMIT;

#
# Data for the `data_menu_master` table  (LIMIT -290,500)
#

INSERT INTO `data_menu_master` (`menu_id`, `menu_kode`, `menu_parent`, `menu_label`, `menu_status`) VALUES

  (1,'mn01','mn01','&Master Data',1),
  (2,'mn0101','mn01','Barang',1),
  (3,'mn0102','mn01','Suplier',1),
  (4,'mn0103','mn01','Gudang',1),
  (5,'mn0104','mn01','Salesman',1),
  (6,'mn0105','mn01','Costumer',1),
  (7,'mn0106','mn01','Bank',1),
  (8,'mn0107','mn01','Bg Ditangan',1),
  (9,'mn0108','mn01','Perkiraan',1),
  (10,'mn0109','mn01','Saldo Awal Neraca',1),
  (11,'mn02','mn02','&Transaksi',1),
  (12,'mn0201','mn02','Pembelian  ',1),
  (13,'mn020101','mn02','Pembelian  ',1),
  (14,'mn020102','mn02','Retur Pembelian',1),
  (15,'mn0202','mn02','Penjualan',1),
  (16,'mn020201','mn02','Penjualan',1),
  (17,'mn020202','mn02','Retur Penjualan',1),
  (18,'mn020203','mn02','Daftar Tagihan',1),
  (19,'mn020204','mn02','Rekap Jual Salesmen',1),
  (20,'mn03','mn03','&Persediaan',1),
  (21,'mn0301','mn03','Stok Awal',1),
  (22,'mn0302','mn03','Mutasi Stok',1),
  (23,'mn0303','mn03','Mutasi Barang',1),
  (24,'mn0304','mn03','Stok Opname',1),
  (25,'mn04','mn04','&Hutang',1),
  (26,'mn0401','mn04','Hutang Awal',1),
  (27,'mn0402','mn04','Pembayaran Hutang',1),
  (28,'mn0403','mn04','Bgo Cair',1),
  (29,'mn05','mn05','P&iutang',1),
  (30,'mn0501','mn05','Piutang Awal',1),
  (31,'mn0502','mn05','Pembayaran Piutang',1),
  (32,'mn0503','mn05','Bg Cair',1),
  (33,'mn0504','mn05','Bg Tolak',1),
  (34,'mn06','mn06','&Akuntansi',1),
  (35,'mn0601','mn06','Kas Masuk/Keluar',1),
  (36,'mn0602','mn06','Jurnal Umum',1),
  (37,'mn0603','mn06','Jurnal Memorial',1),
  (38,'mn07','mn07','&Laporan',1),
  (39,'mn0701','mn07','Efaktur',1),
  (40,'mn070101','mn07','Barang',1),
  (41,'mn070102','mn07','Outlet',1),
  (42,'mn070103','mn07','Pajak Masukan',1),
  (43,'mn070104','mn07','Pajak Keluaran',1),
  (44,'mn070105','mn07','Pajak Retur Masukan',1),
  (45,'mn070106','mn07','Pajak Retur Keluaran',1),
  (46,'mn070107','mn07','Pajak Keluaran Ladaku',1),
  (47,'mn0702','mn07','Master',1),
  (48,'mn070201','mn07','Costumer',1),
  (49,'mn070202','mn07','Barang',1),
  (50,'mn070203','mn07','Supplier',1),
  (51,'mn070204','mn07','Salesman',1),
  (52,'mn0703','mn07','Pembelian  ',1),
  (53,'mn070301','mn07','Pembelian Per Nota',1),
  (54,'mn070302','mn07','Pembelian Per Supplier',1),
  (55,'mn070303','mn07','Pembelian Per Tanggal',1),
  (56,'mn070304','mn07','Pembelian Per Supplier&barang',1),
  (57,'mn070305','mn07','Pembelian Per Tanggal&barang',1),
  (58,'mn070306','mn07','Pembelian Per Suppplier&nota',1),
  (59,'mn070307','mn07','Pembelian Per Tanggal&nota',1),
  (60,'mn070308','mn07','Pembelian Per Nota&barang',1),
  (61,'mn070309','mn07','Pembelian Per Supplier,Nota,Barang',1),
  (62,'mn070310','mn07','Pembelian Per Tanggal,Nota,Barang',1),
  (63,'mn070311','mn07','Retur Pembelian Per Nota&barang(Hpp)',1),
  (64,'mn0704','mn07','Penjualan',1),
  (65,'mn070401','mn07','Penjualan Per Nota',1),
  (66,'mn070402','mn07','Penjualan Per Costumer',1),
  (67,'mn070403','mn07','Penjualan Per Supplier',1),
  (68,'mn070404','mn07','Penjualan Per Tipe',1),
  (69,'mn070405','mn07','Penjualan Per Tipe Per Supplier',1),
  (70,'mn070406','mn07','Penjualan Per Area',1),
  (71,'mn070407','mn07','Penjualan Per Salesman',1),
  (72,'mn070408','mn07','Penjualan Per Tanggal',1),
  (73,'mn070409','mn07','Penjualan Per Barang',1),
  (74,'mn070410','mn07','-',1),
  (75,'mn070411','mn07','Penjualan Per Customer & Nota',1),
  (76,'mn070412','mn07','Penjualan Per Salesman & Nota',1),
  (77,'mn070413','mn07','Penjualan Per Tanggal & Nota',1),
  (78,'mn070414','mn07','Penjualan Pajak Per Tanggal & Nota',1),
  (79,'mn070415','mn07','-',1),
  (80,'mn070416','mn07','Penjualan Per Customer & Barang',1),
  (81,'mn070417','mn07','Penjualan Per Supplier & Barang',1),
  (82,'mn070418','mn07','Penjualan Per Barang & Customer',1),
  (83,'mn070419','mn07','Penjualan Per Salesman & Barang',1),
  (84,'mn070420','mn07','Penjualan Per Salesman, Barang, Customer',1),
  (85,'mn070421','mn07','Penjualan Per Tanggal & Barang',1),
  (86,'mn070422','mn07','-',1),
  (87,'mn070423','mn07','Penjualan Per Salesman & Barang',1),
  (88,'mn070424','mn07','Penjualan Per Salesman & Kelompok Barang',1),
  (89,'mn070425','mn07','-',1),
  (90,'mn070426','mn07','Penjualan Per Nota & Barang',1),
  (91,'mn070427','mn07','Penjualan Per Customer, Nota, Barang',1),
  (92,'mn070428','mn07','Penjualan Per Salesman, Nota, Barang',1),
  (93,'mn070429','mn07','Penjualan Per Tanggal, Nota, Barang',1),
  (94,'mn070430','mn07','Penjualan Per Salesman, Customer, Barang',1),
  (95,'mn070431','mn07','-',1),
  (96,'mn070432','mn07','Laba Penjualan Per Nota',1),
  (97,'mn070433','mn07','Rugi Laba Penjualan',1),
  (98,'mn070434','mn07','Laba Penjualan Per Barang',1),
  (99,'mn070435','mn07','Laba Penjualan Per Supplier',1),
  (100,'mn070436','mn07','Laba Penjualan Per Supplier Presentase',1),
  (101,'mn070437','mn07','Laba Penjualan Per Salesman',1),
  (102,'mn0705','mn07','Inventory',1),
  (103,'mn070501','mn07','Rekap Draft Barang Per Tanggal',1),
  (104,'mn070502','mn07','Rekap Draft Retur Barang Per Tanggal',1),
  (105,'mn070503','mn07','Mutasi Barang Per Barang',1),
  (106,'mn070504','mn07','Mutase Barang Global Per Supplier',1),
  (107,'mn070505','mn07','-',1),
  (108,'mn070506','mn07','Kartu Stok',1),
  (109,'mn070507','mn07','Persediaan',1),
  (110,'mn070508','mn07','Persediaan Rinci',1),
  (111,'mn070509','mn07','-',1),
  (112,'mn070510','mn07','Stok Opname',1),
  (113,'mn070511','mn07','Stok',1),
  (114,'mn070512','mn07','Stok Per Supplier',1),
  (115,'mn070513','mn07','Mutasi Stok',1),
  (116,'mn070514','mn07','Mutase Persediaan',1),
  (117,'mn0706','mn07','Hutang',1),
  (118,'mn070601','mn07','Retur Beli Per Supplier Per Nota',1),
  (119,'mn070602','mn07','Piutang Titipan Per Supplier',1),
  (120,'mn070603','mn07','Hutang Supplier Per Nota',1),
  (121,'mn070604','mn07','Kartu Hutang',1),
  (122,'mn070605','mn07','Pelunasan Hutang Rinci',1),
  (123,'mn070606','mn07','-',1),
  (124,'mn070607','mn07','Pembayaran Bg',1),
  (125,'mn070608','mn07','Bg Cair',1),
  (126,'mn0707','mn07','Piutang',1),
  (127,'mn070701','mn07','Umur Piutang Over 1 Bulang',1),
  (128,'mn070702','mn07','Umur Piutang Over 2 Bulan',1),
  (129,'mn070703','mn07','Piutang Jatuh Tempo Per Salesman',1),
  (130,'mn070704','mn07','-',1),
  (131,'mn070705','mn07','Piutang Customer Per Salesman',1),
  (132,'mn070706','mn07','Piutang Customer Per Salesman (2)',1),
  (133,'mn070707','mn07','Piutang Customer Per Salesman & Tanggal Bayar Global',1),
  (134,'mn070708','mn07','Piutang Customer Per Salesman & Tanggal Bayar',1),
  (135,'mn070709','mn07','Piutang Customer Per Salesman Total',1),
  (136,'mn070710','mn07','Piutang Customer Per Salesman Over 2 Bulan',1),
  (137,'mn070711','mn07','Piutang Customer Area Total',1),
  (138,'mn070712','mn07','Piutang Global Per Salesman',1),
  (139,'mn070713','mn07','Piutang Global Per Customer',1),
  (140,'mn070714','mn07','Kartu Piutang',1),
  (141,'mn070715','mn07','Kartu Piutang Per Salesman',1),
  (142,'mn070716','mn07','Daftar Pelunasan Piutang',1),
  (143,'mn070717','mn07','Pelunasan Piutang Rinci',1),
  (144,'mn070718','mn07','Daftar Tagihan Piutang',1),
  (145,'mn070719','mn07','Daftar Piutang, Penjualan, Tagihan',1),
  (146,'mn070720','mn07','-',1),
  (147,'mn070721','mn07','Daftar Sisa Plafon',1),
  (148,'mn070722','mn07','Daftar Piutang Over Plafon',1),
  (149,'mn070723','mn07','Daftar Umum Piutang Per Salesman',1),
  (150,'mn070724','mn07','Daftar Umum Piutang',1),
  (151,'mn070725','mn07','Daftar Umum Piutang Harian',1),
  (152,'mn070726','mn07','-',1),
  (153,'mn070727','mn07','Penerimaan Bg',1),
  (154,'mn070728','mn07','Bg Cair',1),
  (155,'mn070729','mn07','Bg Belum Cair',1),
  (156,'mn070730','mn07','Bg Tolakan',1),
  (157,'mn070731','mn07','-',1),
  (158,'mn070732','mn07','Piutang Laba Per Salesman',1),
  (159,'mn070733','mn07','Histori Piutang',1),
  (160,'mn0708','mn07','Keuangan',1),
  (161,'mn070801','mn07','Biaya Per Salesman',1),
  (162,'mn070802','mn07','Biaya Per Salesman Global',1),
  (163,'mn070803','mn07','Neraca',1),
  (164,'mn070804','mn07','-',1),
  (165,'mn070805','mn07','Neraca Lajur',1),
  (166,'mn070806','mn07','-',1),
  (167,'mn070807','mn07','Rugi Laba',1),
  (168,'mn070808','mn07','-',1),
  (169,'mn070809','mn07','Buku Besar',1),
  (170,'mn070810','mn07','-',1),
  (171,'mn070811','mn07','Jurnal Umum',1),
  (172,'mn070812','mn07','-',1),
  (173,'mn070813','mn07','Daftar Perkiraan',1),
  (174,'mn08','mn08','P&roses Data',1),
  (175,'mn0801','mn08','Set Periode',1),
  (176,'mn0802','mn08','Re Posting',1),
  (177,'mn0803','mn08','Tutup Buku',1),
  (178,'mn0809','mn08','-',1),
  (179,'mn0811','mn08','Backup',1),
  (180,'mn0812','mn08','Restore',1),
  (181,'mn0813','mn08','Urutkan Transaksi Sto',1),
  (182,'mn0819','mn08','-',1),
  (183,'mn0821','mn08','Update Database',1),
  (184,'mn0822','mn08','Transfer Data From Excel',1),
  (185,'mn0829','mn08','-',1),
  (186,'mn0831','mn08','Setting Nomor Faktur',1),
  (187,'mn0832','mn08','Samakan Data',1),
  (188,'mn0833','mn08','Samakan Data Ladaku',1),
  (189,'mn09','mn09','P&engaturan',1),
  (190,'mn0901','mn09','Set Password',1),
  (191,'mn0909','mn09','-',1),
  (192,'mn0911','mn09','Setting Menu',1),
  (193,'mn0912','mn09','Setting Pos Jurnal',1),
  (194,'mn0919','mn09','-',1),
  (195,'mn0921','mn09','Data User',1),
  (196,'mn0922','mn09','Level Group',1),
  (197,'mn0923','mn09','Reset User',1),
  (198,'mn0929','mn09','-',1),
  (199,'mn10','mn10','Tentang &Kami',1),
  (200,'mn1001','mn10','Versi',1),
  (201,'mn1002','mn10','Copyright',1),
  (202,'mn1003','mn10','Email',1),
  (203,'mn0941','mn09','Log Out',1),
  (204,'mn0942','mn09','Exit',1),
  (205,'mn0931','mn09','Ref Jenis Barang',1),
  (206,'mn0939','mn09','-',1),
  (207,'mn0933','mn09','Ref Jenis Customer',1),
  (208,'mn0934','mn09','Ref Harga Jual',1),
  (209,'mn0932','mn09','Ref Satuan',1);
COMMIT;

#
# Data for the `data_pelanggan_master` table  (LIMIT -496,500)
#

INSERT INTO `data_pelanggan_master` (`pelanggan_kode`, `pelanggan_kantor`, `pelanggan_jenis`, `pelanggan_nama`, `pelanggan_alamat`, `pelanggan_kota`, `pelanggan_kodepos`, `pelanggan_telpon1`, `pelanggan_telpon2`, `pelanggan_fax`, `pelanggan_email`, `pelanggan_keterangan`, `pelanggan_harga`, `pelanggan_hutang`, `pelanggan_status`, `pelanggan_reg_date`, `pelanggan_reg_ip`, `pelanggan_reg_alias`, `pelanggan_upd_date`, `pelanggan_upd_ip`, `pelanggan_upd_alias`) VALUES

  ('01.001','01','03','UMUM','JL. PELANGGAN UMUM NO. 3','0395','12312','231312','12312312','1231312','alfi@dot.com','ADSFAFASDFSAFA','B',35000,1,'2014-07-31 21:16:19','192.168.56.1','admin','2015-11-25 00:00:00','192.168.137.1',''),
  ('01.002','01','03','ANTIKA','KOBER','0914','12313','123131312','131231','','','','D',0,1,'2017-12-01 09:59:26','192.168.10.8','','0000-00-00 00:00:00','',''),
  ('01.003','01','03','ARINA MANA SIKANA','SUMPIUH','0914','','1313','12313','','','','D',0,1,'2017-12-01 10:04:23','192.168.10.8','','0000-00-00 00:00:00','','');
COMMIT;

#
# Data for the `data_pembelian_faktur` table  (LIMIT -491,500)
#

INSERT INTO `data_pembelian_faktur` (`faktur_kode`, `faktur_tanggal_trans`, `faktur_pajak_no`, `faktur_pajak_tanggal`, `faktur_surat_jalan`, `faktur_gudang`, `faktur_supplier`, `faktur_term`, `faktur_jumlah`, `faktur_disc`, `faktur_total`, `faktur_ppn_persen`, `faktur_ppn_jenis`, `faktur_netto`, `faktur_klaim`, `faktur_total_netto`, `faktur_status`, `faktur_reg_date`, `faktur_reg_alias`, `faktur_upd_date`, `faktur_upd_alias`, `faktur_upd_ket`) VALUES

  ('201805110001','2018-05-11','9..909012.','2018-05-11','aaaa','01','001',9,2550000.00,0.00,2550000.00,10.00,'1',2550000,0.00,2550000.00,'9','2018-05-11 08:39:57','dev','2018-05-21 10:28:04','dev',''),
  ('201805110002','2018-05-11','29009000.0099','2018-05-12','222','01.001','001',10,7200000.00,2100.00,7197900.00,10.00,'1',7197900,89.10,7197810.90,'1','2018-05-11 16:25:29','dev','2018-05-12 09:56:54','dev',''),
  ('201805200001','2018-05-20','192ii01','2018-05-21','239023','01','001',20,2000000.00,0.00,2000000.00,10.00,'1',2000000,0.00,2000000.00,'1','2018-05-20 10:29:59','dev','0000-00-00 00:00:00','',''),
  ('201805210001','2018-05-21','1219032','2018-05-22','203434','01','001',21,3000000.00,0.00,3000000.00,10.00,'1',3000000,0.00,3000000.00,'1','2018-05-21 09:26:47','dev','2018-05-21 10:23:18','dev',''),
  ('201805210002','2018-05-21','893400.0220','2018-05-24','983487290','01.001','001',20,8165000.00,0.00,8165000.00,10.00,'1',8165000,0.00,8165000.00,'1','2018-05-21 10:31:24','dev','2018-05-21 12:05:10','dev',''),
  ('201805310001','2018-05-31','90123.9283','2018-05-31','','01','001',10,1000000.00,0.00,1000000.00,10.00,'1',1000000,0.00,1000000.00,'1','2018-05-31 11:39:28','dev','2018-05-31 11:52:59','dev',''),
  ('201806010001','2018-06-01','120398123','2018-06-01','','01','001',90,1000000.00,0.00,1000000.00,10.00,'1',1000000,0.00,1000000.00,'1','2018-06-01 08:27:13','dev','0000-00-00 00:00:00','',''),
  ('201806010002','2018-06-01','910923','2018-06-01','','01','001',90,3885000.00,0.00,3885000.00,10.00,'1',3885000,0.00,3885000.00,'1','2018-06-01 08:41:12','dev','2018-06-01 15:27:51','dev','');
COMMIT;

#
# Data for the `data_pembelian_retur_faktur` table  (LIMIT -495,500)
#

INSERT INTO `data_pembelian_retur_faktur` (`faktur_kode_bukti`, `faktur_tanggal_trans`, `faktur_kode_faktur`, `faktur_kode_exfaktur`, `faktur_pajak_no`, `faktur_pajak_tanggal`, `faktur_surat_jalan`, `faktur_gudang`, `faktur_supplier`, `faktur_sebab`, `faktur_jumlah`, `faktur_ppn_jenis`, `faktur_ppn_persen`, `faktur_netto`, `faktur_status`, `faktur_reg_date`, `faktur_reg_alias`) VALUES

  ('12391.901','2018-05-31','201805310001','','90123.0923','2018-05-31','','01','001','',90000.00,'',10.00,99000.00,'1','2018-05-31 11:55:43','dev'),
  ('2090123','2018-06-01','201806010002','','','2018-06-01','','01','001','',92500.00,'1',10.00,92500.00,'1','2018-06-01 10:14:15','dev'),
  ('90.09121.923','2018-05-14','201805110001','','90.20320.09','2018-05-14','','01','001','',1000000.00,'1',10.00,1100000.00,'1','2018-05-14 13:40:41','dev'),
  ('9182391823','2018-05-22','201805210002','','','2018-05-22','','01.001','001','',55000.00,'',10.00,60500.00,'1','2018-05-22 09:52:44','dev');
COMMIT;

#
# Data for the `data_pembelian_retur_trans` table  (LIMIT -495,500)
#

INSERT INTO `data_pembelian_retur_trans` (`trans_id`, `trans_faktur`, `trans_tanggal`, `trans_barang`, `trans_qty`, `trans_satuan`, `trans_harga_retur`, `trans_jumlah`, `trans_jenis`, `trans_status`, `trans_reg_date`, `trans_reg_alias`) VALUES

  (1,'90.09121.923','2018-05-14','01B000001',10,'03',100000.00,1000000.00,'C','','2018-05-14 13:40:41','dev'),
  (3,'9182391823','2018-05-22','01B000019',10,'02',5500.00,55000.00,'C','','2018-05-22 09:52:44','dev'),
  (5,'12391.901','2018-05-31','KPK212',10,'03',9000.00,90000.00,'C','','2018-05-31 11:55:43','dev'),
  (7,'2090123','2018-06-01','01B000143',5,'13',18500.00,92500.00,'C','','2018-06-01 10:14:15','dev');
COMMIT;

#
# Data for the `data_pembelian_trans` table  (LIMIT -490,500)
#

INSERT INTO `data_pembelian_trans` (`trans_id`, `trans_faktur`, `trans_tanggal`, `trans_barang`, `trans_harga_beli`, `trans_ppn`, `trans_qty`, `trans_satuan`, `trans_disc1`, `trans_disc2`, `trans_disc3`, `trans_disc_rupiah`, `trans_jumlah`, `trans_jenis`, `trans_status`, `trans_reg_date`, `trans_reg_alias`) VALUES

  (15,'201805110002','2018-05-11','01B000001',100000.00,0.00,90,'03',20.00,0.00,0.00,0.00,7200000.00,'C',0,'2018-05-12 09:56:54','dev'),
  (28,'201805200001','2018-05-20','01B000001',100000.00,0.00,20,'03',0.00,0.00,0.00,0.00,2000000.00,'C',0,'2018-05-20 10:29:59','dev'),
  (36,'201805210001','2018-05-21','01B000001',100000.00,0.00,20,'03',0.00,0.00,0.00,0.00,2000000.00,'C',0,'2018-05-21 10:23:18','dev'),
  (37,'201805110001','2018-05-11','01B000001',100000.00,0.00,12,'03',0.00,0.00,0.00,0.00,1200000.00,'C',0,'2018-05-21 10:28:04','dev'),
  (46,'201805210002','2018-05-21','01B000001',100000.00,0.00,80,'03',0.00,0.00,0.00,0.00,8000000.00,'C',0,'2018-05-21 12:05:10','dev'),
  (47,'201805210002','2018-05-21','01B000019',5500.00,0.00,30,'03',0.00,0.00,0.00,0.00,165000.00,'C',0,'2018-05-21 12:05:10','dev'),
  (54,'201805310001','2018-05-31','KPK212',10000.00,0.00,100,'03',0.00,0.00,0.00,0.00,1000000.00,'C',0,'2018-05-31 11:52:59','dev'),
  (55,'201806010001','2018-06-01','KPK212',10000.00,0.00,100,'03',0.00,0.00,0.00,0.00,1000000.00,'C',0,'2018-06-01 08:27:13','dev'),
  (57,'201806010002','2018-06-01','01B000143',18500.00,0.00,210,'BOX',0.00,0.00,0.00,0.00,3885000.00,'C',0,'2018-06-01 15:27:51','dev');
COMMIT;

#
# Data for the `data_pengguna_alias` table  (LIMIT -496,500)
#

INSERT INTO `data_pengguna_alias` (`user_kode`, `user_alias`, `user_group`, `user_pwd`, `user_nama`, `user_karyawan`, `user_login_status`, `user_login_terakhir`, `user_login_device`, `user_status`, `user_reg_date`, `user_reg_ip`, `user_reg_alias`, `user_upd_date`, `user_upd_ip`, `user_upd_alias`, `user_exp_date`) VALUES

  (17,'dev','3','e77989ed21758e78331b20e477fc5582','dev','','0','2018-06-01 15:36:26','YourWaifuIsShit:192.168.10.185','1','2018-04-26 15:56:47','0.0.0.0','dev','2018-04-27 14:48:03','0.0.0.0','dev','2018-07-30'),
  (18,'sss','2','9f6e6800cfae7749eb6c486619254b9c','ssssssssssss','','0','2018-05-03 13:45:02','YourWaifuIsShit:192.168.10.61','1','2018-04-26 16:24:35','0.0.0.0','dev','2018-04-30 13:34:37','192.168.10.192','dev','2018-04-26'),
  (19,'test','4','098f6bcd4621d373cade4e832627b4f6','test','','0','2018-05-31 14:19:59','YourWaifuIsShit:192.168.10.185','1','2018-04-28 08:47:34','0.0.0.0','dev','2018-05-31 14:21:07','192.168.10.185','dev','2018-07-28');
COMMIT;

#
# Data for the `data_pengguna_group` table  (LIMIT -495,500)
#

INSERT INTO `data_pengguna_group` (`group_kode`, `group_nama`, `group_akses`, `group_menu`, `group_keterangan`, `group_reg_date`, `group_reg_ip`, `group_reg_alias`, `group_upd_date`, `group_upd_ip`, `group_upd_alias`) VALUES

  ('1','Administrator','1','','Akses ke semua menu','2014-07-30 08:36:39','192.168.56.1','Administra','2018-05-05 08:42:23','192.168.10.105','dev'),
  ('2','Kasir','2','','Hanya Menu Kasir Saja','2015-11-04 07:27:53','192.168.137.1','','2018-05-31 14:24:38','192.168.10.185','dev'),
  ('3','TestDev','1','','Semuanya','2018-04-27 14:40:07','192.168.10.114','dev','2018-05-22 15:51:39','192.168.10.61','dev'),
  ('4','testava','1','','tesst menu','2018-05-31 14:19:25','192.168.10.185','dev','2018-05-31 14:23:45','192.168.10.185','dev');
COMMIT;

#
# Data for the `data_penjualan_faktur` table  (LIMIT -496,500)
#

INSERT INTO `data_penjualan_faktur` (`faktur_kode`, `faktur_tanggal_trans`, `faktur_jenis_jual`, `faktur_pajak_no`, `faktur_pajak_tanggal`, `faktur_surat_jalan`, `faktur_gudang`, `faktur_customer`, `faktur_sales`, `faktur_term`, `faktur_catatan`, `faktur_jumlah`, `faktur_disc_persen`, `faktur_disc_rupiah`, `faktur_total`, `faktur_ppn_persen`, `faktur_ppn_jenis`, `faktur_netto`, `faktur_klaim`, `faktur_total_netto`, `faktur_status`, `faktur_reg_date`, `faktur_reg_alias`, `faktur_upd_date`, `faktur_upd_alias`) VALUES

  ('201805140001','2018-05-14','','0900.00121.2','2018-05-14','','01','12121','1212',101,'01',1116000.00,0.00,1000.00,1115000.00,10.00,'1',1115000.00,0.00,1115000.00,'9','2018-05-14 09:12:07','dev','2018-05-14 09:14:55','dev'),
  ('201805310001','2018-05-31','0','92992020','2018-05-31','','01','12121','1212',10,'',125000.00,0.00,0.00,125000.00,10.00,'1',125000.00,0.00,125000.00,'1','2018-05-31 12:05:24','dev','0000-00-00 00:00:00',''),
  ('201806010001','2018-06-01','0','912013','2018-06-01','','01','12121','1212',10,'',203500.00,0.00,0.00,203500.00,10.00,'1',203500.00,0.00,203500.00,'1','2018-06-01 14:44:32','dev','0000-00-00 00:00:00','');
COMMIT;

#
# Data for the `data_penjualan_retur_faktur` table  (LIMIT -497,500)
#

INSERT INTO `data_penjualan_retur_faktur` (`faktur_kode_bukti`, `faktur_tanggal_trans`, `faktur_kode_faktur`, `faktur_kode_exfaktur`, `faktur_pajak_no`, `faktur_pajak_tanggal`, `faktur_surat_jalan`, `faktur_gudang`, `faktur_sales`, `faktur_custo`, `faktur_sebab`, `faktur_jumlah`, `faktur_ppn_jenis`, `faktur_ppn_persen`, `faktur_netto`, `faktur_status`, `faktur_reg_date`, `faktur_reg_alias`) VALUES

  ('8090192','2018-05-31','201805310001','','','2018-05-31','','01','1212','12121','',900000.00,'1',10.00,900000.00,'1','2018-05-31 12:12:20','dev'),
  ('9012901292','2018-05-15','201805140001','','9090909090','2018-05-20','','01','1212','12121','',2000.00,'0',10.00,2200.00,'1','2018-05-15 09:55:09','dev');
COMMIT;

#
# Data for the `data_penjualan_retur_trans` table  (LIMIT -497,500)
#

INSERT INTO `data_penjualan_retur_trans` (`trans_id`, `trans_faktur`, `trans_tanggal`, `trans_barang`, `trans_qty`, `trans_satuan`, `trans_harga_retur`, `trans_jumlah`, `trans_jenis`, `trans_status`, `trans_reg_date`, `trans_reg_alias`) VALUES

  (1,'9012901292','2018-05-15','01B000001',10,'02',200.00,2000.00,'C','','2018-05-15 09:55:09','dev'),
  (6,'8090192','2018-05-31','KPK212',10,'02',90000.00,900000.00,'C','','2018-05-31 12:12:20','dev');
COMMIT;

#
# Data for the `data_penjualan_trans` table  (LIMIT -495,500)
#

INSERT INTO `data_penjualan_trans` (`trans_id`, `trans_faktur`, `trans_tanggal`, `trans_barang`, `trans_harga_beli`, `trans_harga_jual`, `trans_qty`, `trans_satuan`, `trans_disc1`, `trans_disc2`, `trans_disc3`, `trans_disc4`, `trans_disc5`, `trans_disc_rupiah`, `trans_jumlah`, `trans_status`, `trans_reg_date`, `trans_reg_alias`) VALUES

  (1,'201805140001','2018-05-14','01B000001',0.00,124000.00,10,'03',10.00,0.00,0.00,0.00,0.00,0.00,1116000.00,'','2018-05-14 09:12:07','dev'),
  (2,'201805140001','2018-05-14','01B000001',0.00,124000.00,10,'02',10.00,0.00,0.00,0.00,0.00,0.00,1116000.00,'','2018-05-14 09:14:55','dev'),
  (3,'201805310001','2018-05-31','KPK212',0.00,12500.00,10,'03',0.00,0.00,0.00,0.00,0.00,0.00,125000.00,'','2018-05-31 12:05:24','dev'),
  (4,'201806010001','2018-06-01','01B000143',0.00,20350.00,10,'BOX',0.00,0.00,0.00,0.00,0.00,0.00,203500.00,'','2018-06-01 14:44:32','dev');
COMMIT;

#
# Data for the `data_rak_master` table  (LIMIT -497,500)
#

INSERT INTO `data_rak_master` (`rak_kode`, `rak_kantor`, `rak_nama`, `rak_tempat`, `rak_keterangan`, `rak_status`, `rak_reg_date`, `rak_reg_ip`, `rak_reg_alias`, `rak_upd_date`, `rak_upd_ip`, `rak_upd_alias`) VALUES

  ('01.001','01','RAK 001','Pojok Depan','',1,'2014-08-01 17:40:03','192.168.56.1','admin','0000-00-00 00:00:00','',''),
  ('01.002','01','RAK 002','Pojok Tengah','',1,'2014-08-01 17:41:16','192.168.56.1','admin','0000-00-00 00:00:00','','');
COMMIT;

#
# Data for the `data_salesman_master` table  (LIMIT -498,500)
#

INSERT INTO `data_salesman_master` (`salesman_kode`, `salesman_nama`, `salesman_alamat`, `salesman_tanggal_masuk`, `salesman_jenis`, `salesman_lahir_kota`, `salesman_lahir_tanggal`, `salesman_hp`, `salesman_fax`, `salesman_nik`, `salesman_target`, `salesman_bank_nama`, `salesman_bank_rekening`, `salesman_bank_atasnama`, `salesman_foto`, `salesman_status`, `salesman_reg_date`, `salesman_reg_alias`, `salesman_upd_date`, `salesman_upd_alias`) VALUES

  ('1212','Andrea Hudson','Warsaw\r\nPoland','2014-05-22','TO','Kutoarjo','1960-02-11','080989999','','',12333333,'Swiss Bank','','','','1','2018-04-30 13:21:49','dev','2018-05-02 16:27:15','dev');
COMMIT;

#
# Data for the `data_supplier_master` table  (LIMIT -498,500)
#

INSERT INTO `data_supplier_master` (`supplier_kode`, `supplier_nama`, `supplier_alamat`, `supplier_telpon1`, `supplier_telpon2`, `supplier_fax`, `supplier_cp`, `supplier_email`, `supplier_npwp`, `supplier_rek_bg`, `supplier_rek_bank`, `supplier_term`, `supplier_keterangan`, `supplier_status`, `supplier_reg_date`, `supplier_reg_ip`, `supplier_reg_alias`, `supplier_upd_date`, `supplier_upd_ip`, `supplier_upd_alias`) VALUES

  ('001','ABC Corp.','12nd Abbey St.\r\nLondon\r\nUK','102-1008','102-1010','102-1009','Max Weber','','','','',12,'adsa\r\nasfasda','1','2018-04-30 15:06:22','192.168.10.192','dev','2018-05-02 16:25:34','192.168.10.37','dev');
COMMIT;

#
# Data for the `kode_cucian` table  (LIMIT -492,500)
#

INSERT INTO `kode_cucian` (`cucian_case`, `cucian_text`, `cucian_rupiah`) VALUES

  (1,'010010010001',10000),
  (2,'010010010003',6000),
  (3,'010010010002',20000),
  (4,'010010020002',5000),
  (5,'010010020001',6000),
  (6,'010010010004',9000),
  (7,'010010010005',15000);
COMMIT;

#
# Data for the `kode_komponen` table  (LIMIT 1,500)
#

INSERT INTO `kode_komponen` (`combo_id`, `combo_komponen`, `combo_kode`, `combo_text`) VALUES

  (1,'01','1','AKTIF'),
  (2,'01','2','ISTIRAHAT'),
  (3,'01','3','PINDAH'),
  (4,'01','4','DIPULANGKAN'),
  (5,'02','1','Pria'),
  (6,'02','2','Wanita'),
  (10,'04','1','Islam'),
  (11,'04','2','Kristen'),
  (12,'04','3','Katolik'),
  (13,'04','4','Hindu'),
  (14,'04','5','Budha'),
  (15,'04','6','Konghucu'),
  (16,'04','7','Lain-Lain / Kepercayaan'),
  (17,'05','1','Tidak Menikah'),
  (18,'05','2','Menikah'),
  (19,'06','01','Suami/Istri'),
  (20,'06','02','Bapak/Ibu Kandung'),
  (21,'06','03','Bapak/Ibu Mertua'),
  (22,'06','04','Bapak/Ibu Tiri'),
  (23,'06','05','Bapak/Ibu Angkat'),
  (24,'06','08','Saudara Kandung'),
  (25,'06','12','Sepupu Kandung'),
  (26,'06','14','Anak Kandung'),
  (27,'06','17','Keponakan Kandung'),
  (28,'07','01','SD / MI'),
  (29,'07','04','Diploma I'),
  (30,'07','05','Diploma II'),
  (31,'07','06','Diploma III (D3)'),
  (32,'07','07','Sarjana (S1)'),
  (33,'07','08','Pasca Sarjana (S2)'),
  (34,'07','09','Doktoral (S3)'),
  (35,'07','99','Lainnya'),
  (36,'08','01','Pegawai Negeri Sipil'),
  (37,'08','02','Pegawai Negeri Non-Sipil'),
  (38,'08','03','Pegawai BUMN/BUMND'),
  (39,'08','04','Pegawai Swasta'),
  (40,'08','05','Pegawai Kontrak'),
  (41,'08','06','Pejabat Negara'),
  (42,'08','20','Pegawai Lain-Lain'),
  (43,'08','21','Wiraswasta'),
  (44,'08','22','Profesional'),
  (45,'08','23','Pekerja Non-Formal'),
  (46,'08','24','Pekerja Informal'),
  (47,'08','25','Ibu Rumah Tangga'),
  (48,'08','26','Pelajar/Mahasiswa'),
  (49,'08','27','Tanpa Pekerjaan'),
  (50,'08','99','Lain-lain'),
  (51,'09','0100','Propinsi Jawa Barat'),
  (52,'09','0102','Bekasi, Kab.'),
  (53,'09','0103','Purwakarta, Kab.'),
  (54,'09','0106','Karawang, Kab.'),
  (55,'09','0108','Bogor, Kab.'),
  (56,'09','0109','Sukabumi, Kab.'),
  (57,'09','0110','Cianjur, Kab.'),
  (58,'09','0111','Bandung, Kab.'),
  (59,'09','0112','Sumedang, Kab.'),
  (60,'09','0113','Tasikmalaya, Kab.'),
  (61,'09','0114','Garut, Kab.'),
  (62,'09','0115','Ciamis, Kab.'),
  (63,'09','0116','Cirebon, Kab.'),
  (64,'09','0117','Kuningan, Kab.'),
  (65,'09','0118','Indramayu, Kab.'),
  (66,'09','0119','Majalengka, Kab.'),
  (67,'09','0121','Subang, Kab.'),
  (68,'09','0180','Banjar, Kota.'),
  (69,'09','0188','Prov. Jawa Barat, Kab./Kota Lainnya.'),
  (70,'09','0191','Bandung, Kota.'),
  (71,'09','0192','Bogor, Kota.'),
  (72,'09','0193','Sukabumi, Kota.'),
  (73,'09','0194','Cirebon, Kota.'),
  (74,'09','0195','Tasikmalaya, Kota.'),
  (75,'09','0196','Cimahi, Kota.'),
  (76,'09','0197','Depok, Kota.'),
  (77,'09','0198','Bekasi, Kota.'),
  (78,'09','0200','Provinsi Banten'),
  (79,'09','0201','Lebak, Kab.'),
  (80,'09','0202','Pandeglang, Kab.'),
  (81,'09','0203','Serang, Kab.'),
  (82,'09','0204','Tangerang, Kab.'),
  (83,'09','0288','Prov. Banten, Kab./Kota Lainnya.'),
  (84,'09','0291','Cilegon, Kota.'),
  (85,'09','0292','Tangerang, Kota.'),
  (86,'09','0300','DKI Jaya'),
  (87,'09','0391','Jakarta Pusat, Wil. Kota'),
  (88,'09','0392','Jakarta Utara , Wil. Kota'),
  (89,'09','0393','Jakarta Barat, Wil. Kota'),
  (90,'09','0394','Jakarta Selatan, Wil. Kota'),
  (91,'09','0395','Jakarta Timur, Wil. Kota'),
  (92,'09','0500','D.I Yogyakarta'),
  (93,'09','0501','Bantul, Kab.'),
  (94,'09','0502','Sleman, Kab.'),
  (95,'09','0503','Gunung Kidul, Kab.'),
  (96,'09','0504','Kulon Progo, Kab.'),
  (97,'09','0588','DI Yogyakarta, Kab./Kota Lainnya.'),
  (98,'09','0591','Yogyakarta, Kota.'),
  (99,'09','0900','Prov. Jawa Tengah'),
  (100,'09','0901','Semarang, Kab.'),
  (101,'09','0902','Kendal, Kab.'),
  (102,'09','0903','Demak, Kab.'),
  (103,'09','0904','Grobogan, Kab.'),
  (104,'09','0905','Pekalongan, Kab.'),
  (105,'09','0906','Tegal, Kab.'),
  (106,'09','0907','Brebes, Kab.'),
  (107,'09','0908','Pati, Kab.'),
  (108,'09','0909','Kudus, Kab.'),
  (109,'09','0910','Pemalang, Kab.'),
  (110,'09','0911','Jepara, Kab.'),
  (111,'09','0912','Rembang, Kab.'),
  (112,'09','0913','Blora, Kab.'),
  (113,'09','0914','Banyumas, Kab.'),
  (114,'09','0915','Cilacap, Kab.'),
  (115,'09','0916','Purbalingga, Kab.'),
  (116,'09','0917','Banjarnegara, Kab.'),
  (117,'09','0918','Magelang, Kab.'),
  (118,'09','0919','Temanggung, Kab.'),
  (119,'09','0920','Wonosobo, Kab.'),
  (120,'09','0921','Purworejo, Kab.'),
  (121,'09','0922','Kebumen, Kab.'),
  (122,'09','0923','Klaten, Kab.'),
  (123,'09','0924','Boyolali, Kab.'),
  (124,'09','0925','Sragen, Kab.'),
  (125,'09','0926','Sukoharjo, Kab.'),
  (126,'09','0927','Karanganyar, Kab.'),
  (127,'09','0928','Wonogiri, Kab.'),
  (128,'09','0929','Batang, Kab.'),
  (129,'09','0988','Prov. Jawa Tengah, Kab./Kota Lainnya.'),
  (130,'09','0991','Semarang, Kota.'),
  (131,'09','0992','Salatiga, Kota.'),
  (132,'09','0993','Pekalongan, Kota.'),
  (133,'09','0994','Tegal, Kota.'),
  (134,'09','0995','Magelang, Kota.'),
  (135,'09','0996','Surakarta, Kota.'),
  (136,'09','0997','Kotif Klaten'),
  (137,'09','0998','Kotif Cilacap'),
  (138,'09','0999','Kotif Purwokerto'),
  (139,'09','1200','Prov. Jawa Timur'),
  (140,'09','1201','Gresik, Kab.'),
  (141,'09','1202','Sidoarjo, Kab.'),
  (142,'09','1203','Mojokerto, Kab.'),
  (143,'09','1204','Jombang, Kab.'),
  (144,'09','1205','Sampang, Kab.'),
  (145,'09','1206','Pamekasan, Kab.'),
  (146,'09','1207','Sumenep, Kab.'),
  (147,'09','1208','Bangkalan, Kab.'),
  (148,'09','1209','Bondowoso, Kab.'),
  (149,'09','1211','Banyuwangi, Kab.'),
  (150,'09','1212','Jember, Kab.'),
  (151,'09','1213','Malang, Kab.'),
  (152,'09','1214','Pasuruan, Kab.'),
  (153,'09','1215','Probolinggo, Kab.'),
  (154,'09','1216','Lumajang, Kab.'),
  (155,'09','1217','Kediri, Kab.'),
  (156,'09','1218','Nganjuk, Kab.'),
  (157,'09','1219','Tulungagung, Kab.'),
  (158,'09','1220','Trenggalek, Kab.'),
  (159,'09','1221','Blitar, Kab.'),
  (160,'09','1222','Madiun, Kab.'),
  (161,'09','1223','Ngawi, Kab.'),
  (162,'09','1224','Magetan, Kab.'),
  (163,'09','1225','Ponorogo, Kab.'),
  (164,'09','1226','Pacitan, Kab.'),
  (165,'09','1227','Bojonegoro, Kab.'),
  (166,'09','1228','Tuban, Kab.'),
  (167,'09','1229','Lamongan, Kab.'),
  (168,'09','1230','Situbondo, Kab.'),
  (169,'09','1271','Batu, Kota.'),
  (170,'09','1288','Prov. Jawa Timur, Kab./Kota Lainnya.'),
  (171,'09','1291','Surabaya, Kota.'),
  (172,'09','1292','Mojokerto, Kota.'),
  (173,'09','1293','Malang, Kota.'),
  (174,'09','1294','Pasuruan, Kota.'),
  (175,'09','1295','Probolinggo, Kota.'),
  (176,'09','1296','Blitar, Kota.'),
  (177,'09','1297','Kediri, Kota.'),
  (178,'09','1298','Madiun, Kota.'),
  (179,'09','1299','Jember, Kota.'),
  (180,'09','2300','Provinsi Bengkulu'),
  (181,'09','2301','Bengkulu Selatan, Kab.'),
  (182,'09','2302','Bengkulu Utara, Kab.'),
  (183,'09','2303','Rejang Lebong, Kab.'),
  (184,'09','2388','Prov. Bengkulu, Kab./Kota Lainnya.'),
  (185,'09','2391','Bengkulu, Kota.'),
  (186,'09','3100','Provinsi Jambi'),
  (187,'09','3101','Batanghari, Kab.'),
  (188,'09','3104','Sarolangun, Kab.'),
  (189,'09','3105','Kerinci, Kab.'),
  (190,'09','3106','Muaro Jambi, Kab.'),
  (191,'09','3107','Tanjung Jabung Barat, Kab.'),
  (192,'09','3108','Tanjung Jabung Timur, Kab.'),
  (193,'09','3109','Tebo, Kab.'),
  (194,'09','3110','Bungo, Kab.'),
  (195,'09','3111','Merangin, Kab.'),
  (196,'09','3188','Prov. Jambi, Kab./Kota Lainnya.'),
  (197,'09','3191','Jambi, Kota.'),
  (198,'09','3200','Provinsi NAD'),
  (199,'09','3201','Aceh Besar, Kab.'),
  (200,'09','3202','Pidie, Kab.'),
  (201,'09','3203','Aceh Utara, Kab.'),
  (202,'09','3204','Aceh Timur, Kab.'),
  (203,'09','3205','Aceh Selatan, Kab.'),
  (204,'09','3206','Aceh Barat, Kab.'),
  (205,'09','3207','Aceh Tengah, Kab.'),
  (206,'09','3208','Aceh Tenggara, Kab.'),
  (207,'09','3209','Aceh Singkil, Kab.'),
  (208,'09','3210','Aceh Jeumpa/Bireuen, Kab.'),
  (209,'09','3211','Aceh Tamiang, Kab.'),
  (210,'09','3212','Gayo Luwes, Kab.'),
  (211,'09','3213','Aceh Barat Daya, Kab.'),
  (212,'09','3214','Aceh Jaya, Kab.'),
  (213,'09','3215','Nagan Raya, Kab.'),
  (214,'09','3216','Aceh Simeuleu, Kab.'),
  (215,'09','3288','Prov. NAD, Kab./Kota Lainnya.'),
  (216,'09','3291','Banda Aceh, Kota.'),
  (217,'09','3292','Sabang, Kota.'),
  (218,'09','3293','Lhokseumawe, Kota.'),
  (219,'09','3294','Langsa, Kota.'),
  (220,'09','3295','Simeulue, Kota.'),
  (221,'09','3300','Provinsi Sumatera Utara'),
  (222,'09','3301','Deli Serdang, Kab.'),
  (223,'09','3302','Langkat, Kab.'),
  (224,'09','3303','Karo, Kab.'),
  (225,'09','3304','Simalungun, Kab.'),
  (226,'09','3305','Labuhan Batu, Kab.'),
  (227,'09','3306','Asahan, Kab.'),
  (228,'09','3307','Dairi, Kab.'),
  (229,'09','3308','Tapanuli Utara, Kab.'),
  (230,'09','3309','Tapanuli Tengah, Kab.'),
  (231,'09','3310','Tapanuli Selatan, Kab.'),
  (232,'09','3311','Nias, Kab.'),
  (233,'09','3312','Rantau Prapat, Kota.'),
  (234,'09','3313','Toba Samosir, Kab.'),
  (235,'09','3314','Mandailing Natal, Kab.'),
  (236,'09','3388','Prov. Sumatera Utara, Kab./Kota Lainnya.'),
  (237,'09','3391','Tebing Tinggi, Kota.'),
  (238,'09','3392','Binjai, Kota.'),
  (239,'09','3393','Pematang Siantar, Kota.'),
  (240,'09','3394','Tanjung Balai, Kota.'),
  (241,'09','3395','Sibolga, Kota.'),
  (242,'09','3396','Medan, Kota.'),
  (243,'09','3398','Kisaran, Kota.'),
  (244,'09','3399','Padang Sidempuan, Kota.'),
  (245,'09','3400','Provinsi Sumatera Barat'),
  (246,'09','3401','Agam, Kab.'),
  (247,'09','3402','Pasaman, Kab.'),
  (248,'09','3403','Limapuluh Koto, Kab.'),
  (249,'09','3404','Solok, Kab.'),
  (250,'09','3405','Padang Pariaman, Kab.'),
  (251,'09','3406','Pesisir Selatan, Kab.'),
  (252,'09','3407','Tanah Datar, Kab.'),
  (253,'09','3408','Sawahlunto/Sijunjung, Kab.'),
  (254,'09','3409','Kepulauan Mentawai, Kab.'),
  (255,'09','3488','Prov. Sumatera Barat, Kab./Kota Lainnya.'),
  (256,'09','3491','Bukittinggi, Kota.'),
  (257,'09','3492','Padang, Kota.'),
  (258,'09','3493','Sawahlunto, Kota.'),
  (259,'09','3494','Padang Panjang, Kota.'),
  (260,'09','3495','Solok, Kota.'),
  (261,'09','3496','Payakumbuh, Kota.'),
  (262,'09','3497','Pariaman, Kota.'),
  (263,'09','3500','Provinsi Riau'),
  (264,'09','3501','Kampar, Kab.'),
  (265,'09','3502','Bengkalis, Kab.'),
  (266,'09','3503','Kepulauan Riau, Kab.'),
  (267,'09','3504','Indragiri Hulu, Kab.'),
  (268,'09','3505','Indragiri Hilir, Kab.'),
  (269,'09','3506','Karimun, Kab.'),
  (270,'09','3507','Natuna, Kab.'),
  (271,'09','3508','Rokan Hulu, Kab.'),
  (272,'09','3509','Rokan Hilir, Kab.'),
  (273,'09','3510','Pelalawan, Kab.'),
  (274,'09','3511','Siak, Kab.'),
  (275,'09','3512','Kuantan Singingi, Kab.'),
  (276,'09','3588','Prov. Riau, Kab./Kota Lainnya.'),
  (277,'09','3591','Pekanbaru, Kota.'),
  (278,'09','3592','Dumai, Kota.'),
  (279,'09','3593','Tanjungpinang, Kota.'),
  (280,'09','3594','Batam, Kota.'),
  (281,'09','3600','Provinsi Sumatera Selatan'),
  (282,'09','3606','Musi Banyuasin, Kab.'),
  (283,'09','3607','Ogan Komering Ulu, Kab.'),
  (284,'09','3608','Lematang Ilir Ogan Tengah (Muara Enim), Kab.'),
  (285,'09','3609','Lahat, Kab.'),
  (286,'09','3610','Musi Rawas, Kab.'),
  (287,'09','3611','Ogan Komering Ilir, Kab.'),
  (288,'09','3612','Pangkalan Balai, Kab.'),
  (289,'09','3688','Prov Sumatera Selatan, Kab./Kota Lainnya.'),
  (290,'09','3691','Palembang, Kota.'),
  (291,'09','3693','Lubuklinggau, Kota.'),
  (292,'09','3694','Prabumulih, Kota.'),
  (293,'09','3695','Baturaja, Kota.'),
  (294,'09','3697','Pagar Alam, Kota.'),
  (295,'09','3700','Provinsi Kep. Bangka Belitung'),
  (296,'09','3701','Bangka, Kab.'),
  (297,'09','3702','Belitung, Kab.'),
  (298,'09','3788','Prov. Babel, Kab./Kota Lainnya.'),
  (299,'09','3791','Pangkal Pinang, Kota.'),
  (300,'09','3900','Provinsi Lampung'),
  (301,'09','3901','Lampung Selatan, Kab.'),
  (302,'09','3902','Lampung Tengah, Kab.'),
  (303,'09','3903','Lampung Utara, Kab.'),
  (304,'09','3904','Lampung Barat, Kab.'),
  (305,'09','3905','Tulang Bawang, Kab.'),
  (306,'09','3906','Tanggamus, Kab.'),
  (307,'09','3907','Lampung Timur, Kab.'),
  (308,'09','3908','Way Kanan, Kab.'),
  (309,'09','3988','Prov. Lampung, Kab./Kota Lainnya.'),
  (310,'09','3991','Bandar Lampung, Kota.'),
  (311,'09','3992','Metro, Kota.'),
  (312,'09','5100','Provinsi Kalimantan Selatan'),
  (313,'09','5101','Banjar, Kab.'),
  (314,'09','5102','Tanah Laut, Kab.'),
  (315,'09','5103','Tapin, Kab.'),
  (316,'09','5104','Hulu Sungai Selatan, Kab.'),
  (317,'09','5105','Hulu Sungai Tengah, Kab.'),
  (318,'09','5106','Hulu Sungai Utara, Kab.'),
  (319,'09','5107','Barito Kuala, Kab.'),
  (320,'09','5108','Kota Baru, Kab.'),
  (321,'09','5109','Tabalong, Kab.'),
  (322,'09','5110','Tanah Bumbu, Kab.'),
  (323,'09','5111','Balangan, Kab.'),
  (324,'09','5188','Prov. Kal-Sel, Kab./Kota Lainnya.'),
  (325,'09','5191','Banjarmasin, Kota.'),
  (326,'09','5192','Banjarbaru, Kota.'),
  (327,'09','5300','Provinsi Kalimantan Barat'),
  (328,'09','5301','Pontianak, Kab.'),
  (329,'09','5302','Sambas, Kab.'),
  (330,'09','5303','Ketapang, Kab.'),
  (331,'09','5304','Sanggau, Kab.'),
  (332,'09','5305','Sintang, Kab.'),
  (333,'09','5306','Kapuas Hulu, Kab.'),
  (334,'09','5307','Bengkayang, Kab.'),
  (335,'09','5308','Landak, Kab.'),
  (336,'09','5388','Prov. Kal-Bar, Kab./Kota Lainnya.'),
  (337,'09','5391','Pontianak, Kota.'),
  (338,'09','5392','Singkawang, Kota.'),
  (339,'09','5400','Provinsi Kalimantan Timur'),
  (340,'09','5401','Kutai Kartanegara, Kab.'),
  (341,'09','5402','Berau, Kab.'),
  (342,'09','5403','Pasir, Kab.'),
  (343,'09','5404','Bulungan, Kab.'),
  (344,'09','5405','Kutai Barat, Kab.'),
  (345,'09','5406','Kutai Timur, Kab.'),
  (346,'09','5407','Bulungan Selatan, Kab.'),
  (347,'09','5408','Bulungan Utara, Kab.'),
  (348,'09','5409','Nunukan, Kab.'),
  (349,'09','5410','Malinau, Kab.'),
  (350,'09','5411','Penajam Paser Utara, Kab.'),
  (351,'09','5488','Prov. Kal-Tim, Kab./Kota Lainnya.'),
  (352,'09','5491','Samarinda, Kota.'),
  (353,'09','5492','Balikpapan, Kota.'),
  (354,'09','5493','Tarakan, Kota.'),
  (355,'09','5494','Bontang, Kota.'),
  (356,'09','5800','Provinsi Kalimantan Tengah'),
  (357,'09','5801','Kapuas, Kab.'),
  (358,'09','5802','Kotawaringin Barat, Kab.'),
  (359,'09','5803','Kotawaringin Timur, Kab.'),
  (360,'09','5804','Murung Raya, Kab.'),
  (361,'09','5805','Barito Timur, Kab.'),
  (362,'09','5806','Barito Selatan, Kab.'),
  (363,'09','5807','Gunung Mas, Kab.'),
  (364,'09','5808','Barito Utara, Kab.'),
  (365,'09','5809','Pulang Pisau, Kab.'),
  (366,'09','5810','Seruyan, Kab.'),
  (367,'09','5811','Katingan, Kab.'),
  (368,'09','5812','Sukamara, Kab.'),
  (369,'09','5813','Lamandau, Kab.'),
  (370,'09','5888','Prov. Kal-Teng, Kab./Kota Lainnya.'),
  (371,'09','5892','Palangkaraya, Kota.'),
  (372,'09','6000','Provinsi Sulawesi Tengah'),
  (373,'09','6001','Donggala, Kab.'),
  (374,'09','6002','Poso, Kab.'),
  (375,'09','6003','Parimo/Banggai, Kab.'),
  (376,'09','6004','Toli-Toli, Kab.'),
  (377,'09','6005','Kab.Banggai Kepulauan'),
  (378,'09','6006','Morowali, Kab.'),
  (379,'09','6007','Buol, Kab.'),
  (380,'09','6088','Prov. Sulawesi Tengah, Kab./Kota Lainnya.'),
  (381,'09','6091','Palu, Kota.'),
  (382,'09','6100','Provinsi Sulawesi Selatan'),
  (383,'09','6101','Pinrang, Kab.'),
  (384,'09','6102','Gowa, Kab.'),
  (385,'09','6103','Wajo, Kab.'),
  (386,'09','6104','Mamuju, Kab.'),
  (387,'09','6105','Bone, Kab.'),
  (388,'09','6106','Tana Toraja, Kab.'),
  (389,'09','6107','Maros, Kab.'),
  (390,'09','6108','Majene, Kab.'),
  (391,'09','6109','Luwu Timur, Kab.'),
  (392,'09','6110','Sinjai, Kab.'),
  (393,'09','6111','Bulukumba, Kab.'),
  (394,'09','6112','Bantaeng, Kab.'),
  (395,'09','6113','Jeneponto, Kab.'),
  (396,'09','6114','Selayar, Kab.'),
  (397,'09','6115','Takalar, Kab.'),
  (398,'09','6116','Barru, Kab.'),
  (399,'09','6117','Sidenreng Rappang, Kab.'),
  (400,'09','6118','Pangkajene Kepulauan, Kab.'),
  (401,'09','6119','Watansoppeng, Kab.'),
  (402,'09','6120','Polewali Mandar, Kab.'),
  (403,'09','6121','Enrekang, Kab.'),
  (404,'09','6122','Luwu Selatan, Kab.'),
  (405,'09','6123','Mamasa, Kab.'),
  (406,'09','6124','Luwu Utara, Kab.'),
  (407,'09','6188','Prov. Sulawesi Selatan, Kab./Kota Lainnya.'),
  (408,'09','6191','Makassar, Kota.'),
  (409,'09','6192','Pare-Pare, Kota.'),
  (410,'09','6193','Palopo, Kota.'),
  (411,'09','6194','Watampone, Kota.'),
  (412,'09','6200','Provinsi Sulawesi Utara'),
  (413,'09','6202','Minahasa, Kab.'),
  (414,'09','6203','Bolaang Mongondow, Kab.'),
  (415,'09','6204','Sangihe, Kab.'),
  (416,'09','6205','kepulauan Talaud, Kab.'),
  (417,'09','6206','Minahasa Selatan, Kab.'),
  (418,'09','6288','Sulawesi Utara, Kab./Kota Lainnya.'),
  (419,'09','6291','Manado, Kota.'),
  (420,'09','6293','Bitung, Kota.'),
  (421,'09','6294','Kota. Tomohon'),
  (422,'09','6300','Provinsi Gorontalo'),
  (423,'09','6301','Gorontalo, Kab.'),
  (424,'09','6302','Bualemo, Kab.'),
  (425,'09','6303','Bonebolango, Kab.'),
  (426,'09','6304','Pohuwato, Kab.'),
  (427,'09','6388','Prov. Gorontalo, Kab./Kota Lainnya.'),
  (428,'09','6391','Gorontalo, Kota.'),
  (429,'09','6900','Provinsi Sulawesi Tenggara'),
  (430,'09','6901','Buton, Kab.'),
  (431,'09','6902','Kendari, Kab.'),
  (432,'09','6903','Muna, Kab.'),
  (433,'09','6904','Kolaka, Kab.'),
  (434,'09','6988','Prov. Sulawesi Tenggara, Kab./Kota Lainnya.'),
  (435,'09','6990','Bau-Bau, Kota.'),
  (436,'09','6991','Kendari, Kota.'),
  (437,'09','7100','Provinsi Nusa Tenggara Barat'),
  (438,'09','7101','Lombok Barat, Kab.'),
  (439,'09','7102','Lombok Tengah, Kab.'),
  (440,'09','7103','Lombok Timur, Kab.'),
  (441,'09','7104','Sumbawa, Kab.'),
  (442,'09','7105','Bima, Kab.'),
  (443,'09','7106','Dompu, Kab.'),
  (444,'09','7188','Prov. NTB, Kab./Kota Lainnya.'),
  (445,'09','7191','Mataram, Kota.'),
  (446,'09','7192','Kota. Bima'),
  (447,'09','7200','Provinsi Bali'),
  (448,'09','7201','Buleleng, Kab.'),
  (449,'09','7202','Jembrana, Kab.'),
  (450,'09','7203','Tabanan, Kab.'),
  (451,'09','7204','Badung, Kab.'),
  (452,'09','7205','Gianyar, Kab.'),
  (453,'09','7206','Klungkung, Kab.'),
  (454,'09','7207','Bangli, Kab.'),
  (455,'09','7208','Karangasem, Kab.'),
  (456,'09','7288','Prov. Bali, Kab./Kota Lainnya.'),
  (457,'09','7291','Denpasar, Kota.'),
  (458,'09','7400','Provinsi Nusa Tenggara Timur'),
  (459,'09','7401','Kupang, Kab.'),
  (460,'09','7402','Timor-Tengah Selatan, Kab.'),
  (461,'09','7403','Timor-Tengah Utara, Kab.'),
  (462,'09','7404','Belu, Kab.'),
  (463,'09','7405','Alor, Kab.'),
  (464,'09','7406','Flores Timur, Kab.'),
  (465,'09','7407','Sikka, Kab.'),
  (466,'09','7408','Ende, Kab.'),
  (467,'09','7409','Ngada, Kab.'),
  (468,'09','7410','Manggarai, Kab.'),
  (469,'09','7411','Sumba Timur, Kab.'),
  (470,'09','7412','Sumba Barat, Kab.'),
  (471,'09','7413','Lembata, Kab.'),
  (472,'09','7414','Rote, Kab.'),
  (473,'09','7488','Prov. NTT, Kab./Kota Lainnya.'),
  (474,'09','7491','Kupang, Kota.'),
  (475,'09','8100','Provinsi Maluku'),
  (476,'09','8101','Maluku Tengah, Kab.'),
  (477,'09','8102','Maluku Tenggara, Kab.'),
  (478,'09','8103','Maluku Tenggara Barat, Kab.'),
  (479,'09','8104','Kab Buru'),
  (480,'09','8188','Prov. Maluku, Kab./Kota Lainnya.'),
  (481,'09','8191','Ambon, Kota.'),
  (482,'09','8200','Provinsi Papua'),
  (483,'09','8201','Jayapura, Kab.'),
  (484,'09','8202','Biak Numfor, Kab.'),
  (485,'09','8204','Sorong, Kab.'),
  (486,'09','8205','Fak-Fak, Kab.'),
  (487,'09','8209','Manokwari, Kab.'),
  (488,'09','8210','Yapen-Waropen, Kab.'),
  (489,'09','8211','Merauke, Kab.'),
  (490,'09','8212','Paniai, Kab.'),
  (491,'09','8213','Jayawijaya, Kab.'),
  (492,'09','8214','Nabire, Kab.'),
  (493,'09','8215','Mimika, Kab.'),
  (494,'09','8216','Puncak Jaya, Kab.'),
  (495,'09','8217','Sarmi, Kab.'),
  (496,'09','8218','Keerom, Kab.'),
  (497,'09','8219','Sorong Selatan, Kab.'),
  (498,'09','8220','Raja Ampat, Kab.'),
  (499,'09','8221','Pegunungan Bintang, Kab.'),
  (500,'09','8222','Yahukimo, Kab.'),
  (501,'09','8223','Tolikara, Kab.'),
  (502,'09','8224','Waropen, Kab.'),
  (503,'09','8225','Kaimana, Kab.');
COMMIT;

#
# Data for the `kode_komponen` table  (LIMIT 431,500)
#

INSERT INTO `kode_komponen` (`combo_id`, `combo_komponen`, `combo_kode`, `combo_text`) VALUES

  (504,'09','8226','Boven Digoel, Kab.'),
  (505,'09','8227','Mappi, Kab.'),
  (506,'09','8228','Asmat, Kab.'),
  (507,'09','8229','Teluk Bintuni, Kab.'),
  (508,'09','8230','Teluk Wondama, Kab.'),
  (509,'09','8288','Prov. Papua, Kab./Kota Lainnya.'),
  (510,'09','8291','Jayapura, Kota.'),
  (511,'09','8292','Sorong, Kota.'),
  (512,'09','8300','Provinsi Maluku Utara'),
  (513,'09','8301','Maluku Utara, Kab.'),
  (514,'09','8302','Halmahera Tengah, Kab.'),
  (515,'09','8388','Prov. Maluku Utara, Kab./Kota Lainnya.'),
  (516,'09','8390','Ternate, Kota.'),
  (517,'09','9999','DI  LUAR  INDONESIA'),
  (518,'10','AD','ANDORRA'),
  (519,'10','AE','UNITED ARAB EMIRAT'),
  (520,'10','AF','AFGHANISTAN'),
  (521,'10','AG','ANTIGUA AND BARBUDA'),
  (522,'10','AI','ANGUILLA'),
  (523,'10','AL','ALBANIA'),
  (524,'10','AM','ARMENIA'),
  (525,'10','AN','NETHERLANDS ANTILLES'),
  (526,'10','AO','ANGOLA'),
  (527,'10','AQ','ANTARCTICA'),
  (528,'10','AR','ARGENTINA'),
  (529,'10','AS','AMERICA SAMOA'),
  (530,'10','AT','AUSTRIA'),
  (531,'10','AU','AUSTRALIA'),
  (532,'10','AW','ARUBA'),
  (533,'10','AZ','AZERBAIJAN'),
  (534,'10','BA','BOSNIA-HERZEGOWINA'),
  (535,'10','BB','BARBADOS'),
  (536,'10','BD','BANGLADESH'),
  (537,'10','BE','BELGIUM'),
  (538,'10','BF','BURKINA FASO'),
  (539,'10','BG','BULGARIA'),
  (540,'10','BH','BAHRAIN'),
  (541,'10','BI','BURUNDI'),
  (542,'10','BJ','BENIN'),
  (543,'10','BM','BERMUDA'),
  (544,'10','BN','BRUNEI DARUSSALAM'),
  (545,'10','BO','BOLIVIA'),
  (546,'10','BR','BRAZIL'),
  (547,'10','BS','BAHAMAS'),
  (548,'10','BT','BHUTAN'),
  (549,'10','BV','BOUVET ISLAND'),
  (550,'10','BW','BOTSWANA'),
  (551,'10','BY','BELARUS'),
  (552,'10','BZ','BELIZE'),
  (553,'10','CA','CANADA'),
  (554,'10','CC','COCOS (KEELING) ISLAND'),
  (555,'10','CD','CONGO, THE DEMOCRATIC REPUBLIC OF THE'),
  (556,'10','CF','CENTRAL AFRICAN REPUBLIC'),
  (557,'10','CG','CONGO'),
  (558,'10','CH','SWISS/SWITZERLAND'),
  (559,'10','CI','IVORY COAST'),
  (560,'10','CK','COOK ISLAND'),
  (561,'10','CL','CHILE'),
  (562,'10','CM','CAMEROON'),
  (563,'10','CN','CHINA'),
  (564,'10','CO','COLOMBIA'),
  (565,'10','CR','COSTA RICA'),
  (566,'10','CU','CUBA'),
  (567,'10','CV','CAPE VERDE'),
  (568,'10','CX','CHRISTMAS ISLANDS'),
  (569,'10','CY','CYPRUS'),
  (570,'10','CZ','CZECH REPUBLIC'),
  (571,'10','DE','GERMANY'),
  (572,'10','DJ','DJIBOUTI'),
  (573,'10','DK','DENMARK'),
  (574,'10','DM','DOMINICA'),
  (575,'10','DO','DOMINICAN REPUBLIC'),
  (576,'10','DZ','ALGERIA/ ALJAZAIR'),
  (577,'10','EC','ECUADOR'),
  (578,'10','EE','ESTONIA'),
  (579,'10','EG','EGYPT'),
  (580,'10','EH','WESTERN SAHARA'),
  (581,'10','ER','ERITREA'),
  (582,'10','ES','SPAIN'),
  (583,'10','ET','ETHIOPIA'),
  (584,'10','FI','FINLAND'),
  (585,'10','FJ','FIJI'),
  (586,'10','FK','FALKLAND ISLANDS'),
  (587,'10','FM','MICRONESIA, FEDERATED STATE OF'),
  (588,'10','FO','FAROE ISLANDS'),
  (589,'10','FR','FRANCE'),
  (590,'10','FX','FRANCE, METROPOLITAN'),
  (591,'10','GA','GABON'),
  (592,'10','GB','UNITED KINGDOM (INGGRIS)'),
  (593,'10','GD','GRENADA'),
  (594,'10','GE','GEORGIA'),
  (595,'10','GF','FRENCH GUIANA'),
  (596,'10','GH','GHANA'),
  (597,'10','GI','GIBRALTAR'),
  (598,'10','GL','GREENLAND'),
  (599,'10','GM','GAMBIA'),
  (600,'10','GN','GUINEA'),
  (601,'10','GP','GUADELOUPE'),
  (602,'10','GQ','EQUATORIAL GUINEA'),
  (603,'10','GR','YUNANI (lihat Greece)'),
  (604,'10','GS','SOUTH GEORGIA AND THE SOUTH SANDWICH  I.'),
  (605,'10','GT','GUATEMALA'),
  (606,'10','GU','GUAM'),
  (607,'10','GW','GUINEA BISSAU'),
  (608,'10','GY','GUYANA'),
  (609,'10','HK','HONGKONG'),
  (610,'10','HM','HEARD AND MCDONALD ISLAND'),
  (611,'10','HN','HONDURAS'),
  (612,'10','HR','CROATIA'),
  (613,'10','HT','HAITI'),
  (614,'10','HU','HUNGARY'),
  (615,'10','ID','INDONESIA'),
  (616,'10','IE','IRELAND'),
  (617,'10','IL','ISRAEL'),
  (618,'10','IN','INDIA'),
  (619,'10','IO','BRITISH INDIAN OCEAN TERRITORY'),
  (620,'10','IQ','IRAQ'),
  (621,'10','IR','IRAN'),
  (622,'10','IS','ICELAND'),
  (623,'10','IT','ITALIA'),
  (624,'10','JM','JAMAICA'),
  (625,'10','JO','JORDAN'),
  (626,'10','JP','JAPAN'),
  (627,'10','KE','KENYA'),
  (628,'10','KG','KYRGYZSTAN'),
  (629,'10','KH','CAMBODIA'),
  (630,'10','KI','KIRIBATI'),
  (631,'10','KM','COMOROS'),
  (632,'10','KN','ST. KITTAND NEVIS/ SAINT KITTS C. AND NEVIS'),
  (633,'10','KP','KOREA UTARA'),
  (634,'10','KR','KOREA SELATAN'),
  (635,'10','KW','KUWAIT'),
  (636,'10','KY','CAYMAN ISLANDS'),
  (637,'10','KZ','KAZAKHSTAN'),
  (638,'10','LA','LAO PEOPLE S DEMOC. REP.'),
  (639,'10','LB','LEBANON'),
  (640,'10','LC','SAINT LUCIA'),
  (641,'10','LI','LIECHTENSTEIN'),
  (642,'10','LK','SRI LANGKA/CEYLON'),
  (643,'10','LR','LIBERIA'),
  (644,'10','LS','LESOTHO'),
  (645,'10','LT','LITHUANIA'),
  (646,'10','LU','LUXEMBOURG'),
  (647,'10','LV','LATVIA'),
  (648,'10','LY','LIBYAN ARAB JAMAHIRIYA'),
  (649,'10','MA','MOROCCO'),
  (650,'10','MC','MONACO'),
  (651,'10','MD','MOLDOVA, REPUBLIC OF'),
  (652,'10','MG','MADAGASCAR'),
  (653,'10','MH','MARSHALL ISLANDS'),
  (654,'10','MK','MACEDONIA'),
  (655,'10','ML','MALI'),
  (656,'10','MM','MYANMAR (BURMA)'),
  (657,'10','MN','MONGOLIA'),
  (658,'10','MO','MACAU'),
  (659,'10','MP','NORTHERN MARIANA ISLAND'),
  (660,'10','MQ','MARTINIQUE'),
  (661,'10','MR','MAURITANIA'),
  (662,'10','MS','MONTSERRAT'),
  (663,'10','MT','MALTA'),
  (664,'10','MU','MAURITIUS'),
  (665,'10','MV','MALDIVES'),
  (666,'10','MW','MALAWI'),
  (667,'10','MX','MEXICO'),
  (668,'10','MY','MALAYSIA'),
  (669,'10','MZ','MOZAMBIQUE'),
  (670,'10','N1','LAINNYA'),
  (671,'10','NA','NAMIBIA'),
  (672,'10','NC','NEW CALEDONIA'),
  (673,'10','NE','NIGER'),
  (674,'10','NF','NORFOLK ISLANDS'),
  (675,'10','NG','NIGERIA'),
  (676,'10','NI','NICARAGUA'),
  (677,'10','NL','NETHERLANDS'),
  (678,'10','NO','NORWAY'),
  (679,'10','NP','NEPAL'),
  (680,'10','NR','NAURU'),
  (681,'10','NU','NIEUE'),
  (682,'10','NZ','NEW ZEALAND'),
  (683,'10','OM','OMAN'),
  (684,'10','PA','PANAMA'),
  (685,'10','PE','PERU'),
  (686,'10','PF','FRENCH POLYNESIA'),
  (687,'10','PG','PAPUA NEW GUINEA'),
  (688,'10','PH','PHILIPPINES'),
  (689,'10','PK','PAKISTAN'),
  (690,'10','PL','POLAND'),
  (691,'10','PM','ST. PIERRE & MIQUELON'),
  (692,'10','PN','PITCAIRN'),
  (693,'10','PR','PUERTO RICO'),
  (694,'10','PT','PORTUGAL'),
  (695,'10','PW','PALAU'),
  (696,'10','PY','PARAGUAY'),
  (697,'10','QA','QATAR'),
  (698,'10','RE','REUNION'),
  (699,'10','RO','ROMANIA'),
  (700,'10','RU','RUSSIAN FEDERATION'),
  (701,'10','RW','RWANDA'),
  (702,'10','SA','SAUDI ARABIA'),
  (703,'10','SB','SOLOMON ISLANDS'),
  (704,'10','SC','SEYCHELLES'),
  (705,'10','SD','SUDAN'),
  (706,'10','SE','SWEDIA/SWEDEN'),
  (707,'10','SG','SINGAPORE'),
  (708,'10','SH','ST. HELENA'),
  (709,'10','SI','SLOVENIA'),
  (710,'10','SJ','SVALBARD AND JAN MAYEN ISLAND'),
  (711,'10','SK','SLOVAKIA (SLOVAK REPUBLIC)'),
  (712,'10','SL','SIERA LEONER'),
  (713,'10','SM','SAN MARINO'),
  (714,'10','SN','SENEGAL'),
  (715,'10','SO','SOMALIA'),
  (716,'10','SR','SURINAME'),
  (717,'10','ST','SAO TOME & PRINCIPE'),
  (718,'10','SU','UNION OF SOVIET SOCIALIST REPUBLICS'),
  (719,'10','SV','EL SALVADOR'),
  (720,'10','SY','SYRIAN ARAB REPUBLIC'),
  (721,'10','SZ','SWAZILAND'),
  (722,'10','TC','TURKS & CAICOS ISLAND'),
  (723,'10','TD','CHAD'),
  (724,'10','TF','FRENCH SOUTHERN TERRITORIES'),
  (725,'10','TG','TOGO'),
  (726,'10','TH','THAILAND'),
  (727,'10','TJ','TAJIKISTAN'),
  (728,'10','TK','TOKELAU'),
  (729,'10','TL','Timor Leste'),
  (730,'10','TM','TURKMENISTAN'),
  (731,'10','TN','TUNISIA'),
  (732,'10','TO','TONGA'),
  (733,'10','TR','TURKEY'),
  (734,'10','TT','TRINIDAD & TOBAGO'),
  (735,'10','TV','TUVALU'),
  (736,'10','TW','TAIWAN/REP. OF CHINA/PROVINCE OF CHINA'),
  (737,'10','TZ','TANZANIA (TAGANZICA & ZANZIBAR)'),
  (738,'10','UA','UKRAINE'),
  (739,'10','UG','UGANDA'),
  (740,'10','UM','US MINOR OUTLYING ISLANDS'),
  (741,'10','US','UNITED STATES OF AMERICA'),
  (742,'10','UY','URUGUAY'),
  (743,'10','UZ','UZBEKISTAN'),
  (744,'10','VA','VATICAN CITY STATE (HOLY SEE)'),
  (745,'10','VC','ST. VINCENT & THE GRENADES'),
  (746,'10','VE','VENEZUELA'),
  (747,'10','VG','VIRGIN ISLANDS (BRITISH)'),
  (748,'10','VI','VIRGIN ISLANDS (US)'),
  (749,'10','VN','VIETNAM'),
  (750,'10','VU','VANUATU'),
  (751,'10','WF','WALLIS AND FUTUNA ISLANDS'),
  (752,'10','WS','SAMOA'),
  (753,'10','XO','WEST AFRICA'),
  (754,'10','YE','YEMEN'),
  (755,'10','YT','MAYOTTE'),
  (756,'10','YU','YUGOSLAVIA'),
  (757,'10','ZA','SOUTH AFRICA'),
  (758,'10','ZM','ZAMBIA'),
  (759,'10','ZW','ZIMBABWE'),
  (760,'01','5','DISKORS'),
  (761,'01','6','LULUS'),
  (974,'07','02','SMP / MTS'),
  (975,'07','03','SMA / ALIYAH'),
  (976,'08','07','TNI / POLRI'),
  (977,'15','01','NAHDATUL `ULAMA [NU]'),
  (978,'15','02','MUHAMMADIYAH'),
  (979,'15','03','AL IRSYAD'),
  (980,'15','04','AL ITTIHADIYAH'),
  (981,'15','05','AL WASLIYAH'),
  (982,'15','06','PERSIS'),
  (983,'15','07','AZ ZIKRO'),
  (984,'15','08','MATHLAUL ANWAR [MA]'),
  (985,'15','09','LDII'),
  (986,'15','10','JAMAAH TABLIGH'),
  (987,'16','01','PARTAI DEMOKRAT [PD]'),
  (988,'16','02','PARTAI GOLONGAN KARYA [GOLKAR]'),
  (989,'16','03','PDIP'),
  (990,'16','04','PKS'),
  (991,'16','05','PPP'),
  (992,'16','06','PKB'),
  (993,'16','07','HANURA'),
  (994,'16','08','GERINDRA'),
  (995,'16','09','PAN'),
  (996,'16','10','PARTAI BULAN BINTANG [PBB]'),
  (997,'19','01','MELUKIS / MENGGAMBAR'),
  (998,'19','02','MENYANYI'),
  (999,'19','03','MENARI'),
  (1000,'19','04','MENGAJI'),
  (1001,'19','05','MENJAHIT'),
  (1002,'19','06','MERIAS'),
  (1003,'19','07','PIDATO'),
  (1004,'19','08','BAHASA ASING'),
  (1005,'19','09','KOMPUTER'),
  (1006,'20','01','BOLA BASKET'),
  (1007,'20','02','BULU TANGKIS'),
  (1008,'20','03','TENIS MEJA'),
  (1009,'20','04','SEPAK BOLA'),
  (1010,'20','05','RENANG'),
  (1011,'20','06','BELA DIRI'),
  (1012,'20','07','BOLA VOLLY'),
  (1014,'14','1','AYAH'),
  (1015,'14','2','IBU'),
  (1016,'14','3','WALI'),
  (1017,'14','4','SAUDARA KANDUNG'),
  (1018,'14','5','KAKEK'),
  (1019,'14','6','NENEK'),
  (1020,'14','7','PAMAN'),
  (1021,'14','8','BIBI'),
  (1022,'18','1','YA'),
  (1023,'18','2','TIDAK'),
  (1024,'17','1','ADIK'),
  (1025,'17','2','KAKAK'),
  (1026,'09','3909','Bandar lampung, Kota.'),
  (1027,'09','8105','Maluku Utara'),
  (1028,'09','7107','Sumbawa Bara, Kab.'),
  (1029,'09','3513','Bintan, Kab.'),
  (1030,'09','2304','Kepahiang, Kab.'),
  (1031,'09','6008','Parigi Moutong'),
  (1032,'09','8400','Provinsi Papua Barat'),
  (1033,'09','8401','Fakfak, Kab.'),
  (1034,'21','1','RINGAN'),
  (1035,'21','2','SEDANG'),
  (1036,'21','3','BERAT'),
  (1037,'22','1','KE LUAR PONDOK (NON KE RUMAH)'),
  (1038,'22','2','PULANG KE RUMAH'),
  (1039,'22','3','ISTIRAHAT (TEMPORER)'),
  (1040,'23','01','AL-AZHAR A'),
  (1041,'23','02','AL-AZHAR B'),
  (1042,'24','1','AWAL TAHUN'),
  (1043,'24','2','AKHIR TAHUN'),
  (1047,'26','1','OPPM'),
  (1048,'26','2','KOORDINATOR'),
  (1049,'26','3','NON OPPM & KOORD'),
  (1050,'26','4','FIRQOH-FIRQOH'),
  (1051,'23','03','SYIRIA UP A'),
  (1052,'23','04','SYIRIA UP B'),
  (1053,'27','01','DAPUR UMUM'),
  (1054,'27','02','UST. AGUS MULYANA'),
  (1055,'27','03','UST. KHOLID KAROMI'),
  (1056,'28','01','USHULUDDIN PA'),
  (1057,'28','02','USHULUDDIN FILSAFAT'),
  (1058,'28','03','SYARIAH PMH'),
  (1059,'28','04','SYARIAH MU`AMALAT'),
  (1060,'28','05','SYARIAH EKONOMI ISLAM'),
  (1061,'28','06','TARBIYAH PBA'),
  (1062,'28','07','TARBIYAH PAI'),
  (1081,'29','1','HARIAN'),
  (1082,'29','2','MINGGUAN'),
  (1083,'29','3','BULANAN'),
  (1084,'29','4','TAHUNAN'),
  (1085,'30','1','SABTU'),
  (1086,'30','2','AHAD'),
  (1087,'30','3','SENIN'),
  (1088,'30','4','SELASA'),
  (1089,'30','5','RABU'),
  (1090,'30','6','KAMIS'),
  (1091,'30','7','JUM`AT'),
  (1092,'31','1','1'),
  (1093,'31','2','1 INT'),
  (1094,'31','3','2'),
  (1095,'31','4','3'),
  (1096,'31','5','3 INT'),
  (1097,'31','6','4'),
  (1098,'31','7','5'),
  (1099,'31','8','6'),
  (1100,'32','01','ALIGHAR'),
  (1101,'33','1','TINGGI'),
  (1102,'33','2','SEDANG'),
  (1103,'33','3','RENDAH'),
  (1104,'34','1','DOKTER'),
  (1105,'34','2','PERAWAT'),
  (1106,'34','3','APOTEKER'),
  (1107,'35','1','SANTRI'),
  (1108,'35','2','GURU'),
  (1109,'35','3','UMUM'),
  (1110,'36','01','AYAH'),
  (1111,'36','02','IBU'),
  (1112,'36','03','WALI'),
  (1113,'36','04','KAKAK'),
  (1114,'36','05','ADIK'),
  (1115,'36','06','KAKEK'),
  (1116,'36','07','NENEK'),
  (1117,'36','08','PAMAN'),
  (1118,'36','09','BIBI'),
  (1119,'36','10','SEPUPU'),
  (1120,'36','11','TEMAN'),
  (1121,'37','1','TAHUNAN'),
  (1122,'37','2','SEMESTERAN'),
  (1123,'38','1','LANGSUNG CETAK'),
  (1124,'38','2','TANYAKAN PENCETAKAN'),
  (1125,'38','3','TIDAK DICETAK'),
  (1136,'25','01','Perdos1'),
  (1137,'25','02','Perdos2'),
  (1138,'25','03','Perdos3'),
  (1139,'25','04','Perdos4'),
  (1140,'25','05','Perdos5'),
  (1141,'25','06','ADM'),
  (1142,'25','07','AIR MINUM LA-TANSA'),
  (1143,'25','08','BAKERY'),
  (1144,'25','09','BKSM'),
  (1145,'25','10','DATA AUDIO'),
  (1146,'25','11','DATA VISUAL'),
  (1147,'25','12','DCC'),
  (1148,'25','13','DLP'),
  (1149,'25','14','KMI'),
  (1150,'25','15','KOPDAGU'),
  (1151,'25','16','LAC'),
  (1152,'25','17','LAUNDRY'),
  (1153,'25','18','MABIKORI'),
  (1154,'25','19','PENGASUHAN'),
  (1155,'25','20','PHOTO COPY'),
  (1156,'25','21','PUSDAC'),
  (1157,'25','22','TAILOR'),
  (1158,'25','23','WARTEL AL-AZHAR'),
  (1159,'25','24','WARTEL SANTINIKETAN'),
  (1160,'25','25','WARTEL SYANGGIT'),
  (1172,'32','02','SYIRIA'),
  (1173,'23','05','SYIRIA DOWN'),
  (1174,'23','06','SYANGGIT A'),
  (1175,'23','07','SYANGGIT B'),
  (1176,'23','08','PAKISTAN'),
  (1177,'39','0','NONE'),
  (1178,'39','1','AKTIF'),
  (1179,'39','2','BLOKIR'),
  (1180,'03','1','Semua Kantor'),
  (1181,'03','2','Lokal Kantor'),
  (1182,'40','1','AKTIF'),
  (1183,'40','9','DELETE'),
  (1184,'41','C','Cash'),
  (1185,'41','K','Kredit'),
  (1186,'42','0','Pending'),
  (1187,'42','1','Validasi'),
  (1188,'42','9','Delete');
COMMIT;

#
# Data for the `kode_laporan` table  (LIMIT -479,500)
#

INSERT INTO `kode_laporan` (`laporan_id`, `laporan_jenis`, `laporan_kode`, `laporan_nama`) VALUES

  (1,1,'01','Transaksi Penjualan'),
  (2,1,'02','Transaksi Penjualan [Cash]'),
  (3,1,'03','Transaksi Penjualan [Kredit]'),
  (4,2,'01','Transaksi Pelunasan Penjualan'),
  (5,1,'04','Penjulan Terlaris'),
  (6,3,'01','Data Pelanggan'),
  (7,3,'02','Hutang Pelanggan'),
  (8,4,'01','Transaksi Pembelian'),
  (9,4,'02','Transaksi Pembelian [Cash]'),
  (10,4,'03','Transaksi Pembelian [Kredit]'),
  (11,4,'04','Pembelian Terlaris'),
  (12,5,'01','Transaksi Retur Pembelian'),
  (13,5,'02','Transaksi Retur Pembelian [Cash]'),
  (14,5,'03','Transaksi Retur Pembelian [Kredit]'),
  (15,5,'04','Retur Pembelian Terlaris'),
  (16,6,'01','Transaksi Retur Penjualan'),
  (17,6,'02','Transaksi Retur Penjualan [Cash]'),
  (18,6,'03','Transaksi Retur Penjualan [Kredit]'),
  (19,6,'04','Retur Penjualan Terlaris'),
  (20,1,'05','Transaksi Penjualan - Resep');
COMMIT;

#
# Data for the `kode_lisensi` table  (LIMIT -498,500)
#

INSERT INTO `kode_lisensi` (`lisensi_id`, `lisensi_mesin`, `lisensi_generate`, `lisensi_tanggal`, `lisensi_status`, `lisensi_reg_date`, `lisensi_reg_ip`, `lisensi_reg_alias`, `lisensi_reg_komp`, `lisensi_reg_mac`, `lisensi_reg_kantor`, `lisensi_reg_kali`) VALUES

  (95,'PCELA212C1101V-BFEBFBFF000206A7','80719e1247f83df24290e166943a3c10','2015-12-14',1,'2015-12-14 16:30:56','192.168.137.1','Administrator','rahmat-pc','00-50-56-C0-00-8','01',1);
COMMIT;

#
# Data for the `kode_menu` table  (LIMIT -3,500)
#

INSERT INTO `kode_menu` (`menu_id`, `menu_group`, `menu_kode`, `menu_parent`, `menu_label`, `menu_set`, `menu_reg_date`, `menu_reg_ip`, `menu_reg_alias`) VALUES

  (5254,'1','mn01','mn01','Master Data',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5255,'1','mn0101','mn01','Barang',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5256,'1','mn0102','mn01','Suplier',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5257,'1','mn0103','mn01','Gudang',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5258,'1','mn0104','mn01','Salesman',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5259,'1','mn0105','mn01','Costumer',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5260,'1','mn0106','mn01','Bank',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5261,'1','mn0107','mn01','Bg Ditangan',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5262,'1','mn0108','mn01','Perkiraan',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5263,'1','mn0109','mn01','Saldo Awal Neraca',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5264,'1','mn02','mn02','Transaksi',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5265,'1','mn0201','mn02','Pembelian',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5266,'1','mn020101','mn02','Pembelian',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5267,'1','mn020102','mn02','Retur Pembelian',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5268,'1','mn0202','mn02','Penjualan',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5269,'1','mn020201','mn02','Penjualan',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5270,'1','mn020202','mn02','Retur Penjualan',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5271,'1','mn020203','mn02','Daftar Tagihan',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5272,'1','mn020204','mn02','Rekap Jual Salesmen',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5273,'1','mn03','mn03','Persediaan',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5274,'1','mn0301','mn03','Stok Awal',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5275,'1','mn0302','mn03','Mutasi Stok',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5276,'1','mn0303','mn03','Mutasi Barang',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5277,'1','mn0304','mn03','Stok Opname',1,'2018-05-05 08:42:23','192.168.10.105','dev'),
  (5278,'1','mn04','mn04','Hutang',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5279,'1','mn0401','mn04','Hutang Awal',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5280,'1','mn0402','mn04','Pembayaran Hutang',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5281,'1','mn0403','mn04','Bgo Cair',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5282,'1','mn05','mn05','Piutang',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5283,'1','mn0501','mn05','Piutang Awal',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5284,'1','mn0502','mn05','Pembayaran Piutang',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5285,'1','mn0503','mn05','Bg Cair',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5286,'1','mn0504','mn05','Bg Tolak',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5287,'1','mn06','mn06','Akuntansi',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5288,'1','mn0601','mn06','Kas Masuk/Keluar',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5289,'1','mn0602','mn06','Jurnal Umum',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5290,'1','mn0603','mn06','Jurnal Memorial',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5291,'1','mn07','mn07','Laporan',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5292,'1','mn0701','mn07','Efaktur',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5293,'1','mn070101','mn07','Barang',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5294,'1','mn070102','mn07','Outlet',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5295,'1','mn070103','mn07','Pajak Masukan',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5296,'1','mn070104','mn07','Pajak Keluaran',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5297,'1','mn070105','mn07','Pajak Retur Masukan',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5298,'1','mn070106','mn07','Pajak Retur Keluaran',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5299,'1','mn070107','mn07','Pajak Keluaran Ladaku',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5300,'1','mn0702','mn07','Master',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5301,'1','mn070201','mn07','Costumer',1,'2018-05-05 08:42:24','192.168.10.105','dev'),
  (5302,'1','mn070202','mn07','Barang',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5303,'1','mn070203','mn07','Supplier',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5304,'1','mn070204','mn07','Salesman',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5305,'1','mn0703','mn07','Pembelian',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5306,'1','mn070301','mn07','Pembelian Per Nota',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5307,'1','mn070302','mn07','Pembelian Per Supplier',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5308,'1','mn070303','mn07','Pembelian Per Tanggal',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5309,'1','mn070304','mn07','Pembelian Per Supplier&barang',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5310,'1','mn070305','mn07','Pembelian Per Tanggal&barang',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5311,'1','mn070306','mn07','Pembelian Per Suppplier&nota',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5312,'1','mn070307','mn07','Pembelian Per Tanggal&nota',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5313,'1','mn070308','mn07','Pembelian Per Nota&barang',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5314,'1','mn070309','mn07','Pembelian Per Supplier,Nota,Barang',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5315,'1','mn070310','mn07','Pembelian Per Tanggal,Nota,Barang',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5316,'1','mn070311','mn07','Retur Pembelian Per Nota&barang(Hpp)',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5317,'1','mn0704','mn07','Penjualan',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5318,'1','mn070401','mn07','Penjualan Per Nota',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5319,'1','mn070402','mn07','Penjualan Per Costumer',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5320,'1','mn070403','mn07','Penjualan Per Supplier',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5321,'1','mn070404','mn07','Penjualan Per Tipe',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5322,'1','mn070405','mn07','Penjualan Per Tipe Per Supplier',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5323,'1','mn070406','mn07','Penjualan Per Area',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5324,'1','mn070407','mn07','Penjualan Per Salesman',1,'2018-05-05 08:42:25','192.168.10.105','dev'),
  (5325,'1','mn070408','mn07','Penjualan Per Tanggal',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5326,'1','mn070409','mn07','Penjualan Per Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5327,'1','mn070410','mn07','-',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5328,'1','mn070411','mn07','Penjualan Per Customer & Nota',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5329,'1','mn070412','mn07','Penjualan Per Salesman & Nota',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5330,'1','mn070413','mn07','Penjualan Per Tanggal & Nota',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5331,'1','mn070414','mn07','Penjualan Pajak Per Tanggal & Nota',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5332,'1','mn070415','mn07','-',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5333,'1','mn070416','mn07','Penjualan Per Customer & Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5334,'1','mn070417','mn07','Penjualan Per Supplier & Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5335,'1','mn070418','mn07','Penjualan Per Barang & Customer',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5336,'1','mn070419','mn07','Penjualan Per Salesman & Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5337,'1','mn070420','mn07','Penjualan Per Salesman, Barang, Customer',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5338,'1','mn070421','mn07','Penjualan Per Tanggal & Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5339,'1','mn070422','mn07','-',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5340,'1','mn070423','mn07','Penjualan Per Salesman & Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5341,'1','mn070424','mn07','Penjualan Per Salesman & Kelompok Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5342,'1','mn070425','mn07','-',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5343,'1','mn070426','mn07','Penjualan Per Nota & Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5344,'1','mn070427','mn07','Penjualan Per Customer, Nota, Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5345,'1','mn070428','mn07','Penjualan Per Salesman, Nota, Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5346,'1','mn070429','mn07','Penjualan Per Tanggal, Nota, Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5347,'1','mn070430','mn07','Penjualan Per Salesman, Customer, Barang',1,'2018-05-05 08:42:26','192.168.10.105','dev'),
  (5348,'1','mn070431','mn07','-',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5349,'1','mn070432','mn07','Laba Penjualan Per Nota',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5350,'1','mn070433','mn07','Rugi Laba Penjualan',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5351,'1','mn070434','mn07','Laba Penjualan Per Barang',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5352,'1','mn070435','mn07','Laba Penjualan Per Supplier',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5353,'1','mn070436','mn07','Laba Penjualan Per Supplier Presentase',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5354,'1','mn070437','mn07','Laba Penjualan Per Salesman',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5355,'1','mn0705','mn07','Inventory',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5356,'1','mn070501','mn07','Rekap Draft Barang Per Tanggal',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5357,'1','mn070502','mn07','Rekap Draft Retur Barang Per Tanggal',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5358,'1','mn070503','mn07','Mutasi Barang Per Barang',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5359,'1','mn070504','mn07','Mutase Barang Global Per Supplier',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5360,'1','mn070505','mn07','-',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5361,'1','mn070506','mn07','Kartu Stok',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5362,'1','mn070507','mn07','Persediaan',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5363,'1','mn070508','mn07','Persediaan Rinci',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5364,'1','mn070509','mn07','-',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5365,'1','mn070510','mn07','Stok Opname',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5366,'1','mn070511','mn07','Stok',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5367,'1','mn070512','mn07','Stok Per Supplier',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5368,'1','mn070513','mn07','Mutasi Stok',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5369,'1','mn070514','mn07','Mutase Persediaan',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5370,'1','mn0706','mn07','Hutang',1,'2018-05-05 08:42:27','192.168.10.105','dev'),
  (5371,'1','mn070601','mn07','Retur Beli Per Supplier Per Nota',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5372,'1','mn070602','mn07','Piutang Titipan Per Supplier',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5373,'1','mn070603','mn07','Hutang Supplier Per Nota',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5374,'1','mn070604','mn07','Kartu Hutang',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5375,'1','mn070605','mn07','Pelunasan Hutang Rinci',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5376,'1','mn070606','mn07','-',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5377,'1','mn070607','mn07','Pembayaran Bg',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5378,'1','mn070608','mn07','Bg Cair',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5379,'1','mn0707','mn07','Piutang',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5380,'1','mn070701','mn07','Umur Piutang Over 1 Bulang',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5381,'1','mn070702','mn07','Umur Piutang Over 2 Bulan',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5382,'1','mn070703','mn07','Piutang Jatuh Tempo Per Salesman',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5383,'1','mn070704','mn07','-',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5384,'1','mn070705','mn07','Piutang Customer Per Salesman',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5385,'1','mn070706','mn07','Piutang Customer Per Salesman (2)',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5386,'1','mn070707','mn07','Piutang Customer Per Salesman & Tanggal Bayar Global',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5387,'1','mn070708','mn07','Piutang Customer Per Salesman & Tanggal Bayar',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5388,'1','mn070709','mn07','Piutang Customer Per Salesman Total',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5389,'1','mn070710','mn07','Piutang Customer Per Salesman Over 2 Bulan',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5390,'1','mn070711','mn07','Piutang Customer Area Total',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5391,'1','mn070712','mn07','Piutang Global Per Salesman',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5392,'1','mn070713','mn07','Piutang Global Per Customer',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5393,'1','mn070714','mn07','Kartu Piutang',1,'2018-05-05 08:42:28','192.168.10.105','dev'),
  (5394,'1','mn070715','mn07','Kartu Piutang Per Salesman',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5395,'1','mn070716','mn07','Daftar Pelunasan Piutang',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5396,'1','mn070717','mn07','Pelunasan Piutang Rinci',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5397,'1','mn070718','mn07','Daftar Tagihan Piutang',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5398,'1','mn070719','mn07','Daftar Piutang, Penjualan, Tagihan',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5399,'1','mn070720','mn07','-',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5400,'1','mn070721','mn07','Daftar Sisa Plafon',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5401,'1','mn070722','mn07','Daftar Piutang Over Plafon',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5402,'1','mn070723','mn07','Daftar Umum Piutang Per Salesman',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5403,'1','mn070724','mn07','Daftar Umum Piutang',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5404,'1','mn070725','mn07','Daftar Umum Piutang Harian',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5405,'1','mn070726','mn07','-',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5406,'1','mn070727','mn07','Penerimaan Bg',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5407,'1','mn070728','mn07','Bg Cair',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5408,'1','mn070729','mn07','Bg Belum Cair',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5409,'1','mn070730','mn07','Bg Tolakan',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5410,'1','mn070731','mn07','-',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5411,'1','mn070732','mn07','Piutang Laba Per Salesman',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5412,'1','mn070733','mn07','Histori Piutang',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5413,'1','mn0708','mn07','Keuangan',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5414,'1','mn070801','mn07','Biaya Per Salesman',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5415,'1','mn070802','mn07','Biaya Per Salesman Global',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5416,'1','mn070803','mn07','Neraca',1,'2018-05-05 08:42:29','192.168.10.105','dev'),
  (5417,'1','mn070804','mn07','-',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5418,'1','mn070805','mn07','Neraca Lajur',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5419,'1','mn070806','mn07','-',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5420,'1','mn070807','mn07','Rugi Laba',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5421,'1','mn070808','mn07','-',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5422,'1','mn070809','mn07','Buku Besar',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5423,'1','mn070810','mn07','-',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5424,'1','mn070811','mn07','Jurnal Umum',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5425,'1','mn070812','mn07','-',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5426,'1','mn070813','mn07','Daftar Perkiraan',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5427,'1','mn08','mn08','Proses Data',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5428,'1','mn0801','mn08','Set Periode',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5429,'1','mn0802','mn08','Re Posting',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5430,'1','mn0803','mn08','Tutup Buku',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5431,'1','mn0809','mn08','-',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5432,'1','mn0811','mn08','Backup',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5433,'1','mn0812','mn08','Restore',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5434,'1','mn0813','mn08','Urutkan Transaksi Sto',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5435,'1','mn0819','mn08','-',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5436,'1','mn0821','mn08','Update Database',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5437,'1','mn0822','mn08','Transfer Data From Excel',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5438,'1','mn0829','mn08','-',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5439,'1','mn0831','mn08','Setting Nomor Faktur',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5440,'1','mn0832','mn08','Samakan Data',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5441,'1','mn0833','mn08','Samakan Data Ladaku',1,'2018-05-05 08:42:30','192.168.10.105','dev'),
  (5442,'1','mn09','mn09','Pengaturan',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5443,'1','mn0901','mn09','Set Password',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5444,'1','mn0909','mn09','-',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5445,'1','mn0911','mn09','Setting Menu',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5446,'1','mn0912','mn09','Setting Pos Jurnal',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5447,'1','mn0919','mn09','-',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5448,'1','mn0921','mn09','Data User',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5449,'1','mn0922','mn09','Level Group',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5450,'1','mn0923','mn09','Reset User',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5451,'1','mn0929','mn09','-',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5452,'1','mn0931','mn09','Ref Jenis Barang',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5453,'1','mn0932','mn09','Ref Jenis Customer',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5454,'1','mn0933','mn09','Ref Harga Jual',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5455,'1','mn0939','mn09','-',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5456,'1','mn0941','mn09','Log Out',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5457,'1','mn0942','mn09','Exit',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5458,'1','mn10','mn10','Tentang Kami',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5459,'1','mn1001','mn10','Versi',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5460,'1','mn1002','mn10','Copyright',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5461,'1','mn1003','mn10','Email',1,'2018-05-05 08:42:31','192.168.10.105','dev'),
  (5670,'3','mn01','mn01','&Master Data',1,'2018-05-22 15:51:39','192.168.10.61','dev'),
  (5671,'3','mn0101','mn01','Barang',1,'2018-05-22 15:51:39','192.168.10.61','dev'),
  (5672,'3','mn0102','mn01','Suplier',1,'2018-05-22 15:51:39','192.168.10.61','dev'),
  (5673,'3','mn0103','mn01','Gudang',1,'2018-05-22 15:51:39','192.168.10.61','dev'),
  (5674,'3','mn0104','mn01','Salesman',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5675,'3','mn0105','mn01','Costumer',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5676,'3','mn0106','mn01','Bank',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5677,'3','mn0107','mn01','Bg Ditangan',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5678,'3','mn0108','mn01','Perkiraan',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5679,'3','mn0109','mn01','Saldo Awal Neraca',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5680,'3','mn02','mn02','&Transaksi',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5681,'3','mn0201','mn02','Pembelian',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5682,'3','mn020101','mn02','Pembelian',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5683,'3','mn020102','mn02','Retur Pembelian',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5684,'3','mn0202','mn02','Penjualan',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5685,'3','mn020201','mn02','Penjualan',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5686,'3','mn020202','mn02','Retur Penjualan',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5687,'3','mn020203','mn02','Daftar Tagihan',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5688,'3','mn020204','mn02','Rekap Jual Salesmen',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5689,'3','mn03','mn03','&Persediaan',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5690,'3','mn0301','mn03','Stok Awal',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5691,'3','mn0302','mn03','Mutasi Stok',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5692,'3','mn0303','mn03','Mutasi Barang',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5693,'3','mn0304','mn03','Stok Opname',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5694,'3','mn04','mn04','&Hutang',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5695,'3','mn0401','mn04','Hutang Awal',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5696,'3','mn0402','mn04','Pembayaran Hutang',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5697,'3','mn0403','mn04','Bgo Cair',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5698,'3','mn05','mn05','P&iutang',1,'2018-05-22 15:51:40','192.168.10.61','dev'),
  (5699,'3','mn0501','mn05','Piutang Awal',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5700,'3','mn0502','mn05','Pembayaran Piutang',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5701,'3','mn0503','mn05','Bg Cair',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5702,'3','mn0504','mn05','Bg Tolak',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5703,'3','mn06','mn06','&Akuntansi',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5704,'3','mn0601','mn06','Kas Masuk/Keluar',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5705,'3','mn0602','mn06','Jurnal Umum',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5706,'3','mn0603','mn06','Jurnal Memorial',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5707,'3','mn07','mn07','&Laporan',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5708,'3','mn0701','mn07','Efaktur',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5709,'3','mn070101','mn07','Barang',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5710,'3','mn070102','mn07','Outlet',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5711,'3','mn070103','mn07','Pajak Masukan',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5712,'3','mn070104','mn07','Pajak Keluaran',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5713,'3','mn070105','mn07','Pajak Retur Masukan',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5714,'3','mn070106','mn07','Pajak Retur Keluaran',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5715,'3','mn070107','mn07','Pajak Keluaran Ladaku',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5716,'3','mn0702','mn07','Master',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5717,'3','mn070201','mn07','Costumer',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5718,'3','mn070202','mn07','Barang',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5719,'3','mn070203','mn07','Supplier',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5720,'3','mn070204','mn07','Salesman',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5721,'3','mn0703','mn07','Pembelian',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5722,'3','mn070301','mn07','Pembelian Per Nota',1,'2018-05-22 15:51:41','192.168.10.61','dev'),
  (5723,'3','mn070302','mn07','Pembelian Per Supplier',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5724,'3','mn070303','mn07','Pembelian Per Tanggal',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5725,'3','mn070304','mn07','Pembelian Per Supplier&barang',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5726,'3','mn070305','mn07','Pembelian Per Tanggal&barang',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5727,'3','mn070306','mn07','Pembelian Per Suppplier&nota',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5728,'3','mn070307','mn07','Pembelian Per Tanggal&nota',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5729,'3','mn070308','mn07','Pembelian Per Nota&barang',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5730,'3','mn070309','mn07','Pembelian Per Supplier,Nota,Barang',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5731,'3','mn070310','mn07','Pembelian Per Tanggal,Nota,Barang',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5732,'3','mn070311','mn07','Retur Pembelian Per Nota&barang(Hpp)',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5733,'3','mn0704','mn07','Penjualan',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5734,'3','mn070401','mn07','Penjualan Per Nota',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5735,'3','mn070402','mn07','Penjualan Per Costumer',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5736,'3','mn070403','mn07','Penjualan Per Supplier',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5737,'3','mn070404','mn07','Penjualan Per Tipe',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5738,'3','mn070405','mn07','Penjualan Per Tipe Per Supplier',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5739,'3','mn070406','mn07','Penjualan Per Area',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5740,'3','mn070407','mn07','Penjualan Per Salesman',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5741,'3','mn070408','mn07','Penjualan Per Tanggal',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5742,'3','mn070409','mn07','Penjualan Per Barang',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5743,'3','mn070410','mn07','-',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5744,'3','mn070411','mn07','Penjualan Per Customer & Nota',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5745,'3','mn070412','mn07','Penjualan Per Salesman & Nota',1,'2018-05-22 15:51:42','192.168.10.61','dev'),
  (5746,'3','mn070413','mn07','Penjualan Per Tanggal & Nota',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5747,'3','mn070414','mn07','Penjualan Pajak Per Tanggal & Nota',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5748,'3','mn070415','mn07','-',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5749,'3','mn070416','mn07','Penjualan Per Customer & Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5750,'3','mn070417','mn07','Penjualan Per Supplier & Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5751,'3','mn070418','mn07','Penjualan Per Barang & Customer',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5752,'3','mn070419','mn07','Penjualan Per Salesman & Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5753,'3','mn070420','mn07','Penjualan Per Salesman, Barang, Customer',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5754,'3','mn070421','mn07','Penjualan Per Tanggal & Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5755,'3','mn070422','mn07','-',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5756,'3','mn070423','mn07','Penjualan Per Salesman & Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5757,'3','mn070424','mn07','Penjualan Per Salesman & Kelompok Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5758,'3','mn070425','mn07','-',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5759,'3','mn070426','mn07','Penjualan Per Nota & Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5760,'3','mn070427','mn07','Penjualan Per Customer, Nota, Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5761,'3','mn070428','mn07','Penjualan Per Salesman, Nota, Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5762,'3','mn070429','mn07','Penjualan Per Tanggal, Nota, Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5763,'3','mn070430','mn07','Penjualan Per Salesman, Customer, Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5764,'3','mn070431','mn07','-',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5765,'3','mn070432','mn07','Laba Penjualan Per Nota',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5766,'3','mn070433','mn07','Rugi Laba Penjualan',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5767,'3','mn070434','mn07','Laba Penjualan Per Barang',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5768,'3','mn070435','mn07','Laba Penjualan Per Supplier',1,'2018-05-22 15:51:43','192.168.10.61','dev'),
  (5769,'3','mn070436','mn07','Laba Penjualan Per Supplier Presentase',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5770,'3','mn070437','mn07','Laba Penjualan Per Salesman',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5771,'3','mn0705','mn07','Inventory',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5772,'3','mn070501','mn07','Rekap Draft Barang Per Tanggal',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5773,'3','mn070502','mn07','Rekap Draft Retur Barang Per Tanggal',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5774,'3','mn070503','mn07','Mutasi Barang Per Barang',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5775,'3','mn070504','mn07','Mutase Barang Global Per Supplier',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5776,'3','mn070505','mn07','-',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5777,'3','mn070506','mn07','Kartu Stok',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5778,'3','mn070507','mn07','Persediaan',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5779,'3','mn070508','mn07','Persediaan Rinci',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5780,'3','mn070509','mn07','-',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5781,'3','mn070510','mn07','Stok Opname',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5782,'3','mn070511','mn07','Stok',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5783,'3','mn070512','mn07','Stok Per Supplier',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5784,'3','mn070513','mn07','Mutasi Stok',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5785,'3','mn070514','mn07','Mutase Persediaan',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5786,'3','mn0706','mn07','Hutang',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5787,'3','mn070601','mn07','Retur Beli Per Supplier Per Nota',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5788,'3','mn070602','mn07','Piutang Titipan Per Supplier',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5789,'3','mn070603','mn07','Hutang Supplier Per Nota',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5790,'3','mn070604','mn07','Kartu Hutang',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5791,'3','mn070605','mn07','Pelunasan Hutang Rinci',1,'2018-05-22 15:51:44','192.168.10.61','dev'),
  (5792,'3','mn070606','mn07','-',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5793,'3','mn070607','mn07','Pembayaran Bg',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5794,'3','mn070608','mn07','Bg Cair',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5795,'3','mn0707','mn07','Piutang',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5796,'3','mn070701','mn07','Umur Piutang Over 1 Bulang',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5797,'3','mn070702','mn07','Umur Piutang Over 2 Bulan',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5798,'3','mn070703','mn07','Piutang Jatuh Tempo Per Salesman',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5799,'3','mn070704','mn07','-',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5800,'3','mn070705','mn07','Piutang Customer Per Salesman',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5801,'3','mn070706','mn07','Piutang Customer Per Salesman (2)',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5802,'3','mn070707','mn07','Piutang Customer Per Salesman & Tanggal Bayar Global',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5803,'3','mn070708','mn07','Piutang Customer Per Salesman & Tanggal Bayar',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5804,'3','mn070709','mn07','Piutang Customer Per Salesman Total',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5805,'3','mn070710','mn07','Piutang Customer Per Salesman Over 2 Bulan',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5806,'3','mn070711','mn07','Piutang Customer Area Total',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5807,'3','mn070712','mn07','Piutang Global Per Salesman',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5808,'3','mn070713','mn07','Piutang Global Per Customer',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5809,'3','mn070714','mn07','Kartu Piutang',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5810,'3','mn070715','mn07','Kartu Piutang Per Salesman',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5811,'3','mn070716','mn07','Daftar Pelunasan Piutang',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5812,'3','mn070717','mn07','Pelunasan Piutang Rinci',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5813,'3','mn070718','mn07','Daftar Tagihan Piutang',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5814,'3','mn070719','mn07','Daftar Piutang, Penjualan, Tagihan',1,'2018-05-22 15:51:45','192.168.10.61','dev'),
  (5815,'3','mn070720','mn07','-',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5816,'3','mn070721','mn07','Daftar Sisa Plafon',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5817,'3','mn070722','mn07','Daftar Piutang Over Plafon',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5818,'3','mn070723','mn07','Daftar Umum Piutang Per Salesman',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5819,'3','mn070724','mn07','Daftar Umum Piutang',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5820,'3','mn070725','mn07','Daftar Umum Piutang Harian',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5821,'3','mn070726','mn07','-',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5822,'3','mn070727','mn07','Penerimaan Bg',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5823,'3','mn070728','mn07','Bg Cair',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5824,'3','mn070729','mn07','Bg Belum Cair',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5825,'3','mn070730','mn07','Bg Tolakan',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5826,'3','mn070731','mn07','-',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5827,'3','mn070732','mn07','Piutang Laba Per Salesman',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5828,'3','mn070733','mn07','Histori Piutang',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5829,'3','mn0708','mn07','Keuangan',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5830,'3','mn070801','mn07','Biaya Per Salesman',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5831,'3','mn070802','mn07','Biaya Per Salesman Global',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5832,'3','mn070803','mn07','Neraca',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5833,'3','mn070804','mn07','-',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5834,'3','mn070805','mn07','Neraca Lajur',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5835,'3','mn070806','mn07','-',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5836,'3','mn070807','mn07','Rugi Laba',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5837,'3','mn070808','mn07','-',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5838,'3','mn070809','mn07','Buku Besar',1,'2018-05-22 15:51:46','192.168.10.61','dev'),
  (5839,'3','mn070810','mn07','-',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5840,'3','mn070811','mn07','Jurnal Umum',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5841,'3','mn070812','mn07','-',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5842,'3','mn070813','mn07','Daftar Perkiraan',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5843,'3','mn08','mn08','P&roses Data',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5844,'3','mn0801','mn08','Set Periode',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5845,'3','mn0802','mn08','Re Posting',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5846,'3','mn0803','mn08','Tutup Buku',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5847,'3','mn0809','mn08','-',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5848,'3','mn0811','mn08','Backup',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5849,'3','mn0812','mn08','Restore',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5850,'3','mn0813','mn08','Urutkan Transaksi Sto',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5851,'3','mn0819','mn08','-',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5852,'3','mn0821','mn08','Update Database',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5853,'3','mn0822','mn08','Transfer Data From Excel',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5854,'3','mn0829','mn08','-',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5855,'3','mn0831','mn08','Setting Nomor Faktur',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5856,'3','mn0832','mn08','Samakan Data',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5857,'3','mn0833','mn08','Samakan Data Ladaku',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5858,'3','mn09','mn09','P&engaturan',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5859,'3','mn0901','mn09','Set Password',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5860,'3','mn0909','mn09','-',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5861,'3','mn0911','mn09','Setting Menu',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5862,'3','mn0912','mn09','Setting Pos Jurnal',1,'2018-05-22 15:51:47','192.168.10.61','dev'),
  (5863,'3','mn0919','mn09','-',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5864,'3','mn0921','mn09','Data User',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5865,'3','mn0922','mn09','Level Group',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5866,'3','mn0923','mn09','Reset User',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5867,'3','mn0929','mn09','-',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5868,'3','mn0931','mn09','Ref Jenis Barang',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5869,'3','mn0932','mn09','Ref Satuan',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5870,'3','mn0933','mn09','Ref Jenis Customer',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5871,'3','mn0934','mn09','Ref Harga Jual',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5872,'3','mn0939','mn09','-',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5873,'3','mn0941','mn09','Log Out',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5874,'3','mn0942','mn09','Exit',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5875,'3','mn10','mn10','Tentang &Kami',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5876,'3','mn1001','mn10','Versi',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5877,'3','mn1002','mn10','Copyright',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5878,'3','mn1003','mn10','Email',1,'2018-05-22 15:51:48','192.168.10.61','dev'),
  (5944,'4','mn01','mn01','&Master Data',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5945,'4','mn0101','mn01','Barang',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5946,'4','mn0102','mn01','Suplier',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5947,'4','mn0103','mn01','Gudang',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5948,'4','mn0104','mn01','Salesman',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5949,'4','mn0105','mn01','Costumer',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5950,'4','mn0107','mn01','Bg Ditangan',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5951,'4','mn02','mn02','&Transaksi',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5952,'4','mn0201','mn02','Pembelian',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5953,'4','mn020101','mn02','Pembelian',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5954,'4','mn020102','mn02','Retur Pembelian',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5955,'4','mn0202','mn02','Penjualan',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5956,'4','mn020201','mn02','Penjualan',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5957,'4','mn020202','mn02','Retur Penjualan',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5958,'4','mn020203','mn02','Daftar Tagihan',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5959,'4','mn020204','mn02','Rekap Jual Salesmen',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5960,'4','mn03','mn03','&Persediaan',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5961,'4','mn0301','mn03','Stok Awal',1,'2018-05-31 14:23:45','192.168.10.185','dev'),
  (5962,'4','mn0302','mn03','Mutasi Stok',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5963,'4','mn0303','mn03','Mutasi Barang',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5964,'4','mn0304','mn03','Stok Opname',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5965,'4','mn09','mn09','P&engaturan',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5966,'4','mn0901','mn09','Set Password',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5967,'4','mn0909','mn09','-',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5968,'4','mn0911','mn09','Setting Menu',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5969,'4','mn0919','mn09','-',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5970,'4','mn0921','mn09','Data User',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5971,'4','mn0922','mn09','Level Group',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5972,'4','mn0929','mn09','-',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5973,'4','mn0931','mn09','Ref Jenis Barang',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5974,'4','mn0932','mn09','Ref Satuan',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5975,'4','mn0939','mn09','-',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5976,'4','mn0941','mn09','Log Out',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5977,'4','mn0942','mn09','Exit',1,'2018-05-31 14:23:46','192.168.10.185','dev'),
  (5978,'2','mn01','mn01','&Master Data',1,'2018-05-31 14:24:38','192.168.10.185','dev'),
  (5979,'2','mn0101','mn01','Barang',1,'2018-05-31 14:24:38','192.168.10.185','dev'),
  (5980,'2','mn0102','mn01','Suplier',1,'2018-05-31 14:24:38','192.168.10.185','dev'),
  (5981,'2','mn0103','mn01','Gudang',1,'2018-05-31 14:24:38','192.168.10.185','dev'),
  (5982,'2','mn02','mn02','&Transaksi',1,'2018-05-31 14:24:38','192.168.10.185','dev'),
  (5983,'2','mn0201','mn02','Pembelian',1,'2018-05-31 14:24:38','192.168.10.185','dev'),
  (5984,'2','mn020101','mn02','Pembelian',1,'2018-05-31 14:24:38','192.168.10.185','dev'),
  (5985,'2','mn020102','mn02','Retur Pembelian',1,'2018-05-31 14:24:38','192.168.10.185','dev'),
  (5986,'2','mn0202','mn02','Penjualan',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5987,'2','mn020201','mn02','Penjualan',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5988,'2','mn020202','mn02','Retur Penjualan',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5989,'2','mn020203','mn02','Daftar Tagihan',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5990,'2','mn020204','mn02','Rekap Jual Salesmen',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5991,'2','mn04','mn04','&Hutang',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5992,'2','mn0401','mn04','Hutang Awal',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5993,'2','mn0402','mn04','Pembayaran Hutang',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5994,'2','mn05','mn05','P&iutang',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5995,'2','mn0501','mn05','Piutang Awal',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5996,'2','mn0502','mn05','Pembayaran Piutang',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5997,'2','mn0503','mn05','Bg Cair',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5998,'2','mn06','mn06','&Akuntansi',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (5999,'2','mn0601','mn06','Kas Masuk/Keluar',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6000,'2','mn0602','mn06','Jurnal Umum',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6001,'2','mn08','mn08','P&roses Data',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6002,'2','mn0801','mn08','Set Periode',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6003,'2','mn0802','mn08','Re Posting',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6004,'2','mn0803','mn08','Tutup Buku',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6005,'2','mn0809','mn08','-',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6006,'2','mn0811','mn08','Backup',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6007,'2','mn0812','mn08','Restore',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6008,'2','mn0819','mn08','-',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6009,'2','mn0821','mn08','Update Database',1,'2018-05-31 14:24:39','192.168.10.185','dev'),
  (6010,'2','mn0822','mn08','Transfer Data From Excel',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6011,'2','mn0829','mn08','-',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6012,'2','mn0831','mn08','Setting Nomor Faktur',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6013,'2','mn09','mn09','P&engaturan',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6014,'2','mn0901','mn09','Set Password',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6015,'2','mn0929','mn09','-',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6016,'2','mn0931','mn09','Ref Jenis Barang',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6017,'2','mn0932','mn09','Ref Satuan',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6018,'2','mn0933','mn09','Ref Jenis Customer',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6019,'2','mn10','mn10','Tentang &Kami',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6020,'2','mn1001','mn10','Versi',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6021,'2','mn1002','mn10','Copyright',1,'2018-05-31 14:24:40','192.168.10.185','dev'),
  (6022,'2','mn1003','mn10','Email',1,'2018-05-31 14:24:40','192.168.10.185','dev');
COMMIT;

#
# Data for the `log_login` table  (LIMIT -480,500)
#

INSERT INTO `log_login` (`log_reg`, `log_user`, `log_nama`, `log_tanggal`, `log_ip`, `log_komputer`, `log_mac`, `log_versi`) VALUES

  ('2018-05-31','dev','dev','2018-05-31 14:49:34','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 08:26:32','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 08:39:28','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 08:51:32','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 09:04:07','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 09:11:36','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 09:12:55','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 09:28:58','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 09:34:55','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 09:35:55','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 09:38:00','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 10:11:46','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 10:13:47','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 13:23:29','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 14:42:35','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 15:27:31','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 15:29:30','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 15:34:48','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','0.0.1'),
  ('2018-06-01','dev','dev','2018-06-01 15:36:26','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','0.0.1');
COMMIT;

#
# Data for the `log_stock` table  (LIMIT -490,500)
#

INSERT INTO `log_stock` (`log_reg`, `log_user`, `log_barang`, `log_gudang`, `log_nama`, `log_tanggal`, `log_ip`, `log_komputer`, `log_mac`, `log_ket`) VALUES

  ('2018-06-01','dev','KPK212','01','PEMBELIAN 201806010001','2018-06-01 08:27:13','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00',''),
  ('2018-06-01','dev','01B000143','01','SETUP AWAL STOK','2018-06-01 08:41:12','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00','SYSTEM'),
  ('2018-06-01','dev','01B000143','01','PEMBELIAN 201806010002','2018-06-01 08:41:12','127.0.0.1','YourWaifuIsShit','00-00-00-00-00-00',''),
  ('2018-06-01','dev','01B000143','01','RETUR BELI 201806010002','2018-06-01 10:14:15','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','BUKTI 2090123'),
  ('2018-06-01','dev','01B000143','03','SETUP AWAL STOK','2018-06-01 13:24:11','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','SYSTEM'),
  ('2018-06-01','dev','01B000143','01','MUTASIGUDANG MG201806010001 OUT','2018-06-01 13:24:11','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','03'),
  ('2018-06-01','dev','01B000143','03','MUTASIGUDANG MG201806010001 IN','2018-06-01 13:24:11','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','01'),
  ('2018-06-01','dev','01B000143','01','PENJUALAN 201806010001','2018-06-01 14:44:32','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9',''),
  ('2018-06-01','dev','01B000143','01','PEMBELIAN 201806010002','2018-06-01 15:27:51','192.168.10.185','YourWaifuIsShit','00-71-CC-42-97-C9','');
COMMIT;

#
# Data for the `ref_kategori` table  (LIMIT -495,500)
#

INSERT INTO `ref_kategori` (`kategori_kode`, `kategori_nama`, `kategori_keterangan`) VALUES

  ('001','Minuman','Kategori untuk jenis-jenis minuman'),
  ('002','bahan kimia','kategori untuk bahan-bahan kimia pencucian'),
  ('003','kosmetik',' '),
  ('004','Minuman','Kategori minuman ringan untuk pengunjung');
COMMIT;

#
# Data for the `ref_kategori_sub` table  (LIMIT -495,500)
#

INSERT INTO `ref_kategori_sub` (`sub_kode`, `sub_kategori`, `sub_nama`) VALUES

  ('001','001','Cuci Mobil'),
  ('002','001','Cuci Motor'),
  ('003','001','Cuci Karpet'),
  ('004','004','Minuman Ringan');
COMMIT;

#
# Data for the `ref_logo` table  (LIMIT -496,500)
#

INSERT INTO `ref_logo` (`logo_kode`, `logo_nama`) VALUES

  ('B','Biru'),
  ('H','Hijau'),
  ('M','Merah');
COMMIT;

#
# Data for the `ref_pelanggan` table  (LIMIT -496,500)
#

INSERT INTO `ref_pelanggan` (`pelanggan_kode`, `pelanggan_nama`, `pelanggan_keterangan`) VALUES

  ('01','Member','Pelanggan dengan jenis member atau agen'),
  ('02','Cabang Usaha','Pelanggan dari cabang usaha perusahaan'),
  ('03','Umum','Pelanggan umum');
COMMIT;

#
# Data for the `ref_penyesuaian` table  (LIMIT -494,500)
#

INSERT INTO `ref_penyesuaian` (`penyesuaian_kode`, `penyesuaian_nama`, `penyesuaian_keterangan`) VALUES

  ('01','Hilang','Penyesuian data karena HILANG'),
  ('02','Rusak','Penyesuaian data karena RUSAK'),
  ('03','Koreksi','Penyesuaian data karena KOREKSI'),
  ('04','Saldo Awal','Penyesuaian data karena saldo AWAL'),
  ('05','Stock Opname','Penyesuaian data karena STOCK OPNAME');
COMMIT;

#
# Data for the `ref_satuan` table  (LIMIT -480,500)
#

INSERT INTO `ref_satuan` (`satuan_kode`, `satuan_nama`, `satuan_keterangan`, `satuan_reg_date`, `satuan_reg_alias`, `satuan_upd_date`, `satuan_upd_alias`) VALUES

  ('01','AMPUL','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('02','BOTOL','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('03','BOX','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('04','CAPSUL','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('05','DUS','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('06','KALENG','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('07','KLG','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('08','OVULA','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('09','PCS','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('10','SAC','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('11','SAK','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('12','SATUAN','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('13','STRIP','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('14','SUPPO','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('15','TAB','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('16','TABLET','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('17','TUBE','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('18','VIAL','','0000-00-00 00:00:00','','0000-00-00 00:00:00',''),
  ('BOX','Box','yass','2018-05-22 15:56:22','dev','2018-05-22 15:56:36','dev');
COMMIT;

#
# Data for the `set_app` table  (LIMIT -489,500)
#

INSERT INTO `set_app` (`app_case`, `app_text`) VALUES

  ('TokoNama','Apotek Purwokerto'),
  ('TokoAlamat','Purwokerto'),
  ('TokoKota','0914'),
  ('TokoTelpon','123456'),
  ('TokoEmail','aji@gmail.com'),
  ('TokoPemilik','Aji'),
  ('Version','1.0.2'),
  ('TokoFax','123456'),
  ('PoinSkor','10'),
  ('TokoKotaNama','Purwokerto');
COMMIT;

#
# Data for the `set_cetakan` table  (LIMIT -482,500)
#

INSERT INTO `set_cetakan` (`cetakan_case`, `cetakan_text`) VALUES

  ('StrukUkuranFont','8'),
  ('StrukLebarKertas','500'),
  ('StrukPanjangKertas','70'),
  ('StrukHeaderNama','3'),
  ('StrukHeaderAlamat','3'),
  ('StrukHeaderKota','3'),
  ('StrukHeaderTelpon','3'),
  ('StrukHeaderWaktu','3'),
  ('StrukHeaderGarisAtas','3'),
  ('StrukHeaderTransKode','3'),
  ('StrukIsiKode','3'),
  ('StrukIsiNama','10'),
  ('StrukIsiTandaKali','15'),
  ('StrukIsi','0'),
  ('StrukNamaFont','Arial Narrow'),
  ('StrukFooterText',' ::Terima Kasih ::'),
  ('StrukTabKiri','3');
COMMIT;

#
# Data for the `set_warna` table  (LIMIT -497,500)
#

INSERT INTO `set_warna` (`warna_case`, `warna_text`) VALUES

  ('PenjualanTrans','&H008080FF&'),
  ('PembelianTrans','&H000040C0&');
COMMIT;

#
# Data for the `setup_perkiraan` table  (LIMIT -497,500)
#

INSERT INTO `setup_perkiraan` (`perk_kode`, `perk_parent`, `perk_nama`, `perk_jenis`, `perk_jurnal`, `perk_d_or_k`, `perk_keterangan`) VALUES

  ('101','101','KAS','0','0','D','aaaa'),
  ('101.2','101','ddd','1','1','D','aaa');
COMMIT;

#
# Data for the `temp_penjualan_laba` table  (LIMIT -496,500)
#

INSERT INTO `temp_penjualan_laba` (`laba_tanggal`, `laba_kantor`, `laba_kode`, `laba_nama`, `laba_harga_pokok`, `laba_harga_jual`, `laba_volume`, `laba_discount`, `laba_total_jual`, `laba_total_pokok`, `laba_akhir`) VALUES

  ('2015-12-03','01','01F1512030001','text',9000,10750,1,0,10750,9000,1750),
  ('2015-12-03','01','01F1512030001','Aqua',5000,5600,4,0,22400,20000,2400),
  ('2015-12-14','01','01F1512140001','text',9000,10750,3,0,32250,27000,5250);
COMMIT;

#
# Data for the `x_menu` table  (LIMIT -297,500)
#

INSERT INTO `x_menu` (`menu_kode`, `menu_parent`, `menu_label`, `menu_status`) VALUES

  ('mn01','mn01','MASTER DATA','1'),
  ('mn0101','mn01','Barang','1'),
  ('mn0102','mn01','Suplier','1'),
  ('mn0103','mn01','Gudang','1'),
  ('mn0104','mn01','salesman','1'),
  ('mn0105','mn01','costumer','1'),
  ('mn0106','mn01','bank','1'),
  ('mn0107','mn01','BG ditangan','1'),
  ('mn0108','mn01','perkiraan','1'),
  ('mn0109','mn01','saldo awal neraca','1'),
  ('mn02','mn02','TRANSAKSI','1'),
  ('mn0201','mn02','Pembelian  ','1'),
  ('mn020101','mn02','pembelian  ','1'),
  ('mn020102','mn02','retur pembelian','1'),
  ('mn0202','mn02','Penjualan','1'),
  ('mn020201','mn02','penjualan','1'),
  ('mn020202','mn02','retur penjualan','1'),
  ('mn020203','mn02','daftar tagihan','1'),
  ('mn020204','mn02','rekap jual salesmen','1'),
  ('mn03','mn03','PERSEDIAAN','1'),
  ('mn0301','mn03','stok awal','1'),
  ('mn0302','mn03','mutasi stok','1'),
  ('mn0303','mn03','mutasi barang','1'),
  ('mn0304','mn03','stok opname','1'),
  ('mn04','mn04','HUTANG','1'),
  ('mn0401','mn04','hutang awal','1'),
  ('mn0402','mn04','pembayaran hutang','1'),
  ('mn0403','mn04','BGO cair','1'),
  ('mn05','mn05','PIUTANG','1'),
  ('mn0501','mn05','piutang awal','1'),
  ('mn0502','mn05','pembayaran piutang','1'),
  ('mn0503','mn05','BG cair','1'),
  ('mn0504','mn05','BG tolak','1'),
  ('mn06','mn06','AKUNTANSI','1'),
  ('mn0601','mn06','kas masuk/keluar','1'),
  ('mn0602','mn06','jurnal umum','1'),
  ('mn0603','mn06','jurnal memorial','1'),
  ('mn07','mn07','LAPORAN','1'),
  ('mn0701','mn07','eFaktur','1'),
  ('mn070101','mn07','barang','1'),
  ('mn070102','mn07','outlet','1'),
  ('mn070103','mn07','pajak masukan','1'),
  ('mn070104','mn07','pajak keluaran','1'),
  ('mn070105','mn07','pajak retur masukan','1'),
  ('mn070106','mn07','pajak retur keluaran','1'),
  ('mn070107','mn07','pajak keluaran ladaku','1'),
  ('mn0702','mn07','Master','1'),
  ('mn070201','mn07','costumer','1'),
  ('mn070202','mn07','barang','1'),
  ('mn070203','mn07','supplier','1'),
  ('mn070204','mn07','salesman','1'),
  ('mn0703','mn07','Pembelian  ','1'),
  ('mn070301','mn07','Pembelian per nota','1'),
  ('mn070302','mn07','Pembelian per supplier','1'),
  ('mn070303','mn07','Pembelian per tanggal','1'),
  ('mn070304','mn07','Pembelian per supplier&barang','1'),
  ('mn070305','mn07','Pembelian per tanggal&barang','1'),
  ('mn070306','mn07','Pembelian per suppplier&nota','1'),
  ('mn070307','mn07','Pembelian per tanggal&nota','1'),
  ('mn070308','mn07','Pembelian per nota&barang','1'),
  ('mn070309','mn07','Pembelian per supplier,nota,barang','1'),
  ('mn070310','mn07','Pembelian per tanggal,nota,barang','1'),
  ('mn070311','mn07','Retur pembelian per nota&barang(HPP)','1'),
  ('mn0704','mn07','Penjualan','1'),
  ('mn070401','mn07','Penjualan per nota','1'),
  ('mn070402','mn07','Penjualan per costumer','1'),
  ('mn070403','mn07','Penjualan per supplier','1'),
  ('mn070404','mn07','Penjualan per tipe','1'),
  ('mn070405','mn07','Penjualan per tipe per supplier','1'),
  ('mn070406','mn07','Penjualan per area','1'),
  ('mn070407','mn07','Penjualan per salesman','1'),
  ('mn070408','mn07','Penjualan per tanggal','1'),
  ('mn070409','mn07','Penjualan per barang','1'),
  ('mn070410','mn07','-','1'),
  ('mn070411','mn07','Penjualan per customer & nota','1'),
  ('mn070412','mn07','Penjualan per salesman & nota','1'),
  ('mn070413','mn07','Penjualan per tanggal & nota','1'),
  ('mn070414','mn07','Penjualan pajak per tanggal & nota','1'),
  ('mn070415','mn07','-','1'),
  ('mn070416','mn07','Penjualan per customer & barang','1'),
  ('mn070417','mn07','Penjualan per supplier & barang','1'),
  ('mn070418','mn07','Penjualan per barang & customer','1'),
  ('mn070419','mn07','Penjualan per salesman & barang','1'),
  ('mn070420','mn07','Penjualan per salesman, barang, customer','1'),
  ('mn070421','mn07','Penjualan per tanggal & barang','1'),
  ('mn070422','mn07','-','1'),
  ('mn070423','mn07','Penjualan per salesman & barang','1'),
  ('mn070424','mn07','Penjualan per salesman & kelompok barang','1'),
  ('mn070425','mn07','-','1'),
  ('mn070426','mn07','Penjualan per nota & barang','1'),
  ('mn070427','mn07','Penjualan per customer, nota, barang','1'),
  ('mn070428','mn07','Penjualan per salesman, nota, barang','1'),
  ('mn070429','mn07','Penjualan per tanggal, nota, barang','1'),
  ('mn070430','mn07','Penjualan per salesman, customer, barang','1'),
  ('mn070431','mn07','-','1'),
  ('mn070432','mn07','Laba penjualan per nota','1'),
  ('mn070433','mn07','Rugi laba penjualan','1'),
  ('mn070434','mn07','Laba penjualan per barang','1'),
  ('mn070435','mn07','Laba penjualan per supplier','1'),
  ('mn070436','mn07','Laba penjualan per supplier presentase','1'),
  ('mn070437','mn07','Laba penjualan per salesman','1'),
  ('mn0705','mn07','Inventory','1'),
  ('mn070501','mn07','Rekap draft barang per tanggal','1'),
  ('mn070502','mn07','Rekap draft retur barang per tanggal','1'),
  ('mn070503','mn07','Mutasi barang per barang','1'),
  ('mn070504','mn07','Mutase barang global per supplier','1'),
  ('mn070505','mn07','-','1'),
  ('mn070506','mn07','Kartu stok','1'),
  ('mn070507','mn07','Persediaan','1'),
  ('mn070508','mn07','Persediaan rinci','1'),
  ('mn070509','mn07','-','1'),
  ('mn070510','mn07','Stok opname','1'),
  ('mn070511','mn07','Stok','1'),
  ('mn070512','mn07','Stok per supplier','1'),
  ('mn070513','mn07','Mutasi stok','1'),
  ('mn070514','mn07','Mutase persediaan','1'),
  ('mn0706','mn07','Hutang','1'),
  ('mn070601','mn07','Retur beli per supplier per nota','1'),
  ('mn070602','mn07','Piutang titipan per supplier','1'),
  ('mn070603','mn07','Hutang supplier per nota','1'),
  ('mn070604','mn07','Kartu hutang','1'),
  ('mn070605','mn07','Pelunasan hutang rinci','1'),
  ('mn070606','mn07','-','1'),
  ('mn070607','mn07','Pembayaran BG','1'),
  ('mn070608','mn07','BG cair','1'),
  ('mn0707','mn07','Piutang','1'),
  ('mn070701','mn07','Umur piutang over 1 bulang','1'),
  ('mn070702','mn07','Umur piutang over 2 bulan','1'),
  ('mn070703','mn07','Piutang jatuh tempo per salesman','1'),
  ('mn070704','mn07','-','1'),
  ('mn070705','mn07','Piutang customer per salesman','1'),
  ('mn070706','mn07','Piutang customer per salesman (2)','1'),
  ('mn070707','mn07','Piutang customer per salesman & tanggal bayar global','1'),
  ('mn070708','mn07','Piutang customer per salesman & tanggal bayar','1'),
  ('mn070709','mn07','Piutang customer per salesman total','1'),
  ('mn070710','mn07','Piutang customer per salesman over 2 bulan','1'),
  ('mn070711','mn07','Piutang customer area total','1'),
  ('mn070712','mn07','Piutang global per salesman','1'),
  ('mn070713','mn07','Piutang global per customer','1'),
  ('mn070714','mn07','Kartu piutang','1'),
  ('mn070715','mn07','Kartu piutang per salesman','1'),
  ('mn070716','mn07','Daftar pelunasan piutang','1'),
  ('mn070717','mn07','Pelunasan piutang rinci','1'),
  ('mn070718','mn07','Daftar tagihan piutang','1'),
  ('mn070719','mn07','Daftar piutang, penjualan, tagihan','1'),
  ('mn070720','mn07','-','1'),
  ('mn070721','mn07','Daftar sisa plafon','1'),
  ('mn070722','mn07','Daftar piutang over plafon','1'),
  ('mn070723','mn07','Daftar umum piutang per salesman','1'),
  ('mn070724','mn07','Daftar umum piutang','1'),
  ('mn070725','mn07','Daftar umum piutang harian','1'),
  ('mn070726','mn07','-','1'),
  ('mn070727','mn07','Penerimaan BG','1'),
  ('mn070728','mn07','BG cair','1'),
  ('mn070729','mn07','BG belum cair','1'),
  ('mn070730','mn07','BG tolakan','1'),
  ('mn070731','mn07','-','1'),
  ('mn070732','mn07','Piutang laba per salesman','1'),
  ('mn070733','mn07','Histori piutang','1'),
  ('mn0708','mn07','Keuangan','1'),
  ('mn070801','mn07','Biaya per salesman','1'),
  ('mn070802','mn07','Biaya per salesman global','1'),
  ('mn070803','mn07','Neraca','1'),
  ('mn070804','mn07','-','1'),
  ('mn070805','mn07','Neraca lajur','1'),
  ('mn070806','mn07','-','1'),
  ('mn070807','mn07','Rugi laba','1'),
  ('mn070808','mn07','-','1'),
  ('mn070809','mn07','Buku besar','1'),
  ('mn070810','mn07','-','1'),
  ('mn070811','mn07','Jurnal umum','1'),
  ('mn070812','mn07','-','1'),
  ('mn070813','mn07','Daftar perkiraan','1'),
  ('mn08','mn08','PROSES DATA','1'),
  ('mn0801','mn08','Set periode','1'),
  ('mn0802','mn08','Re posting','1'),
  ('mn0803','mn08','Tutup buku','1'),
  ('mn0804','mn08','--------------','1'),
  ('mn0805','mn08','Backup','1'),
  ('mn0806','mn08','Restore','1'),
  ('mn0807','mn08','Urutkan transaksi sto','1'),
  ('mn0808','mn08','--------------','1'),
  ('mn0809','mn08','Update database','1'),
  ('mn0810','mn08','Transfer data from excel','1'),
  ('mn0811','mn08','--------------','1'),
  ('mn0812','mn08','Setting nomor faktur','1'),
  ('mn0813','mn08','Samakan data','1'),
  ('mn0814','mn08','Samakan data ladaku','1'),
  ('mn09','mn09','PENGATURAN','1'),
  ('mn0901','mn09','Set password','1'),
  ('mn0902','mn09','--------------','1'),
  ('mn0903','mn09','Setting umum','1'),
  ('mn0904','mn09','Setting pos jurnal','1'),
  ('mn0905','mn09','--------------','1'),
  ('mn0906','mn09','User','1'),
  ('mn0907','mn09','--------------','1'),
  ('mn0908','mn09','Log off','1'),
  ('mn0909','mn09','Exit','1'),
  ('mn10','mn10','TENTANG KAMI','1'),
  ('mn1001','mn10','versi','1'),
  ('mn1002','mn10','CopyRight','1'),
  ('mn1003','mn10','Email','1');
COMMIT;



/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;