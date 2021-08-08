using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public string MaHd { get; set; }
        public DateTime? NgayLap { get; set; }
        public string Usename { get; set; }
        public string Iddocgia { get; set; }

        public virtual Docgium IddocgiaNavigation { get; set; }
        public virtual Account UsenameNavigation { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
