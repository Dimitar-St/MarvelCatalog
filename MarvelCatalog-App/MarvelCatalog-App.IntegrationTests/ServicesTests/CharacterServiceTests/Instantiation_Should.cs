using MarvelCatalog_App.Data;
using MarvelCatalog_App.Data.UnitOfWork;
using NUnit.Framework;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Repositories;
using MarvelCatalog_App.Services;
using MarvelCatalog_App.Services.Contracts;

namespace MarvelCatalog_App.IntegrationTests.ServicesTests.CharacterServiceTests
{
    [TestFixture]
    public class Instantiation_Should
    {
        [Test]
        public void ThrowArgumentNullEcpetion_WhenIsPassedInvalidUnitOfWork()
        {
            // Arrange
            var dbContext = new EfMarvelCatalogDbContext();
            var repository = new EfRepository<CharacterDataModel>(dbContext);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CharacterService(null, repository));
        }

        [Test]
        public void ThrowArgumentNullEcpetion_WhenIsPassedInvalidEfRepository()
        {
            // Arrange
            var dbContext = new EfMarvelCatalogDbContext();
            var unitOfWork = new UnitOfwork(dbContext);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CharacterService(unitOfWork, null));
        }

        [Test]
        public void CreateCorrectlyCharacterService_IfEfRepositoryIsNotNull()
        {
            var dbContext = new EfMarvelCatalogDbContext();
            var unitOfWork = new UnitOfwork(dbContext);
            var repository = new EfRepository<CharacterDataModel>(dbContext);

            Assert.DoesNotThrow(() => new CharacterService(unitOfWork, repository));
        }

        [Test]
        public void CreateInstance_OfTypeICharacterService()
        {
            var dbContext = new EfMarvelCatalogDbContext();
            var unitOfWork = new UnitOfwork(dbContext);
            var repository = new EfRepository<CharacterDataModel>(dbContext);

            var characterService = new CharacterService(unitOfWork, repository);

            Assert.IsInstanceOf<ICharacterService>(characterService);
        }

    }
}
