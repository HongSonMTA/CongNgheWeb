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
ALTER TABLE KhachHang DROP COLUMN MatKhau
ALTER TABLE dbo.KhachHang ADD  TaiKhoan VARCHAR(30) REFERENCES TaiKhoan(TaiKhoan)
ALTER TABLE dbo.Sach ADD MaTG INT REFERENCES dbo.TacGia(MaTG) 
ALTER TABLE dbo.KhachHang ADD DiaChi NVARCHAR(MAX)
CREATE TABLE TaiKhoan(
TaiKhoan VARCHAR(30) PRIMARY KEY,
MatKhau VARCHAR(30) ,
PhanQuyen INT
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
PRIMARY KEY (MaDH,MaSach)
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

--insert sách
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123450, N'Công Nghệ Thông Tin', 150.000 , null, null, '2015/01/01', 10, 0001, 001)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123451, N'Khoa Học Máy Tính', 170.000 , null, null, '2015/01/01', 7, 0001, 001)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123452, N'Luật', 130.000 , null, null, '2014/11/01', 5, 0002, 002)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123453, N'Mỹ Thuật', 50.000 , null, null, '2014/01/01', 23, 0002, 002)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123454, N'Khoa Học Đời Sống', 250.000 , null, null, '2012/07/13', 10, 0003, 003)
INSERT INTO Sach (MaSach, TenSach, GiaBan, MoTa, AnhBia, NgayCapNhat, SoLuongTon, MaNXB, MaChuDe)
VALUES (123455, N'Khoa Học Sức Khỏe', 250.000 , null, null, '2012/08/01', 1, 0003, 003)


--INSERt chi tiết tác giả
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (1, 123450, N'Tác Giả', null)
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (1, 123451, N'Tác Giả', null)
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (2, 123452, N'Tác Giả', null)
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (2, 123453, N'Tác Giả', null)
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (3, 123454, N'Tác Giả', null)
INSERT INTO ChiTietTacGia (MaTG, MaSach, VaiTro, ViTri) VALUES (3, 123455, N'Tác Giả', null)


--insert chi tiết đơn hàng
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (01, 123450, 4, 600.000)
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (02, 123451, 3, 510.000)
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (03, 123452, 10, 1.000000)
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (04, 123453, 7, 350.000)
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (05, 123454, 15, 3.750000)
INSERT INTO ChiTietDonHang (MaDH, MaSach, SoLuong, DonGia) VALUES (06, 123455, 2, 500.000)


update ChiTietDonHang
Set DonGia=500000
WHERE MaDH=05

update Sach
Set MaSach=123455
WHERE 