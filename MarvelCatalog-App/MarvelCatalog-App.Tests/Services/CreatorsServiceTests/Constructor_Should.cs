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

namespace MarvelCatalog_App.Tests.Services.CreatorsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidUnitOfWork()
        {
            // Arrange
            IUnitOfWork invalidUnitOfWork = null;
            var mockedRepo = new Mock<IEfRepository<CreatorsDataModel>>();

            // Act & Assert
            Assert.That(() => new CreatorsService(invalidUnitOfWork, mockedRepo.Object), 
                                Throws.ArgumentNullException.With.Message.Contains("unitOfWork"));
        }
        
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidRepository()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            IEfRepository<CreatorsDataModel> invalidRepo = null;

            // Act & Assert
            Assert.That(() => new CreatorsService(mockedUnitOfWork.Object, invalidRepo),
                            Throws.ArgumentNullException.With.Message.Contains("creatorsRepository"));
        }

        [Test]
        public void NotThrowArgumentNullException()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CreatorsDataModel>>();

            // Act & Assert
            Assert.DoesNotThrow(() => new CreatorsService(mockedUnitOfWork.Object, mockedRepo.Object));
        }
    }
}
