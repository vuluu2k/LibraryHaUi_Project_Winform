using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class Muontrataicho
    {
        public string Iddocgia { get; set; }
        public string Idsach { get; set; }
        public string Idphongdoc { get; set; }
        public int? Vitriban { get; set; }
        public DateTime? Giovao { get; set; }
        public DateTime? Giora { get; set; }
        public string Tinhtrangsach { get; set; }

        public virtual Docgium IddocgiaNavigation { get; set; }
        public virtual PhongDoc IdphongdocNavigation { get; set; }
        public virtual Sach IdsachNavigation { get; set; }
    }
}
