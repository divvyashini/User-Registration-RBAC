namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDefaultTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "UserClaim");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserClaim", newName: "AspNetUsers");
        }
    }
}
