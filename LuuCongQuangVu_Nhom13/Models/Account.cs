using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class Account
    {
        public Account()
        {
            HoaDonThanhLis = new HashSet<HoaDonThanhLi>();
            HoaDons = new HashSet<HoaDon>();
        }

        public string Usename { get; set; }
        public string Password { get; set; }
        public string Capdo { get; set; }
        public string Tenchutaikhoan { get; set; }

        public virtual ICollection<HoaDonThanhLi> HoaDonThanhLis { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
