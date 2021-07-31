using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("PhongDoc")]
    public partial class PhongDoc
    {
        public PhongDoc()
        {
            QuanLiDocGia = new HashSet<QuanLiDocGium>();
        }

        [Key]
        [StringLength(4)]
        public string Idphongdoc { get; set; }
        [StringLength(50)]
        public string Tennhanvien { get; set; }

        [InverseProperty(nameof(QuanLiDocGium.IdphongdocNavigation))]
        public virtual ICollection<QuanLiDocGium> QuanLiDocGia { get; set; }
    }
}
