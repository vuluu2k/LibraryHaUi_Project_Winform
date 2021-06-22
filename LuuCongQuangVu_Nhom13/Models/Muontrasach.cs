using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("muontrasach")]
    public partial class Muontrasach
    {
        [Key]
        [Column("iddocgia")]
        [StringLength(4)]
        public string Iddocgia { get; set; }
        [Key]
        [Column("idsach")]
        [StringLength(4)]
        public string Idsach { get; set; }
        [Column("ngaymuon", TypeName = "datetime")]
        public DateTime? Ngaymuon { get; set; }
        [Column("ngayhentra", TypeName = "datetime")]
        public DateTime? Ngayhentra { get; set; }
        [Column("ngaythuctra", TypeName = "datetime")]
        public DateTime? Ngaythuctra { get; set; }

        [ForeignKey(nameof(Iddocgia))]
        [InverseProperty(nameof(Docgium.Muontrasaches))]
        public virtual Docgium IddocgiaNavigation { get; set; }
        [ForeignKey(nameof(Idsach))]
        [InverseProperty(nameof(Sach.Muontrasaches))]
        public virtual Sach IdsachNavigation { get; set; }
    }
}
