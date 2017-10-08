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
    public class GetAllComics_Should
    {
        [Test]
        public void Call_GetComicsMethod_OfTheService()
        {
            // Arrange
            var comics = new List<ComicsDataModel>();
            var comicsViewModels = new List<ComicsAdminViewModel>();

            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.GetComics()).Returns(comics);
            mockedMapper.Setup(mapper => mapper.Map<IEnumerable<ComicsAdminViewModel>>(comics))
                        .Returns(comicsViewModels);
            
            var comicsAdministrationContrller = new ComicsAdministrationController(mockedService.Object,mockedMapper.Object, mockedFactory.Object);

            // Act
            comicsAdministrationContrller.GetAllComics();

            // Assert
            mockedService.Verify(service => service.GetComics(), Times.Once);
        }

        [Test]
        public void Call_MapMethod_OfTheService()
        {
            // Arrange
            var comics = new List<ComicsDataModel>();
            var comicsViewModels = new List<ComicsAdminViewModel>();

            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.GetComics()).Returns(comics);
            mockedMapper.Setup(mapper => mapper.Map<IEnumerable<ComicsAdminViewModel>>(comics))
                        .Returns(comicsViewModels);

            var comicsAdministrationContrller = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            comicsAdministrationContrller.GetAllComics();

            // Assert
            mockedMapper.Verify(mapper => mapper.Map<IEnumerable<ComicsAdminViewModel>>(comics), Times.Once);
        }
    }
}
