namespace QuanLyLinhKienMayTinh.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ThongKeDoanhThuLoiNhuan : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE FUNCTION dbo.LayGiaGoc(@MaSP int)
                RETURNS int
                AS
                BEGIN
                DECLARE @result int;
                SELECT @result = ROUND(SUM(ctpn.DonGiaNhap * ctpn.SoLuongNhap) / SUM(ctpn.SoLuongNhap), 2)
                FROM PhieuNhap pn
                INNER JOIN ChiTietPhieuNhap ctpn
                ON pn.MaPN = ctpn.MaPN
                WHERE MaSP = @MaSP
                RETURN @result;
                END"
            );

            CreateStoredProcedure("ThongKeDoanhThuLoiNhuan", p => new { fromDate = p.String(), toDate = p.String() },
            @"
                SELECT 
                ddh.NgayDatHang as Ngay,
                SUM(ctddh.SoLuong * ctddh.DonGia) as DoanhThu,
                SUM((ctddh.SoLuong * ctddh.DonGia) - (ctddh.SoLuong * dbo.LayGiaGoc(sp.MaSP))) as LoiNhuan
                FROM DonDatHang ddh
                INNER JOIN ChiTietDonDatHang ctddh
                ON ddh.MaDDH = ctddh.MaDDH
                INNER JOIN SanPham sp
                ON ctddh.MaSP = sp.MaSP
                WHERE ddh.NgayDatHang <= cast(@toDate as date) and ddh.NgayDatHang >= cast(@fromDate as date)
                group by ddh.NgayDatHang"
            );
        }

        public override void Down()
        {
        }
    }
}