using Marvel_Catalog_App.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Data.Repositories
{
    public interface IEfRepository<T> where T : class, IDeletable
    {
        IEnumerable<T> All { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
