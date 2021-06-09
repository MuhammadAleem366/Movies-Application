namespace MVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNumberAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("Update movies set MoviesAvailable = InStock ");
        }
        
        public override void Down()
        {
        }
    }
}
