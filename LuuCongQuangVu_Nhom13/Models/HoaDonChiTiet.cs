using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("HoaDonChiTiet")]
    public partial class HoaDonChiTiet
    {
        [Key]
        [Column("MaHD")]
        [StringLength(4)]
        public string MaHd { get; set; }
        [Key]
        [StringLength(4)]
        public string Idsach { get; set; }
        public int? SoLuongMua { get; set; }

        [ForeignKey(nameof(Idsach))]
        [InverseProperty(nameof(Sach.HoaDonChiTiets))]
        public virtual Sach IdsachNavigation { get; set; }
        [ForeignKey(nameof(MaHd))]
        [InverseProperty(nameof(HoaDon.HoaDonChiTiets))]
        public virtual HoaDon MaHdNavigation { get; set; }
    }
}
