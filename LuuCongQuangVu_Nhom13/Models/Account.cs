using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    [Table("account")]
    public partial class Account
    {
        [Key]
        [Column("usename")]
        [StringLength(50)]
        public string Usename { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("capdo")]
        [StringLength(50)]
        public string Capdo { get; set; }
    }
}
