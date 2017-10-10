using AutoMapper;
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
    public class RemoveComicsFromDb_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidValue()
        {
            // Arrange
            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            var comicsAdministrationController = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act & Assert
            Assert.That(() => comicsAdministrationController.RemoveComicsFromDb(null),
                        Throws.ArgumentNullException.With.Message.Contain("comics"));
        }

        [Test]
        public void Call_RemoveComicMethod()
        {
            // Arrange
            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();
            var viewModel = new ComicsViewModel();
            
            viewModel.Title = "title";

            mockedService.Setup(service => service.RemoveComic(viewModel.Title));

            var comicsAdministrationController = new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            comicsAdministrationController.RemoveComicsFromDb(viewModel);


            // Assert
            mockedService.Verify(service => service.RemoveComic(viewModel.Title), Times.Once);
        }
    }
}
