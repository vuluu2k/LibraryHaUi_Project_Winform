using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class HoaDonThanhLi
    {
        public HoaDonThanhLi()
        {
            Thanhlisaches = new HashSet<Thanhlisach>();
        }

        public string MaHdtl { get; set; }
        public DateTime? NgayLap { get; set; }
        public string Usename { get; set; }

        public virtual Account UsenameNavigation { get; set; }
        public virtual ICollection<Thanhlisach> Thanhlisaches { get; set; }
    }
}
