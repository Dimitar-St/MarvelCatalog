namespace MarvelCatalog_App.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IaddednewpropertiesontheCharacterDataModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CharacterDataModels", "AbilitiesDesctiption", c => c.String());
            AddColumn("dbo.CharacterDataModels", "Powers", c => c.String());
            AddColumn("dbo.CharacterDataModels", "Origin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CharacterDataModels", "Origin");
            DropColumn("dbo.CharacterDataModels", "Powers");
            DropColumn("dbo.CharacterDataModels", "AbilitiesDesctiption");
        }
    }
}
