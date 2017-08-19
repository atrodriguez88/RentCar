namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrand_IdInCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Brand_Id_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Brand_Id_Id");
            AddForeignKey("dbo.Cars", "Brand_Id_Id", "dbo.Brands", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Brand_Id_Id", "dbo.Brands");
            DropIndex("dbo.Cars", new[] { "Brand_Id_Id" });
            DropColumn("dbo.Cars", "Brand_Id_Id");
        }
    }
}
