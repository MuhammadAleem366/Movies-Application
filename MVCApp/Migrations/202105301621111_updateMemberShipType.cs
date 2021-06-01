namespace MVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMemberShipType : DbMigration
    {
        public override void Up()
        {

            Sql("UPDATE MemberShipTypes SET Name='As Per Go' WHERE Id = 1");
            Sql("UPDATE MemberShipTypes SET Name='Monthly' WHERE Id = 2");
            Sql("UPDATE MemberShipTypes SET Name='Quarter' WHERE Id = 3");
            Sql("UPDATE MemberShipTypes SET Name='Annual' WHERE Id = 4");
            }
        
        public override void Down()
        {
        }
    }
}
