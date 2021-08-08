using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class Thanhlisach
    {
        public string MaHdtl { get; set; }
        public string Idsach { get; set; }
        public string Donvinhanthanhli { get; set; }
        public int? Soluong { get; set; }
        public string Tinhtrangsach { get; set; }
        public double? Phantramgiaban { get; set; }

        public virtual Sach IdsachNavigation { get; set; }
        public virtual HoaDonThanhLi MaHdtlNavigation { get; set; }
    }
}
