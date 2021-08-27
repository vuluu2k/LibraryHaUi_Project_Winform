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
	Capdo nvarchar(50),
	Tenchutaikhoan nvarchar(50)
)
go
insert into Account values('Vuong', '123456', N'Nhân viên',N'Phạm Quốc Vương')
insert into Account values('Vu', '123456', N'Admin', N'Lưu Công Quang Vũ')
insert into Account values('Thanh', '123456', N'Nhân viên', N'Lê Văn Thành')
insert into Account values('Nam', '123456', N'Nhân viên', N'Đỗ Viết Nam')
insert into Account values('Admin', '123456', N'Admin', N'Admin')
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
insert into Docgia values('D001', N'Nguyen Van A','2000/03/04', N'Thanh Hóa', N'Sinh viên', '0949999352')
insert into Docgia values('D002', N'Nguyen Van B','2001/06/10', N'Nghệ An', N'Sinh viên', '0940678352')
insert into Docgia values('D003', N'Nguyen Van C','2000/08/15', N'Nam Định', N'Sinh viên', '0948888352')
insert into Docgia values('D004', N'Nguyen Van D','2002/10/10', N'Hà Nội', N'Sinh viên', '0989709170')
insert into Docgia values('GV05', N'Nguyen Van E','2000/11/15', N'Hà Nam', N'Giảng viên', '0823547627')
go
create table Theloai(
	Idtheloai char(4) primary key,
	Tentheloai nvarchar(50)
)
go
insert into Theloai values('T001',N'Khoa học công nghệ')
insert into Theloai values('T002',N'Kinh tế')
insert into Theloai values('T003',N'Nghiên cứu khoa học')
insert into Theloai values('T004',N'Văn hóa xã hội – Lịch sử')
insert into Theloai values('T005',N'Giáo trình')
insert into Theloai values('T006',N'Văn học nghệ thuật')
insert into Theloai values('T007',N'Tài liệu khác')
go
create table Sach(
	Idsach char(4) primary key,
	Tensach nvarchar(50),
	Tacgia nvarchar(50),
	Soluong int,
	Idtheloai char(4),
	Giasach float,
	Ngaynhap datetime,
	Nhaxuatban nvarchar(50),
	Vitri nvarchar(50),
	constraint fk_idtheloai foreign key(Idtheloai) references Theloai(Idtheloai)
)
go
insert into Sach values('S001', N'Lập trình Android', N'Phạm Quốc Vương', 10, 'T005', 100000,'2019/01/20', N'HaUi', N'CS1-Nhổn-Bắc Từ Liêm-Hà Nội')
insert into Sach values('S002', N'Lập trình C#', N'Lưu Công Quang Vũ', 15, 'T005', 80000,'2020/01/20', N'HaUi', N'CS1-Nhổn-Bắc Từ Liêm-Hà Nội')
insert into Sach values('S003', N'Lập trình Java', N'Đỗ Viết Nam', 20, 'T005', 120000,'2019/01/20', N'HaUi', N'CS3-Tp.Phủ Lý-Hà Nam')
insert into Sach values('S004', N'Lập trình Ruby', N'Lê Văn Thành', 16, 'T005', 70000,'2018/01/20', N'HaUi', N'CS2-Tây Tựu-Bắc Từ Liêm-Hà Nội')
insert into Sach values('S005', N'Kinh tế lượng', N'Trân Anh Toan', 16, 'T002', 70000,'2020/01/20', N'HaUi', N'CS2-Tây Tựu-Bắc Từ Liêm-Hà Nội')
insert into Sach values('S006', N'Thị trường chứng khoán', N'Hoàng Anh', 10, 'T002', 100000,'2021/01/20', N'HaUi', N'CS1-Nhổn-Bắc Từ Liêm-Hà Nội')
go
create table Muontrasach(
	Iddocgia char(4),
	Idsach char(4),
	primary key(Iddocgia, Idsach),
	constraint fk_idsach foreign key(Idsach) references Sach(Idsach),
	constraint fk_iddocgia foreign key(Iddocgia) references Docgia(Iddocgia),
	Soluongmuon int,
	Ngaymuon datetime,
	Ngayhentra datetime,
	Ngaythuctra datetime
)
go
insert into Muontrasach values('D001', 'S001',2, '2021/01/10', '2021/01/20', '2021/01/18')
insert into Muontrasach values('D002', 'S001',3, '2021/01/7', '2021/01/15', '2021/01/13')
insert into Muontrasach values('D003', 'S003',3, '2021/01/9', '2021/01/14', '2021/01/14')
insert into Muontrasach values('D004', 'S001',3, '2021/01/9', '2021/01/14', '2021/01/14')
insert into Muontrasach values('GV05', 'S002',3, '2021/01/9', '2021/01/14', '2021/01/14')
go
create table HoaDon(
	MaHD char(4) primary key,
	NgayLap datetime,
	Usename nvarchar(50),
	Iddocgia char(4),
	Idgiangvien char(4),
	foreign key(Usename) references Account(Usename),
	foreign key(Iddocgia) references Docgia(Iddocgia)
)
go
insert into HoaDon values('H001',  '2020/05/20',N'Thanh', 'D001','GV05')
insert into HoaDon values('H002',  '2020/05/14',N'Vu', 'D003','GV05')
insert into HoaDon values('H003',  '2020/05/16',N'Nam', 'D002','GV05')
insert into HoaDon values('H004',  '2020/04/16',N'Vuong', 'D003','GV05')
insert into HoaDon values('H005',  '2020/06/16',N'Vuong', 'D001','GV05')
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
insert into HoaDonChiTiet values('H001', 'S001', 3)
insert into HoaDonChiTiet values('H002', 'S003', 2)
insert into HoaDonChiTiet values('H003', 'S002', 1)
insert into HoaDonChiTiet values('H004', 'S004', 1)
insert into HoaDonChiTiet values('H005', 'S005', 2)
go

