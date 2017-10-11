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
    public class GetComic_Should
    {
        [Test]
        public void ThrowArgumentNullExcpetion_WhenIsPassed_InvalidArgumentValue()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<ComicsDataModel>>();

            var comicsService = new ComicsService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act & Assert
            Assert.That(() => comicsService.GetComic(null),
                         Throws.ArgumentNullException.With.Message.Contain("title"));
        }

        [Test]
        public void Call_AllProperty_ForTheRepository()
        {
            // Arrange
            var comicsDataModels = new List<ComicsDataModel>();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<ComicsDataModel>>();

            mockedRepo.Setup(repo => repo.All).Returns(comicsDataModels);

            var comicsService = new ComicsService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            comicsService.GetComic("title");

            // Assert
            mockedRepo.Verify(repo => repo.All, Times.Once);
        }
    }
}
