namespace Vidya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateDb : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Documentary')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Classic')");

            Sql("INSERT INTO Videos (Name, NumberInStock, ReleaseDate, DateAdded, GenreId) VALUES ('Die Hard', 3, 14/2/2000, 15/3/2000, 1)");

            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationMonths, DiscountRate, MembershipName) VALUES (1, 0, 0, 0, 'Pay as You Go')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationMonths, DiscountRate, MembershipName) VALUES (2, 30, 1, 10, 'Monthly')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationMonths, DiscountRate, MembershipName) VALUES (3, 90, 3, 15, 'Quarterly')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationMonths, DiscountRate, MembershipName) VALUES (4, 300, 12, 20, 'Annual')");
        }
        
        public override void Down()
        {
        }
    }
}
