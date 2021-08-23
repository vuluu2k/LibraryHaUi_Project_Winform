using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("Sach")]
    public partial class Sach
    {
        public Sach()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
            Muontrasaches = new HashSet<Muontrasach>();
            Muontrataichos = new HashSet<Muontrataicho>();
            Thanhlisaches = new HashSet<Thanhlisach>();
        }

        [Key]
        [StringLength(4)]
        public string Idsach { get; set; }
        [StringLength(50)]
        public string Tensach { get; set; }
        [StringLength(50)]
        public string Tacgia { get; set; }
        public int? Soluong { get; set; }
        [StringLength(4)]
        public string Idtheloai { get; set; }
        public double? Giasach { get; set; }
        [StringLength(50)]
        public string Nhaxuatban { get; set; }
        [StringLength(50)]
        public string Vitri { get; set; }

        [ForeignKey(nameof(Idtheloai))]
        [InverseProperty(nameof(Theloai.Saches))]
        public virtual Theloai IdtheloaiNavigation { get; set; }
        [InverseProperty(nameof(HoaDonChiTiet.IdsachNavigation))]
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        [InverseProperty(nameof(Muontrasach.IdsachNavigation))]
        public virtual ICollection<Muontrasach> Muontrasaches { get; set; }
        [InverseProperty(nameof(Muontrataicho.IdsachNavigation))]
        public virtual ICollection<Muontrataicho> Muontrataichos { get; set; }
        [InverseProperty(nameof(Thanhlisach.IdsachNavigation))]
        public virtual ICollection<Thanhlisach> Thanhlisaches { get; set; }
    }
}
