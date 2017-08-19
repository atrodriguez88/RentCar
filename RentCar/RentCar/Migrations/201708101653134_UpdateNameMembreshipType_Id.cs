namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameMembreshipType_Id : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from Customers");
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            AddColumn("dbo.Customers", "MembershipType_Id1", c => c.Int());
            AlterColumn("dbo.Customers", "MembershipType_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipType_Id1");
            AddForeignKey("dbo.Customers", "MembershipType_Id1", "dbo.MembershipTypes", "Id");
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipType_Id1", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id1" });
            AlterColumn("dbo.Customers", "MembershipType_Id", c => c.Int());
            DropColumn("dbo.Customers", "MembershipType_Id1");
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
