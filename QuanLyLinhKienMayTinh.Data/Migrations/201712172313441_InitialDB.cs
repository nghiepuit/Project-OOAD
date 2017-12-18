namespace QuanLyLinhKienMayTinh.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BinhLuan",
                c => new
                    {
                        MaBL = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(nullable: false),
                        MaTV = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaBL)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: true)
                .ForeignKey("dbo.ThanhVien", t => t.MaTV, cascadeDelete: true)
                .Index(t => t.MaTV)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NgayCapNhat = c.DateTime(nullable: false),
                        CauHinh = c.String(),
                        MoTa = c.String(),
                        HinhAnh = c.String(),
                        SoLuongTon = c.Int(nullable: false),
                        LuotXem = c.Int(nullable: false),
                        LuotBinhChon = c.Int(nullable: false),
                        LuotBinhLuan = c.Int(nullable: false),
                        SoLanMua = c.Int(nullable: false),
                        Moi = c.Boolean(nullable: false),
                        MaNCC = c.Int(nullable: false),
                        MaNSX = c.Int(nullable: false),
                        MaLSP = c.Int(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.LoaiSanPham", t => t.MaLSP, cascadeDelete: true)
                .ForeignKey("dbo.NhaCungCap", t => t.MaNCC, cascadeDelete: true)
                .ForeignKey("dbo.NhaSanXuat", t => t.MaNSX, cascadeDelete: true)
                .Index(t => t.MaNCC)
                .Index(t => t.MaNSX)
                .Index(t => t.MaLSP);
            
            CreateTable(
                "dbo.LoaiSanPham",
                c => new
                    {
                        MaLSP = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false),
                        Icon = c.String(),
                        BiDanh = c.String(),
                    })
                .PrimaryKey(t => t.MaLSP);
            
            CreateTable(
                "dbo.NhaCungCap",
                c => new
                    {
                        MaNCC = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        Email = c.String(),
                        DienThoai = c.String(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.NhaSanXuat",
                c => new
                    {
                        MaNSX = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false),
                        ThongTin = c.String(),
                        Logo = c.String(),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaNSX);
            
            CreateTable(
                "dbo.ThanhVien",
                c => new
                    {
                        MaTV = c.Int(nullable: false, identity: true),
                        TaiKhoan = c.String(nullable: false),
                        MatKhau = c.String(nullable: false),
                        HoTen = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        Email = c.String(),
                        DienThoai = c.String(),
                        MaLTV = c.Int(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                        CauHoi = c.String(),
                        CauTraLoi = c.String(),
                    })
                .PrimaryKey(t => t.MaTV)
                .ForeignKey("dbo.LoaiThanhVien", t => t.MaLTV, cascadeDelete: true)
                .Index(t => t.MaLTV);
            
            CreateTable(
                "dbo.LoaiThanhVien",
                c => new
                    {
                        MaLTV = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false),
                        KhuyenMai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaLTV);
            
            CreateTable(
                "dbo.ChiTietDonDatHang",
                c => new
                    {
                        MaCTDDH = c.Int(nullable: false, identity: true),
                        MaDDH = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                        TenSP = c.String(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaCTDDH)
                .ForeignKey("dbo.DonDatHang", t => t.MaDDH, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: true)
                .Index(t => t.MaDDH)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.DonDatHang",
                c => new
                    {
                        MaDDH = c.Int(nullable: false, identity: true),
                        NgayDatHang = c.DateTime(nullable: false),
                        TinhTrangGiaoHang = c.Boolean(nullable: false),
                        NgayGiaoHang = c.DateTime(nullable: false),
                        DaThanhToan = c.Boolean(nullable: false),
                        MaKH = c.Int(nullable: false),
                        UuDai = c.Int(nullable: false),
                        DaHuy = c.Boolean(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaDDH)
                .ForeignKey("dbo.KhachHang", t => t.MaKH, cascadeDelete: true)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false),
                        DiaChi = c.String(),
                        Email = c.String(),
                        DienThoai = c.String(),
                        MaTV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH)
                .ForeignKey("dbo.ThanhVien", t => t.MaTV, cascadeDelete: true)
                .Index(t => t.MaTV);
            
            CreateTable(
                "dbo.ChiTietPhieuNhap",
                c => new
                    {
                        MaCTPN = c.Int(nullable: false, identity: true),
                        MaPN = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                        DonGiaNhap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SoLuongNhap = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaCTPN)
                .ForeignKey("dbo.PhieuNhap", t => t.MaPN, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: true)
                .Index(t => t.MaPN)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.PhieuNhap",
                c => new
                    {
                        MaPN = c.Int(nullable: false, identity: true),
                        MaNCC = c.Int(nullable: false),
                        NgayNhap = c.DateTime(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaPN)
                .ForeignKey("dbo.NhaCungCap", t => t.MaNCC, cascadeDelete: false)
                .Index(t => t.MaNCC);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietPhieuNhap", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.ChiTietPhieuNhap", "MaPN", "dbo.PhieuNhap");
            DropForeignKey("dbo.PhieuNhap", "MaNCC", "dbo.NhaCungCap");
            DropForeignKey("dbo.ChiTietDonDatHang", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.ChiTietDonDatHang", "MaDDH", "dbo.DonDatHang");
            DropForeignKey("dbo.DonDatHang", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.KhachHang", "MaTV", "dbo.ThanhVien");
            DropForeignKey("dbo.BinhLuan", "MaTV", "dbo.ThanhVien");
            DropForeignKey("dbo.ThanhVien", "MaLTV", "dbo.LoaiThanhVien");
            DropForeignKey("dbo.BinhLuan", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.SanPham", "MaNSX", "dbo.NhaSanXuat");
            DropForeignKey("dbo.SanPham", "MaNCC", "dbo.NhaCungCap");
            DropForeignKey("dbo.SanPham", "MaLSP", "dbo.LoaiSanPham");
            DropIndex("dbo.PhieuNhap", new[] { "MaNCC" });
            DropIndex("dbo.ChiTietPhieuNhap", new[] { "MaSP" });
            DropIndex("dbo.ChiTietPhieuNhap", new[] { "MaPN" });
            DropIndex("dbo.KhachHang", new[] { "MaTV" });
            DropIndex("dbo.DonDatHang", new[] { "MaKH" });
            DropIndex("dbo.ChiTietDonDatHang", new[] { "MaSP" });
            DropIndex("dbo.ChiTietDonDatHang", new[] { "MaDDH" });
            DropIndex("dbo.ThanhVien", new[] { "MaLTV" });
            DropIndex("dbo.SanPham", new[] { "MaLSP" });
            DropIndex("dbo.SanPham", new[] { "MaNSX" });
            DropIndex("dbo.SanPham", new[] { "MaNCC" });
            DropIndex("dbo.BinhLuan", new[] { "MaSP" });
            DropIndex("dbo.BinhLuan", new[] { "MaTV" });
            DropTable("dbo.PhieuNhap");
            DropTable("dbo.ChiTietPhieuNhap");
            DropTable("dbo.KhachHang");
            DropTable("dbo.DonDatHang");
            DropTable("dbo.ChiTietDonDatHang");
            DropTable("dbo.LoaiThanhVien");
            DropTable("dbo.ThanhVien");
            DropTable("dbo.NhaSanXuat");
            DropTable("dbo.NhaCungCap");
            DropTable("dbo.LoaiSanPham");
            DropTable("dbo.SanPham");
            DropTable("dbo.BinhLuan");
        }
    }
}
