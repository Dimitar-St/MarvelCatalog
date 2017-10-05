namespace MarvelCatalog_App.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iaddednewuserfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharacterDataModels", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.ComicsDataModels", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CharacterDataModels", "User_Id");
            CreateIndex("dbo.ComicsDataModels", "User_Id");
            AddForeignKey("dbo.CharacterDataModels", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ComicsDataModels", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComicsDataModels", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CharacterDataModels", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ComicsDataModels", new[] { "User_Id" });
            DropIndex("dbo.CharacterDataModels", new[] { "User_Id" });
            DropColumn("dbo.ComicsDataModels", "User_Id");
            DropColumn("dbo.CharacterDataModels", "User_Id");
        }
    }
}
