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
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidService()
        {
            // Arrange
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            // Act & Assert
            Assert.That(() => new ComicsAdministrationController(null, mockedMapper.Object, mockedFactory.Object),
                        Throws.ArgumentNullException.With.Message.Contains("service"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidMapper()
        {
            // Arrange
            var mockedService = new Mock<IComicsService>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            // Act & Assert
            Assert.That(() => new ComicsAdministrationController(mockedService.Object, null, mockedFactory.Object),
                        Throws.ArgumentNullException.With.Message.Contains("mapper"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidFactory()
        {
            // Arrange
            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.That(() => new ComicsAdministrationController(mockedService.Object, mockedMapper.Object, null),
                        Throws.ArgumentNullException.With.Message.Contains("factory"));
        }
    }
}
