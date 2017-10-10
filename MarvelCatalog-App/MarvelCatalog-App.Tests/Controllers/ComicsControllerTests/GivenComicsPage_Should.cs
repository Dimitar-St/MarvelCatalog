using AutoMapper;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Controllers;
using MarvelCatalog_App.Services.Contracts;
using MarvelCatalog_App.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Tests.Controllers.ComicsControllerTests
{
    [TestFixture]
    public class GivenComicsPage_Should
    {
        [Test]
        public void Call_GetComicMethod_FromService()
        {
            // Arrange
            var comicName = "some name";

            var comicsDataModel = new ComicsDataModel();
            var comicsViewModel = new ComicsViewModel("", "", "", 1, new List<CharacterDataModel>());

            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();

            mockedService.Setup(service => service.GetComic(comicName)).Returns(comicsDataModel);
            mockedMapper.Setup(mapper => mapper.Map<ComicsViewModel>(comicsDataModel)).Returns(comicsViewModel);

            var comicsController = new ComicsController(mockedService.Object, mockedMapper.Object);

            // Act
            comicsController.GivenComicsPage(comicName);

            // Assert
            mockedService.Verify(service => service.GetComic(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Call_MapMethod_FromMapper()
        {
            // Arrange
            var comicName = "some name";

            var comicsDataModel = new ComicsDataModel("asdasd", "asdasd", "asdad", 1, new List<CharacterDataModel>());
            var comicsViewModel = new ComicsViewModel("asdasd", "asdasd", "asdad", 1, new List<CharacterDataModel>());

            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();

            mockedService.Setup(service => service.GetComic(comicName)).Returns(comicsDataModel);
            mockedMapper.Setup(mapper => mapper.Map<ComicsViewModel>(comicsDataModel)).Returns(comicsViewModel);

            var comicsController = new ComicsController(mockedService.Object, mockedMapper.Object);

            // Act
            comicsController.GivenComicsPage(comicName);

            // Assert
            mockedMapper.Verify(m => m.Map<ComicsViewModel>(comicsDataModel), Times.Once);
        }
    }
}
