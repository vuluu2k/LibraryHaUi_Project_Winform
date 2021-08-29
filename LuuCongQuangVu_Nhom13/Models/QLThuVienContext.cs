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
        public virtual DbSet<Sachxepgium> Sachxepgia { get; set; }
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
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Usename)
                    .HasName("PK__Account__813EFC5D69435D23");

                entity.ToTable("Account");

                entity.Property(e => e.Usename).HasMaxLength(50);

                entity.Property(e => e.Capdo).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Tenchutaikhoan).HasMaxLength(50);
            });

            modelBuilder.Entity<Docgium>(entity =>
            {
                entity.HasKey(e => e.Iddocgia)
                    .HasName("PK__Docgia__0646586FA986B344");

                entity.Property(e => e.Iddocgia)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Diachi).HasMaxLength(100);

                entity.Property(e => e.Hoten).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Nghenghiep).HasMaxLength(50);

                entity.Property(e => e.Sodienthoai)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E0977E0133");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaHD")
                    .IsFixedLength(true);

                entity.Property(e => e.Iddocgia)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Idgiangvien)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.Usename).HasMaxLength(50);

                entity.HasOne(d => d.IddocgiaNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Iddocgia)
                    .HasConstraintName("FK__HoaDon__Iddocgia__34C8D9D1");

                entity.HasOne(d => d.UsenameNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Usename)
                    .HasConstraintName("FK__HoaDon__Usename__33D4B598");
            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.HasKey(e => new { e.Idsach, e.MaHd })
                    .HasName("PK__HoaDonCh__A47A85FFA14DE8F3");

                entity.ToTable("HoaDonChiTiet");

                entity.Property(e => e.Idsach)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaHd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaHD")
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
                    .HasName("PK__HoaDonTh__141754D3CB4A3D16");

                entity.ToTable("HoaDonThanhLi");

                entity.Property(e => e.MaHdtl)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaHDTL")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.Usename).HasMaxLength(50);

                entity.HasOne(d => d.UsenameNavigation)
                    .WithMany(p => p.HoaDonThanhLis)
                    .HasForeignKey(d => d.Usename)
                    .HasConstraintName("FK__HoaDonTha__Usena__4222D4EF");
            });

            modelBuilder.Entity<Muontrasach>(entity =>
            {
                entity.HasKey(e => new { e.Iddocgia, e.Idsach })
                    .HasName("PK__Muontras__0D26D596B0F5D87D");

                entity.ToTable("Muontrasach");

                entity.Property(e => e.Iddocgia)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Idsach)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ngayhentra).HasColumnType("datetime");

                entity.Property(e => e.Ngaymuon).HasColumnType("datetime");

                entity.Property(e => e.Ngaythuctra).HasColumnType("datetime");

                entity.Property(e => e.Tinhtrangtra).HasMaxLength(150);

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
                entity.HasKey(e => new { e.Iddocgia, e.Idsach })
                    .HasName("PK__Muontrat__0D26D596CB880AEE");

                entity.ToTable("Muontrataicho");

                entity.Property(e => e.Iddocgia)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Idsach)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Giomuon).HasColumnType("datetime");

                entity.Property(e => e.Giotra).HasColumnType("datetime");

                entity.Property(e => e.Trangthai).HasMaxLength(50);

                entity.HasOne(d => d.IddocgiaNavigation)
                    .WithMany(p => p.Muontrataichos)
                    .HasForeignKey(d => d.Iddocgia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idddocgia");

                entity.HasOne(d => d.IdsachNavigation)
                    .WithMany(p => p.Muontrataichos)
                    .HasForeignKey(d => d.Idsach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_iddsach");
            });

            modelBuilder.Entity<PhongDoc>(entity =>
            {
                entity.HasKey(e => e.Idphongdoc)
                    .HasName("PK__PhongDoc__C6DEA31AAB655C7D");

                entity.ToTable("PhongDoc");

                entity.Property(e => e.Idphongdoc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Usename).HasMaxLength(50);

                entity.HasOne(d => d.UsenameNavigation)
                    .WithMany(p => p.PhongDocs)
                    .HasForeignKey(d => d.Usename)
                    .HasConstraintName("fk_username");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Idsach)
                    .HasName("PK__Sach__B608DF91EF171EA2");

                entity.ToTable("Sach");

                entity.Property(e => e.Idsach)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Idtheloai)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ngaynhap).HasColumnType("datetime");

                entity.Property(e => e.Nhaxuatban).HasMaxLength(50);

                entity.Property(e => e.Tacgia).HasMaxLength(50);

                entity.Property(e => e.Tensach).HasMaxLength(50);

                entity.Property(e => e.Vitri).HasMaxLength(50);

                entity.HasOne(d => d.IdtheloaiNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Idtheloai)
                    .HasConstraintName("fk_idtheloai");
            });

            modelBuilder.Entity<Sachxepgium>(entity =>
            {
                entity.HasKey(e => e.Idxepgia)
                    .HasName("PK__Sachxepg__9966BBCFF887A974");

                entity.Property(e => e.Idxepgia)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Idsach)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdsachNavigation)
                    .WithMany(p => p.Sachxepgia)
                    .HasForeignKey(d => d.Idsach)
                    .HasConstraintName("fk_idsachxepgia");
            });

            modelBuilder.Entity<Thanhlisach>(entity =>
            {
                entity.HasKey(e => new { e.Idsach, e.MaHdtl })
                    .HasName("PK__Thanhlis__9749AADC3143F464");

                entity.ToTable("Thanhlisach");

                entity.Property(e => e.Idsach)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaHdtl)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaHDTL")
                    .IsFixedLength(true);

                entity.Property(e => e.Tinhtrangsach).HasMaxLength(50);

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
                    .HasName("PK__Theloai__F9AEA2386DA53A6F");

                entity.ToTable("Theloai");

                entity.Property(e => e.Idtheloai)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tentheloai).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
