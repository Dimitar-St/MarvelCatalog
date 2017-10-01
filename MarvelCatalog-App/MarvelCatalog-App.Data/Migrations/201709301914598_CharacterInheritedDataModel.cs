namespace MarvelCatalog_App.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterInheritedDataModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharacterDataModels", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.CharacterDataModels", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.CharacterDataModels", "isDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.CharacterDataModels", "ModifiedOn", c => c.DateTime());
            CreateIndex("dbo.CharacterDataModels", "isDeleted");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CharacterDataModels", new[] { "isDeleted" });
            DropColumn("dbo.CharacterDataModels", "ModifiedOn");
            DropColumn("dbo.CharacterDataModels", "isDeleted");
            DropColumn("dbo.CharacterDataModels", "DeletedOn");
            DropColumn("dbo.CharacterDataModels", "CreatedOn");
        }
    }
}
