namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeekBrands : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Brands (Name,Version) values ('Toyota','Corolla')");
            Sql("Insert Into Brands (Name,Version) values ('Dogde','Gran Caravan')");
            Sql("Insert Into Brands (Name,Version) values ('Honda','Lexus')");
            Sql("Insert Into Brands (Name,Version) values ('BMW','LI')");
            Sql("Insert Into Brands (Name,Version) values ('Mercedes','LEv2')");
        }
        
        public override void Down()
        {
        }
    }
}
