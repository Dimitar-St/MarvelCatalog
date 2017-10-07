using AutoMapper;
using MarvelCatalog_App.Controllers;
using MarvelCatalog_App.Services;
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
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullExcpetion_WhenIsPassed_InvalidService()
        {
            // Arrange
            ICreatorsService invalidService = null;
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.That(() => new CreatorsController(invalidService, mockedMapper.Object),
                               Throws.ArgumentNullException.With.Message.Contains("service"));
        }

        [Test]
        public void ThowArgumentNullException_WhenIsPassed_InvalidMapper()
        {
            // Arrange
            var mockedService = new Mock<ICreatorsService>();
            IMapper invalidMapper = null;

            // Act & Assert
            Assert.That(() => new CreatorsController(mockedService.Object, invalidMapper),
                            Throws.ArgumentNullException.With.Message.Contains("mapper"));
        }

        [Test]
        public void NotThrowArgumentNullException()
        {
            // Arrange
            var mockedService = new Mock<ICreatorsService>();
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.DoesNotThrow(() => new CreatorsController(mockedService.Object, mockedMapper.Object));
        }
    }
}
