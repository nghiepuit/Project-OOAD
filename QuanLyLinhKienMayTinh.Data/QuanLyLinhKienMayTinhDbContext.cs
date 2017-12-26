using QuanLyLinhKienMayTinh.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace QuanLyLinhKienMayTinh.Data
{
    public class QuanLyLinhKienMayTinhDbContext : DbContext
    {
        public QuanLyLinhKienMayTinhDbContext() : base("QuanLyLinhKienMayTinhConnection")
        {
            // load bản cha tự động include bản con
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<BinhLuan> BinhLuan { get; set; }
        public DbSet<ChiTietDonDatHang> ChiTietDonDatHang { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }
        public DbSet<DonDatHang> DonDatHang { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<LoaiThanhVien> LoaiThanhVien { get; set; }
        public DbSet<NhaCungCap> NhaCungCap { get; set; }
        public DbSet<NhaSanXuat> NhaSanXuat { get; set; }
        public DbSet<PhieuNhap> PhieuNhap { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<ThanhVien> ThanhVien { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}