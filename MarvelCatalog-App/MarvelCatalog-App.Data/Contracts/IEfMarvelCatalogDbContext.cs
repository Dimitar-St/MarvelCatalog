using Marvel_Catalog_App.Data.API.Models;
using Marvel_Catalog_App.Data.API.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Data.Contracts
{
    public interface IEfMarvelCatalogDbContext
    {
        IDbSet<CharacterDataModel> Characters { get; set; }

        IDbSet<T> GetSet<T>() where T : class, IDeletable;
    }
}
