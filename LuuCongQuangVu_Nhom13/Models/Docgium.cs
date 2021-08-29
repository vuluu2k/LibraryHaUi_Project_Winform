using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class Docgium
    {
        public Docgium()
        {
            HoaDons = new HashSet<HoaDon>();
            Muontrasaches = new HashSet<Muontrasach>();
            Muontrataichos = new HashSet<Muontrataicho>();
        }

        public string Iddocgia { get; set; }
        public string Hoten { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Diachi { get; set; }
        public string Nghenghiep { get; set; }
        public string Sodienthoai { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<Muontrasach> Muontrasaches { get; set; }
        public virtual ICollection<Muontrataicho> Muontrataichos { get; set; }
    }
}
