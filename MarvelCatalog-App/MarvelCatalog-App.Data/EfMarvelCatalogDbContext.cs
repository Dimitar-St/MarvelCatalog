using Marvel_Catalog_App.Data.API.Models;
using Marvel_Catalog_App.Data.API.Models.Contracts;
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

        public static EfMarvelCatalogDbContext Create()
        {
            return new EfMarvelCatalogDbContext();
        }

        public IDbSet<T> GetSet<T>() where T : class, IDeletable
        {
            return base.Set<T>();
        }

    }
}
