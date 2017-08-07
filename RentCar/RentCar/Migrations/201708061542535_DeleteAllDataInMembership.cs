namespace RentCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAllDataInMembership : DbMigration
    {
        public override void Up()
        {
            //Sql("Delete from Customers");
            //Sql("Delete from MembershipTypes");
            Sql("Insert Into MembershipTypes (SignUpFee,DurationInMonths,DiscountRate) values ('Pay as You Go',0,0,0)");
            Sql("Insert Into MembershipTypes(SignUpFee,DurationInMonths,DiscountRate) values ('Yearly',30,1,10)");
            Sql("Insert Into MembershipTypes(SignUpFee,DurationInMonths,DiscountRate) values ('Monthly',90,3,15)");
            Sql("Insert Into MembershipTypes(SignUpFee,DurationInMonths,DiscountRate) values ('Weekly',300,12,20)");

        }
        
        public override void Down()
        {
        }
    }
}
