using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("docgia")]
    public partial class Docgium
    {
        public Docgium()
        {
            Muontrasaches = new HashSet<Muontrasach>();
            Thethuviens = new HashSet<Thethuvien>();
        }

        [Key]
        [Column("iddocgia")]
        [StringLength(4)]
        public string Iddocgia { get; set; }
        [Column("hoten")]
        [StringLength(50)]
        public string Hoten { get; set; }
        [Column("ngaysinh", TypeName = "datetime")]
        public DateTime? Ngaysinh { get; set; }
        [Column("diachi")]
        [StringLength(100)]
        public string Diachi { get; set; }
        [Column("nghenghiep")]
        [StringLength(50)]
        public string Nghenghiep { get; set; }
        [Column("sodienthoai")]
        [StringLength(11)]
        public string Sodienthoai { get; set; }

        [InverseProperty(nameof(Muontrasach.IddocgiaNavigation))]
        public virtual ICollection<Muontrasach> Muontrasaches { get; set; }
        [InverseProperty(nameof(Thethuvien.IddocgiaNavigation))]
        public virtual ICollection<Thethuvien> Thethuviens { get; set; }
    }
}
