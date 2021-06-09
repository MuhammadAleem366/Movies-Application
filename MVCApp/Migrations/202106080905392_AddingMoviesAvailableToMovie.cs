namespace MVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMoviesAvailableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MoviesAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE movies Set MoviesAvailable = InStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MoviesAvailable");
        }
    }
}
