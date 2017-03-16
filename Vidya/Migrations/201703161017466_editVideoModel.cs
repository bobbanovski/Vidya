namespace Vidya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editVideoModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Genre", c => c.String());
            AddColumn("dbo.Videos", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Videos", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Videos", "DateAdded", c => c.DateTime(nullable: false));
            Sql("UPDATE Videos SET Genre = 'Documentary' WHERE Id = 1");
            Sql("UPDATE Videos SET NumberInStock = 3 WHERE Id = 1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "DateAdded");
            DropColumn("dbo.Videos", "ReleaseDate");
            DropColumn("dbo.Videos", "NumberInStock");
            DropColumn("dbo.Videos", "Genre");
        }
    }
}
