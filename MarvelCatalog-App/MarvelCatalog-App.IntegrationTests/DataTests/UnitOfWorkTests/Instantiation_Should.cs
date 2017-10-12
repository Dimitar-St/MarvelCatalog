using MarvelCatalog_App.Data;
using MarvelCatalog_App.Data.UnitOfWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.IntegrationTests.DataTests.UnitOfWorkTests
{
    [TestFixture]
    public class Instantiation_Should
    {
        [Test]
        public void ThrowArgumentNullEcpetion_WhenIsPassedInvalidValue()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UnitOfwork(null));
        }

        [Test]
        public void CreateCorrectlyUnitOfWork_WhenDbContextIsNotNull()
        {
            // Arrange
            var dbContext = new EfMarvelCatalogDbContext();

            // Act and Assert
            Assert.DoesNotThrow(() => new UnitOfwork(dbContext));
        }

        [Test]
        public void CreateInstance_OfTypeIUnitOfWork()
        {
            // Arrange
            var dbContext = new EfMarvelCatalogDbContext();

            // Act
            var unitOfWork = new UnitOfwork(dbContext);

            // Assert
            Assert.IsInstanceOf<IUnitOfWork>(unitOfWork);
        }
    }
}
