namespace MarvelCatalog_App.Data.Migrations
{
    using Marvel_Catalog_App.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MarvelCatalog_App.Data.EfMarvelCatalogDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        private void SeedUsers(EfMarvelCatalogDbContext context)
        {
        }

        private void SeedSampleCharacters(EfMarvelCatalogDbContext context)
        {
            var character = new CharacterDataModel();
            
            character.Name = "Iron Man";
            character.isDeleted = false;
            character.Image = "https://upload.wikimedia.org/wikipedia/en/e/e0/Iron_Man_bleeding_edge.jpg";
            character.CreatedOn = DateTime.Now;
            character.Description = "Iron Man is a 2008 American superhero film based on the Marvel Comics character of the same name, produced by Marvel Studios and distributed by Paramount Pictures.1 It is the first film in the Marvel Cinematic Universe. The film was directed by Jon Favreau, with a screenplay by the writing teams of Mark Fergus and Hawk Ostby and Art Marcum and Matt Holloway. It stars Robert Downey Jr., Terrence Howard, Jeff Bridges, Shaun Toub, and Gwyneth Paltrow. In Iron Man, Tony Stark, an industrialist and master engineer, builds a powered exoskeleton and becomes the technologically advanced superhero Iron Man.";

            context.Characters.Add(character);

            context.SaveChanges();
        }

        protected override void Seed(EfMarvelCatalogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //this.SeedUsers(context);
            //this.SeedSampleCharacters(context);
        }
    }
}
