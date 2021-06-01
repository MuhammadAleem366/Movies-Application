namespace MVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENREs(id,name) VALUES(1,'Horror')");
            Sql("INSERT INTO GENREs(id,name) VALUES(2,'Crime')");
            Sql("INSERT INTO GENREs(id,name) VALUES(3,'Action')");
            Sql("INSERT INTO GENREs(id,name) VALUES(4,'Romance')");
            Sql("INSERT INTO GENREs(id,name) VALUES(5,'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
