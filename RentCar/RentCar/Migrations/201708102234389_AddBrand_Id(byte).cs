namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrand_Idbyte : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Brand_", c => c.Short(nullable: false));
            DropForeignKey("dbo.Cars", "Brand_Id1", "dbo.Brands");
            DropIndex("dbo.Cars", new[] { "Brand_Id1" });
            AlterColumn("dbo.Cars", "Brand_Id", c => c.Int());
            DropColumn("dbo.Cars", "Brand_Id1");
            CreateIndex("dbo.Cars", "Brand_Id");
            AddForeignKey("dbo.Cars", "Brand_Id", "dbo.Brands", "Id");
        }
    }
}
