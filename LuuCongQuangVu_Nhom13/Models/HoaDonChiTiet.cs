using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class HoaDonChiTiet
    {
        public string MaHd { get; set; }
        public string Idsach { get; set; }
        public int? SoLuongMua { get; set; }

        public virtual Sach IdsachNavigation { get; set; }
        public virtual HoaDon MaHdNavigation { get; set; }
    }
}
