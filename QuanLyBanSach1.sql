CREATE DATABASE QuanLyBanSach
GO
USE QuanLyBanSach
GO
CREATE TABLE KhachHang(
MaKH INT PRIMARY KEY,
TenKH NVARCHAR(50) ,
TaiKhoan VARCHAR(50),
MatKhau VARCHAR(50),
Email VARCHAR(50),
GioiTinh NVARCHAR(5) CHECK (GioiTinh IN (N'Nam',N'Nữ')),
SDT VARCHAR(15),
NgaySinh DATE 
)
GO
CREATE TABLE ChuDe(
MaChuDe INT PRIMARY KEY,
TenChuDe NVARCHAR(50)
)
GO
CREATE TABLE NhaXuatBan(
MaNXB INT PRIMARY KEY,
TenNXB NVARCHAR(50),
DiaChi NVARCHAR(200),
SDT VARCHAR(15)
)
GO
CREATE TABLE TacGia (
MaTG INT PRIMARY KEY,
TenTG NVARCHAR(50),
DiaChi NVARCHAR(200),
TieuSu NVARCHAR(MaX),
SDT VARCHAR(15)
)
GO
CREATE TABLE Sach(
MaSach INT PRIMARY KEY,
TenSach NVARCHAR(50),
GiaBan INT,
MoTa NVARCHAR(MAX),
AnhBia NVARCHAR(50),
NgayCapNhat DATE,
SoLuongTon INT,
MaNXB INT REFERENCES dbo.NhaXuatBan(MaNXB),
MaChuDe INT REFERENCES dbo.ChuDe(MaChuDe) 
)
GO
CREATE TABLE ChiTietTacGia (
MaTG INT REFERENCES dbo.TacGia(MaTG),
MaSach INT REFERENCES dbo.Sach(MaSach),
VaiTro NVARCHAR(50) ,
ViTri NVARCHAR(50),
PRIMARY KEY (MaTG,MaSach)
)
GO
CREATE TABLE DonHang(
MaDH INT PRIMARY KEY,
DaThanhToan INT,
TinhTrangDH INT,
NgayDat DATE,
NgayGiao DATE,
MaKH INT REFERENCES dbo.KhachHang(MaKH)
)
GO
CREATE TABLE ChiTietDonHang(
MaDH INT REFERENCES dbo.DonHang(MaDH),
MaSach INT REFERENCES dbo.Sach(MaSach),
SoLuong INT,
DonGia INT, 
)
GO


--insert khách hàng
INSERT INTO KhachHang (MaKH, TenKH, TaiKhoan, MatKhau, Email, GioiTinh, SDT, NgaySinh)  
VALUES (1, N'Nguyễn Thị Thùy', 'Thùy', '123', 'thuy12@gmail.com', N'Nữ', '01636020635', '1997/11/12');
INSERT INTO KhachHang (MaKH, TenKH, TaiKhoan, MatKhau, Email, GioiTinh, SDT, NgaySinh)  
VALUES (2, N'Nguyễn Thị Phượng', 'Phượng', '123', 'phuong12@gmail.com', N'Nữ', '01636020636', '1997/07/22');
INSERT INTO KhachHang (MaKH, TenKH, TaiKhoan, MatKhau, Email, GioiTinh, SDT, NgaySinh)  
VALUES (3, N'Nguyễn Thị Huyền Trang', 'Trang', '123', 'trang12@gmail.com', N'Nữ', '01636020637', '1997/11/03');
INSERT INTO KhachHang (MaKH, TenKH, TaiKhoan, MatKhau, Email, GioiTinh, SDT, NgaySinh)  
VALUES (4, N'Nguyễn Thị Thoa', 'Thoa', '123', 'thoa12@gmail.com', N'Nữ', '01636020638', '1997/11/28');
INSERT INTO KhachHang (MaKH, TenKH, TaiKhoan, MatKhau, Email, GioiTinh, SDT, NgaySinh)  
VALUES (5, N'Phạm Hồng Sơn', 'Sơn', '123', 'son12@gmail.com', N'Nam', '01636020639', '1997/07/12');


