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
            Muontrataichos = new HashSet<Muontrataicho>();
        }

        [Key]
        [StringLength(4)]
        public string Idphongdoc { get; set; }
        [StringLength(50)]
        public string Tennhanvien { get; set; }
        public int? Soban { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Giomocua { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Giodong { get; set; }

        [InverseProperty(nameof(Muontrataicho.IdphongdocNavigation))]
        public virtual ICollection<Muontrataicho> Muontrataichos { get; set; }
    }
}
