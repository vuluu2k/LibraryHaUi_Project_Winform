using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class Theloai
    {
        public Theloai()
        {
            Saches = new HashSet<Sach>();
        }

        public string Idtheloai { get; set; }
        public string Tentheloai { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
