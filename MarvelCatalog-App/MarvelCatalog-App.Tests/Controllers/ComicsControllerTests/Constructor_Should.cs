using AutoMapper;
using MarvelCatalog_App.Controllers;
using MarvelCatalog_App.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MarvelCatalog_App.Tests.Controllers.ComicsControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Thow_ArgumentNullException_WhenIs_PassedA_InvalidServiceValue()
        {
            // Arrange
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.That(() => new ComicsController(null, mockedMapper.Object),
                            Throws.ArgumentNullException.With.Message.Contains("comicsService"));
        }

        [Test]
        public void Throw_ArgumentNullException_When_IsPassed_ANull_MapperValue()
        {
            // Arrange
            var mockedService = new Mock<IComicsService>();

            // Act & Assert
            Assert.That(() => new ComicsController(mockedService.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains("mapper"));
        }

        [Test]
        public void NotThrow_ArgumentNullException_When_ArePassed_ValidValues()
        {
            // Arrange
            var mockedService = new Mock<IComicsService>();
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.DoesNotThrow(() => new ComicsController(mockedService.Object, mockedMapper.Object));
        }
    }
}
