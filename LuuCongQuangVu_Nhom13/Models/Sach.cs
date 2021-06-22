using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("sach")]
    public partial class Sach
    {
        public Sach()
        {
            Muontrasaches = new HashSet<Muontrasach>();
        }

        [Key]
        [Column("idsach")]
        [StringLength(4)]
        public string Idsach { get; set; }
        [Column("tensach")]
        [StringLength(50)]
        public string Tensach { get; set; }
        [Column("tacgia")]
        [StringLength(50)]
        public string Tacgia { get; set; }
        [Column("soluong")]
        public int? Soluong { get; set; }
        [Column("theloai")]
        [StringLength(50)]
        public string Theloai { get; set; }
        [Column("giasach")]
        public double? Giasach { get; set; }
        [Column("nhaxuatban")]
        [StringLength(50)]
        public string Nhaxuatban { get; set; }
        [Column("vitri")]
        [StringLength(50)]
        public string Vitri { get; set; }

        [InverseProperty(nameof(Muontrasach.IdsachNavigation))]
        public virtual ICollection<Muontrasach> Muontrasaches { get; set; }
    }
}
