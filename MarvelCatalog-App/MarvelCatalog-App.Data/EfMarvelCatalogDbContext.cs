using Marvel_Catalog_App.Data.Models;
using Marvel_Catalog_App.Data.Models.Contracts;
using MarvelCatalog_App.Data.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Data
{
    public class EfMarvelCatalogDbContext : IdentityDbContext<User>, IEfMarvelCatalogDbContext
    {
        public EfMarvelCatalogDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<CharacterDataModel> Characters { get; set; }

        public IDbSet<ComicsDataModel> Comics { get; set; }

        public static EfMarvelCatalogDbContext Create()
        {
            return new EfMarvelCatalogDbContext();
        }

        public IDbSet<T> GetSet<T>() where T : class, IDeletable
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditableRules();

            return base.SaveChanges();
        }

        private void ApplyAuditableRules()
        {
            var auditables = this.ChangeTracker.Entries()
                   .Where(e =>
            e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in auditables)
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
