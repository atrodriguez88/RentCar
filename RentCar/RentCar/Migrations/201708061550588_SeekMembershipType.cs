namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeekMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into MembershipTypes (Name,SignUpFee,DurationInMonths,DiscountRate) values ('Pay as You Go',0,0,0)");
            Sql("Insert Into MembershipTypes(Name,SignUpFee,DurationInMonths,DiscountRate) values ('Yearly',30,1,10)");
            Sql("Insert Into MembershipTypes(Name,SignUpFee,DurationInMonths,DiscountRate) values ('Monthly',90,3,15)");
            Sql("Insert Into MembershipTypes(Name,SignUpFee,DurationInMonths,DiscountRate) values ('Weekly',300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
