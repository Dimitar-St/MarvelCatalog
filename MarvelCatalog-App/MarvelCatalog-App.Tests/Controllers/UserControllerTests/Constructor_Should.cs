using AutoMapper;
using MarvelCatalog_App.Controllers;
using MarvelCatalog_App.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Tests.Controllers.UserControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidServiceValue()
        {
            // Arrange
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.That(() => new UserController(null, mockedMapper.Object),
                        Throws.ArgumentNullException.With.Message.Contain("service"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidMapperValue()
        {
            // Arrange
            var mockedService = new Mock<IUserService>();

            // Act & Assert
            Assert.That(() => new UserController(mockedService.Object, null),
                        Throws.ArgumentNullException.With.Message.Contain("mapper"));
        }

        [Test]
        public void NotThrowArgumentNullException()
        {
            // Arrange
            var mockedService = new Mock<IUserService>();
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.DoesNotThrow(() => new UserController(mockedService.Object, mockedMapper.Object));
        }
    }
}
