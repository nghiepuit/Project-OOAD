namespace QuanLyLinhKienMayTinh.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnullablekhachhangmatv : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KhachHang", "MaTV", "dbo.ThanhVien");
            DropIndex("dbo.KhachHang", new[] { "MaTV" });
            AlterColumn("dbo.KhachHang", "MaTV", c => c.Int());
            CreateIndex("dbo.KhachHang", "MaTV");
            AddForeignKey("dbo.KhachHang", "MaTV", "dbo.ThanhVien", "MaTV");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KhachHang", "MaTV", "dbo.ThanhVien");
            DropIndex("dbo.KhachHang", new[] { "MaTV" });
            AlterColumn("dbo.KhachHang", "MaTV", c => c.Int(nullable: false));
            CreateIndex("dbo.KhachHang", "MaTV");
            AddForeignKey("dbo.KhachHang", "MaTV", "dbo.ThanhVien", "MaTV", cascadeDelete: true);
        }
    }
}
