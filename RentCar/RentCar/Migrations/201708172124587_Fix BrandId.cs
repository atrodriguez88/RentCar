namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixBrandId : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from Cars");
            Sql("Delete from Customers");
            DropIndex("dbo.Cars", new[] { "Brand_Id1" });
            DropColumn("dbo.Cars", "Brand_Id");
            RenameColumn(table: "dbo.Cars", name: "Brand_Id1", newName: "Brand_Id");
            AddColumn("dbo.Cars", "BrandId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Cars", "Brand_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Brand_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cars", new[] { "Brand_Id" });
            AlterColumn("dbo.Cars", "Brand_Id", c => c.Byte(nullable: false));
            DropColumn("dbo.Cars", "BrandId");
            RenameColumn(table: "dbo.Cars", name: "Brand_Id", newName: "Brand_Id1");
            AddColumn("dbo.Cars", "Brand_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Cars", "Brand_Id1");
        }
    }
}
