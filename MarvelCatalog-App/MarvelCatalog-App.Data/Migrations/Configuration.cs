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
        private const string AdministratorUserName = "info@telerikacademy.com";
        private const string AdministratorPassword = "123456";


        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        private void SeedUsers(EfMarvelCatalogDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedSampleCreators(EfMarvelCatalogDbContext context)
        {
                var description = "Gillen cited inspiration from I, Claudius,[6] The Godfather,[7] and the TV series House of Cards in portraying the internal machinations of the Empire. If Jason Aaron's concurrent Star Wars comic depicts Vader on 'a Tuesday,' then Gillen's series shows the relatively mundane politics he must grapple with during the rest of the week. He mentioned Vader's antagonists include the military officials who do not believe in the Force.[1]";
                
                var creator = new CreatorsDataModel("Jessica Abel", "https://upload.wikimedia.org/wikipedia/commons/3/38/JessicaAbel4-29-11.jpg", 40, description, "Career", new Dictionary<string, string>());

                context.Creators.Add(creator);

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
            //this.SeedSampleCreators(context);
        }
    }
}
