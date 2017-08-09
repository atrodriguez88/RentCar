namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NowOKwithBrandModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Brands", "Name", c => c.String(nullable: false));
        }
    }
}
