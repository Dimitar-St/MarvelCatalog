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
    public class Schould
    {
        [Test]
        public void CreateInstanceOfDatabase()
        {
            // Arrange
            var db = new EfMarvelCatalogDbContext();

            // Act & Assert
            Assert.IsInstanceOf<EfMarvelCatalogDbContext>(db);
        }

        [Test]
        public void BeTypeOfICarsDbContext()
        {
            // Arrange
            var db = new EfMarvelCatalogDbContext();

            // Act & Assert
            Assert.IsInstanceOf<IEfMarvelCatalogDbContext>(db);
        }
    }
}
