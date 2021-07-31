using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class QuanLiDocGium
    {
        [Key]
        [StringLength(4)]
        public string Idphongdoc { get; set; }
        [Key]
        [StringLength(4)]
        public string Iddocgia { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Giovao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Giora { get; set; }

        [ForeignKey(nameof(Iddocgia))]
        [InverseProperty(nameof(Docgium.QuanLiDocGia))]
        public virtual Docgium IddocgiaNavigation { get; set; }
        [ForeignKey(nameof(Idphongdoc))]
        [InverseProperty(nameof(PhongDoc.QuanLiDocGia))]
        public virtual PhongDoc IdphongdocNavigation { get; set; }
    }
}
