CREATE DATABASE QL_BanHoa
USE QL_BanHoa
GO
CREATE TABLE ADMIN
(
	USENAME NCHAR(10) NOT NULL,
	PASS NCHAR(10) NOT NULL,
	--QUYEN NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_AD PRIMARY KEY(USENAME),
	CONSTRAINT UNI_USENAME UNIQUE(USENAME)
)
CREATE TABLE THELOAI
(
	MaTL INT NOT NULL,
	TenTL NVARCHAR(50) ,
	DienGia NVARCHAR(50),
	CONSTRAINT PK_TheLoai PRIMARY KEY(MaTL),
	CONSTRAINT UNI_MATL UNIQUE(MaTL)
)

CREATE TABLE CHUNGLOAI
(
	MaCL INT NOT NULL,
	TenCL NVARCHAR(100) NOT NULL,
	MaTL INT NOT NULL,
	AnhBia nvarchar(max) NULL,
	DienGia NVARCHAR(1000),
	GiaBan decimal(18, 0) NULL,
	CONSTRAINT PK_ChungLoai PRIMARY KEY(MaCL),
	CONSTRAINT FK_ChungLoai_TheLoai FOREIGN KEY(MaTL) REFERENCES THELOAI(MaTL),
	CONSTRAINT UNI_MACL UNIQUE(MaCL)
)


CREATE TABLE KHACHHANG
(
	MaKH INT NOT NULL,
	HoTen NVARCHAR(80) ,
	TenKH NVARCHAR(80) ,
	MatKhau NVARCHAR(80) ,
	MST NVARCHAR(20) ,
	DiaChi NVARCHAR(100) ,
	GioiTinh NCHAR(5),
	SDT NCHAR(10),
	CONSTRAINT PK_KhachHang PRIMARY KEY(MaKH),
	CONSTRAINT UNI_MAKH UNIQUE(MaKH),
	CONSTRAINT CHK_GioiTinhKH check(GioiTinh=N'Nam' or GioiTinh=N'Nữ')
)
select * from KHACHHANG


CREATE TABLE HOADON
(
	SoHD INT NOT NULL,
	NgaLap_HD DATE NOT NULL,
	MaKH INT NOT NULL,
	CONSTRAINT PK_HoaDon PRIMARY KEY(SoHD),
	CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY(MaKH) REFERENCES KHACHHANG(MaKH),
	CONSTRAINT UNI_SoHD UNIQUE(SoHD)
)
CREATE TABLE CT_HOADON
(
	SoCT INT NOT NULL,
	SoHD INT,
	MaCL INT,
	SoLuong INT,
	DonGia INT,
	ThanhTien INT,
	CONSTRAINT PK_CTHoaDon PRIMARY KEY(SoCT),
	CONSTRAINT FK_CTHoaDon_HoaDon FOREIGN KEY(SoHD) REFERENCES HOADON(SoHD),
	CONSTRAINT FK_CTHoaDon_ChungLoai FOREIGN KEY(MaCL) REFERENCES CHUNGLOAI(MaCL),
	CONSTRAINT UNI_SoHDCT UNIQUE(SoCT),
	CONSTRAINT CHK_SoLuong check(SoLuong>=0)
)

INSERT INTO THELOAI(MaTL,TenTL,DienGia)
VALUES	(02,N'Hộp Hoa',null),
		(03,N'Lẵng Hoa',null),
		(04,N'Kệ Hoa',null),
		(05,N'Hoa Tươi',null),
		(06,N'Bó Hoa',null),
		(07,N'Bình Hoa',null)