create table PhongDoc(
	Idphongdoc char(4) primary key,
	Tennhanvien nvarchar(50),
	Soban int,
	Giomocua datetime,
	Giodong datetime,
)
go
insert into PhongDoc values('P001',N'Phạm Thị Hà',40,'2021/1/2 12:00:00','2021/1/2 15:00:00')
insert into PhongDoc values('P002',N'Lê Văn Thành',50,'2021/1/2 13:00:00','2021/1/2 16:00:00')
insert into PhongDoc values('P003',N'Trần Văn Quân',45,'2021/1/2 12:00:00','2021/1/2 15:00:00')
insert into PhongDoc values('P004',N'Trần Văn Thái',60,'2021/1/2 12:00:00','2021/1/2 15:00:00')
insert into PhongDoc values('P005',N'Ngô Việt Chung',72,'2021/1/2 12:00:00','2021/1/2 15:00:00')
go

create table Muontrataicho(
	Iddocgia char(4),
	Idsach char(4),
	Idphongdoc char(4),
	primary key(Iddocgia, Idsach, Idphongdoc),
	constraint fk_iddphongdoc foreign key(Idphongdoc) references PhongDoc(Idphongdoc),
	constraint fk_iddsach foreign key(Idsach) references sach(Idsach),
	constraint fk_idddocgia foreign key(Iddocgia) references docgia(Iddocgia),
	Vitriban int,
	Giovao datetime,
	Giora datetime,
	Tinhtrangsach nvarchar(100)
)
insert into Muontrataicho values('D001', 'S001', 'P001',10, '2021/1/2 12:00:00', '2021/1/2 15:00:00', N'Bình Thường')
insert into Muontrataicho values('D001', 'S002','P001',12, '2021/1/2 12:00:00', '2021/1/2 14:00:00',N'Bình thường')
insert into Muontrataicho values('D002', 'S003','P002',5, '2021/1/2 12:00:00', '2021/1/2 13:00:00', N'Hỏng trang 20')
insert into Muontrataicho values('D003', 'S004','P002',7, '2021/1/2 12:00:00', '2021/1/2 13:00:00', N'Hỏng trang 35')
insert into Muontrataicho values('D004', 'S005','P002',15, '2021/1/2 12:00:00', '2021/1/2 13:00:00', N'Hỏng trang 14')
go

create table HoaDonThanhLi(
	MaHDTL char(4) primary key,
	NgayLap datetime,
	Usename nvarchar(50),
	foreign key(Usename) references Account(Usename)
)
go
insert into HoaDonThanhLi values('TL01',  '2020/05/25',N'Thanh')
insert into HoaDonThanhLi values('TL02',  '2020/06/16',N'Vu')
insert into HoaDonThanhLi values('TL03',  '2020/04/20',N'Nam')
insert into HoaDonThanhLi values('TL04',  '2020/04/20',N'Nam')
insert into HoaDonThanhLi values('TL05',  '2020/04/20',N'Vu')
go
create table Thanhlisach(
	
	MaHDTL char(4),
	Idsach char(4),
	primary key(Idsach, MaHDTL),
	constraint fk_idssach foreign key(Idsach) references Sach(Idsach),
	constraint mahdtl foreign key(MaHDTL) references HoaDonThanhLi(MaHDTL),
	Soluong int,
	Tinhtrangsach nvarchar(50),
	Phantramgiaban float
)
go
insert into Thanhlisach values('TL01','S001',   2, N'quá niên hạn', 0.25)
insert into Thanhlisach values('TL01','S002',  3, N'quá niên hạn', 0.2)
insert into Thanhlisach values('TL02','S003',   3, N'sách hư hỏng', 0.3)
insert into Thanhlisach values('TL03','S002',  1, N'nội dung không còn phù hợp', 0.4)
insert into Thanhlisach values('TL03','S004',  1, N'nội dung không còn phù hợp', 0.4)
go






