namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheemodelbackingtheApplicationDbContextcontexthaschangedsincethedatabasewascreated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Cars", new[] { "Brand_Id" });
            AlterColumn("dbo.Brands", "Name", c => c.String());
            AlterColumn("dbo.Brands", "Version", c => c.String());
            AlterColumn("dbo.Cars", "Brand_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Brand_Id");
            AddForeignKey("dbo.Cars", "Brand_Id", "dbo.Brands", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Cars", new[] { "Brand_Id" });
            AlterColumn("dbo.Cars", "Brand_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Brands", "Version", c => c.String(nullable: false));
            AlterColumn("dbo.Brands", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Cars", "Brand_Id");
            AddForeignKey("dbo.Cars", "Brand_Id", "dbo.Brands", "Id", cascadeDelete: true);
        }
    }
}
