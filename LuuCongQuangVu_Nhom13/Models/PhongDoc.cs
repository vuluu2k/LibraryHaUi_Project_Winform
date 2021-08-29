using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class PhongDoc
    {
        public string Idphongdoc { get; set; }
        public string Usename { get; set; }
        public int? Soghe { get; set; }
        public int? Somaytinh { get; set; }
        public int? Sodieuhoa { get; set; }
        public int? Soquattran { get; set; }

        public virtual Account UsenameNavigation { get; set; }
    }
}
