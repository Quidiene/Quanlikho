create database QuanLiXuatNhapKho;
use QuanLiXuatNhapKho;
CREATE TABLE [dbo].[TaiKhoanNV](
	[MaNV] [varchar](5) NOT NULL primary key ,
	[TenNV] [nvarchar](64) NOT NULL,
	[Dchi] [nvarchar](64) NOT NULL,
	[Sdt] [varchar](10) NOT NULL,
	[Tendangnhap] [varchar](64) NOT NULL,
	[Chucvu] [varchar](1) NOT NULL,
	[MatKhau] [varchar](16) NOT NULL)

CREATE TABLE [dbo].[LoaiHang](
	[MaLoai] [varchar](10) NOT NULL primary key,
	[Tenloai] [nvarchar](20) NOT NULL
	)

CREATE TABLE [dbo].[NhaCC](
	[MaNCC] [nvarchar](10) NOT NULL primary key,
	[TenNCC] [nvarchar](64) NOT NULL,
	[Dchi] [nvarchar](64) NOT NULL,
	[sdt] [varchar](10) NOT NULL)

CREATE TABLE [dbo].[PhieuNH](
	[MaPN] [nvarchar](10) NOT NULL primary key,
	[NgayNhap] [date] NOT NULL,
	[MaNV] [varchar](5) NOT NULL)

CREATE TABLE [dbo].[HangHoa](
	[MaHH] [nvarchar](10) NOT NULL primary key,
	[TenHH] [nvarchar](64) NOT NULL,
	[TSLuong] [int] NOT NULL,
	[Donvitinh] [nvarchar](12) NULL,
	[MaNCC] [nvarchar](10) NULL,
	[MaLoai] [varchar](10) NULL,
	[GiamGia] [int] NULL,
	[ThanhTien] [float] NULL,
	[NgaySX] [date] NULL,
	[HanSD] [date] NULL,
	[GiaNhap] [float] NULL)
	drop table Hanghoa
CREATE TABLE [dbo].[ChitietNH](
	[MaPN] [nvarchar](10) NOT NULL,
	[MaHH] [nvarchar](10) NOT NULL,
	[TenHH] [nvarchar](64) NULL,
	[GiaNhap] [float] NULL,
	[Donvitinh] [nvarchar](10) NULL,
	[NgaySX] [date] NULL,
	[HanSD] [date] NULL,
	[SoLuong] [int] NULL,
	[GiamGia] [int] NULL,
	[ThanhTien] [float] NULL,
	primary key (MaPN,MaHH))

CREATE TABLE [dbo].[ChitietXH](
	[MaPX] [nvarchar](10) NOT NULL,
	[MaHH] [nvarchar](10) NOT NULL,
	[TenHH] [nvarchar](64) NULL,
	[GiaXuat] [float] NULL,
	[SoLuong] [int] NULL,
	[GiamGia] [int] NULL,
	[ThanhTien] [float] NULL,
	primary key (MaPX,MaHH))

CREATE TABLE [dbo].[KhachHang](
	[MaKH] [nvarchar](20) NOT NULL primary key,
	[TenKH] [nvarchar](64) NOT NULL,
	[Dchi] [nvarchar](64) NOT NULL,
	[sdt] [varchar](10) NULL)

CREATE TABLE [dbo].[PhieuXuat](
	[MaPX] [nvarchar](10) NOT NULL primary key,
	[NgayXuat] [date] NOT NULL,
	[MaNV] [varchar](5) NOT NULL,
	[MaKH] [nvarchar](20) NOT NULL)
Create Table BaoCao(
	[MaHH] [nvarchar](10) NOT NULL,
	[TenHH] [nvarchar](64) NULL,
	[SoLuongNhap] float,
	[SoLuongXuat] float
)
