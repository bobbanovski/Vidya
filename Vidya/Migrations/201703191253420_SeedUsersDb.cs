namespace Vidya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersDb : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'd218431b-90f0-4284-84ba-dd411c2b3a7c', N'robert.coleman1@uqconnect.edu.au', 0, N'APMjbUIGBAVbixjijHRAeE0bc+UOqZqx9nUN/b5BdKxpE7n5Up9evpWf93IJOlX3FA==', N'c3b5af1e-1d11-41dc-92ab-be1f32288ed1', NULL, 0, 0, NULL, 1, 0, N'demo@demo.demo')");

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cc9d4ae1-78e0-4c75-9cd0-e3b5b38b17c9', N'ManageVideos')");

            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd218431b-90f0-4284-84ba-dd411c2b3a7c', N'cc9d4ae1-78e0-4c75-9cd0-e3b5b38b17c9')");
        }
        
        public override void Down()
        {
        }
    }
}
