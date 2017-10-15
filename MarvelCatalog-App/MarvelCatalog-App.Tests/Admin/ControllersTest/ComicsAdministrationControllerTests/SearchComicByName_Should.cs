using AutoMapper;
using Marvel_Catalog_App.Data.Models.Contracts;
using MarvelCatalog_App.Areas.Admin.Controllers;
using MarvelCatalog_App.Services.Contracts;
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
    public class SearchComicByName_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidArgument()
        {
            // Arrange
            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            var comicsAdministrationController = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act & Assert
            Assert.That(() => comicsAdministrationController.SearchComicByName(null),
                        Throws.ArgumentNullException.With.Message.Contain("name"));
        }

        [Test]
        public void Call_GetComics_FromTheService()
        {
            // Arrange
            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.GetComic("name"));

            var comicsAdministrationController = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            comicsAdministrationController.SearchComicByName("name");

            // Assert
            mockedService.Verify(service => service.GetComic("name"), Times.Once);
        }
    }
}
