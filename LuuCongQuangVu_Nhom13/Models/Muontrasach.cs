using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("Muontrasach")]
    public partial class Muontrasach
    {
        [Key]
        [StringLength(4)]
        public string Iddocgia { get; set; }
        [Key]
        [StringLength(4)]
        public string Idsach { get; set; }
        public int? Soluongmuon { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Ngaymuon { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Ngayhentra { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Ngaythuctra { get; set; }
        [StringLength(150)]
        public string Tinhtrangtra { get; set; }

        [ForeignKey(nameof(Iddocgia))]
        [InverseProperty(nameof(Docgium.Muontrasaches))]
        public virtual Docgium IddocgiaNavigation { get; set; }
        [ForeignKey(nameof(Idsach))]
        [InverseProperty(nameof(Sach.Muontrasaches))]
        public virtual Sach IdsachNavigation { get; set; }
    }
}
