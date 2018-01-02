namespace QuanLyLinhKienMayTinh.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addngaygiaohangnullableok : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DonDatHang", "NgayGiaoHang", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
