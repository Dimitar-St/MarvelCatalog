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
    public class MainComicsPage_Should
    {
        [Test]
        public void Call_GetComicsMethod_FromTheService()
        {
            // Arrange
            var comicsDataModel = new List<ComicsDataModel>();
            var comicsViewModel = new List<ComicsViewModel>();

            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();

            mockedService.Setup(s => s.GetComics()).Returns(comicsDataModel);
            mockedMapper.Setup(mapper => mapper.Map<IEnumerable<ComicsViewModel>>(comicsDataModel))
                        .Returns(comicsViewModel);

            var comicsController = new ComicsController(mockedService.Object, mockedMapper.Object);

            comicsController.MainComicsPage();

            mockedService.Verify(s => s.GetComics(), Times.Once);
        }

        [Test]
        public void Call_MapMethod_FromTheService()
        {
            // Arrange
            var comicsDataModel = new List<ComicsDataModel>();
            var comicsViewModel = new List<ComicsViewModel>();

            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();

            mockedService.Setup(s => s.GetComics()).Returns(comicsDataModel);
            mockedMapper.Setup(mapper => mapper.Map<IEnumerable<ComicsViewModel>>(comicsDataModel))
                        .Returns(comicsViewModel);

            var comicsController = new ComicsController(mockedService.Object, mockedMapper.Object);

            comicsController.MainComicsPage();

            mockedMapper.Verify(mapper => mapper.Map<IEnumerable<ComicsViewModel>>(comicsDataModel), Times.Once);
        }
    }
}
