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
        public virtual DbSet<HoaDonThanhLi> HoaDonThanhLis { get; set; }
        public virtual DbSet<Muontrasach> Muontrasaches { get; set; }
        public virtual DbSet<Muontrataicho> Muontrataichos { get; set; }
        public virtual DbSet<PhongDoc> PhongDocs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Thanhlisach> Thanhlisaches { get; set; }
        public virtual DbSet<Theloai> Theloais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HUEUU43\\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Usename)
                    .HasName("PK__Account__813EFC5D843FCAD5");
            });

            modelBuilder.Entity<Docgium>(entity =>
            {
                entity.HasKey(e => e.Iddocgia)
                    .HasName("PK__Docgia__0646586F79395F48");

                entity.Property(e => e.Iddocgia)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Sodienthoai).IsUnicode(false);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E02B0E27D8");

                entity.Property(e => e.MaHd)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Iddocgia)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Idgiangvien)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IddocgiaNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Iddocgia)
                    .HasConstraintName("FK__HoaDon__Iddocgia__31EC6D26");

                entity.HasOne(d => d.UsenameNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Usename)
                    .HasConstraintName("FK__HoaDon__Usename__30F848ED");
            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.HasKey(e => new { e.Idsach, e.MaHd })
                    .HasName("PK__HoaDonCh__A47A85FFB9CCE378");

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

            modelBuilder.Entity<HoaDonThanhLi>(entity =>
            {
                entity.HasKey(e => e.MaHdtl)
                    .HasName("PK__HoaDonTh__141754D353A5DC17");

                entity.Property(e => e.MaHdtl)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.UsenameNavigation)
                    .WithMany(p => p.HoaDonThanhLis)
                    .HasForeignKey(d => d.Usename)
                    .HasConstraintName("FK__HoaDonTha__Usena__3F466844");
            });

            modelBuilder.Entity<Muontrasach>(entity =>
            {
                entity.HasKey(e => new { e.Iddocgia, e.Idsach })
                    .HasName("PK__Muontras__0D26D596B1195BB7");

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

            modelBuilder.Entity<Muontrataicho>(entity =>
            {
                entity.HasKey(e => new { e.Iddocgia, e.Idsach, e.Idphongdoc })
                    .HasName("PK__Muontrat__16E00B35260E377C");

                entity.Property(e => e.Iddocgia)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Idsach)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Idphongdoc)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IddocgiaNavigation)
                    .WithMany(p => p.Muontrataichos)
                    .HasForeignKey(d => d.Iddocgia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idddocgia");

                entity.HasOne(d => d.IdphongdocNavigation)
                    .WithMany(p => p.Muontrataichos)
                    .HasForeignKey(d => d.Idphongdoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_iddphongdoc");

                entity.HasOne(d => d.IdsachNavigation)
                    .WithMany(p => p.Muontrataichos)
                    .HasForeignKey(d => d.Idsach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_iddsach");
            });

            modelBuilder.Entity<PhongDoc>(entity =>
            {
                entity.HasKey(e => e.Idphongdoc)
                    .HasName("PK__PhongDoc__C6DEA31A0A3FB8C7");

                entity.Property(e => e.Idphongdoc)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Idsach)
                    .HasName("PK__Sach__B608DF91C641A450");

                entity.Property(e => e.Idsach)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Idtheloai)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdtheloaiNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Idtheloai)
                    .HasConstraintName("fk_idtheloai");
            });

            modelBuilder.Entity<Thanhlisach>(entity =>
            {
                entity.HasKey(e => new { e.Idsach, e.MaHdtl })
                    .HasName("PK__Thanhlis__9749AADC4F73DFA7");

                entity.Property(e => e.Idsach)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaHdtl)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdsachNavigation)
                    .WithMany(p => p.Thanhlisaches)
                    .HasForeignKey(d => d.Idsach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idssach");

                entity.HasOne(d => d.MaHdtlNavigation)
                    .WithMany(p => p.Thanhlisaches)
                    .HasForeignKey(d => d.MaHdtl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mahdtl");
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.Idtheloai)
                    .HasName("PK__Theloai__F9AEA2387775750E");

                entity.Property(e => e.Idtheloai)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