--insert dơn hàng
INSERT INTO DonHang (MaDH, DaThanhToan, TinhTrangDH, NgayDat, NgayGiao,MaKH)
VALUES (01, null, null, '2018/05/01', '2018/05/10', 1)
INSERT INTO DonHang (MaDH, DaThanhToan, TinhTrangDH, NgayDat, NgayGiao,MaKH)
VALUES (02, null, null, '2018/04/01', '2018/04/15', 2)
INSERT INTO DonHang (MaDH, DaThanhToan, TinhTrangDH, NgayDat, NgayGiao,MaKH)
VALUES (03, null, null, '2018/04/21', '2018/05/01', 3)
INSERT INTO DonHang (MaDH, DaThanhToan, TinhTrangDH, NgayDat, NgayGiao,MaKH)
VALUES (04, null, null, '2018/03/19', '2018/03/29', 4)
INSERT INTO DonHang (MaDH, DaThanhToan, TinhTrangDH, NgayDat, NgayGiao,MaKH)
VALUES (05, null, null, '2018/05/04', '2018/05/11', 5)
INSERT INTO DonHang (MaDH, DaThanhToan, TinhTrangDH, NgayDat, NgayGiao,MaKH)
VALUES (06, null, null, '2018/03/04', '2018/03/11', 5)


--insert chủ đề
INSERT INTO ChuDe (MaChuDe, TenChuDe) VALUES (001, N'Tin Học')
INSERT INTO ChuDe (MaChuDe, TenChuDe) VALUES (002, N'Nhân Văn Học')
INSERT INTO ChuDe (MaChuDe, TenChuDe) VALUES (003, N'Khoa Học')
INSERT INTO ChuDe (MaChuDe, TenChuDe) VALUES (004, N'Toán Học')
INSERT INTO ChuDe (MaChuDe, TenChuDe) VALUES (005, N'Xã Hội Học')
INSERT INTO ChuDe (MaChuDe, TenChuDe) VALUES (006, N'Ngôn Ngữ')
INSERT INTO ChuDe (MaChuDe, TenChuDe) VALUES (007, N'Công Nghệ')
INSERT INTO ChuDe (MaChuDe, TenChuDe) VALUES (008, N'Chương Trình Học')
INSERT INTO ChuDe (MaChuDe, TenChuDe) VALUES (009, N'Khác')


--insert nhà xuất bản
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SDT) VALUES (0001, N'NXB Trẻ', N'Hà Nội', '0987725039' )
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SDT) VALUES (0002, N'NXB Văn Học', N'Hà Nội', '0987725049' )
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SDT) VALUES (0003, N'NXB Lao Động', N'TP Hồ Chí Minh', '0987725539' )
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SDT) VALUES (0004, N'NXB Kim Đồng', N'Hà Nội', '0987725639' )
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SDT) VALUES (0005, N'NXB Giáo Dục', N'TP Hồ Chí Minh', '0987725739' )
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SDT) VALUES (0006, N'NXB Chính Trị Quốc Gia', N'TP Hồ Chí Minh', '0987725139' )
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SDT) VALUES (0007, N'NXB Tổng Hợp Thành Phố Hồ Chí Minh', N'TP Hồ Chí Minh', '0987725239' )
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SDT) VALUES (0008, N'NXB Tư Pháp', N'Hà Nội', '0987725339' )
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SDT) VALUES (0009, N'NXB Thông Tin và Truyền Thông', N'Hà Nội', '0987721139' )
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SDT) VALUES (0010, N'NXB Giao Thông Vận Tải', N'Hà Nội', '0988725039' )


