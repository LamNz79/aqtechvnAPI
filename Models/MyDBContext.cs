using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AQapi.Models;

public partial class MyDBContext : DbContext
{
    public MyDBContext()
    {
    }

    public MyDBContext(DbContextOptions<MyDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BanLanhDao> BanLanhDaos { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<DoiTac> DoiTacs { get; set; }

    public virtual DbSet<Footer> Footers { get; set; }

    public virtual DbSet<GiaiThuong> GiaiThuongs { get; set; }

    public virtual DbSet<Header> Headers { get; set; }

    public virtual DbSet<HoTroDienThoai> HoTroDienThoais { get; set; }

    public virtual DbSet<HoTroUngDung> HoTroUngDungs { get; set; }

    public virtual DbSet<LichSuPhatTrien> LichSuPhatTriens { get; set; }

    public virtual DbSet<LogOn> LogOns { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<TaiKhoanDatum> TaiKhoanData { get; set; }

    public virtual DbSet<TaiSaoBanChon> TaiSaoBanChons { get; set; }

    public virtual DbSet<ThietLapChung> ThietLapChungs { get; set; }

    public virtual DbSet<ThongTinBaiViet> ThongTinBaiViets { get; set; }

    public virtual DbSet<ThongTinTrangChu> ThongTinTrangChus { get; set; }

    public virtual DbSet<TinVeGiaoDucDaoTao> TinVeGiaoDucDaoTaos { get; set; }

    public virtual DbSet<VanHoaVaHoatDongCongTy> VanHoaVaHoatDongCongTies { get; set; }

    public virtual DbSet<YkienDanhGium> YkienDanhGia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=103.98.160.17;Initial Catalog=Aqtech;User ID=dev;Password=dev@edusoft;Connect Timeout=1800;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BanLanhDao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BanLanhD__3214EC079C164E5A");

            entity.ToTable("BanLanhDao");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NoiDungTa)
                .HasMaxLength(2000)
                .HasColumnName("NoiDungTA");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDe).HasMaxLength(2000);
            entity.Property(e => e.TieuDeTa)
                .HasMaxLength(2000)
                .HasColumnName("TieuDeTA");
            entity.Property(e => e.TomTat).HasMaxLength(2000);
            entity.Property(e => e.TomTatTa)
                .HasMaxLength(2000)
                .HasColumnName("TomTatTA");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Banner__3214EC07DCB32BF4");

            entity.ToTable("Banner");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NoiDungTa)
                .HasMaxLength(2000)
                .HasColumnName("NoiDungTA");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDe).HasMaxLength(2000);
            entity.Property(e => e.TieuDeTa)
                .HasMaxLength(2000)
                .HasColumnName("TieuDeTA");
            entity.Property(e => e.TomTat).HasMaxLength(2000);
            entity.Property(e => e.TomTatTa)
                .HasMaxLength(2000)
                .HasColumnName("TomTatTA");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contact__3214EC0774923352");

            entity.ToTable("Contact");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DonViCongTac).HasMaxLength(1000);
            entity.Property(e => e.Email).HasMaxLength(1000);
            entity.Property(e => e.HoTenNguoiGui).HasMaxLength(1000);
            entity.Property(e => e.NgayGui).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasMaxLength(1000);
            entity.Property(e => e.SoDienThoai).HasMaxLength(1000);
        });

        modelBuilder.Entity<DoiTac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DoiTac__3214EC07B2575CBA");

            entity.ToTable("DoiTac");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EmailNhanTin).HasMaxLength(1000);
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDe).HasMaxLength(1000);
            entity.Property(e => e.TomTat).HasMaxLength(1000);
        });

        modelBuilder.Entity<Footer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__footer__3213E83F2A4892AD");

            entity.ToTable("footer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(1000)
                .HasColumnName("email");
            entity.Property(e => e.Stt).HasColumnName("STT");
        });

        modelBuilder.Entity<GiaiThuong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GiaiThuo__3214EC0719E94C10");

            entity.ToTable("GiaiThuong");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.KyHieu).HasMaxLength(100);
            entity.Property(e => e.Link)
                .HasMaxLength(1000)
                .HasColumnName("link");
            entity.Property(e => e.TieuDe).HasMaxLength(2000);
            entity.Property(e => e.TieuDeTa).HasMaxLength(2000);
        });

        modelBuilder.Entity<Header>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Header__3214EC07A81507A6");

            entity.ToTable("Header");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DanhMuc).HasMaxLength(1000);
            entity.Property(e => e.DanhMucCha).HasMaxLength(1000);
            entity.Property(e => e.DanhMucChaTa)
                .HasMaxLength(1000)
                .HasColumnName("DanhMucChaTA");
            entity.Property(e => e.DanhMucTa)
                .HasMaxLength(1000)
                .HasColumnName("DanhMucTA");
            entity.Property(e => e.Link).HasColumnName("link");
            entity.Property(e => e.Stt).HasColumnName("STT");
        });

        modelBuilder.Entity<HoTroDienThoai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HoTroDie__3214EC07B4D4F3D9");

            entity.ToTable("HoTroDienThoai");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SoDienThoai).HasMaxLength(1000);
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.Ten).HasMaxLength(1000);
        });

        modelBuilder.Entity<HoTroUngDung>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HoTroUng__3214EC078A0ADF16");

            entity.ToTable("HoTroUngDung");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code)
                .HasMaxLength(1000)
                .HasColumnName("CODE");
            entity.Property(e => e.LoaiUngDung).HasMaxLength(1000);
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.Ten).HasMaxLength(1000);
        });

        modelBuilder.Entity<LichSuPhatTrien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LichSuPh__3214EC074A3ACB2B");

            entity.ToTable("LichSuPhatTrien");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NoiDungTa)
                .HasMaxLength(2000)
                .HasColumnName("NoiDungTA");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDe).HasMaxLength(2000);
            entity.Property(e => e.TieuDeTa)
                .HasMaxLength(2000)
                .HasColumnName("TieuDeTA");
            entity.Property(e => e.TomTat).HasMaxLength(2000);
            entity.Property(e => e.TomTatTa)
                .HasMaxLength(2000)
                .HasColumnName("TomTatTA");
        });

        modelBuilder.Entity<LogOn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LogOn__3213E83FE90E29F4");

            entity.ToTable("LogOn");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Password).HasMaxLength(1000);
            entity.Property(e => e.RePass).HasMaxLength(1000);
            entity.Property(e => e.UserName).HasMaxLength(1000);
            entity.Property(e => e.VerificationCode)
                .HasMaxLength(1000)
                .IsFixedLength();
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Menu__3213E83F67FEBBEE");

            entity.ToTable("Menu");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdCha).HasColumnName("id_cha");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TenMenu).HasMaxLength(2000);
            entity.Property(e => e.TenMenuTa).HasMaxLength(2000);
            entity.Property(e => e.TieuDe).HasMaxLength(2000);

            entity.HasOne(d => d.IdChaNavigation).WithMany(p => p.InverseIdChaNavigation)
                .HasForeignKey(d => d.IdCha)
                .HasConstraintName("FK__Menu__id_cha__02084FDA");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SanPham__3214EC07E68570BA");

            entity.ToTable("SanPham");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NoiDungTa)
                .HasMaxLength(2000)
                .HasColumnName("NoiDungTA");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDe).HasMaxLength(2000);
            entity.Property(e => e.TieuDeTa)
                .HasMaxLength(2000)
                .HasColumnName("TieuDeTA");
            entity.Property(e => e.TomTat).HasMaxLength(2000);
            entity.Property(e => e.TomTatTa)
                .HasMaxLength(2000)
                .HasColumnName("TomTatTA");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__setting__3214EC07278A0D9E");

            entity.ToTable("setting");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsHienThi).HasColumnName("isHienThi");
            entity.Property(e => e.KyHieu).HasMaxLength(2000);
            entity.Property(e => e.NoiDung).HasColumnName("noi_dung");
            entity.Property(e => e.NoiDungTa).HasColumnName("noi_dung_ta");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDeTa).HasColumnName("tieuDeTa");
            entity.Property(e => e.TomTat).HasColumnName("tomTat");
            entity.Property(e => e.TomTatTa).HasColumnName("tomTatTa");
        });

        modelBuilder.Entity<TaiKhoanDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiKhoan__3214EC076782FBB2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(300);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.HoTen).HasMaxLength(1000);
            entity.Property(e => e.Password).HasMaxLength(1000);
            entity.Property(e => e.SoDienThoai).HasMaxLength(200);
            entity.Property(e => e.Username).HasMaxLength(1000);
        });

        modelBuilder.Entity<TaiSaoBanChon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiSaoBa__3214EC07EAB3944F");

            entity.ToTable("TaiSaoBanChon");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NoiDungTa)
                .HasMaxLength(2000)
                .HasColumnName("NoiDungTA");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDe).HasMaxLength(2000);
            entity.Property(e => e.TieuDeTa)
                .HasMaxLength(2000)
                .HasColumnName("TieuDeTA");
            entity.Property(e => e.TomTat).HasMaxLength(2000);
            entity.Property(e => e.TomTatTa)
                .HasMaxLength(2000)
                .HasColumnName("TomTatTA");
        });

        modelBuilder.Entity<ThietLapChung>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ThietLap__3214EC07464F2F76");

            entity.ToTable("ThietLapChung");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DiaChi)
                .HasMaxLength(2000)
                .HasColumnName("dia_chi");
            entity.Property(e => e.DiaChiTa)
                .HasMaxLength(2000)
                .HasColumnName("dia_chi_ta");
            entity.Property(e => e.Email)
                .HasMaxLength(2000)
                .HasColumnName("email");
            entity.Property(e => e.Fax)
                .HasMaxLength(2000)
                .HasColumnName("fax");
            entity.Property(e => e.LinkFacebook).HasMaxLength(1000);
            entity.Property(e => e.LinkYoutube).HasMaxLength(1000);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(2000)
                .HasColumnName("so_dien_thoai");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TenWebsite).HasMaxLength(1000);
            entity.Property(e => e.TenWebsiteTa)
                .HasMaxLength(1000)
                .HasColumnName("TenWebsiteTA");
            entity.Property(e => e.Title).HasMaxLength(1000);
            entity.Property(e => e.TitleTa)
                .HasMaxLength(1000)
                .HasColumnName("TitleTA");
        });

        modelBuilder.Entity<ThongTinBaiViet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ThongTin__3214EC07EF0407FF");

            entity.ToTable("ThongTinBaiViet");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.KyHieu).HasMaxLength(100);
            entity.Property(e => e.LoaiBaiViet)
                .HasMaxLength(2000)
                .HasColumnName("loai_bai_viet");
            entity.Property(e => e.NgayDang)
                .HasColumnType("datetime")
                .HasColumnName("ngay_dang");
            entity.Property(e => e.NoiDungTa).HasColumnName("NoiDungTA");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDe).HasMaxLength(2000);
            entity.Property(e => e.TieuDeTa)
                .HasMaxLength(2000)
                .HasColumnName("TieuDeTA");
            entity.Property(e => e.TomTatTa).HasColumnName("TomTatTA");
        });

        modelBuilder.Entity<ThongTinTrangChu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ThongTin__3214EC07B4BECE21");

            entity.ToTable("ThongTinTrangChu");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsHienThiTrangChu).HasColumnName("isHienThiTrangChu");
            entity.Property(e => e.KyHieu).HasMaxLength(100);
            entity.Property(e => e.Link)
                .HasMaxLength(1000)
                .HasColumnName("link");
            entity.Property(e => e.Ma).HasMaxLength(1000);
            entity.Property(e => e.Nhom)
                .HasMaxLength(2000)
                .HasColumnName("nhom");
            entity.Property(e => e.NoiDungTa).HasColumnName("NoiDungTA");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDe).HasMaxLength(2000);
            entity.Property(e => e.TieuDeTa)
                .HasMaxLength(2000)
                .HasColumnName("TieuDeTA");
            entity.Property(e => e.TomTatTa).HasColumnName("TomTatTA");
        });

        modelBuilder.Entity<TinVeGiaoDucDaoTao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TinVeGia__3214EC07DE1872AE");

            entity.ToTable("TinVeGiaoDucDaoTao");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NgayDangTin).HasColumnType("date");
            entity.Property(e => e.NoiDungTa)
                .HasMaxLength(2000)
                .HasColumnName("NoiDungTA");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDe).HasMaxLength(2000);
            entity.Property(e => e.TieuDeTa)
                .HasMaxLength(2000)
                .HasColumnName("TieuDeTA");
            entity.Property(e => e.TomTat).HasMaxLength(2000);
            entity.Property(e => e.TomTatTa)
                .HasMaxLength(2000)
                .HasColumnName("TomTatTA");
        });

        modelBuilder.Entity<VanHoaVaHoatDongCongTy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VanHoaVa__3214EC0784173604");

            entity.ToTable("VanHoaVaHoatDongCongTy");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NoiDungTa)
                .HasMaxLength(2000)
                .HasColumnName("NoiDungTA");
            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.TieuDe).HasMaxLength(2000);
            entity.Property(e => e.TieuDeTa)
                .HasMaxLength(2000)
                .HasColumnName("TieuDeTA");
            entity.Property(e => e.TomTat).HasMaxLength(2000);
            entity.Property(e => e.TomTatTa)
                .HasMaxLength(2000)
                .HasColumnName("TomTatTA");
        });

        modelBuilder.Entity<YkienDanhGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__YKienDan__3213E83F283A364D");

            entity.ToTable("YKienDanhGia");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ChucVu).HasMaxLength(1000);
            entity.Property(e => e.DonVi).HasMaxLength(1000);
            entity.Property(e => e.HoTen).HasMaxLength(1000);
            entity.Property(e => e.IsHienThiTrangChu).HasColumnName("isHienThiTrangChu");
            entity.Property(e => e.Ngay)
                .HasColumnType("datetime")
                .HasColumnName("ngay");
            entity.Property(e => e.NoiDungTa)
                .HasMaxLength(2000)
                .HasColumnName("noi_dung_ta");
            entity.Property(e => e.TomTat)
                .HasMaxLength(2000)
                .HasColumnName("tom_tat");
            entity.Property(e => e.TomTatTa)
                .HasMaxLength(2000)
                .HasColumnName("tom_tat_ta");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
