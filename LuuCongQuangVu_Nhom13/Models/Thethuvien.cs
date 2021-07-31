using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("thethuvien")]
    public partial class Thethuvien
    {
        [Key]
        [Column("idthe")]
        [StringLength(4)]
        public string Idthe { get; set; }
        [Column("iddocgia")]
        [StringLength(4)]
        public string Iddocgia { get; set; }
        [Column("ngaycap", TypeName = "datetime")]
        public DateTime? Ngaycap { get; set; }
        [Column("ngayhethan", TypeName = "datetime")]
        public DateTime? Ngayhethan { get; set; }

        [ForeignKey(nameof(Iddocgia))]
        //[InverseProperty(nameof(Docgium.Thethuviens))]
        public virtual Docgium IddocgiaNavigation { get; set; }
    }
}
