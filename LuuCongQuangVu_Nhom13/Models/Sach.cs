using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class Sach
    {
        public Sach()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
            Muontrasaches = new HashSet<Muontrasach>();
            Muontrataichos = new HashSet<Muontrataicho>();
            Sachxepgia = new HashSet<Sachxepgium>();
            Thanhlisaches = new HashSet<Thanhlisach>();
        }

        public string Idsach { get; set; }
        public string Tensach { get; set; }
        public string Tacgia { get; set; }
        public int? Soluong { get; set; }
        public string Idtheloai { get; set; }
        public double? Giasach { get; set; }
        public string Nhaxuatban { get; set; }
        public DateTime? Ngaynhap { get; set; }
        public string Vitri { get; set; }

        public virtual Theloai IdtheloaiNavigation { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual ICollection<Muontrasach> Muontrasaches { get; set; }
        public virtual ICollection<Muontrataicho> Muontrataichos { get; set; }
        public virtual ICollection<Sachxepgium> Sachxepgia { get; set; }
        public virtual ICollection<Thanhlisach> Thanhlisaches { get; set; }
    }
}