--insert tác giả
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (1, N'Nguyễn Nhật Ánh', N'Hưng Yên', null, '01696552692')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (2, N'Trang Hạ', N'Bến Tre', null, '01696552691')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (3, N'Nguyễn Phong Việt', N'Vũng Tầu', null, '01696552693')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (4, N'Anh Khang', N'Hà Nội', null, '01696552694')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (5, N'Sơn Paris', N'Đồng Tháp', null, '01696552695')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (6, N'Gào', N'Hà Nội', null, '01696552696')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (7, N'Nguyễn Ngọc Thạch', N'Yên Bái', null, '01696552697')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (8, N'Đỗ Nhật Nam', N'TP Hồ Chí Minh', null, '01696552698')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (9, N'Hamlet Trương', N'Hải Dương', null, '01696552699')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (10, N'Lris Cao', N'Nghệ Tĩnh', null, '01696552690')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (11, N'Nguyễn Du', N'Hưng Yên', null, '01696553692')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (12, N'Thùy Linh', N'Bến Tre', null, '01696552691')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (13, N'Bảo Bình', N'Vũng Tầu', null, '01696554693')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (14, N'Đức Nguyên', N'Hà Nội', null, '01696555694')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (15, N'Nguyễn Ngọc Ngạn', N'Đồng Tháp', null, '01696556695')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (16, N'Từ Thông', N'Hà Nội', null, '01696557696')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (17, N'Phạm Hải Đăng', N'Yên Bái', null, '01696558697')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (18, N'Chạy', N'TP Hồ Chí Minh', null, '01696559698')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (19, N'Trang Đài', N'Hải Dương', null, '01696562699')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (20, N'Mưa', N'Nghệ Tĩnh', null, '01696572690')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (31, N'An Nhiên', N'Hưng Yên', null, '01696552692')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (32, N'Nguyễn Tú Tài', N'Bến Tre', null, '01696552691')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (33, N'Đỗ Hải Phong', N'Vũng Tầu', null, '01696552693')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (34, N'Nguyên Khang', N'Hà Nội', null, '01696552694')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (35, N'Xồi', N'Đồng Tháp', null, '01696552695')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (36, N'Quang Hải', N'Hà Nội', null, '01696552696')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (37, N'Nhân Đức', N'Yên Bái', null, '01696552697')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (38, N'Hồ Nhật Nam', N'TP Hồ Chí Minh', null, '01696552698')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (39, N'Tú Trường', N'Hải Dương', null, '01696552699')
INSERT INTO TacGia (MaTG, TenTG, DiaChi, TieuSu, SDT) VALUES (40, N'Xuân Diệu', N'Nghệ Tĩnh', null, '01696552690')








