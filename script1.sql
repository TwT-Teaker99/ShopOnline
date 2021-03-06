USE [master]
GO
/****** Object:  Database [HTBanThuoc1]    Script Date: 12/2/2020 7:27:51 PM ******/
CREATE DATABASE [HTBanThuoc1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HTBanThuoc1', FILENAME = N'D:\HTBanThuoc1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HTBanThuoc1_log', FILENAME = N'D:\HTBanThuoc1_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HTBanThuoc1] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HTBanThuoc1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HTBanThuoc1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET ARITHABORT OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HTBanThuoc1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HTBanThuoc1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HTBanThuoc1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HTBanThuoc1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HTBanThuoc1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HTBanThuoc1] SET  MULTI_USER 
GO
ALTER DATABASE [HTBanThuoc1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HTBanThuoc1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HTBanThuoc1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HTBanThuoc1] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HTBanThuoc1] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HTBanThuoc1]
GO
/****** Object:  Table [dbo].[CHITIETDONHANG]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETDONHANG](
	[MaDH] [int] NOT NULL,
	[MaThuoc] [nchar](15) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK__CHITIETD__339E9903C8239439] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DANHMUC]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANHMUC](
	[MaDM] [int] NOT NULL,
	[TenDM] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DIACHI]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIACHI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DiaChi] [nvarchar](max) NULL,
	[KhachHangID] [int] NULL,
 CONSTRAINT [PK_DIACHI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONHANG](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [date] NULL,
	[MaKH] [int] NULL,
	[Diachi] [nvarchar](max) NULL,
	[TongTien] [int] NULL,
	[GhiChu] [nvarchar](max) NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK__DONHANG__27258661B47DE07B] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[SDT] [char](11) NULL,
	[Ten] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ROLES]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLES](
	[IDRole] [int] NOT NULL,
	[RoleName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TAIKHOANQUANTRI]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOANQUANTRI](
	[UserName] [nchar](30) NOT NULL,
	[PassWord] [nchar](50) NULL,
	[HoTen] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[THUOC]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUOC](
	[MaThuoc] [nchar](15) NOT NULL,
	[TenThuoc] [nvarchar](50) NULL,
	[ThanhPhan] [nvarchar](50) NULL,
	[CongDung] [nvarchar](50) NULL,
	[LieuLuong] [nvarchar](max) NULL,
	[SoLuongTon] [int] NULL,
	[DonGia] [int] NULL,
	[MaDanhMuc] [int] NULL,
	[DonVi] [nvarchar](50) NOT NULL,
	[DangThuoc] [nvarchar](50) NOT NULL,
	[URLAnh] [nchar](50) NULL,
 CONSTRAINT [PK_THUOC] PRIMARY KEY CLUSTERED 
(
	[MaThuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USERinROLES]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERinROLES](
	[IDRole] [int] NOT NULL,
	[UserName] [nchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDRole] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[CTDonHang]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTDonHang]
AS SELECT DH.MaDH, CH.MaThuoc, T.TenThuoc, CH.SoLuong, CH.DonGia FROM dbo.CHITIETDONHANG CH, dbo.DONHANG DH, dbo.THUOC T
WHERE CH.MaDH = DH.MaDH AND CH.MaThuoc=T.MaThuoc


GO
/****** Object:  View [dbo].[View_1]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT    dbo.THUOC.*
FROM         dbo.THUOC





GO
INSERT [dbo].[CHITIETDONHANG] ([MaDH], [MaThuoc], [SoLuong], [DonGia]) VALUES (1, N'ABC            ', 2, 20000)
INSERT [dbo].[CHITIETDONHANG] ([MaDH], [MaThuoc], [SoLuong], [DonGia]) VALUES (1, N'PCTM           ', 1, 20000)
INSERT [dbo].[CHITIETDONHANG] ([MaDH], [MaThuoc], [SoLuong], [DonGia]) VALUES (2, N'ACM1           ', 3, 50000)
INSERT [dbo].[CHITIETDONHANG] ([MaDH], [MaThuoc], [SoLuong], [DonGia]) VALUES (3, N'CSR            ', 4, 25000)
INSERT [dbo].[CHITIETDONHANG] ([MaDH], [MaThuoc], [SoLuong], [DonGia]) VALUES (5, N'CSR            ', 2, 25000)
INSERT [dbo].[CHITIETDONHANG] ([MaDH], [MaThuoc], [SoLuong], [DonGia]) VALUES (8, N'CSR            ', 1, 25000)
INSERT [dbo].[CHITIETDONHANG] ([MaDH], [MaThuoc], [SoLuong], [DonGia]) VALUES (10, N'ABC            ', 1, 20000)
INSERT [dbo].[DANHMUC] ([MaDM], [TenDM]) VALUES (1, N'Thuốc tây y')
INSERT [dbo].[DANHMUC] ([MaDM], [TenDM]) VALUES (2, N'Thuốc đông y')
INSERT [dbo].[DANHMUC] ([MaDM], [TenDM]) VALUES (3, N'Sản phẩm thiên nhiên')
SET IDENTITY_INSERT [dbo].[DIACHI] ON 

INSERT [dbo].[DIACHI] ([ID], [DiaChi], [KhachHangID]) VALUES (1, N'12 Mỹ Đình, Nam Từ Liêm, Hà Nội', 1)
INSERT [dbo].[DIACHI] ([ID], [DiaChi], [KhachHangID]) VALUES (2, N'123 Nguyễn Hoàng, Nam Từ Liêm, Hà Nội', 2)
INSERT [dbo].[DIACHI] ([ID], [DiaChi], [KhachHangID]) VALUES (3, N'64 Hoàng Quốc Việt, Bắc Từ Liêm, Hà Nội', 3)
SET IDENTITY_INSERT [dbo].[DIACHI] OFF
SET IDENTITY_INSERT [dbo].[DONHANG] ON 

INSERT [dbo].[DONHANG] ([MaDH], [NgayLap], [MaKH], [Diachi], [TongTien], [GhiChu], [TinhTrang]) VALUES (1, CAST(N'2020-05-06' AS Date), 1, N'514 Trần Cung', 60000, N'Giao hàng buổi trưa', N'Đang Giao Hàng')
INSERT [dbo].[DONHANG] ([MaDH], [NgayLap], [MaKH], [Diachi], [TongTien], [GhiChu], [TinhTrang]) VALUES (2, CAST(N'2020-05-27' AS Date), 2, N'213 Mỹ Đình', 150000, N'Nhận hàng tại bưu cục', N'Hoàn Thành')
INSERT [dbo].[DONHANG] ([MaDH], [NgayLap], [MaKH], [Diachi], [TongTien], [GhiChu], [TinhTrang]) VALUES (3, CAST(N'2020-05-28' AS Date), 3, N'457 Cầu Giấy', 100000, N'Liên hệ trước 30 phút', N'Hủy')
INSERT [dbo].[DONHANG] ([MaDH], [NgayLap], [MaKH], [Diachi], [TongTien], [GhiChu], [TinhTrang]) VALUES (5, CAST(N'2020-06-09' AS Date), 3, N'123', 50000, N'1', N'Hoàn Thành')
INSERT [dbo].[DONHANG] ([MaDH], [NgayLap], [MaKH], [Diachi], [TongTien], [GhiChu], [TinhTrang]) VALUES (8, CAST(N'2020-06-09' AS Date), 1, N'3116  Doctors Drive', 25000, N'Khu 2, Thị trấn Tam Nông, Phú Thọ', N'Đang Giao Hàng')
INSERT [dbo].[DONHANG] ([MaDH], [NgayLap], [MaKH], [Diachi], [TongTien], [GhiChu], [TinhTrang]) VALUES (10, CAST(N'2020-06-11' AS Date), 2, N'3116  Doctors Drive', 20000, N'1', N'Huỷ')
SET IDENTITY_INSERT [dbo].[DONHANG] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([SDT], [Ten], [Email], [MatKhau], [MaKH]) VALUES (N'0988974425 ', N'Nguyễn Văn An', N'anvan@gmail.com', N'123', 1)
INSERT [dbo].[KHACHHANG] ([SDT], [Ten], [Email], [MatKhau], [MaKH]) VALUES (N'0875441123 ', N'Trần Bình Minh', N'Binhtran123@gmail.com', N'123', 2)
INSERT [dbo].[KHACHHANG] ([SDT], [Ten], [Email], [MatKhau], [MaKH]) VALUES (N'0374822156 ', N'Lê Cao Cường', N'cuongle99@gmail.com', N'123', 3)
INSERT [dbo].[KHACHHANG] ([SDT], [Ten], [Email], [MatKhau], [MaKH]) VALUES (N'0975514895 ', N'Nguyễn Minh Hải', N'minhhaiat@gmail.com', N'12345', 4)
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
INSERT [dbo].[ROLES] ([IDRole], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[ROLES] ([IDRole], [RoleName]) VALUES (2, N'Member')
INSERT [dbo].[TAIKHOANQUANTRI] ([UserName], [PassWord], [HoTen]) VALUES (N'dongvanhung                   ', N'123                                               ', N'Dong Van Hung')
INSERT [dbo].[TAIKHOANQUANTRI] ([UserName], [PassWord], [HoTen]) VALUES (N'lotrunghieu                   ', N'123                                               ', N'Lỗ Trung Hiếu')
INSERT [dbo].[TAIKHOANQUANTRI] ([UserName], [PassWord], [HoTen]) VALUES (N'nguyenvandung                 ', N'123                                               ', N'Nguyen Van Dung')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [ThanhPhan], [CongDung], [LieuLuong], [SoLuongTon], [DonGia], [MaDanhMuc], [DonVi], [DangThuoc], [URLAnh]) VALUES (N'12             ', N'Dầu Gan Cá Hồi A', N'Tinh dầu gan cá hồi', N'Bổ sung Vitamin A,B', N'30ml/lần, 2 lần/ ngày', 10, 120000, 3, N'Chai', N'Tinh dầu', N'SP2_DauCa.jpg                                     ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [ThanhPhan], [CongDung], [LieuLuong], [SoLuongTon], [DonGia], [MaDanhMuc], [DonVi], [DangThuoc], [URLAnh]) VALUES (N'ABC            ', N'Abicin 250', N'Amikacin', N'Tác dụng kháng sinh', N'Người lớn 2v/1 lần, ngày 2 lần; Trẻ em 1v/lần, ngày 2 lần', 1497, 20000, 1, N'viên', N'Viên', N'SP1_Gung.jpg                                      ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [ThanhPhan], [CongDung], [LieuLuong], [SoLuongTon], [DonGia], [MaDanhMuc], [DonVi], [DangThuoc], [URLAnh]) VALUES (N'ACM1           ', N'Gừng nướng mật ong', N'Gừng, mật ong', N'Dùng trong bệnh tim', N'2 gói/ ngày', 200, 50000, 3, N'Hộp(15 gói)', N'gói bột', N'SP1_Gung.jpg                                      ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [ThanhPhan], [CongDung], [LieuLuong], [SoLuongTon], [DonGia], [MaDanhMuc], [DonVi], [DangThuoc], [URLAnh]) VALUES (N'CSR            ', N'Casoran', N'Cao hoa hòe, Cao dừa cạn, Cao tâm sen, Cao cúc hoa', N'Thuốc hạ huyết áp', N'2v/ lần', 1200, 25000, 2, N'viên', N'Viên nén', N'SP1_Gung.jpg                                      ')
INSERT [dbo].[THUOC] ([MaThuoc], [TenThuoc], [ThanhPhan], [CongDung], [LieuLuong], [SoLuongTon], [DonGia], [MaDanhMuc], [DonVi], [DangThuoc], [URLAnh]) VALUES (N'PCTM           ', N'PARACETAMOL 500 mg', N'Paracetamol', N'Hạ sốt', N'Người lớn 2v/1 lần, ngày 2 lần; Trẻ em 1v/lần, ngày 2 lần', 1397, 20000, 1, N'Viên', N'Viên', N'SP1_Gung.jpg                                      ')
INSERT [dbo].[USERinROLES] ([IDRole], [UserName]) VALUES (1, N'dongvanhung                   ')
INSERT [dbo].[USERinROLES] ([IDRole], [UserName]) VALUES (2, N'lotrunghieu                   ')
INSERT [dbo].[USERinROLES] ([IDRole], [UserName]) VALUES (2, N'nguyenvandung                 ')
ALTER TABLE [dbo].[CHITIETDONHANG]  WITH CHECK ADD  CONSTRAINT [FK__CHITIETDON__MaDH__398D8EEE] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DONHANG] ([MaDH])
GO
ALTER TABLE [dbo].[CHITIETDONHANG] CHECK CONSTRAINT [FK__CHITIETDON__MaDH__398D8EEE]
GO
ALTER TABLE [dbo].[CHITIETDONHANG]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETDONHANG_THUOC] FOREIGN KEY([MaThuoc])
REFERENCES [dbo].[THUOC] ([MaThuoc])
GO
ALTER TABLE [dbo].[CHITIETDONHANG] CHECK CONSTRAINT [FK_CHITIETDONHANG_THUOC]
GO
ALTER TABLE [dbo].[DIACHI]  WITH CHECK ADD  CONSTRAINT [FK_DIACHI_KHACHHANG] FOREIGN KEY([KhachHangID])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[DIACHI] CHECK CONSTRAINT [FK_DIACHI_KHACHHANG]
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DONHANG_KHACHHANG]
GO
ALTER TABLE [dbo].[THUOC]  WITH CHECK ADD  CONSTRAINT [FK__THUOC__MaDM__1273C1CD] FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DANHMUC] ([MaDM])
GO
ALTER TABLE [dbo].[THUOC] CHECK CONSTRAINT [FK__THUOC__MaDM__1273C1CD]
GO
ALTER TABLE [dbo].[USERinROLES]  WITH CHECK ADD FOREIGN KEY([IDRole])
REFERENCES [dbo].[ROLES] ([IDRole])
GO
ALTER TABLE [dbo].[USERinROLES]  WITH CHECK ADD FOREIGN KEY([UserName])
REFERENCES [dbo].[TAIKHOANQUANTRI] ([UserName])
GO
/****** Object:  Trigger [dbo].[updateDH]    Script Date: 12/2/2020 7:27:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[updateDH] ON [dbo].[CHITIETDONHANG]
FOR INSERT,UpDate
AS BEGIN
UPDATE dbo.DONHANG
SET TongTien=(SELECT SUM(DonGia*SoLuong)FROM dbo.CHITIETDONHANG WHERE MaDH=dbo.DONHANG.MaDH)
WHERE MaDH IN (SELECT MaDH FROM inserted)
end

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "THUOC"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
USE [master]
GO
ALTER DATABASE [HTBanThuoc1] SET  READ_WRITE 
GO
