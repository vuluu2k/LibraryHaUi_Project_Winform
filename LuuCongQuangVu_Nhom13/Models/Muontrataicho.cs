using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class Muontrataicho
    {
        public string Iddocgia { get; set; }
        public string Idsach { get; set; }
        public string Trangthai { get; set; }
        public DateTime? Giomuon { get; set; }
        public DateTime? Giotra { get; set; }

        public virtual Docgium IddocgiaNavigation { get; set; }
        public virtual Sach IdsachNavigation { get; set; }
    }
}
