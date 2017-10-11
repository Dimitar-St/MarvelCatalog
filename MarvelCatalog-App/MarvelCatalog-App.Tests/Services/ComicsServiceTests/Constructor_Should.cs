using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Repositories;
using MarvelCatalog_App.Data.UnitOfWork;
using MarvelCatalog_App.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Tests.Services.ComicsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_When_UnitOfWork_IsNull()
        {
            var mockedRepo = new Mock<IEfRepository<ComicsDataModel>>();

            // Arrang & Act & Assert
            Assert.That(() => new ComicsService(null, mockedRepo.Object),
                        Throws.ArgumentNullException.With.Message.Contains("unitOfwork"));
        }
        
        [Test]
        public void Throw_ArgumentNullException_When_IEfRepository_IsNull()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            

            // Act & Assert
            Assert.That(() => new ComicsService(mockedUnitOfWork.Object, null),
                                Throws.ArgumentNullException.With.Message.Contains("comicsRepository"));
        }
    }
}
