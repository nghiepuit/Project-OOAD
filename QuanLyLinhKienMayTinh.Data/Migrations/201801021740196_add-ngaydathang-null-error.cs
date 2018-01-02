namespace QuanLyLinhKienMayTinh.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addngaydathangnullerror : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonDatHang", "NgayDatHang", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DonDatHang", "NgayGiaoHang", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DonDatHang", "NgayGiaoHang", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DonDatHang", "NgayDatHang", c => c.DateTime(nullable: false));
        }
    }
}
