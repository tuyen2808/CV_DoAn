USE [QL_BanHoa]
GO
select * from CHUNGLOAI
/****** Object:  Table [dbo].[ADMIN]    Script Date: 11/17/2019 2:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMIN](
	[USENAME] [nchar](10) NOT NULL,
	[PASS] [nchar](10) NOT NULL,
 CONSTRAINT [PK_AD] PRIMARY KEY CLUSTERED 
(
	[USENAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHUNGLOAI]    Script Date: 11/17/2019 2:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUNGLOAI](
	[MaCL] [int] NOT NULL,
	[TenCL] [nvarchar](100) NOT NULL,
	[MaTL] [int] NOT NULL,
	[AnhBia] [nvarchar](max) NULL,
	[DienGia] [nvarchar](1000) NULL,
	[GiaBan] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChungLoai] PRIMARY KEY CLUSTERED 
(
	[MaCL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CT_HOADON]    Script Date: 11/17/2019 2:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_HOADON](
	[SoCT] [int] IDENTITY(1,1) NOT NULL,
	[SoHD] [int] NULL,
	[MaCL] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK_CTHoaDon] PRIMARY KEY CLUSTERED 
(
	[SoCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 11/17/2019 2:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[SoHD] [int] IDENTITY(1,1) NOT NULL,
	[NgaLap_HD] [date] NOT NULL,
	[MaKH] [int] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[SoHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 11/17/2019 2:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](80) NULL,
	[TenKH] [nvarchar](80) NULL,
	[MatKhau] [nvarchar](80) NULL,
	[MST] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[GioiTinh] [nchar](5) NULL,
	[SDT] [nchar](10) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[THELOAI]    Script Date: 11/17/2019 2:52:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAI](
	[MaTL] [int] NOT NULL,
	[TenTL] [nvarchar](50) NULL,
	[DienGia] [nvarchar](50) NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ADMIN] ([USENAME], [PASS]) VALUES (N'admin     ', N'123456    ')
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (1, N'Mây Tím', 6, N'hoasalem.jpg', N'Một bó hoa salem mang màu tím nhẹ nhàng', CAST(75000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (2, N'Tinh Khiết (Thạch Thảo Trắng)', 6, N'thachthaotrang.jpg', N'Hình ảnh cánh đồng cúc thạch thảo nở rộ tràn ngập sắc trắng tinh khôi và đầy dễ thương luôn chiếm được cảm tình của mọi người', CAST(85000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (3, N'Vintage', 6, N'vintage.jpg', N'bó hoa từ 3 bông hồng trắng kết hợp tinh tế cùng tông giấy gói màu trầm hiện đại mà đẹp đầy tinh tế', CAST(60000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (4, N'Hương Nắng', 7, N'huongnang.jpg', N'Bó hoa với tông màu sắc tinh tế, cùng các loại hoa mang màu sắc ngọt ngào mà dễ thương như lan mokara, hồng pastel điểm thêm các loại hoa nhí khác', CAST(75000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (5, N'Khoe Sắc', 7, N'khoesac.jpg', N'Hoa hồng luôn là loại hoa được yêu thích nhất, không phải chỉ vì vẻ đẹp và hương thơm mà còn vì hoa hồng đại diện cho loại hoa của tình yêu, vì vậy bình hoa hồng này sẽ giúp bạn cho đi và nhận lại được nhiều yêu thương', CAST(85000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (6, N'Tỏa Sáng', 3, N'calimero.jpg', N'Được làm từ những bông hướng dương tươi nhất và điểm tô bởi những nhánh cúc calimero trắng, lẵng hoa tỏa sáng rực rỡ và mang đầy sức sống, may mắn như nắng ngày hè.', CAST(85000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (7, N'Hân Hoan', 3, N'hanhoan.jpg', N'Giỏ hoa nhỏ xinh đem đến những hy vọng, may mắn và niềm vui rạng ngời nhất với những bông hoa cúc nhỏ xinh', CAST(95000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (8, N'Yêu Thương Nhỏ', 2, N'yeuthuongnho.jpg', N'Hộp hoa là sự kết hợp đầy lãng mạn của baby trắng xung quanh, và đặc biệt hơn là một đóa hồng đỏ rực được thiết kế ngay chính giữa trái tim, thay  lời yêu thì thầm nhỏ nhẹ nhưng đầy chân thành của bạn dành cho người ấy', CAST(65000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (9, N'Món Quà Hạnh Phúc', 2, N'monquahanhphuc.jpg', N' Hộp hoa là sự kết hợp đầy lãng mạn của hoa hồng được xếp ngay ngắn và tô điểm thêm hoa baby trắng xung quanh, và đặc biệt hơn là một món quà nhỏ được thiết kế ngay chính giữa  thay  lời yêu thì thầm nhỏ nhẹ nhưng đầy chân thành của bạn dành cho người ấy', CAST(85000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (10, N'Kệ Hoa Khai Trương Nhiệt Huyết', 4, N'nhiethuyet.jpg', N'Sắc đỏ rực rỡ nổi bật từ hoa đồng tiền không những mang đến sự may mắn, thịnh vượng, mà còn  gọi mời những điều tốt lành nhất đến với người nhận để họ có thể bắt đầu chuyến hành trình hướng đến mục tiêu đầy to lớn và vĩ đại của mình một cách thuận lợi và gặt hái được nhiều thành tựu', CAST(45000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (11, N'Hoa Khai Trương Cát Tường', 3, N'khaitruong.jpg', N'Chỉ với chủ đề đơn sắc vàng tươi thắm nhưng chiếc kệ không hề đơn giản khi nó, dưới bàn tay đầy nghệ thuật của thợ hoa, được thiết kế một cách độc đáo và đặc sắc', CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (12, N'Hoa Lan Hồ Điệp', 5, N'lanhodiep.jpg', N'Hoa lan trắng còn gợi cho ta nghĩ tới sự thanh lịch, khiêm tốn, màu trắng tinh khiết biểu tượng cho sự ngây thơm khiêm tốn đầy ân sủng, hoa lan trắng đại diện cho lòng tốt sự chân thành đầy nhiệt huyết', CAST(55000 AS Decimal(18, 0)))
INSERT [dbo].[CHUNGLOAI] ([MaCL], [TenCL], [MaTL], [AnhBia], [DienGia], [GiaBan]) VALUES (13, N'Hoa Hồng', 5, N'hoahong.jpg', N'Hoa hồng sen sẽ là một lựa chọn tuyệt vời cho những món quà dành cho người mà ta yêu. Đôi lúc trong cuộc sống đầy những căng thẳng và mệt mỏi, một bó hoa tuy giản đơn nhưng sẽ mang lại những cảm xúc thật hạnh phúc và khó quên đó', CAST(25000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[CT_HOADON] ON 

INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 1, 5, 1, 5000, 5000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (2, 1, 6, 1, 5000, 5000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (3, 3, 3, 1, 60000, 60000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (4, 3, 4, 1, 75000, 75000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (5, 4, 2, 1, 85000, 85000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (6, 4, 4, 1, 75000, 75000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (7, 4, 10, 1, 45000, 45000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (8, 5, 13, 1, 25000, 25000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (9, 6, 3, 1, 60000, 60000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (10, 6, 4, 1, 75000, 75000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (11, 6, 8, 1, 65000, 65000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (12, 7, 2, 1, 85000, 85000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (13, 7, 7, 2, 95000, 190000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (14, 8, 11, 1, 100000, 100000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (15, 8, 6, 1, 85000, 85000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (16, 9, 2, 1, 85000, 85000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (17, 9, 3, 1, 60000, 60000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (18, 9, 7, 1, 95000, 95000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (19, 10, 2, 1, 85000, 85000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (20, 10, 7, 1, 95000, 95000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (21, 11, 7, 1, 95000, 95000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (22, 11, 8, 1, 65000, 65000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (23, 12, 3, 1, 60000, 60000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (24, 12, 11, 1, 100000, 100000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (25, 13, 3, 1, 60000, 60000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (26, 13, 7, 1, 95000, 95000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (27, 13, 11, 1, 100000, 100000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (28, 14, 2, 1, 85000, 85000)
INSERT [dbo].[CT_HOADON] ([SoCT], [SoHD], [MaCL], [SoLuong], [DonGia], [ThanhTien]) VALUES (29, 14, 11, 1, 100000, 100000)
SET IDENTITY_INSERT [dbo].[CT_HOADON] OFF
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (0, CAST(0x61400B00 AS Date), 0)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (1, CAST(0x61400B00 AS Date), 1)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (2, CAST(0x61400B00 AS Date), 3)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (3, CAST(0x61400B00 AS Date), 2)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (4, CAST(0x61400B00 AS Date), 3)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (5, CAST(0x61400B00 AS Date), 0)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (6, CAST(0x61400B00 AS Date), 2)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (7, CAST(0x61400B00 AS Date), 2)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (8, CAST(0x61400B00 AS Date), 1)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (9, CAST(0x62400B00 AS Date), 2)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (10, CAST(0x62400B00 AS Date), 0)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (11, CAST(0x62400B00 AS Date), 0)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (12, CAST(0x62400B00 AS Date), 2)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (13, CAST(0x62400B00 AS Date), 5)
INSERT [dbo].[HOADON] ([SoHD], [NgaLap_HD], [MaKH]) VALUES (14, CAST(0x63400B00 AS Date), 0)
SET IDENTITY_INSERT [dbo].[HOADON] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [TenKH], [MatKhau], [MST], [DiaChi], [GioiTinh], [SDT]) VALUES (0, N'Quân', N'quandeptrai', N'123456', N'123', N'B12/7', N'Nam  ', N'0764028579')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [TenKH], [MatKhau], [MST], [DiaChi], [GioiTinh], [SDT]) VALUES (1, N'Nguyễn Văn Tâm', N'KH01', N'123', N'TH01', N'09 Bùi Xuân Phái,Phường Tây Thạnh,Quận Tân Phú,TP.HCM', N'Nam  ', N'0386135588')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [TenKH], [MatKhau], [MST], [DiaChi], [GioiTinh], [SDT]) VALUES (2, N'Lê Như', N'KH02', N'123', N'TH05', N'25 Nguyễn Quý Anh,Phường Tân Sơn Nhì,Quận Tân Phú,TP.HCM', N'Nữ   ', N'0987735588')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [TenKH], [MatKhau], [MST], [DiaChi], [GioiTinh], [SDT]) VALUES (3, N'Nguyễn Minh Nhật', N'KH03', N'123', N'TH34', N'45 Tây Thạnh,Phường Tây Thạnh,Quận Tân Phú,TP.HCM', N'Nam  ', N'076135588 ')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [TenKH], [MatKhau], [MST], [DiaChi], [GioiTinh], [SDT]) VALUES (4, N'Nguyễn Như Hoa', N'KH04', N'123', N'TH37', N'1028 Tân kỳ Tân Quý,Phường Bình Hưng Hòa,Quận Bình Tân,TP.HCM', N'Nữ   ', N'0906135588')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [TenKH], [MatKhau], [MST], [DiaChi], [GioiTinh], [SDT]) VALUES (5, N'Quân Huỳnh', N'demo', N'123', N'123', N'1412', N'Nam  ', N'123       ')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [TenKH], [MatKhau], [MST], [DiaChi], [GioiTinh], [SDT]) VALUES (6, N'quandz', N'Huỳnh Thanh Võ Hoàng Quân', N'123456', N'123', N'B12/7', N'Nam  ', N'0764028579')
INSERT [dbo].[KHACHHANG] ([MaKH], [HoTen], [TenKH], [MatKhau], [MST], [DiaChi], [GioiTinh], [SDT]) VALUES (7, N'Hào', N'haoxinhgai', N'123', N'123', N'B12', N'Nam  ', N'123456    ')
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
INSERT [dbo].[THELOAI] ([MaTL], [TenTL], [DienGia]) VALUES (2, N'Hộp Hoa', NULL)
INSERT [dbo].[THELOAI] ([MaTL], [TenTL], [DienGia]) VALUES (3, N'Lẵng Hoa', NULL)
INSERT [dbo].[THELOAI] ([MaTL], [TenTL], [DienGia]) VALUES (4, N'Kệ Hoa', NULL)
INSERT [dbo].[THELOAI] ([MaTL], [TenTL], [DienGia]) VALUES (5, N'Hoa Tươi', NULL)
INSERT [dbo].[THELOAI] ([MaTL], [TenTL], [DienGia]) VALUES (6, N'Bó Hoa', NULL)
INSERT [dbo].[THELOAI] ([MaTL], [TenTL], [DienGia]) VALUES (7, N'Bình Hoa', NULL)
SET ANSI_PADDING ON

GO
/****** Object:  Index [UNI_USENAME]    Script Date: 11/17/2019 2:52:13 PM ******/
ALTER TABLE [dbo].[ADMIN] ADD  CONSTRAINT [UNI_USENAME] UNIQUE NONCLUSTERED 
(
	[USENAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UNI_MACL]    Script Date: 11/17/2019 2:52:13 PM ******/
ALTER TABLE [dbo].[CHUNGLOAI] ADD  CONSTRAINT [UNI_MACL] UNIQUE NONCLUSTERED 
(
	[MaCL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UNI_SoHDCT]    Script Date: 11/17/2019 2:52:13 PM ******/
ALTER TABLE [dbo].[CT_HOADON] ADD  CONSTRAINT [UNI_SoHDCT] UNIQUE NONCLUSTERED 
(
	[SoCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UNI_SoHD]    Script Date: 11/17/2019 2:52:13 PM ******/
ALTER TABLE [dbo].[HOADON] ADD  CONSTRAINT [UNI_SoHD] UNIQUE NONCLUSTERED 
(
	[SoHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UNI_MAKH]    Script Date: 11/17/2019 2:52:13 PM ******/
ALTER TABLE [dbo].[KHACHHANG] ADD  CONSTRAINT [UNI_MAKH] UNIQUE NONCLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UNI_MATL]    Script Date: 11/17/2019 2:52:13 PM ******/
ALTER TABLE [dbo].[THELOAI] ADD  CONSTRAINT [UNI_MATL] UNIQUE NONCLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CHUNGLOAI]  WITH CHECK ADD  CONSTRAINT [FK_ChungLoai_TheLoai] FOREIGN KEY([MaTL])
REFERENCES [dbo].[THELOAI] ([MaTL])
GO
ALTER TABLE [dbo].[CHUNGLOAI] CHECK CONSTRAINT [FK_ChungLoai_TheLoai]
GO
ALTER TABLE [dbo].[CT_HOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDon_ChungLoai] FOREIGN KEY([MaCL])
REFERENCES [dbo].[CHUNGLOAI] ([MaCL])
GO
ALTER TABLE [dbo].[CT_HOADON] CHECK CONSTRAINT [FK_CTHoaDon_ChungLoai]
GO
ALTER TABLE [dbo].[CT_HOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHoaDon_HoaDon] FOREIGN KEY([SoHD])
REFERENCES [dbo].[HOADON] ([SoHD])
GO
ALTER TABLE [dbo].[CT_HOADON] CHECK CONSTRAINT [FK_CTHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[CT_HOADON]  WITH CHECK ADD  CONSTRAINT [CHK_SoLuong] CHECK  (([SoLuong]>=(0)))
GO
ALTER TABLE [dbo].[CT_HOADON] CHECK CONSTRAINT [CHK_SoLuong]
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD  CONSTRAINT [CHK_GioiTinhKH] CHECK  (([GioiTinh]=N'Nam' OR [GioiTinh]=N'Nữ'))
GO
ALTER TABLE [dbo].[KHACHHANG] CHECK CONSTRAINT [CHK_GioiTinhKH]
GO
