using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Contracts;
using MarvelCatalog_App.Data.Repositories;
using System;

namespace MarvelCatalog_App.Data.UnitOfWork
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly IEfRepository<CharacterDataModel> characterRepository;
        private readonly IEfRepository<ComicsDataModel> comicsRepository;
        private readonly IEfRepository<CreatorsDataModel> creatorsRepository;
        private readonly IEfMarvelCatalogDbContext dbContext;

        public UnitOfwork(IEfMarvelCatalogDbContext dbContext, IEfRepository<CharacterDataModel> charactersRepository,
                          IEfRepository<ComicsDataModel> comicsRepository, IEfRepository<CreatorsDataModel> creatorsRepository)
        {
            this.dbContext = dbContext;
            this.characterRepository = charactersRepository;
            this.comicsRepository = comicsRepository;
            this.creatorsRepository = creatorsRepository;
        }

        public IEfRepository<CharacterDataModel> CharactersRepository
        {
            get
            {
                return this.characterRepository;
            }
        }

        public IEfRepository<ComicsDataModel> ComicsRepository
        {
            get
            {
                return this.comicsRepository;
            }
        }

        public IEfRepository<CreatorsDataModel> CreatorsRepository
        {
            get
            {
                return this.creatorsRepository;
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
