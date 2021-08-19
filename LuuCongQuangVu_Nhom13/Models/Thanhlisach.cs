using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("Thanhlisach")]
    public partial class Thanhlisach
    {
        [Key]
        [Column("MaHDTL")]
        [StringLength(4)]
        public string MaHdtl { get; set; }
        [Key]
        [StringLength(4)]
        public string Idsach { get; set; }
        public int? Soluong { get; set; }
        [StringLength(50)]
        public string Tinhtrangsach { get; set; }
        public double? Phantramgiaban { get; set; }

        [ForeignKey(nameof(Idsach))]
        [InverseProperty(nameof(Sach.Thanhlisaches))]
        public virtual Sach IdsachNavigation { get; set; }
        [ForeignKey(nameof(MaHdtl))]
        [InverseProperty(nameof(HoaDonThanhLi.Thanhlisaches))]
        public virtual HoaDonThanhLi MaHdtlNavigation { get; set; }
    }
}
