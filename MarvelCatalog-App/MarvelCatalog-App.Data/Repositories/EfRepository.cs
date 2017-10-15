using Marvel_Catalog_App.Data.Models.Contracts;
using MarvelCatalog_App.Data.Contracts;
using MarvelCatalog_App.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections;
using Bytes2you.Validation;

namespace MarvelCatalog_App.Data.Repositories
{
    public class EfRepository<T> : IEfRepository<T>, IEnumerable<T>
          where T : class, IDeletable
    {
        private readonly IEfMarvelCatalogDbContext dbContext;
        private readonly IDbSet<T> dbSet;

        public EfRepository(IEfMarvelCatalogDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, nameof(dbContext)).IsNull().Throw();

            this.dbSet = dbContext.GetSet<T>();
            this.dbContext = dbContext;
        }
        
        public IEnumerable<T> All
        {
            get
            {
                return this.dbContext.GetSet<T>().Select(x => x).ToList();
            }
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            this.dbSet.Attach(entity);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
