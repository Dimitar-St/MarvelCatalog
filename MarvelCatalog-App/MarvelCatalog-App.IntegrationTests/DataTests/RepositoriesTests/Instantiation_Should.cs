using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data;
using MarvelCatalog_App.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.IntegrationTests.DataTests.RepositoriesTests
{
    [TestFixture]
    public class Instantiation_Should
    {
        [Test]
        public void ThrowArgumentNullEcpetion_WhenIsPassedInvalidValue()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new EfRepository<CharacterDataModel>(null));
        }

        [Test]
        public void CreateCorrectlyRepository_WhenDbContextIsNotNull()
        {
            // Arrange
            var dbContext = new EfMarvelCatalogDbContext();

            // Act and Assert
            Assert.DoesNotThrow(() => new EfRepository<CharacterDataModel>(dbContext));
        }

        [Test]
        public void CreateInstance_OfTypeIEfRepository()
        {
            // Arrange
            var dbContext = new EfMarvelCatalogDbContext();

            // Act
            var unitOfWork = new EfRepository<CharacterDataModel>(dbContext);

            // Assert
            Assert.IsInstanceOf<IEfRepository<CharacterDataModel>>(unitOfWork);
        }
    }
}
