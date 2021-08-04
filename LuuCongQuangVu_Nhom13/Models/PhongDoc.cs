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
            QuanLiPhongDocs = new HashSet<QuanLiPhongDoc>();
        }

        [Key]
        [StringLength(4)]
        public string Idphongdoc { get; set; }
        [StringLength(50)]
        public string Tennhanvien { get; set; }

        [InverseProperty(nameof(QuanLiPhongDoc.IdphongdocNavigation))]
        public virtual ICollection<QuanLiPhongDoc> QuanLiPhongDocs { get; set; }
    }
}
