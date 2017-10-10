using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Repositories;
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
    }
}
