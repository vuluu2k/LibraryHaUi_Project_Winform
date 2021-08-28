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
insert into Account values('Lan', '123456', N'Nhân viên',N'Đàm Thị Lan')
insert into Account values('Huyen', '123456', N'Nhân viên',N'Nguyễn Thị Huyền')
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
	Nhaxuatban nvarchar(50),
	Ngaynhap datetime,
	Vitri nvarchar(50),
	constraint fk_idtheloai foreign key(Idtheloai) references Theloai(Idtheloai)
)
go
insert into Sach values('S001', N'Lập trình Android', N'Phạm Quốc Vương', 10, 'T005', 100000, N'HaUi','2020/01/02', N'CS1-Nhổn-Bắc Từ Liêm-Hà Nội')
insert into Sach values('S002', N'Lập trình C#', N'Lưu Công Quang Vũ', 15, 'T005', 80000, N'HaUi','2021/08/10', N'CS1-Nhổn-Bắc Từ Liêm-Hà Nội')
insert into Sach values('S003', N'Lập trình Java', N'Đỗ Viết Nam', 20, 'T005', 120000, N'HaUi','2020/01/05', N'CS3-Tp.Phủ Lý-Hà Nam')
insert into Sach values('S004', N'Lập trình Ruby', N'Lê Văn Thành', 16, 'T005', 70000, N'HaUi','2005/01/04', N'CS2-Tây Tựu-Bắc Từ Liêm-Hà Nội')
insert into Sach values('S005', N'Kinh tế lượng', N'Trân Anh Toan', 16, 'T002', 70000, N'HaUi','2000/01/02', N'CS2-Tây Tựu-Bắc Từ Liêm-Hà Nội')
insert into Sach values('S006', N'Thị trường chứng khoán', N'Hoàng Anh', 10, 'T002', 100000, N'HaUi','2015/01/06', N'CS1-Nhổn-Bắc Từ Liêm-Hà Nội')
go
create table Sachxepgia(
	Idxepgia char(9) primary key,
	Idsach char(4),
	constraint fk_idsachxepgia foreign key(Idsach) references Sach(Idsach)
)
go
insert into Sachxepgia values('010100001', 'S001')
insert into Sachxepgia values('030100002', 'S002')
insert into Sachxepgia values('010100003', 'S001')
insert into Sachxepgia values('020100004', 'S004')
insert into Sachxepgia values('030100005', 'S005')
insert into Sachxepgia values('020100006', 'S005')
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
	Ngaythuctra datetime,
	Tinhtrangtra nvarchar(150)
)
go
insert into Muontrasach values('D001', 'S001',1, '2021/01/10', '2021/04/10', '2021/04/18', N'bình thường')
insert into Muontrasach values('D001', 'S003',1, '2021/08/28', '2021/11/26',null,null)
insert into Muontrasach values('D002', 'S001',1, '2021/01/7', '2021/04/7', '2021/03/13', N'bình thường')
insert into Muontrasach values('D003', 'S005',1, '2021/01/9', '2021/02/9', '2021/02/6', N'bình thường')
insert into Muontrasach values('D003', 'S002',1, '2021/08/28', '2021/11/26',null,null)
insert into Muontrasach values('D003', 'S006',1, '2021/08/28', '2021/9/27',null,null)
insert into Muontrasach values('D004', 'S001',1, '2021/01/9', '2021/04/9', '2021/04/14', N'bình thường')
insert into Muontrasach values('D004', 'S003',1, '2021/01/9', '2021/04/9',null,null)
insert into Muontrasach values('GV05', 'S002',1, '2021/01/9', '2021/04/9', '2021/04/1', N'rách, cũ')
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
	Usename nvarchar(50),
	Soghe int,
	Somaytinh int,
	Sodieuhoa int,
	Soquattran int,
	constraint fk_username foreign key(Usename) references Account(Usename)
)
go
insert into PhongDoc values('P001',N'Vuong',50,10,6,8)
insert into PhongDoc values('P002',N'Lan',50,12,6,8)
insert into PhongDoc values('P003',N'Thanh',55,11,8,10)
insert into PhongDoc values('P004',N'Nam',50,9,6,8)
insert into PhongDoc values('P005',N'Huyen',55,12,8,10)
go

create table Muontrataicho(
	Iddocgia char(4),
	Idsach char(4),
	primary key(Iddocgia, Idsach),
	constraint fk_iddsach foreign key(Idsach) references sach(Idsach),
	constraint fk_idddocgia foreign key(Iddocgia) references docgia(Iddocgia),
	Trangthai nvarchar(50),
	Giomuon datetime,
	Giotra datetime,
)
go

insert into Muontrataicho values('D001', 'S001', N'Đang mượn','2021/1/2 12:00:00', '2021/1/2 15:00:00')
insert into Muontrataicho values('D001', 'S002', N'Đã trả'   ,'2021/1/2 12:00:00', '2021/1/2 14:00:00')
insert into Muontrataicho values('D002', 'S003', N'Đang mượn','2021/1/2 12:00:00', '2021/1/2 13:00:00')
insert into Muontrataicho values('D003', 'S004', N'Đang mượn','2021/1/2 12:00:00', '2021/1/2 13:00:00')
insert into Muontrataicho values('D004', 'S005', N'Đã trả'   ,'2021/1/2 12:00:00', '2021/1/2 13:00:00')
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






