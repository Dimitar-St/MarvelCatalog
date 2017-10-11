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
    public class AddComic_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidArgument()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<ComicsDataModel>>();

            var comicsService = new ComicsService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act & Assert
            Assert.That(() => comicsService.AddComic(null),
                        Throws.ArgumentNullException.With.Message.Contain("comic"));
        }

        [Test]
        public void Call_AddMethod_OfTheRepository()
        {
            // Arrange
            var comicsDataModels = new List<ComicsDataModel>();
            var comic = new ComicsDataModel();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<ComicsDataModel>>();

            mockedRepo.Setup(repo => repo.Add(comic));
            mockedUnitOfWork.Setup(unit => unit.SaveChanges());

            var comicsService = new ComicsService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            comicsService.AddComic(comic);

            // Assert
            mockedRepo.Verify(repo => repo.Add(comic), Times.Once);
        }

        [Test]
        public void Call_SaveChangesMethod_OfTheUnitOfWork()
        {
            // Arrange
            var comicsDataModels = new List<ComicsDataModel>();
            var comic = new ComicsDataModel();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<ComicsDataModel>>();

            mockedRepo.Setup(repo => repo.Add(comic));
            mockedUnitOfWork.Setup(unit => unit.SaveChanges());

            var comicsService = new ComicsService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            comicsService.AddComic(comic);

            // Assert
            mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
        }
    }
}
