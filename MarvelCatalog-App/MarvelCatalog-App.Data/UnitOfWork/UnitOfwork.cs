using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Contracts;
using MarvelCatalog_App.Data.Repositories;
using System;

namespace MarvelCatalog_App.Data.UnitOfWork
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly IEfRepository<CharacterDataModel> characterRepository;
        private readonly IEfMarvelCatalogDbContext dbContext;

        public UnitOfwork(IEfMarvelCatalogDbContext dbContext, IEfRepository<CharacterDataModel> charactersRepository)
        {
            this.dbContext = dbContext;
            this.characterRepository = charactersRepository;
        }

        public IEfRepository<CharacterDataModel> CharactersRepository
        {
            get
            {
                return this.characterRepository;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
