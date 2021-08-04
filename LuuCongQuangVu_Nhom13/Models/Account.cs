using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("Account")]
    public partial class Account
    {
        public Account()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(50)]
        public string Usename { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Capdo { get; set; }
        [StringLength(50)]
        public string Tenchutaikhoan { get; set; }

        [InverseProperty(nameof(HoaDon.UsenameNavigation))]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