INSERT INTO CHUNGLOAI(MaCL,TenCL,MaTL,AnhBia,DienGia,GiaBan)
VALUES	(01,N'Mây Tím',06,N'hoasalem.jpg',N'Một bó hoa salem mang màu tím nhẹ nhàng', CAST(75000 AS Decimal(18, 0))),
		(02,N'Tinh Khiết (Thạch Thảo Trắng)',06,N'thachthaotrang.jpg',N'Hình ảnh cánh đồng cúc thạch thảo nở rộ tràn ngập sắc trắng tinh khôi và đầy dễ thương luôn chiếm được cảm tình của mọi người', CAST(85000 AS Decimal(18, 0))),
		(03,N'Vintage',06,N'vintage.jpg',N'bó hoa từ 3 bông hồng trắng kết hợp tinh tế cùng tông giấy gói màu trầm hiện đại mà đẹp đầy tinh tế', CAST(60000 AS Decimal(18, 0))),
		(04,N'Hương Nắng',07,N'huongnang.jpg',N'Bó hoa với tông màu sắc tinh tế, cùng các loại hoa mang màu sắc ngọt ngào mà dễ thương như lan mokara, hồng pastel điểm thêm các loại hoa nhí khác', CAST(75000 AS Decimal(18, 0))),
		(05,N'Khoe Sắc',07,N'khoesac.jpg',N'Hoa hồng luôn là loại hoa được yêu thích nhất, không phải chỉ vì vẻ đẹp và hương thơm mà còn vì hoa hồng đại diện cho loại hoa của tình yêu, vì vậy bình hoa hồng này sẽ giúp bạn cho đi và nhận lại được nhiều yêu thương', CAST(85000 AS Decimal(18, 0))),
		(06,N'Tỏa Sáng',03,N'calimero.jpg',N'Được làm từ những bông hướng dương tươi nhất và điểm tô bởi những nhánh cúc calimero trắng, lẵng hoa tỏa sáng rực rỡ và mang đầy sức sống, may mắn như nắng ngày hè.', CAST(85000 AS Decimal(18, 0))),
		(07,N'Hân Hoan',03,N'hanhoan.jpg',N'Giỏ hoa nhỏ xinh đem đến những hy vọng, may mắn và niềm vui rạng ngời nhất với những bông hoa cúc nhỏ xinh', CAST(95000 AS Decimal(18, 0))),
		(08,N'Yêu Thương Nhỏ',02,N'yeuthuongnho.jpg',N'Hộp hoa là sự kết hợp đầy lãng mạn của baby trắng xung quanh, và đặc biệt hơn là một đóa hồng đỏ rực được thiết kế ngay chính giữa trái tim, thay  lời yêu thì thầm nhỏ nhẹ nhưng đầy chân thành của bạn dành cho người ấy', CAST(65000 AS Decimal(18, 0))),
		(09,N'Món Quà Hạnh Phúc',02,N'monquahanhphuc.jpg',N' Hộp hoa là sự kết hợp đầy lãng mạn của hoa hồng được xếp ngay ngắn và tô điểm thêm hoa baby trắng xung quanh, và đặc biệt hơn là một món quà nhỏ được thiết kế ngay chính giữa  thay  lời yêu thì thầm nhỏ nhẹ nhưng đầy chân thành của bạn dành cho người ấy', CAST(85000 AS Decimal(18, 0))),
		(10,N'Kệ Hoa Khai Trương Nhiệt Huyết',04,N'nhiethuyet.jpg',N'Sắc đỏ rực rỡ nổi bật từ hoa đồng tiền không những mang đến sự may mắn, thịnh vượng, mà còn  gọi mời những điều tốt lành nhất đến với người nhận để họ có thể bắt đầu chuyến hành trình hướng đến mục tiêu đầy to lớn và vĩ đại của mình một cách thuận lợi và gặt hái được nhiều thành tựu', CAST(45000 AS Decimal(18, 0))),
		(11,N'Hoa Khai Trương Cát Tường',03,N'khaitruong.jpg',N'Chỉ với chủ đề đơn sắc vàng tươi thắm nhưng chiếc kệ không hề đơn giản khi nó, dưới bàn tay đầy nghệ thuật của thợ hoa, được thiết kế một cách độc đáo và đặc sắc', CAST(100000 AS Decimal(18, 0))),
		(12,N'Hoa Lan Hồ Điệp',05,N'lanhodiep.jpg',N'Hoa lan trắng còn gợi cho ta nghĩ tới sự thanh lịch, khiêm tốn, màu trắng tinh khiết biểu tượng cho sự ngây thơm khiêm tốn đầy ân sủng, hoa lan trắng đại diện cho lòng tốt sự chân thành đầy nhiệt huyết', CAST(55000 AS Decimal(18, 0))),
		(13,N'Hoa Hồng',05,N'hoahong.jpg',N'Hoa hồng sen sẽ là một lựa chọn tuyệt vời cho những món quà dành cho người mà ta yêu. Đôi lúc trong cuộc sống đầy những căng thẳng và mệt mỏi, một bó hoa tuy giản đơn nhưng sẽ mang lại những cảm xúc thật hạnh phúc và khó quên đó', CAST(25000 AS Decimal(18, 0)))


INSERT INTO KHACHHANG(MaKH,HoTen,TenKH,MatKhau,MST,DiaChi,GioiTinh,SDT)
VALUES (01,N'Nguyễn Văn Tâm',N'KH01',N'123',N'TH01',N'09 Bùi Xuân Phái,Phường Tây Thạnh,Quận Tân Phú,TP.HCM',N'Nam','0386135588'),
		(02,N'Lê Như',N'KH02',N'123',N'TH05',N'25 Nguyễn Quý Anh,Phường Tân Sơn Nhì,Quận Tân Phú,TP.HCM',N'Nữ','0987735588'),
		(03,N'Nguyễn Minh Nhật',N'KH03',N'123',N'TH34',N'45 Tây Thạnh,Phường Tây Thạnh,Quận Tân Phú,TP.HCM',N'Nam','076135588'),
		(04,N'Nguyễn Như Hoa',N'KH04',N'123',N'TH37',N'1028 Tân kỳ Tân Quý,Phường Bình Hưng Hòa,Quận Bình Tân,TP.HCM',N'Nữ','0906135588')

INSERT INTO ADMIN(USENAME,PASS)
VALUES('admin','123456')

		select * from KHACHHANG
		select * from ADMIN