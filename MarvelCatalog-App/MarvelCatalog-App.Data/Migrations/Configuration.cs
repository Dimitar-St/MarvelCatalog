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
