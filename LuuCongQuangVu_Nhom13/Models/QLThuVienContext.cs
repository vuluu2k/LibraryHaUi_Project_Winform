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
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual DbSet<Muontrasach> Muontrasaches { get; set; }
        public virtual DbSet<PhongDoc> PhongDocs { get; set; }
        public virtual DbSet<QuanLiDocGium> QuanLiDocGia { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CMV45C1\\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Usename)
                    .HasName("PK__Account__813EFC5DFAC320B0");
            });

            modelBuilder.Entity<Docgium>(entity =>
            {
                entity.HasKey(e => e.Iddocgia)
                    .HasName("PK__Docgia__0646586F289A0A6B");

                entity.Property(e => e.Iddocgia)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Sodienthoai).IsUnicode(false);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E0CB5A2F2A");

                entity.Property(e => e.MaHd)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Iddocgia)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IddocgiaNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Iddocgia)
                    .HasConstraintName("FK__HoaDon__Iddocgia__2E1BDC42");
            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.HasKey(e => new { e.Idsach, e.MaHd })
                    .HasName("PK__HoaDonCh__A47A85FFE8C99904");

                entity.Property(e => e.Idsach)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaHd)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdsachNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.Idsach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idsach");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mahd");
            });

            modelBuilder.Entity<Muontrasach>(entity =>
            {
                entity.HasKey(e => new { e.Iddocgia, e.Idsach })
                    .HasName("PK__Muontras__0D26D5963F63A098");

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

            modelBuilder.Entity<PhongDoc>(entity =>
            {
                entity.HasKey(e => e.Idphongdoc)
                    .HasName("PK__PhongDoc__C6DEA31A64767243");

                entity.Property(e => e.Idphongdoc)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<QuanLiDocGium>(entity =>
            {
                entity.HasKey(e => new { e.Idphongdoc, e.Iddocgia })
                    .HasName("PK__QuanLiDo__26BAC69CE0235FFC");

                entity.Property(e => e.Idphongdoc)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Iddocgia)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IddocgiaNavigation)
                    .WithMany(p => p.QuanLiDocGia)
                    .HasForeignKey(d => d.Iddocgia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkiddocgia");

                entity.HasOne(d => d.IdphongdocNavigation)
                    .WithMany(p => p.QuanLiDocGia)
                    .HasForeignKey(d => d.Idphongdoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idphongdoc");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Idsach)
                    .HasName("PK__Sach__B608DF917C22FFB8");

                entity.Property(e => e.Idsach)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
