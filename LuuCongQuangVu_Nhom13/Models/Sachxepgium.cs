using System;
using System.Collections.Generic;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class Sachxepgium
    {
        public string Idxepgia { get; set; }
        public string Idsach { get; set; }

        public virtual Sach IdsachNavigation { get; set; }
    }
}
