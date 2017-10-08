using AutoMapper;
using Marvel_Catalog_App.Data.Models;
using Marvel_Catalog_App.Data.Models.Contracts;
using MarvelCatalog_App.Areas.Admin.Controllers;
using MarvelCatalog_App.Areas.Admin.Models;
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
    public class GetComicByTitle_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidTitle()
        {
            // Arrange
            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            var comicsAdministrationController = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act & Assert
            Assert.That(() => comicsAdministrationController.GetComicByTitle(null),
                        Throws.ArgumentNullException.With.Message.Contains("title"));
        }

        [Test]
        public void Call_GetComicMethod_FromTheService()
        {
            // Arrange
            var title = "title";
            var comicsDataModel = new ComicsDataModel();
            var comicsViewModel = new ComicsAdminViewModel();

            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.GetComic(title)).Returns(comicsDataModel);
            mockedMapper.Setup(mapper => mapper.Map<ComicsAdminViewModel>(comicsDataModel)).Returns(comicsViewModel);

            var comicsAdministrationController = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act 
            comicsAdministrationController.GetComicByTitle(title);

            // Assert
            mockedService.Verify(service => service.GetComic(title), Times.Once);
        }

        [Test]
        public void Call_MapMethod_FromTheMapper()
        {
            // Arrange
            var title = "title";
            var comicsDataModel = new ComicsDataModel();
            var comicsViewModel = new ComicsAdminViewModel();

            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.GetComic(title)).Returns(comicsDataModel);
            mockedMapper.Setup(mapper => mapper.Map<ComicsAdminViewModel>(comicsDataModel)).Returns(comicsViewModel);

            var comicsAdministrationController = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act 
            comicsAdministrationController.GetComicByTitle(title);

            // Assert
            mockedMapper.Verify(mapper => mapper.Map<ComicsAdminViewModel>(comicsDataModel), Times.Once);
        }
    }
}
