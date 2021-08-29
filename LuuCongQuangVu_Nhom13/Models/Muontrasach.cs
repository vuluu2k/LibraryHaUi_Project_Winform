using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class Muontrasach
    {
        public string Iddocgia { get; set; }
        public string Idsach { get; set; }
        public int? Soluongmuon { get; set; }
        public DateTime? Ngaymuon { get; set; }
        public DateTime? Ngayhentra { get; set; }
        public DateTime? Ngaythuctra { get; set; }
        public string Tinhtrangtra { get; set; }

        public virtual Docgium IddocgiaNavigation { get; set; }
        public virtual Sach IdsachNavigation { get; set; }
    }
}
