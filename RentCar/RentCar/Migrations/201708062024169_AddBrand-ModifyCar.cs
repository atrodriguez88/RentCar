namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrandModifyCar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "Stock", c => c.Short(nullable: false));
            AddColumn("dbo.Cars", "Brand_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "Brand_Id");
            AddForeignKey("dbo.Cars", "Brand_Id", "dbo.Brands", "Id", cascadeDelete: true);
            DropColumn("dbo.Cars", "Brand");
            DropColumn("dbo.Cars", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Year", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "Brand", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Cars", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Cars", new[] { "Brand_Id" });
            DropColumn("dbo.Cars", "Brand_Id");
            DropColumn("dbo.Cars", "Stock");
            DropColumn("dbo.Cars", "ReleaseDate");
            DropTable("dbo.Brands");
        }
    }
}
