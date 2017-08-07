namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemodelbackingtheApplicationDbContextcontexthaschangedsincethedatabasewascreated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Brands", "Version", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Brands", "Version", c => c.String());
            AlterColumn("dbo.Brands", "Name", c => c.String());
        }
    }
}
