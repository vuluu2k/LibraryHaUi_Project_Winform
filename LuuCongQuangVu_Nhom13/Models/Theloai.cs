using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("Theloai")]
    public partial class Theloai
    {
        public Theloai()
        {
            Saches = new HashSet<Sach>();
        }

        [Key]
        [StringLength(4)]
        public string Idtheloai { get; set; }
        [StringLength(50)]
        public string Tentheloai { get; set; }

        [InverseProperty(nameof(Sach.IdtheloaiNavigation))]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
