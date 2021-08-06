using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("Muontrataicho")]
    public partial class Muontrataicho
    {
        [Key]
        [StringLength(4)]
        public string Iddocgia { get; set; }
        [Key]
        [StringLength(4)]
        public string Idsach { get; set; }
        [Key]
        [StringLength(4)]
        public string Idphongdoc { get; set; }
        public int? Vitriban { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Giovao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Giora { get; set; }
        [StringLength(100)]
        public string Tinhtrangsach { get; set; }

        [ForeignKey(nameof(Iddocgia))]
        [InverseProperty(nameof(Docgium.Muontrataichos))]
        public virtual Docgium IddocgiaNavigation { get; set; }
        [ForeignKey(nameof(Idphongdoc))]
        [InverseProperty(nameof(PhongDoc.Muontrataichos))]
        public virtual PhongDoc IdphongdocNavigation { get; set; }
        [ForeignKey(nameof(Idsach))]
        [InverseProperty(nameof(Sach.Muontrataichos))]
        public virtual Sach IdsachNavigation { get; set; }
    }
}
