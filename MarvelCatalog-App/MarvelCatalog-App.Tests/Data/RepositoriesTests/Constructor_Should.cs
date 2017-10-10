using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Contracts;
using MarvelCatalog_App.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Tests.Data.RepositoriesTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_NullArgumentValue()
        {
            // Arrange & Act & Assert
            Assert.That(() => new EfRepository<CharacterDataModel>(null),
                        Throws.ArgumentNullException.With.Message.Contain("dbContext"));
        }

        [Test]
        public void NotThrowNulArgumentNullException_WhenIsPassed_ValidValue()
        {
            // Arrange
            var mockedDbContext = new Mock<IEfMarvelCatalogDbContext>();

            mockedDbContext.Setup(db => db.GetSet<CharacterDataModel>());

            // Act & Assert
            Assert.DoesNotThrow(() => new EfRepository<CharacterDataModel>(mockedDbContext.Object));
        }

        [Test]
        public void Call_GetSetMethod_FromTheDbContext()
        {
            // Arrange
            var mockedDbContext = new Mock<IEfMarvelCatalogDbContext>();

            mockedDbContext.Setup(db => db.GetSet<CharacterDataModel>());

            // Act
            var repo = new EfRepository<CharacterDataModel>(mockedDbContext.Object);

            // Assert
            mockedDbContext.Verify(db => db.GetSet<CharacterDataModel>(), Times.Once);
        }
    }
}
