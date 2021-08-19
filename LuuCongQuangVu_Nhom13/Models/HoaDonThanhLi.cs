using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("HoaDonThanhLi")]
    public partial class HoaDonThanhLi
    {
        public HoaDonThanhLi()
        {
            Thanhlisaches = new HashSet<Thanhlisach>();
        }

        [Key]
        [Column("MaHDTL")]
        [StringLength(4)]
        public string MaHdtl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayLap { get; set; }
        [StringLength(50)]
        public string Usename { get; set; }

        [ForeignKey(nameof(Usename))]
        [InverseProperty(nameof(Account.HoaDonThanhLis))]
        public virtual Account UsenameNavigation { get; set; }
        [InverseProperty(nameof(Thanhlisach.MaHdtlNavigation))]
        public virtual ICollection<Thanhlisach> Thanhlisaches { get; set; }
    }
}
