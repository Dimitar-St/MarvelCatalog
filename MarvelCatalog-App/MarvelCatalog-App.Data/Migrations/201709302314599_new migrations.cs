namespace MarvelCatalog_App.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigrations : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AspNetUsers", "isDeleted");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "isDeleted" });
        }
    }
}
