using MarvelCatalog_App.Data;
using MarvelCatalog_App.Data.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Tests.Data.MarvelCtalogDbContext
{
    [TestFixture]
    public class CreateMehtod_Should
    {
        [Test]
        public void ShouldReturnInstanceOfCarsDbContext()
        {
            // Arrange
            var db = EfMarvelCatalogDbContext.Create();

            // Act & Assert
            Assert.IsInstanceOf<EfMarvelCatalogDbContext>(db);
        }

        [Test]
        public void ShouldReturnInstanceOfICarsDbContext()
        {
            // Arrange
            var db = EfMarvelCatalogDbContext.Create();

            // Act & Assert
            Assert.IsInstanceOf<IEfMarvelCatalogDbContext>(db);
        }
    }
}