--insert sách
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123450, N'Công Nghệ Thông Tin', 150000 , null, null, '2015/01/01', 10, 0001, 001)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123451, N'Khoa Học Máy Tính', 170000 , null, null, '2015/01/01', 7, 0001, 001)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123452, N'Luật', 130000 , null, null, '2014/11/01', 5, 0002, 002)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123453, N'Mỹ Thuật', 50000 , null, null, '2014/01/01', 23, 0002, 002)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123454, N'Khoa Học Đời Sống', 250000 , null, null, '2012/07/13', 10, 0003, 003)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123455, N'Khoa Học Sức Khỏe', 250000 , null, null, '2012/08/01', 1, 0003, 003)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123456, N'Internet', 50000 , null, null, '2014/01/01', 40, 0001, 001)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123457, N'Lập Trình', 70000 , null, null, '2014/01/01', 17, 0001, 001)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123458, N'Mã Nguồn Mở', 750000 , null, null, '2014/11/01', 5, 0001, 001)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123459, N'Lập Trình Game Console', 250000 , null, null, '2014/01/01', 20, 0001, 001)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123460, N'Phần Cứng ', 50000 , null, null, '2012/07/13', 10, 0001, 001)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123461, N'Phần Mềm ', 50000 , null, null, '2012/08/01', 11, 0001, 001)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123462, N'Nghệ Thuật Trình Diễn ', 90000 , null, null, '2014/01/01', 19, 0002, 002)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123463, N'Sử Học', 70000 , null, null, '2013/01/01', 7, 0002, 002)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123464, N'Tôn Giáo ', 230000 , null, null, '2014/10/01', 5, 0002, 002)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123465, N'Triết Học', 150000 , null, null, '2013/01/01', 3, 0002, 002)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123466, N'Văn Học', 50000 , null, null, '2012/07/13', 10, 0002, 002)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123467, N'Khoa Học Sức Khỏe', 150000 , null, null, '2012/05/01', 1, 0003, 003)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123468, N'Hướng Dẫn Học Khoa Học ', 70000 , null, null, '2014/01/01', 29, 0003, 003)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123469, N'Khoa Học Vật Chất', 80000 , null, null, '2012/01/01', 7, 0003, 003)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123470, N'Toán Học Ứng Dụng ', 130000 , null, null, '2015/10/01', 5, 0004, 004)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123471, N'Toán Học Thuần Túy', 150000 , null, null, '2013/01/01', 3, 0004, 004)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123472, N'Sử Toán Học', 50000 , null, null, '2012/07/13', 10, 0004, 004)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123473, N'Số Học Sơ Cấp', 150000 , null, null, '2012/05/01', 1, 0004, 004)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123474, N'Địa Lý Học ', 130000 , null, null, '2015/10/01', 5, 0005, 005)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123475, N'Khoa Học Chính Trị', 150000 , null, null, '2013/01/01', 3, 0005, 005)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123476, N'Kinh Doanh', 50000 , null, null, '2012/07/13', 10, 0005, 005)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123477, N'Kinh Tế Học', 150000 , null, null, '2012/05/01', 1, 0005, 005)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123478, N'Ngôn Ngữ Học ', 130000 , null, null, '2015/10/01', 5, 0005, 005)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123479, N'Nhân Loại Học', 150000 , null, null, '2013/01/01', 3, 0005, 005)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123480, N'Tâm Lý Học', 50000 , null, null, '2012/07/13', 10, 0005, 005)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123481, N'Xã Hội Học', 150000 , null, null, '2012/05/01', 1, 0005, 005)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123482, N'Giáo Dục Ngôn Ngữ ', 130000 , null, null, '2015/10/01', 5, 0006, 006)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123483, N'Ngôn Ngữ Nhân Tạo', 150000 , null, null, '2013/01/01', 3, 0006, 006)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123484, N'Ngôn Ngữ Trực Quan', 50000 , null, null, '2012/07/13', 10, 0006, 006)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123485, N'Ngôn Ngữ Cơ Thể', 150000 , null, null, '2012/05/01', 1, 0006, 006)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123486, N'Chương Trình Học Châu Âu', 50000 , null, null, '2012/07/13', 10, 0007, 007)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123487, N'Chương Trình Học Châu Phi', 150000 , null, null, '2012/05/01', 1, 0007, 007)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123488, N'Chương Trình Học Châu Úc', 150000 , null, null, '2012/05/01', 1, 0007, 007)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123489, N'Chương Trình Học Nam Mỹ', 150000 , null, null, '2012/05/01', 1, 0007, 007)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123490, N'Chương Trình Học Quốc Tế', 150000 , null, null, '2012/05/01', 1, 0007, 007)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123491, N'Kỹ Năng Sống Sót', 150000 , null, null, '2012/05/01', 1, 0008, 008)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123492, N'Cải Thiện Bản Thân', 150000 , null, null, '2012/05/01', 1, 0008, 008)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123493, N'Hoạt Động Giải Trí', 150000 , null, null, '2012/05/01', 1, 0008, 008)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123494, N'Vũ Trang', 150000 , null, null, '2012/05/01', 1, 0008, 008)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123495, N'Du Học', 150000 , null, null, '2012/05/01', 1, 0008, 008)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123496, N'Thuật Hùng Biện', 50000 , null, null, '2012/07/13', 10, 0006, 006)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123497, N'Ngôn Ngữ Của Chúa', 150000 , null, null, '2012/05/01', 1, 0006, 006)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123498, N'Kỹ Thuật Điện ', 130000 , null, null, '2015/10/01', 5, 0007, 007)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123499, N'Xây Dựng Hệ Thống', 150000 , null, null, '2013/01/01', 3, 0007, 007)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123500, N'Chương Trình Học Bắc Mỹ', 50000 , null, null, '2012/07/13', 10, 0007, 007)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123501, N'Chương Trình Học Châu Ắ', 150000 , null, null, '2012/05/01', 1, 0007, 007)

--INSERt chi tiết tác giả
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (1, 123450, N'Tác Giả', null)
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (1, 123451, N'Tác Giả', null)
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (2, 123452, N'Tác Giả', null)
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (2, 123453, N'Tác Giả', null)
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (3, 123454, N'Tác Giả', null)
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (3, 123455, N'Tác Giả', null)


--insert chi tiết đơn hàng
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (01, 123450, 4, 600000)
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (02, 123451, 3, 510000)
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (03, 123452, 10, 1000000)
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (04, 123453, 7, 350000)
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (05, 123454, 15, 3750000)
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (06, 123455, 2, 500000)


update ChiTietDonHang
Set DonGia=600000
WHERE MaDH=01

update Sach
Set MaSach=123455
WHERE 

go
CREATE PROC sachxuatban (@TenTG nvarchar(50))
AS
BEGIN
	SELECT TacGia.MaTG,TenTG,COUNT(MaSach) AS 'Số Lượng Sách' FROM dbo.TacGia,dbo.ChiTietTacGia
	WHERE ChiTietTacGia.MaTG=TacGia.MaTG AND TenTG =@TenTG
	GROUP BY TacGia.MaTG,TenTG
END
EXEC dbo.sachxuatban @TenTG = N'Nguyễn Hoàng Minh' -- nvarchar(50)


