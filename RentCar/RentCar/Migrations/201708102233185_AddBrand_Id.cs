namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrand_Id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Brand_Id_Id", "dbo.Brands");
            DropIndex("dbo.Cars", new[] { "Brand_Id_Id" });
            AddColumn("dbo.Cars", "Brand_", c => c.Short(nullable: false));
            DropColumn("dbo.Cars", "Brand_Id_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Brand_Id_Id", c => c.Int());
            DropColumn("dbo.Cars", "Brand_");
            CreateIndex("dbo.Cars", "Brand_Id_Id");
            AddForeignKey("dbo.Cars", "Brand_Id_Id", "dbo.Brands", "Id");
        }
    }
}
