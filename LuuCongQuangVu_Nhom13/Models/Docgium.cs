using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class Docgium
    {
        public Docgium()
        {
            HoaDons = new HashSet<HoaDon>();
            Muontrasaches = new HashSet<Muontrasach>();
            QuanLiDocGia = new HashSet<QuanLiDocGium>();
        }

        [Key]
        [StringLength(4)]
        public string Iddocgia { get; set; }
        [StringLength(50)]
        public string Hoten { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgaySinh { get; set; }
        [StringLength(100)]
        public string Diachi { get; set; }
        [StringLength(50)]
        public string Nghenghiep { get; set; }
        [StringLength(11)]
        public string Sodienthoai { get; set; }

        [InverseProperty(nameof(HoaDon.IddocgiaNavigation))]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        [InverseProperty(nameof(Muontrasach.IddocgiaNavigation))]
        public virtual ICollection<Muontrasach> Muontrasaches { get; set; }
        [InverseProperty(nameof(QuanLiDocGium.IddocgiaNavigation))]
        public virtual ICollection<QuanLiDocGium> QuanLiDocGia { get; set; }
    }
}
