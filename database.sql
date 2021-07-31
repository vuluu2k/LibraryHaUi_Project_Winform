use master
go
if exists(select name from Sys.databases where name= 'QLThuVien') drop database QLThuVien
go
create database QLThuVien
go
use QLThuVien
go
create table Account(
	Usename nvarchar(50) primary key,
	Password nvarchar(50),
	Capdo nvarchar(50)
)
go
insert into Account values('vuong', '123456', N'Nhân viên')
insert into Account values('vu', '123456', N'Admin')
insert into Account values('thanh', '123456', N'Nhân viên')
insert into Account values('nam', '123456', N'Nhân viên')
go
create table Docgia(
	Iddocgia char(4) primary key,
	Hoten nvarchar(50),
	NgaySinh datetime,
	Diachi nvarchar(100),
	Nghenghiep nvarchar(50),
	Sodienthoai varchar(11)
)
go
insert into Docgia values('d001', N'Nguyen Van A','2020/01/10', N'Thanh Hóa', N'sinh viên', '0949999352')
insert into Docgia values('d002', N'Nguyen Van B','2020/01/10', N'Nghệ An', N'sinh viên', '0940678352')
insert into Docgia values('d003', N'Nguyen Van C','2020/01/10', N'Nam Định', N'sinh viên', '0948888352')
go
create table Sach(
	Idsach char(4) primary key,
	Tensach nvarchar(50),
	Tacgia nvarchar(50),
	Soluong int,
	Theloai nvarchar(50),
	Giasach float,
	Nhaxuatban nvarchar(50),
	Vitri nvarchar(50)
)
go
insert into Sach values('s001', N'cho tôi một vé đi tuổi thơ', N'phạm quốc vương', 10, N'tiểu thuyết', 100000, N'Kim đồng', N'Nghệ An')
insert into Sach values('s002', N'cuộc chiến sinh tử', N'Lưu Công Quang Vũ', 15, N'truyện trinh thám', 80000, N'Anh thơ', N'Nam Định')
insert into Sach values('s003', N'Thanh Hóa chuyện chưa kể', N'Đỗ Viết Nam', 20, N'tiểu thuyết', 120000, N'Ánh Dương', N'Thanh Hóa')
insert into Sach values('s004', N'Thanh Hóa ngoại truyện', N'Lê Văn Thành', 16, N'tiểu thuyết', 70000, N'Kim Đồng', N'Thanh Hóa')
go
create table Muontrasach(
	Iddocgia char(4),
	Idsach char(4),
	primary key(Iddocgia, Idsach),
	constraint fk_idsach foreign key(Idsach) references sach(Idsach),
	constraint fk_iddocgia foreign key(Iddocgia) references docgia(Iddocgia),
	Ngaymuon datetime,
	Ngayhentra datetime,
	Ngaythuctra datetime
)
go
insert into Muontrasach values('d001', 's001', '2021/01/10', '2021/01/20', '2021/01/18')
insert into Muontrasach values('d002', 's001', '2021/01/7', '2021/01/15', '2021/01/13')
insert into Muontrasach values('d003', 's003', '2021/01/9', '2021/01/14', '2021/01/14')
go
create table HoaDon(
	MaHD char(4) primary key,
	NgayLap datetime,
	NguoiLap nvarchar(50),
	Iddocgia char(4),
	foreign key(Iddocgia) references Docgia(Iddocgia)
)
go
insert into HoaDon values('h001',  '2020/05/20',N'phạm văn x', 'd001')
insert into HoaDon values('h002',  '2020/05/14',N'phạm văn y', 'd003')
insert into HoaDon values('h003',  '2020/05/16',N'phạm văn z', 'd002')
go

create table HoaDonChiTiet(
	MaHD char(4),
	Idsach char(4),
	primary key(Idsach, MaHD),
	constraint idsach foreign key(Idsach) references sach(Idsach),
	constraint mahd foreign key(MaHD) references HoaDon(MaHD),
	SoLuongMua int
)
go
insert into HoaDonChiTiet values('h001', 's001', 3)
insert into HoaDonChiTiet values('h002', 's003', 2)
insert into HoaDonChiTiet values('h003', 's002', 1)
go

create table PhongDoc(
	Idphongdoc char(4) primary key,
	Tennhanvien nvarchar(50)
)
go
insert into PhongDoc values('p001', N'Phạm Thị Hà')
insert into PhongDoc values('p002', N'Ngô Thị Trang')
go
create table QuanLiDocGia(
	Idphongdoc char(4),
	Iddocgia char(4),
	primary key(Idphongdoc, Iddocgia),
	constraint fk_idphongdoc foreign key(Idphongdoc) references PhongDoc(Idphongdoc),
	constraint fkiddocgia foreign key(Iddocgia) references DocGia(Iddocgia),
	Giovao datetime,
	Giora datetime
)
go
insert into QuanLiDocGia values('p001', 'd001','2021/1/2 12:00:00', '2021/1/2 15:00:00')
insert into QuanLiDocGia values('p002', 'd002','2021/1/2 12:00:00', '2021/1/2 14:00:00')
insert into QuanLiDocGia values('p002', 'd001','2021/1/2 12:00:00', '2021/1/2 13:00:00')
insert into QuanLiDocGia values('p001', 'd003','2021/1/2 12:00:00', '2021/1/2 12:15:00')
insert into QuanLiDocGia values('p001', 'd002','2021/1/2 12:00:00', '2021/1/2 12:30:00')
go



