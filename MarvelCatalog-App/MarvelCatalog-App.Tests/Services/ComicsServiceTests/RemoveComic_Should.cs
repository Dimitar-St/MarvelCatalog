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
    public class RemoveComic_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidValue()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<ComicsDataModel>>();
            
            var comicsService = new ComicsService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act & Assert
            Assert.That(() => comicsService.RemoveComic(null),
                        Throws.ArgumentNullException.With.Message.Contain("title"));
        }

        [Test]
        public void Call_AllProperty_OfEfRepository()
        {
            // Arrange
            var comicsDataModels = new List<ComicsDataModel>()
            {
                new ComicsDataModel()
                {
                    Title = "title",
                    isDeleted = false
                }
            };

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<ComicsDataModel>>();

            mockedRepo.Setup(repo => repo.All).Returns(comicsDataModels);
            mockedUnitOfWork.Setup(unit => unit.SaveChanges());

            var comicsService = new ComicsService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            comicsService.RemoveComic("title");

            // Arrange
            mockedRepo.Verify(repo => repo.All, Times.Once);
        }

        [Test]
        public void Call_SaveChangesMethod_OfTheUnitOfWork()
        {
            // Arrange
            var comicsDataModels = new List<ComicsDataModel>()
            {
                new ComicsDataModel()
                {
                    Title = "title",
                    isDeleted = false
                }
            };

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<ComicsDataModel>>();

            mockedRepo.Setup(repo => repo.All).Returns(comicsDataModels);
            mockedUnitOfWork.Setup(unit => unit.SaveChanges());

            var comicsService = new ComicsService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            comicsService.RemoveComic("title");

            // Arrange
            mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
        }
    }
}
