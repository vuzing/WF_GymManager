USE [master]
GO
/****** Object:  Database [GYMCLUB]    Script Date: 04/06/2023 6:56:46 CH ******/
CREATE DATABASE [GYMCLUB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GYMCLUB', FILENAME = N'D:\SQL\MSSQL16.SQLEXPRESS\MSSQL\DATA\GYMCLUB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GYMCLUB_log', FILENAME = N'D:\SQL\MSSQL16.SQLEXPRESS\MSSQL\DATA\GYMCLUB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GYMCLUB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GYMCLUB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GYMCLUB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GYMCLUB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GYMCLUB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GYMCLUB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GYMCLUB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GYMCLUB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GYMCLUB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GYMCLUB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GYMCLUB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GYMCLUB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GYMCLUB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GYMCLUB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GYMCLUB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GYMCLUB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GYMCLUB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GYMCLUB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GYMCLUB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GYMCLUB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GYMCLUB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GYMCLUB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GYMCLUB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GYMCLUB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GYMCLUB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GYMCLUB] SET  MULTI_USER 
GO
ALTER DATABASE [GYMCLUB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GYMCLUB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GYMCLUB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GYMCLUB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GYMCLUB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GYMCLUB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [GYMCLUB] SET QUERY_STORE = ON
GO
ALTER DATABASE [GYMCLUB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GYMCLUB]
GO
/****** Object:  Table [dbo].[NHANVIENLETAN]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIENLETAN](
	[MaNV] [nchar](4) NOT NULL,
	[TenNV] [nvarchar](max) NULL,
	[GIOITINH] [nchar](10) NULL,
	[SDT] [int] NULL,
	[EMAIL] [nvarchar](50) NULL,
	[LUONG] [int] NULL,
 CONSTRAINT [PK_NHANVIENLETAN] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemNV]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TimKiemNV]
    (@MaNV Nvarchar(4),
	@TenNV Nvarchar(max),
	@Gioitinh nvarchar (10),
	@SoDT int,
	@Email VarChar(50),
	@Luong int)
RETURNS TABLE
AS
RETURN
    SELECT *
    FROM NHANVIENLETAN
    WHERE
        (@MaNV IS NULL OR MaNV = @MaNV)
        AND (@TenNV IS NULL OR TenNV LIKE N'%' + @TenNV + N'%')
		AND (@Gioitinh IS NULL OR GIOITINH = @Gioitinh)
		AND (@SoDT IS NULL OR SDT = @SoDT )
		AND (@Email IS NULL OR EMAIL LIKE N'%' + @Email + N'%')
        AND (@Luong IS NULL OR LUONG = @Luong);
		          
GO
/****** Object:  Table [dbo].[THUCPHAMBOSUNG]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUCPHAMBOSUNG](
	[MaTP] [nchar](5) NOT NULL,
	[MaLoaiTP] [nchar](5) NOT NULL,
	[TenTP] [nvarchar](max) NULL,
	[KhoiLuong] [real] NULL,
	[HuongVi] [nchar](30) NULL,
	[SoLanDung] [int] NULL,
	[GiaTien] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_THUCPHAMBOSUNG] PRIMARY KEY CLUSTERED 
(
	[MaTP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemTPBS]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TimKiemTPBS]
    (@Matp NVARCHAR(5),
	@Maloai NVARCHAR(5),
    @tentp NVARCHAR(max),
	@khoiluong real,
	@huongvi NVARCHAR(50),
	@solandung int,
	@giatien int,
	@soluong int)
RETURNS TABLE
AS
RETURN
    SELECT *
    FROM THUCPHAMBOSUNG
    WHERE
        (@Matp IS NULL OR MaTP = @Matp )
        AND (@Maloai IS NULL OR MaLoaiTP =@Maloai)
        AND (@tentp IS NULL OR TenTP = @tentp)
        AND (@khoiluong IS NULL OR KhoiLuong = @khoiluong)
        AND (@huongvi IS NULL OR HuongVi LIKE N'%' + @huongvi + N'%')
		AND (@solandung IS NULL OR SoLanDung = @solandung)
		AND (@giatien IS NULL OR GiaTien = @giatien)
		AND (@soluong IS NULL OR SoLuong = @soluong)
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [nchar](5) NOT NULL,
	[TenKH] [nvarchar](max) NOT NULL,
	[GIOITINH] [nchar](10) NOT NULL,
	[SDT] [int] NOT NULL,
	[EMAIL] [nvarchar](max) NOT NULL,
	[DIACHI] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemKhachHang]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TimKiemKhachHang]
    (@MaKH Nvarchar(5),
	@TenKH Nvarchar(max),
	@Gioitinh nvarchar (10),
	@SoDT int,
	@Email VarChar(max),
	@DiaChi NVARCHAR(max))
RETURNS TABLE
AS
RETURN
    SELECT *
    FROM KHACHHANG
    WHERE
        (@MaKH IS NULL OR MaKH = @MaKH)
        AND (@TenKH IS NULL OR TenKH LIKE N'%' + @TenKH + N'%')
		AND (@Gioitinh IS NULL OR GIOITINH = @Gioitinh)
		AND (@SoDT IS NULL OR SDT = @SoDT )
		AND (@Email IS NULL OR EMAIL LIKE N'%' + @Email + N'%')
        AND (@DiaChi IS NULL OR DIACHI LIKE N'%' + @DiaChi + N'%');              
GO
/****** Object:  Table [dbo].[PERSONALTRAINER]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONALTRAINER](
	[MaPT] [nchar](4) NOT NULL,
	[TenPT] [nvarchar](max) NOT NULL,
	[GIOITINH] [nchar](10) NULL,
	[SDT] [int] NULL,
	[EMAIL] [nvarchar](max) NULL,
	[LUONG] [int] NULL,
	[HOAHONG] [int] NULL,
 CONSTRAINT [PK_PERSONALTRAINER] PRIMARY KEY CLUSTERED 
(
	[MaPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemPT]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TimKiemPT]
    (@MaPT Nvarchar(4),
	@TenPT Nvarchar(max),
	@Gioitinh nvarchar (10),
	@SoDT int,
	@Email VarChar(max),
	@Luong int,
	@TienHoahong int)
RETURNS TABLE
AS
RETURN
    SELECT *
    FROM PERSONALTRAINER
    WHERE
        (@MaPT IS NULL OR MaPT = @MaPT)
        AND (@TenPT IS NULL OR TenPT LIKE N'%' + @TenPT + N'%')
		AND (@Gioitinh IS NULL OR GIOITINH = @Gioitinh)
		AND (@SoDT IS NULL OR SDT = @SoDT )
		AND (@Email IS NULL OR EMAIL LIKE N'%' + @Email + N'%')
        AND (@Luong IS NULL OR LUONG = @Luong)
		AND(@TienHoahong IS NULL OR HOAHONG = @TienHoahong);              
GO
/****** Object:  Table [dbo].[CHITIEU]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIEU](
	[MaCT] [nchar](4) NOT NULL,
	[MucDich] [nvarchar](50) NULL,
	[Tien] [int] NULL,
	[ThoiGianChiTra] [datetime] NULL,
 CONSTRAINT [PK_CHITIEU] PRIMARY KEY CLUSTERED 
(
	[MaCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemChiTieu]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[TimKiemChiTieu]
(
    @MaCT NCHAR(4),
    @MucDich NVARCHAR(50),
    @Tien int,
    @ThoiGianChiTra DATETIME
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM CHITIEU
    WHERE
        (@MaCT IS NULL OR MaCT = @MaCT)
        AND (@MucDich IS NULL OR MucDich = @MucDich)
        AND (@Tien IS NULL OR Tien = @Tien)
        AND (CONVERT(DATE, @ThoiGianChiTra) = CONVERT(DATE, GETDATE()) OR (ThoiGianChiTra = @ThoiGianChiTra))
);
GO
/****** Object:  Table [dbo].[LOP]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOP](
	[MaLOP] [nchar](5) NOT NULL,
	[MaLoaiLOP] [nchar](4) NOT NULL,
	[MaPT] [nchar](4) NOT NULL,
	[MaTV] [nchar](5) NOT NULL,
	[NGAYBATDAU] [datetime] NOT NULL,
	[NGAYKETTHUC] [datetime] NOT NULL,
	[GHICHU] [nvarchar](max) NULL,
	[ChiPhi] [int] NULL,
 CONSTRAINT [PK_LOP] PRIMARY KEY CLUSTERED 
(
	[MaLOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemLop]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[TimKiemLop]
    (@Malop NVARCHAR(5),
	@Maloai NVARCHAR(4),
    @Mapt NVARCHAR(4),
	@Matv  NVARCHAR(5),
	@ngaybatdau datetime,
	@ngayketthuc datetime,
	@ghichu NVARCHAR(max),
	@chiphi int)
RETURNS TABLE
AS
RETURN
    SELECT *
    FROM LOP
    WHERE
         (@Malop IS NULL OR MaLOP = @Malop)
        AND (@Maloai IS NULL OR MaLoaiLOP = @Maloai)
        AND (@Mapt IS NULL OR MaPT = @Mapt)
        AND (@Matv IS NULL OR MaTV = @Matv)
        AND (CONVERT(DATE, @ngaybatdau) = CONVERT(DATE, GETDATE()) OR (NGAYBATDAU = @ngaybatdau))
        AND (CONVERT(DATE, @ngayketthuc) = CONVERT(DATE, GETDATE()) OR (NGAYKETTHUC = @ngayketthuc))
        AND (@ghichu IS NULL OR GHICHU LIKE '%' + @ghichu + '%')
        AND (@chiphi IS NULL OR ChiPhi = @chiphi)
		
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MaNCC] [nchar](5) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[SDT] [int] NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemNCC]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TimKiemNCC]
    (@MaNCC Nvarchar(5),
	@TenNCC Nvarchar(50),
	@DiaChi NVARCHAR(max),
	@Email NVarChar(max),
	@SoDT int)
RETURNS TABLE
AS
RETURN
    SELECT *
    FROM NHACUNGCAP
    WHERE
        (@MaNCC IS NULL OR MaNCC = @MaNCC)
        AND (@TenNCC IS NULL OR TenNCC LIKE N'%' + @TenNCC + N'%')
		AND (@DiaChi IS NULL OR DIACHI LIKE N'%' + @DiaChi + N'%')		
		AND (@Email IS NULL OR EMAIL LIKE N'%' + @Email + N'%')
        AND (@SoDT IS NULL OR SDT = @SoDT );              
GO
/****** Object:  Table [dbo].[THANHVIEN]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THANHVIEN](
	[MaTV] [nchar](5) NOT NULL,
	[TenTV] [nvarchar](max) NOT NULL,
	[GIOITINH] [nchar](10) NOT NULL,
	[SDT] [int] NOT NULL,
	[EMAIL] [nvarchar](max) NOT NULL,
	[NGAYBATDAU] [datetime] NOT NULL,
	[NGAYKETTHUC] [datetime] NOT NULL,
 CONSTRAINT [PK_THANHVIEN] PRIMARY KEY CLUSTERED 
(
	[MaTV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemThanhVien]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create FUNCTION [dbo].[TimKiemThanhVien]
    (@MaTV Nvarchar(5),
	@TenTV Nvarchar(max),
	@Gioitinh nvarchar (10),
	@SoDT int,
	@Email VarChar(max),
	@NgayBD datetime ,
	@NgayKT datetime
)
RETURNS TABLE
AS
RETURN
    SELECT *
    FROM THANHVIEN
    WHERE
        (@MaTV IS NULL OR MaTV = @MaTV)
        AND (@TenTV IS NULL OR TenTV LIKE N'%' + @TenTV + N'%')
		AND (@Gioitinh IS NULL OR GIOITINH = @Gioitinh)
		AND (@SoDT IS NULL OR SDT = @SoDT )
		AND (@Email IS NULL OR EMAIL LIKE N'%' + @Email + N'%')
		AND (CONVERT(DATE, @NgayBD) = CONVERT(DATE, GETDATE()) OR (NGAYBATDAU = @NgayBD))
        AND (CONVERT(DATE, @NgayKT) = CONVERT(DATE, GETDATE()) OR (NGAYKETTHUC = @NgayKT))
GO
/****** Object:  Table [dbo].[HOADONTHANHTOAN]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADONTHANHTOAN](
	[MaHD] [nchar](5) NOT NULL,
	[MaNV] [nchar](4) NULL,
	[MaTP] [nchar](5) NULL,
	[MaLoaiTP] [nchar](5) NULL,
	[MaKH] [nchar](5) NULL,
	[SoLuong] [int] NULL,
	[TongTien] [int] NULL,
	[GhiChu] [nvarchar](max) NULL,
	[ThoiGianThanhToan] [datetime] NULL,
 CONSTRAINT [PK_HOADONTHANHTOAN] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemHoaDon]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[TimKiemHoaDon]
    (@MaHD NCHAR(5),
	@MaNV Nchar(4),
	@MaTP nchar(5),
	@MaloaiTP nchar(5),
	@MaKH nCHAR(5),
	@SoLuong int,
	@SoTien INT,
	@Ghichu nvarchar(max),
	@Thoigian datetime)
RETURNS TABLE
AS
RETURN
    SELECT *
    FROM HOADONTHANHTOAN
    WHERE
        (@MaHD IS NULL OR MaHD = @MaHD)
        AND (@MaNV IS NULL OR MaNV = @MaNV)
		AND (@MaTP IS NULL OR MaTP = @MaTP)
		AND (@MaloaiTP IS NULL OR MaLoaiTP = @MaloaiTP )
		AND (@MaKH IS NULL OR MaKH  = @MaKH)
        AND (@SoLuong IS NULL OR SoLuong = @SoLuong)
		AND(@SoTien IS NULL OR TongTien = @SoTien)
		AND(@Ghichu IS NULL OR GhiChu LIKE N'%' + @Ghichu + N'%') 
		AND(CONVERT(DATE, @Thoigian) = CONVERT(DATE, GETDATE()) OR (@Thoigian IS NULL OR ThoiGianThanhToan = @Thoigian))              
GO
/****** Object:  Table [dbo].[NHAPHANG]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAPHANG](
	[MaNH] [nchar](5) NOT NULL,
	[MaNCC] [nchar](5) NULL,
	[MaTP] [nchar](5) NULL,
	[LoaiTP] [nchar](5) NULL,
	[SoLuong] [int] NULL,
	[TongTien] [int] NULL,
	[NgayNhap] [datetime] NULL,
 CONSTRAINT [PK_NHAPHANG] PRIMARY KEY CLUSTERED 
(
	[MaNH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TimKiemNhapHang]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TimKiemNhapHang]
    (@MaNH NCHAR(5),
	@MaNCC Nchar(5),
	@MaTP nchar(5),
	@MaloaiTP nchar(5),
	@SoLuong int,
	@SoTien INT,
	@Thoigian datetime)
RETURNS TABLE
AS
RETURN
    SELECT *
    FROM NHAPHANG
    WHERE
        (@MaNH IS NULL OR MaNH = @MaNH)
        AND (@MaNCC IS NULL OR MaNCC = @MaNCC)
		AND (@MaTP IS NULL OR MaTP = @MaTP)
		AND (@MaloaiTP IS NULL OR LoaiTP = @MaloaiTP )
        AND (@SoLuong IS NULL OR SoLuong = @SoLuong)
		AND(@SoTien IS NULL OR TongTien = @SoTien)		
		AND(CONVERT(DATE, @Thoigian) = CONVERT(DATE, GETDATE()) OR (@Thoigian IS NULL OR NgayNhap = @Thoigian))              
GO
/****** Object:  Table [dbo].[LOAILOP]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAILOP](
	[MaLoaiLOP] [nchar](4) NOT NULL,
	[LoaiLOP] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LOAILOP] PRIMARY KEY CLUSTERED 
(
	[MaLoaiLOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAITPBS]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAITPBS](
	[MaLoaiTP] [nchar](5) NOT NULL,
	[TenLoaiTP] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOAITPBS] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CHITIEU] ([MaCT], [MucDich], [Tien], [ThoiGianChiTra]) VALUES (N'CT01', N'Tiền Điện', 1200000, CAST(N'2023-05-12T00:00:00.000' AS DateTime))
INSERT [dbo].[CHITIEU] ([MaCT], [MucDich], [Tien], [ThoiGianChiTra]) VALUES (N'CT02', N'Tiền Nước', 100000, CAST(N'2023-05-11T00:00:00.000' AS DateTime))
INSERT [dbo].[CHITIEU] ([MaCT], [MucDich], [Tien], [ThoiGianChiTra]) VALUES (N'CT03', N'Lắp Đặt Máy Tập', 50000000, CAST(N'2023-06-04T00:00:00.000' AS DateTime))
INSERT [dbo].[CHITIEU] ([MaCT], [MucDich], [Tien], [ThoiGianChiTra]) VALUES (N'CT04', N'Bảo Trì', 5000000, CAST(N'2023-06-04T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[HOADONTHANHTOAN] ([MaHD], [MaNV], [MaTP], [MaLoaiTP], [MaKH], [SoLuong], [TongTien], [GhiChu], [ThoiGianThanhToan]) VALUES (N'HD001', N'NV01', N'TP001', N'LTP01', N'KH001', 1, 1600000, NULL, NULL)
INSERT [dbo].[HOADONTHANHTOAN] ([MaHD], [MaNV], [MaTP], [MaLoaiTP], [MaKH], [SoLuong], [TongTien], [GhiChu], [ThoiGianThanhToan]) VALUES (N'HD002', N'NV02', N'TP008', N'LTP02', N'KH002', 2, 120000, NULL, NULL)
INSERT [dbo].[HOADONTHANHTOAN] ([MaHD], [MaNV], [MaTP], [MaLoaiTP], [MaKH], [SoLuong], [TongTien], [GhiChu], [ThoiGianThanhToan]) VALUES (N'HD003', N'NV03', N'TP016', N'LTP05', N'KH003', 1, 2950000, NULL, NULL)
INSERT [dbo].[HOADONTHANHTOAN] ([MaHD], [MaNV], [MaTP], [MaLoaiTP], [MaKH], [SoLuong], [TongTien], [GhiChu], [ThoiGianThanhToan]) VALUES (N'HD004', N'NV04', N'TP012', N'LTP03', N'KH004', 2, 900000, NULL, NULL)
INSERT [dbo].[HOADONTHANHTOAN] ([MaHD], [MaNV], [MaTP], [MaLoaiTP], [MaKH], [SoLuong], [TongTien], [GhiChu], [ThoiGianThanhToan]) VALUES (N'HD005', N'NV01', N'TP014', N'LTP04', N'KH001', 1, 580000, NULL, NULL)
GO
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GIOITINH], [SDT], [EMAIL], [DIACHI]) VALUES (N'KH001', N'Nguyen Van Anh Dong ', N'Nam       ', 796559365, N'vad@gmail.com', N'Q9')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GIOITINH], [SDT], [EMAIL], [DIACHI]) VALUES (N'KH002', N'Nguyen Huu Thinh', N'Nam       ', 934567891, N'nht@gmail.com', N'Q9')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GIOITINH], [SDT], [EMAIL], [DIACHI]) VALUES (N'KH003', N'Duong Hieu Dong', N'Nam       ', 789664312, N'dhd@gmail.com', N'Q9')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GIOITINH], [SDT], [EMAIL], [DIACHI]) VALUES (N'KH004', N'Dao Dao Duc', N'Nam       ', 783456781, N'ddd@gmail.com', N'Q9')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GIOITINH], [SDT], [EMAIL], [DIACHI]) VALUES (N'KH005', N'Trieu Nhat Nam', N'Nam       ', 843123456, N'tnn@gmail.conm', N'Q10')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GIOITINH], [SDT], [EMAIL], [DIACHI]) VALUES (N'KH006', N'Tran Thi Anh Vien', N'Nu        ', 786754623, N'ttan@gmail.com', N'Q4')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GIOITINH], [SDT], [EMAIL], [DIACHI]) VALUES (N'KH007', N'Duong Thi Dao', N'Nu        ', 943497556, N'dtd@gmail.com', N'Q6')
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKH], [GIOITINH], [SDT], [EMAIL], [DIACHI]) VALUES (N'KH008', N'Nguyen Phuong Su', N'Nu        ', 123455678, N'nps@gmail.com', N'Q1')
GO
INSERT [dbo].[LOAILOP] ([MaLoaiLOP], [LoaiLOP]) VALUES (N'ML01', N'1 Kèm 1')
INSERT [dbo].[LOAILOP] ([MaLoaiLOP], [LoaiLOP]) VALUES (N'ML02', N'Lớp Nhóm')
INSERT [dbo].[LOAILOP] ([MaLoaiLOP], [LoaiLOP]) VALUES (N'ML03', N'Đào Tạo PT ')
GO
INSERT [dbo].[LOAITPBS] ([MaLoaiTP], [TenLoaiTP]) VALUES (N'LTP01', N'WheyProtein')
INSERT [dbo].[LOAITPBS] ([MaLoaiTP], [TenLoaiTP]) VALUES (N'LTP02', N'BCAA,EAA')
INSERT [dbo].[LOAITPBS] ([MaLoaiTP], [TenLoaiTP]) VALUES (N'LTP03', N'Vitamin')
INSERT [dbo].[LOAITPBS] ([MaLoaiTP], [TenLoaiTP]) VALUES (N'LTP04', N'Creatine,PreWorkout')
INSERT [dbo].[LOAITPBS] ([MaLoaiTP], [TenLoaiTP]) VALUES (N'LTP05', N'MassGainer')
GO
INSERT [dbo].[LOP] ([MaLOP], [MaLoaiLOP], [MaPT], [MaTV], [NGAYBATDAU], [NGAYKETTHUC], [GHICHU], [ChiPhi]) VALUES (N'LOP01', N'ML01', N'PT01', N'TV001', CAST(N'2023-05-29T00:00:00.000' AS DateTime), CAST(N'2023-07-29T00:00:00.000' AS DateTime), N'tập Sáng Chiều', 20000000)
INSERT [dbo].[LOP] ([MaLOP], [MaLoaiLOP], [MaPT], [MaTV], [NGAYBATDAU], [NGAYKETTHUC], [GHICHU], [ChiPhi]) VALUES (N'LOP02', N'ML01', N'PT01', N'TV006', CAST(N'2023-05-29T00:00:00.000' AS DateTime), CAST(N'2023-07-29T00:00:00.000' AS DateTime), N'', 50000000)
INSERT [dbo].[LOP] ([MaLOP], [MaLoaiLOP], [MaPT], [MaTV], [NGAYBATDAU], [NGAYKETTHUC], [GHICHU], [ChiPhi]) VALUES (N'LOP03', N'ML02', N'PT02', N'TV003', CAST(N'2023-05-29T00:00:00.000' AS DateTime), CAST(N'2023-07-29T00:00:00.000' AS DateTime), N'Nhom 2', 8000000)
INSERT [dbo].[LOP] ([MaLOP], [MaLoaiLOP], [MaPT], [MaTV], [NGAYBATDAU], [NGAYKETTHUC], [GHICHU], [ChiPhi]) VALUES (N'LOP04', N'ML02', N'PT04', N'TV006', CAST(N'2023-07-31T00:00:00.000' AS DateTime), CAST(N'2024-02-28T00:00:00.000' AS DateTime), N'Nhom 2', 4000000)
GO
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT]) VALUES (N'NCC01', N'WheyStore', N'Q9', N'Wheystore@gmail.com', 987643512)
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT]) VALUES (N'NCC02', N'The Gioi Whey', N'Ha Noi', N'TGW@gmail.com', 987762313)
INSERT [dbo].[NHACUNGCAP] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT]) VALUES (N'NCC03', N'King Supliment', N'Q1', N'KI@gmail.com', 786854931)
GO
INSERT [dbo].[NHANVIENLETAN] ([MaNV], [TenNV], [GIOITINH], [SDT], [EMAIL], [LUONG]) VALUES (N'NV01', N'Phan Vu Thang', N'Nam       ', 1234567890, N'pvt@gmail.com', 10000000)
INSERT [dbo].[NHANVIENLETAN] ([MaNV], [TenNV], [GIOITINH], [SDT], [EMAIL], [LUONG]) VALUES (N'NV02', N'Tran Ngoc Bien', N'Nam       ', 987654231, N'tnb@gmail.com', 10000000)
INSERT [dbo].[NHANVIENLETAN] ([MaNV], [TenNV], [GIOITINH], [SDT], [EMAIL], [LUONG]) VALUES (N'NV03', N'Nguyen Thi Dao', N'Nu        ', 987654321, N'ntd@gmail.com', 8500000)
INSERT [dbo].[NHANVIENLETAN] ([MaNV], [TenNV], [GIOITINH], [SDT], [EMAIL], [LUONG]) VALUES (N'NV04', N'Huynh Thi Thu Thuy', N'Nu        ', 123094512, N'httt@gmail.com', 9000000)
GO
INSERT [dbo].[NHAPHANG] ([MaNH], [MaNCC], [MaTP], [LoaiTP], [SoLuong], [TongTien], [NgayNhap]) VALUES (N'NH001', N'NCC01', N'TP001', N'LTP01', 20, 32890000, CAST(N'2023-01-31T00:00:00.000' AS DateTime))
INSERT [dbo].[NHAPHANG] ([MaNH], [MaNCC], [MaTP], [LoaiTP], [SoLuong], [TongTien], [NgayNhap]) VALUES (N'NH002', N'NCC02', N'TP002', N'LTP01', 12, 31000000, CAST(N'2023-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[NHAPHANG] ([MaNH], [MaNCC], [MaTP], [LoaiTP], [SoLuong], [TongTien], [NgayNhap]) VALUES (N'NH003', N'NCC03', N'TP012', N'LTP03', 10, 4500000, CAST(N'2023-05-30T00:00:00.000' AS DateTime))
INSERT [dbo].[NHAPHANG] ([MaNH], [MaNCC], [MaTP], [LoaiTP], [SoLuong], [TongTien], [NgayNhap]) VALUES (N'NH004', N'NCC03', N'TP003', N'LTP01', 23, 45000000, CAST(N'2023-06-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PERSONALTRAINER] ([MaPT], [TenPT], [GIOITINH], [SDT], [EMAIL], [LUONG], [HOAHONG]) VALUES (N'PT01', N'Phung Huu Thanh', N'Nam       ', 786865906, N'pht@gmail.com', 30000000, 17500000)
INSERT [dbo].[PERSONALTRAINER] ([MaPT], [TenPT], [GIOITINH], [SDT], [EMAIL], [LUONG], [HOAHONG]) VALUES (N'PT02', N'Nguyen Thanh Binh', N'Nam       ', 923456781, N'ntb@gmail.com', 40000000, 8000000)
INSERT [dbo].[PERSONALTRAINER] ([MaPT], [TenPT], [GIOITINH], [SDT], [EMAIL], [LUONG], [HOAHONG]) VALUES (N'PT03', N'Nguyen Quang Dang ', N'Nam       ', 798668431, N'nqd@gmail.com', 25000000, 0)
INSERT [dbo].[PERSONALTRAINER] ([MaPT], [TenPT], [GIOITINH], [SDT], [EMAIL], [LUONG], [HOAHONG]) VALUES (N'PT04', N'Ho Thi Thuy Vi', N'Nu        ', 634234123, N'httv@gmai.com', 15000000, 3000000)
INSERT [dbo].[PERSONALTRAINER] ([MaPT], [TenPT], [GIOITINH], [SDT], [EMAIL], [LUONG], [HOAHONG]) VALUES (N'PT05', N'Nguyen Hoang Phuong Ngan', N'Nu        ', 942480884, N'nhpn@gmail.com', 15000000, 0)
GO
INSERT [dbo].[THANHVIEN] ([MaTV], [TenTV], [GIOITINH], [SDT], [EMAIL], [NGAYBATDAU], [NGAYKETTHUC]) VALUES (N'TV001', N'Nguyen Van A', N'Nam       ', 786865943, N'nva@gmail.com', CAST(N'2023-05-29T12:00:00.000' AS DateTime), CAST(N'2023-11-29T12:00:00.000' AS DateTime))
INSERT [dbo].[THANHVIEN] ([MaTV], [TenTV], [GIOITINH], [SDT], [EMAIL], [NGAYBATDAU], [NGAYKETTHUC]) VALUES (N'TV002', N'Phung Thi Anh Thu', N'Nu        ', 786854693, N'ptat@gmail.com', CAST(N'2023-06-01T12:00:00.000' AS DateTime), CAST(N'2024-06-01T12:00:00.000' AS DateTime))
INSERT [dbo].[THANHVIEN] ([MaTV], [TenTV], [GIOITINH], [SDT], [EMAIL], [NGAYBATDAU], [NGAYKETTHUC]) VALUES (N'TV003', N'Nguyen Van Anh Dong', N'Nam       ', 986743721, N'vad@gmail.com', CAST(N'2023-05-30T12:00:00.000' AS DateTime), CAST(N'2023-06-30T12:00:00.000' AS DateTime))
INSERT [dbo].[THANHVIEN] ([MaTV], [TenTV], [GIOITINH], [SDT], [EMAIL], [NGAYBATDAU], [NGAYKETTHUC]) VALUES (N'TV004', N'Vo Van Ngan', N'Nu        ', 942487668, N'vvn@gmail.com', CAST(N'2023-07-12T12:00:00.000' AS DateTime), CAST(N'2024-07-12T12:00:00.000' AS DateTime))
INSERT [dbo].[THANHVIEN] ([MaTV], [TenTV], [GIOITINH], [SDT], [EMAIL], [NGAYBATDAU], [NGAYKETTHUC]) VALUES (N'TV005', N'Duong Gia Kiet', N'Nam       ', 987654321, N'dgk@gmail.com', CAST(N'2023-05-31T12:00:00.000' AS DateTime), CAST(N'2023-12-01T12:00:00.000' AS DateTime))
INSERT [dbo].[THANHVIEN] ([MaTV], [TenTV], [GIOITINH], [SDT], [EMAIL], [NGAYBATDAU], [NGAYKETTHUC]) VALUES (N'TV006', N'Nguyen Thuy Duong', N'Nu        ', 987123456, N'ntd@gmail.com', CAST(N'2023-05-31T12:00:00.000' AS DateTime), CAST(N'2023-12-01T12:00:00.000' AS DateTime))
GO
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP001', N'LTP01', N'Rule 1 Protein', 2.6, N'Vanilla                       ', 69, 1490000, 112)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP002', N'LTP01', N'ISO HD 5lbs 100% Isolate', 2.27, N'Vanilla                       ', 69, 1490000, 112)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP003', N'LTP01', N'Mutant Iso Surge', 2.27, N'Coconut Cream                 ', 71, 1950000, 123)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP004', N'LTP01', N'Hộp 12 thanh Applied Protein Crunch Bar', 0.75, N'                              ', 0, 690000, 100)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP005', N'LTP02', N'Mutant BCAA', 1.1, N'Pineapple Passiob             ', 90, 1390000, 100)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP006', N'LTP02', N'Mutant BCAA', 0.3, N'Watermelon                    ', 30, 590000, 100)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP007', N'LTP02', N'Nutrex EAA Hydration', 0.4, N'Bood Orange                   ', 30, 550000, 100)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP008', N'LTP02', N'BCAA Amino Hydrate', 0.2, N'Orange Bust                   ', NULL, 60000, 98)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP009', N'LTP03', N' Now Omega-3 200 vien', 0.3, NULL, NULL, 380000, 100)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP010', N'LTP03', N'Platinum Multi Vitamin 90 viên', 0.1, NULL, 3, 350000, 100)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP011', N'LTP03', N'OstroVit Glucosamine MSM Chondroitin - 90 viên
', 0.1, NULL, 1, 350000, 100)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP012', N'LTP03', N'Bronson Vitamin K2 + D3 120 viên', 0.1, NULL, 1, 450000, 108)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP013', N'LTP04', N'Nutrex Outlift', 0.7, N'Miami Vice                    ', 20, 580000, 100)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP014', N'LTP04', N'CobraLab The Curse', 0.25, N'Peach Rings                   ', 50, 580000, 99)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP015', N'LTP05', N'Mass Fusion', 5.4, N'Strawberry                    ', 22, 1690000, 100)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP016', N'LTP05', N'Mass Tech 2000', 10, N'Chocolate                     ', 20, 2950000, 49)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP017', N'LTP01', N'Rule1 Protein', 2.2, N'Chocolate                     ', 76, 1600000, 99)
INSERT [dbo].[THUCPHAMBOSUNG] ([MaTP], [MaLoaiTP], [TenTP], [KhoiLuong], [HuongVi], [SoLanDung], [GiaTien], [SoLuong]) VALUES (N'TP018', N'LTP01', N'BCAA pro', 1.3, N'Cacao                         ', 76, 150000, 12)
GO
ALTER TABLE [dbo].[HOADONTHANHTOAN]  WITH CHECK ADD  CONSTRAINT [FK_HOADONTHANHTOAN_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[HOADONTHANHTOAN] CHECK CONSTRAINT [FK_HOADONTHANHTOAN_KHACHHANG]
GO
ALTER TABLE [dbo].[HOADONTHANHTOAN]  WITH CHECK ADD  CONSTRAINT [FK_HOADONTHANHTOAN_LOAITPBS] FOREIGN KEY([MaLoaiTP])
REFERENCES [dbo].[LOAITPBS] ([MaLoaiTP])
GO
ALTER TABLE [dbo].[HOADONTHANHTOAN] CHECK CONSTRAINT [FK_HOADONTHANHTOAN_LOAITPBS]
GO
ALTER TABLE [dbo].[HOADONTHANHTOAN]  WITH CHECK ADD  CONSTRAINT [FK_HOADONTHANHTOAN_NHANVIENLETAN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIENLETAN] ([MaNV])
GO
ALTER TABLE [dbo].[HOADONTHANHTOAN] CHECK CONSTRAINT [FK_HOADONTHANHTOAN_NHANVIENLETAN]
GO
ALTER TABLE [dbo].[HOADONTHANHTOAN]  WITH CHECK ADD  CONSTRAINT [FK_HOADONTHANHTOAN_THUCPHAMBOSUNG] FOREIGN KEY([MaTP])
REFERENCES [dbo].[THUCPHAMBOSUNG] ([MaTP])
GO
ALTER TABLE [dbo].[HOADONTHANHTOAN] CHECK CONSTRAINT [FK_HOADONTHANHTOAN_THUCPHAMBOSUNG]
GO
ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_LOP_LOAILOP] FOREIGN KEY([MaLoaiLOP])
REFERENCES [dbo].[LOAILOP] ([MaLoaiLOP])
GO
ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_LOP_LOAILOP]
GO
ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_LOP_PERSONALTRAINER] FOREIGN KEY([MaPT])
REFERENCES [dbo].[PERSONALTRAINER] ([MaPT])
GO
ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_LOP_PERSONALTRAINER]
GO
ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_LOP_THANHVIEN] FOREIGN KEY([MaTV])
REFERENCES [dbo].[THANHVIEN] ([MaTV])
GO
ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_LOP_THANHVIEN]
GO
ALTER TABLE [dbo].[NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_NHAPHANG_LOAITPBS] FOREIGN KEY([LoaiTP])
REFERENCES [dbo].[LOAITPBS] ([MaLoaiTP])
GO
ALTER TABLE [dbo].[NHAPHANG] CHECK CONSTRAINT [FK_NHAPHANG_LOAITPBS]
GO
ALTER TABLE [dbo].[NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_NHAPHANG_NHACUNGCAP] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NHACUNGCAP] ([MaNCC])
GO
ALTER TABLE [dbo].[NHAPHANG] CHECK CONSTRAINT [FK_NHAPHANG_NHACUNGCAP]
GO
ALTER TABLE [dbo].[NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_NHAPHANG_THUCPHAMBOSUNG] FOREIGN KEY([MaTP])
REFERENCES [dbo].[THUCPHAMBOSUNG] ([MaTP])
GO
ALTER TABLE [dbo].[NHAPHANG] CHECK CONSTRAINT [FK_NHAPHANG_THUCPHAMBOSUNG]
GO
ALTER TABLE [dbo].[THUCPHAMBOSUNG]  WITH CHECK ADD  CONSTRAINT [FK_THUCPHAMBOSUNG_LOAITPBS] FOREIGN KEY([MaLoaiTP])
REFERENCES [dbo].[LOAITPBS] ([MaLoaiTP])
GO
ALTER TABLE [dbo].[THUCPHAMBOSUNG] CHECK CONSTRAINT [FK_THUCPHAMBOSUNG_LOAITPBS]
GO
/****** Object:  StoredProcedure [dbo].[spSuaChiTieu]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaChiTieu]
@MaCT NCHAR(4),
@Mucdich nvarchar(50),
@SoTien int,
@Thoigian datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        UPDATE CHITIEU
        SET MaCT = @MaCT,
			MucDich =@Mucdich,
			Tien =@SoTien,
			ThoiGianChiTra =@Thoigian
        WHERE MaCT = @MaCT
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
		DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spSuaHoaDon]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaHoaDon]
@MaHD NCHAR(5),
@MaNV Nchar(4),
@MaTP nchar(5),
@MaloaiTP nchar(5),
@MaKH nCHAR(5),
@SoLuong int,
@SoTien INT,
@Ghichu nvarchar(max),
@Thoigian datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        UPDATE HOADONTHANHTOAN
        SET MaHD=@MaHD ,
			MaNV=@MaNV ,
			MaTP=@MaTP ,
			MaLoaiTP=@MaloaiTP ,
			MaKH=@MaKH ,
			SoLuong=@SoLuong ,
			TongTien=@SoTien ,
			GhiChu=@Ghichu,
			ThoiGianThanhToan=@Thoigian 
        WHERE MaHD = @MaHD;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
		DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spSuaKhachHang]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaKhachHang]
@MaKH Nvarchar(5),
@TenKH Nvarchar(max),
@Gioitinh nvarchar (10),
@SoDT int,
@Email VarChar(max),
@DiaChi NVARCHAR(max)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        -- Update the customer record
        UPDATE KHACHHANG
        SET MaKH = @MaKH,
            TenKH = @TenKH,
			GIOITINH =@Gioitinh,
			EMAIL = @Email,
            SDT = @SoDT,
            DiaChi = @DiaChi           
        WHERE MaKH = @MaKH;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
		DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spSuaLoaiLop]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaLoaiLop]
(
     @Maloai NVARCHAR(4),
     @tenloai NVARCHAR(max)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; 
        IF NOT EXISTS (SELECT * FROM LOAILOP WHERE MaLoaiLOP =  @Maloai)
        BEGIN
            RAISERROR('Lớp này không tồn tại ', 16, 1);
        END
        ELSE
        BEGIN
            -- Thực hiện cập nhật dữ liệu trong bảng MAY
            UPDATE LOAILOP
            SET MaLoaiLOP =  @Maloai,LoaiLOP = @tenloai
            WHERE MaLoaiLOP =  @Maloai;
        END

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN;

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spSuaLoaiTPBS]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaLoaiTPBS]
(
     @Maloai NVARCHAR(5),
     @tenloai NVARCHAR(50)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; 
        IF NOT EXISTS (SELECT * FROM LOAITPBS WHERE MaLoaiTP =  @Maloai)
        BEGIN
            RAISERROR('Loại dịch vụ này không tồn tại ', 16, 1);
        END
        ELSE
        BEGIN
            -- Thực hiện cập nhật dữ liệu trong bảng MAY
            UPDATE LOAITPBS
            SET MaLoaiTP =  @Maloai,TenLoaiTP = @tenloai
            WHERE MaLoaiTP =  @Maloai;
        END

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN;

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spSuaLop]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaLop]
(
    
    @Malop NVARCHAR(5),
	@Maloai NVARCHAR(4),
    @Mapt NVARCHAR(4),
	@Matv  NVARCHAR(5),
	@ngaybatdau datetime,
	@ngayketthuc datetime,
	@ghichu NVARCHAR(max),
	@chiphi int
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; 
        IF NOT EXISTS (SELECT * FROM LOP WHERE MaLOP =  @Malop)
        BEGIN
            RAISERROR('Lớp này không tồn tại ', 16, 1);
        END
		IF NOT EXISTS (SELECT * FROM LOP WHERE MaLoaiLOP =  @Maloai)
        BEGIN
            RAISERROR('Loại lớp này không tồn tại ', 16, 1);
        END
		IF NOT EXISTS (SELECT * FROM LOP WHERE MaLoaiLOP =  @Maloai)
        BEGIN
            RAISERROR('Loại lớp này không tồn tại ', 16, 1);
        END		
        ELSE
        BEGIN
            -- Thực hiện cập nhật dữ liệu trong bảng MAY
            UPDATE LOP
            SET MaLOP=@Malop , MaLoaiLOP=@Maloai , MaPT=@Mapt , MaTV=@Matv,
				NGAYBATDAU=@ngaybatdau,NGAYKETTHUC=@ngayketthuc,GHICHU=@ghichu,ChiPhi=@chiphi
			WHERE MaLOP = @Malop
        END

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN;

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spSuaNCC]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaNCC]
@MaNCC Nchar(5),
@TenNCC Nvarchar(50),
@DiaChi NVARCHAR(max),
@Email NVarChar(max),
@SoDT int
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        -- Update the customer record
        UPDATE NHACUNGCAP
        SET MaNCC = @MaNCC,
            TenNCC = @TenNCC,
			DiaChi = @DiaChi,   
			Email = @Email,
            SDT = @SoDT      
        WHERE MaNCC = @MaNCC;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
		DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spSuaNhapHang]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaNhapHang]
@MaNH NCHAR(5),
@MaNCC Nchar(5),
@MaTP nchar(5),
@MaloaiTP nchar(5),
@SoLuong int,
@SoTien INT,
@Thoigian datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        UPDATE NHAPHANG
        SET MaNH=@MaNH ,
			MaNCC=@MaNCC ,
			MaTP=@MaTP ,
			LoaiTP=@MaloaiTP ,
			SoLuong=@SoLuong ,
			TongTien=@SoTien ,
			NgayNhap=@Thoigian 
        WHERE MaNH = @MaNH;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
		DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spSuaNV]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaNV]
@MaNV Nvarchar(4),
@TenNV Nvarchar(max),
@Gioitinh nvarchar (10),
@SoDT int,
@Email VarChar(50),
@Luong int
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        UPDATE NHANVIENLETAN
        SET MaNV = @MaNV,
            TenNV = @TenNV,
			GIOITINH =@Gioitinh,
			EMAIL = @Email,
            SDT = @SoDT,
            LUONG = @Luong
        WHERE MaNV = @MaNV;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
		DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spSuaPT]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaPT]
@MaPT Nvarchar(4),
@TenPT Nvarchar(max),
@Gioitinh nvarchar (10),
@SoDT int,
@Email VarChar(max),
@Luong int,
@TienHoahong int 
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        UPDATE PERSONALTRAINER
        SET MaPT = @MaPT,
            TenPT = @TenPT,
			GIOITINH =@Gioitinh,
			EMAIL = @Email,
            SDT = @SoDT,
            LUONG = @Luong,
			HOAHONG = @TienHoahong
        WHERE MaPT = @MaPT;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
		DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spSuaThanhVien]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSuaThanhVien]
@MaTV Nvarchar(5),
@TenTV Nvarchar(max),
@Gioitinh nvarchar (10),
@SoDT int,
@Email VarChar(max),
@NgayBD datetime ,
@NgayKT datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        -- Update the customer record
        UPDATE THANHVIEN
        SET MaTV= @MaTV ,
			TenTV = @TenTV,
			GIOITINH =@Gioitinh ,
			SDT=@SoDT ,
			EMAIL = @Email ,
			NGAYBATDAU=@NgayBD ,
			NGAYKETTHUC=@NgayKT         
        WHERE MaTV = @MaTV;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
		DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spSuaTPBS]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSuaTPBS]
(    
    @Matp NVARCHAR(5),
	@Maloai NVARCHAR(5),
    @tentp NVARCHAR(max),
	@khoiluong real,
	@huongvi NVARCHAR(50),
	@solandung int,
	@giatien int,
	@soluong int
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;        
            -- Thực hiện cập nhật dữ liệu trong bảng MAY
            UPDATE THUCPHAMBOSUNG
            SET MaTP=@Matp, MaLoaiTP =  @Maloai,TenTP = @tentp, KhoiLuong=@khoiluong, HuongVi = @huongvi , SoLanDung=@solandung , GiaTien = @giatien , SoLuong = @soluong
            WHERE MaTP =  @Matp ;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
		DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spThemChiTieu]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spThemChiTieu]
@MaCT NCHAR(4),
@Mucdich nvarchar(50),
@SoTien int,
@Thoigian datetime
AS
BEGIN
    BEGIN TRY
        -- Start the transaction
        BEGIN TRAN;

        -- Perform the insert operation
        INSERT INTO CHITIEU(MaCT,MucDich,Tien,ThoiGianChiTra) values (@MaCT,@Mucdich,@SoTien,@Thoigian );

        -- Commit the transaction
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        -- If there's any error, rollback the transaction
        ROLLBACK TRAN;

        -- Raise an error with custom message
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemHoaDon]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemHoaDon]
(@MaHD NCHAR(5),
@MaNV Nchar(4),
@MaTP nchar(5),
@MaloaiTP nchar(5),
@MaKH nCHAR(5),
@SoLuong int,
@SoTien INT,
@Ghichu nvarchar(max),
@Thoigian datetime)
AS
BEGIN
    BEGIN TRY
        -- Start the transaction
        BEGIN TRAN;

        -- Perform the insert operation
        INSERT INTO HOADONTHANHTOAN (MaHD,MaNV,MaTP,MaLoaiTP,MaKH,SoLuong,TongTien,GhiChu,ThoiGianThanhToan) values (@MaHD, @MaNV ,@MaTP ,@MaloaiTP ,@MaKH ,@SoLuong ,@SoTien ,@Ghichu,@Thoigian );

        -- Commit the transaction
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        -- If there's any error, rollback the transaction
        ROLLBACK TRAN;

        -- Raise an error with custom message
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemKhachHang]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemKhachHang]
@MaKH Nvarchar(5),
@TenKH Nvarchar(max),
@Gioitinh nvarchar (10),
@SoDT int,
@Email VarChar(max),
@DiaChi NVARCHAR(max)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        INSERT INTO KHACHHANG(MaKH,TenKH,GIOITINH,SDT,EMAIL,DIACHI)
        VALUES (@MaKH,@TenKH,@Gioitinh, @SoDT, @Email, @DiaChi);
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemLoaiLop]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemLoaiLop]
(
   
    @Maloai NVARCHAR(4),
    @tenloai NVARCHAR(max)
    
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; -- Bắt đầu transaction

        -- Thực hiện chèn dữ liệu vào bảng DICHVU
        INSERT INTO LOAILOP (MaLoaiLOP,LoaiLOP)
        VALUES ( @Maloai,@tenloai);

        COMMIT TRAN; -- Hoàn tất transaction
    END TRY
    BEGIN CATCH
        -- Nếu xảy ra lỗi, rollback transaction và phát sinh thông báo lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN; -- Rollback transaction nếu đang trong transaction

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spThemLoaiTPBS]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemLoaiTPBS]
(
   
    @Maloai NVARCHAR(5),
    @tenloai NVARCHAR(50)
    
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; -- Bắt đầu transaction

        -- Thực hiện chèn dữ liệu vào bảng DICHVU
        INSERT INTO LOAITPBS (MaLoaiTP,TenLoaiTP)
        VALUES ( @Maloai,@tenloai);

        COMMIT TRAN; -- Hoàn tất transaction
    END TRY
    BEGIN CATCH
        -- Nếu xảy ra lỗi, rollback transaction và phát sinh thông báo lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN; -- Rollback transaction nếu đang trong transaction

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spThemLop]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemLop]
(
    @Malop NVARCHAR(5),
	@Maloai NVARCHAR(4),
    @Mapt NVARCHAR(4),
	@Matv  NVARCHAR(5),
	@ngaybatdau datetime,
	@ngayketthuc datetime,
	@ghichu NVARCHAR(max),
	@chiphi int
  
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; -- Bắt đầu transaction

        -- Thực hiện chèn dữ liệu vào bảng DICHVU
        INSERT INTO LOP(MaLOP,MaLoaiLOP,MaPT,MaTV,NGAYBATDAU,NGAYKETTHUC,GHICHU,ChiPhi)
        VALUES (  @Malop ,
				@Maloai ,
				@Mapt ,
				@Matv  ,
				@ngaybatdau ,
				@ngayketthuc ,
				@ghichu ,
				@chiphi  );

        COMMIT TRAN; -- Hoàn tất transaction
    END TRY
    BEGIN CATCH
        -- Nếu xảy ra lỗi, rollback transaction và phát sinh thông báo lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN; -- Rollback transaction nếu đang trong transaction

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spThemNCC]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemNCC]
@MaNCC Nvarchar(5),
@TenNCC Nvarchar(50),
@DiaChi NVARCHAR(max),
@Email NVarChar(max),
@SoDT int
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        INSERT INTO NHACUNGCAP(MaNCC,TenNCC,DIACHI,EMAIL,SDT)
        VALUES (@MaNCC,@TenNCC,  @DiaChi, @Email,@SoDT);
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemNhapHang]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemNhapHang]
@MaNH NCHAR(5),
@MaNCC Nchar(5),
@MaTP nchar(5),
@MaloaiTP nchar(5),
@SoLuong int,
@SoTien INT,
@Thoigian datetime
AS
BEGIN
    BEGIN TRY
        -- Start the transaction
        BEGIN TRAN;

        -- Perform the insert operation
        INSERT INTO NHAPHANG(MaNH,MaNCC,MaTP,LoaiTP,SoLuong,TongTien,NgayNhap) values (@MaNH,@MaNCC, @MaTP ,@MaloaiTP ,@SoLuong ,@SoTien, @Thoigian );

        -- Commit the transaction
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        -- If there's any error, rollback the transaction
        ROLLBACK TRAN;

        -- Raise an error with custom message
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemNV]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spThemNV]
@MaNV Nvarchar(4),
@TenNV Nvarchar(max),
@Gioitinh nvarchar (10),
@SoDT int,
@Email VarChar(50),
@Luong int
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        INSERT INTO NHANVIENLETAN(MaNV,TenNV,GIOITINH,SDT,EMAIL,LUONG)
        VALUES (@MaNV,@TenNV,@Gioitinh, @SoDT, @Email,@Luong);
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemPT]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemPT]
@MaPT Nvarchar(4),
@TenPT Nvarchar(max),
@Gioitinh nvarchar (10),
@SoDT int,
@Email VarChar(max),
@Luong int,
@TienHoahong int 
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        INSERT INTO PERSONALTRAINER(MaPT,TenPT,GIOITINH,SDT,EMAIL,LUONG,HOAHONG)
        VALUES (@MaPT,@TenPT,@Gioitinh, @SoDT, @Email,@Luong,@TienHoahong);
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemThanhVien]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemThanhVien]
@MaTV Nvarchar(5),
@TenTV Nvarchar(max),
@Gioitinh nvarchar (10),
@SoDT int,
@Email VarChar(max),
@NgayBD datetime ,
@NgayKT datetime
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        INSERT INTO THANHVIEN(MaTV,TenTV,GIOITINH,SDT,EMAIL,NGAYBATDAU,NGAYKETTHUC)
        VALUES (@MaTV ,
				@TenTV ,
				@Gioitinh ,
				@SoDT ,
				@Email ,
				@NgayBD ,
				@NgayKT );
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spThemTPBS]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spThemTPBS]
(
   
    @Matp NVARCHAR(5),
	@Maloai NVARCHAR(5),
    @tentp NVARCHAR(max),
	@khoiluong real,
	@huongvi NVARCHAR(50),
	@solandung int,
	@giatien int,
	@soluong int
    
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; -- Bắt đầu transaction

        -- Thực hiện chèn dữ liệu vào bảng DICHVU
        INSERT INTO THUCPHAMBOSUNG(MaTP,MaLoaiTP,TenTP,KhoiLuong,HuongVi,SoLanDung,GiaTien,SoLuong)
        VALUES ( @Matp,@Maloai,@tentp,@khoiluong ,
				@huongvi ,
				@solandung ,
				@giatien ,
				@soluong );

        COMMIT TRAN; -- Hoàn tất transaction
    END TRY
    BEGIN CATCH
        -- Nếu xảy ra lỗi, rollback transaction và phát sinh thông báo lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN; -- Rollback transaction nếu đang trong transaction

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaChiTieu]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaChiTieu]
@MaCT NCHAR(4)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        DELETE FROM CHITIEU WHERE MaCT = @MaCT;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaHoaDon]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaHoaDon]
@MaHD NCHAR(5)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        DELETE FROM HOADONTHANHTOAN WHERE MaHD = @MaHD;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaKhachHang]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaKhachHang]
@MaKH NCHAR(5)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        DELETE FROM KHACHHANG WHERE MaKH = @MaKH;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaLoaiLop]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaLoaiLop]
(
    @Ma_LOAI NVARCHAR(4)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; -- Bắt đầu transaction
        -- Thực hiện xóa dữ liệu trong bảng DICHVU
        DELETE FROM LOAILOP WHERE MaLoaiLOP = @Ma_LOAI;
        COMMIT TRAN; -- Hoàn tất transaction
    END TRY
    BEGIN CATCH
        -- Nếu xảy ra lỗi, rollback transaction và phát sinh thông báo lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN; -- Rollback transaction nếu đang trong transaction

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaLoaiTPBS]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaLoaiTPBS]
(
    @Ma_LOAI NVARCHAR(5)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; -- Bắt đầu transaction
        -- Thực hiện xóa dữ liệu trong bảng DICHVU
        DELETE FROM LOAITPBS WHERE MaLoaiTP = @Ma_LOAI;
        COMMIT TRAN; -- Hoàn tất transaction
    END TRY
    BEGIN CATCH
        -- Nếu xảy ra lỗi, rollback transaction và phát sinh thông báo lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN; -- Rollback transaction nếu đang trong transaction

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaLop]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaLop]
(
    @Malop NVARCHAR(5)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; -- Bắt đầu transaction
        -- Thực hiện xóa dữ liệu trong bảng DICHVU
        DELETE FROM LOP WHERE MaLOP = @Malop;
        COMMIT TRAN; -- Hoàn tất transaction
    END TRY
    BEGIN CATCH
        -- Nếu xảy ra lỗi, rollback transaction và phát sinh thông báo lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN; -- Rollback transaction nếu đang trong transaction

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaNCC]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaNCC]
@MaNCC NCHAR(5)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        DELETE FROM NHACUNGCAP WHERE MaNCC = @MaNCC;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaNhapHang]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaNhapHang]
@MaNH NCHAR(5)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        DELETE FROM NHAPHANG WHERE MaNH = @MaNH;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaNV]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaNV]
@MaNV NCHAR(4)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        DELETE FROM NHANVIENLETAN WHERE MaNV = @MaNV;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaPT]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaPT]
@MaPT NCHAR(4)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        DELETE FROM PERSONALTRAINER WHERE MaPT = @MaPT;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaThanhVien]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaThanhVien]
@MaTV NCHAR(5)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN;
        DELETE FROM THANHVIEN WHERE MaTV = @MaTV;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[spXoaTPBS]    Script Date: 04/06/2023 6:56:47 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaTPBS]
(
    @Matp NVARCHAR(5)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRAN; -- Bắt đầu transaction
        -- Thực hiện xóa dữ liệu trong bảng DICHVU
        DELETE FROM THUCPHAMBOSUNG WHERE MaTP = @Matp;
        COMMIT TRAN; -- Hoàn tất transaction
    END TRY
    BEGIN CATCH
        -- Nếu xảy ra lỗi, rollback transaction và phát sinh thông báo lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN; -- Rollback transaction nếu đang trong transaction

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState); -- Phát sinh thông báo lỗi
    END CATCH;
END
GO
USE [master]
GO
ALTER DATABASE [GYMCLUB] SET  READ_WRITE 
GO
