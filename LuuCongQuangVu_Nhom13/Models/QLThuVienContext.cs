using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LuuCongQuangVu_Nhom13.Models
{
    public partial class QLThuVienContext : DbContext
    {
        public QLThuVienContext()
        {
        }

        public QLThuVienContext(DbContextOptions<QLThuVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Docgium> Docgia { get; set; }
        public virtual DbSet<Muontrasach> Muontrasaches { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Thethuvien> Thethuviens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-03QHJ5S\\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Usename)
                    .HasName("PK__account__D1DDB568FCC25F28");
            });

            modelBuilder.Entity<Docgium>(entity =>
            {
                entity.HasKey(e => e.Iddocgia)
                    .HasName("PK__docgia__DFF217792222E09D");

                entity.Property(e => e.Iddocgia)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Sodienthoai).IsUnicode(false);
            });

            modelBuilder.Entity<Muontrasach>(entity =>
            {
                entity.HasKey(e => new { e.Iddocgia, e.Idsach })
                    .HasName("PK__muontras__C2F2BD655210C591");

                entity.Property(e => e.Iddocgia)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Idsach)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IddocgiaNavigation)
                    .WithMany(p => p.Muontrasaches)
                    .HasForeignKey(d => d.Iddocgia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_iddocgia");

                entity.HasOne(d => d.IdsachNavigation)
                    .WithMany(p => p.Muontrasaches)
                    .HasForeignKey(d => d.Idsach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idsach");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Idsach)
                    .HasName("PK__sach__D00AA1C0D87971A3");

                entity.Property(e => e.Idsach)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Thethuvien>(entity =>
            {
                entity.HasKey(e => e.Idthe)
                    .HasName("PK__thethuvi__2A4110003BBE8CC8");

                entity.Property(e => e.Idthe)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Iddocgia)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IddocgiaNavigation)
                    .WithMany(p => p.Thethuviens)
                    .HasForeignKey(d => d.Iddocgia)
                    .HasConstraintName("FK__thethuvie__iddoc__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
