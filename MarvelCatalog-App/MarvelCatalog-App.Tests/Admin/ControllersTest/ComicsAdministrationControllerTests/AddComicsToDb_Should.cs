using AutoMapper;
using Marvel_Catalog_App.Data.Models;
using Marvel_Catalog_App.Data.Models.Contracts;
using MarvelCatalog_App.Areas.Admin.Controllers;
using MarvelCatalog_App.Services.Contracts;
using MarvelCatalog_App.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Tests.Admin.ControllersTest.ComicsAdministrationControllerTests
{
    [TestFixture]
    public class AddComicsToDb_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidViewModel()
        {
            // Arrange
            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            var comicsAdministrationController = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act & Assert
            Assert.That(() => comicsAdministrationController.AddComicsToDb(null),
                        Throws.ArgumentNullException.With.Message.Contains("comic"));
        }

        [Test]
        public void Call_CreateComicsMethod_FromThesFactory()
        {
            // Arrange
            var comicsDataModel = new ComicsDataModel();
            var comicsViewModel = new ComicsViewModel();

            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedFactory.Setup(fac => fac.CreateComics()).Returns(comicsDataModel);
            mockedService.Setup(service => service.AddComic(comicsDataModel));

            var comicsAdministrationController = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            comicsAdministrationController.AddComicsToDb(comicsViewModel);

            // Assert
            mockedFactory.Verify(fac => fac.CreateComics(), Times.Once);
        }

        [Test]
        public void Call_AddComicMethod_FromThesService()
        {
            // Arrange
            var comicsDataModel = new ComicsDataModel();
            var comicsViewModel = new ComicsViewModel();

            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedFactory.Setup(fac => fac.CreateComics()).Returns(comicsDataModel);
            mockedService.Setup(service => service.AddComic(comicsDataModel));

            var comicsAdministrationController = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            comicsAdministrationController.AddComicsToDb(comicsViewModel);

            // Assert
            mockedService.Verify(service => service.AddComic(comicsDataModel), Times.Once);
        }
    }
}
