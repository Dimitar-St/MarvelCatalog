using AutoMapper;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Controllers;
using MarvelCatalog_App.Services;
using MarvelCatalog_App.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Tests.Controllers.CreatorsControllerTests
{
    [TestFixture]
    public class MainCreatorsPage_Should
    {
        [Test]
        public void Call_GetCreatorsMethod_OfTheService()
        {
            // Arrange
            var creatorsDataModels = new List<CreatorsDataModel>();
            var creatorsViewModel = new List<CreatorViewModel>();

            var mockedService = new Mock<ICreatorsService>();
            var mockedMapper = new Mock<IMapper>();

            mockedService.Setup(service => service.GetCreators()).Returns(creatorsDataModels);
            mockedMapper.Setup(mapper => mapper.Map<IEnumerable<CreatorViewModel>>(creatorsDataModels))
                            .Returns(creatorsViewModel);

            var creatorController = new CreatorsController(mockedService.Object, mockedMapper.Object);

            // Act
            creatorController.MainCreatorsPage();

            // Assert
            mockedService.Verify(service => service.GetCreators(), Times.Once);
        }

        [Test]
        public void Call_MappMethod_OfTheMapper()
        {
            // Arrange
            var creatorsDataModels = new List<CreatorsDataModel>();
            var creatorsViewModel = new List<CreatorViewModel>();

            var mockedService = new Mock<ICreatorsService>();
            var mockedMapper = new Mock<IMapper>();

            mockedService.Setup(service => service.GetCreators()).Returns(creatorsDataModels);
            mockedMapper.Setup(mapper => mapper.Map<IEnumerable<CreatorViewModel>>(creatorsDataModels))
                            .Returns(creatorsViewModel);

            var creatorController = new CreatorsController(mockedService.Object, mockedMapper.Object);

            // Act
            creatorController.MainCreatorsPage();

            // Assert
            mockedMapper.Verify(mapper => mapper.Map<IEnumerable<CreatorViewModel>>(creatorsDataModels), Times.Once);
        }
    }
}
