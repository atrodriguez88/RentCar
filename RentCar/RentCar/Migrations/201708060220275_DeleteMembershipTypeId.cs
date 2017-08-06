namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMembershipTypeId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Brand", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "MembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AlterColumn("dbo.Cars", "Brand", c => c.String());
        }
    }
}
