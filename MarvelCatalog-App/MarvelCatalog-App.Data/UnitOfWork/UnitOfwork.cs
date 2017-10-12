using Bytes2you.Validation;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Contracts;
using MarvelCatalog_App.Data.Repositories;
using System;

namespace MarvelCatalog_App.Data.UnitOfWork
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly IEfMarvelCatalogDbContext dbContext;

        public UnitOfwork(IEfMarvelCatalogDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, nameof(dbContext)).IsNull().Throw();

            this.dbContext = dbContext;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }
    }
}
