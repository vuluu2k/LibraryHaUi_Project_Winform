using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class PhongDoc
    {
        public PhongDoc()
        {
            Muontrataichos = new HashSet<Muontrataicho>();
        }

        public string Idphongdoc { get; set; }
        public string Tennhanvien { get; set; }
        public int? Soban { get; set; }
        public DateTime? Giomocua { get; set; }
        public DateTime? Giodong { get; set; }

        public virtual ICollection<Muontrataicho> Muontrataichos { get; set; }
    }
}
