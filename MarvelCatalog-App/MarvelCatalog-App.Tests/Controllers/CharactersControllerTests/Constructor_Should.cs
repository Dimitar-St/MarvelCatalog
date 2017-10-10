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

namespace MarvelCatalog_App.Tests.Controllers.CharactersControllerTests
{

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_When_IsPassed_ANull_ServiceValue()
        {
            // Arrange
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.That(() => new CharactersController(null, mockedMapper.Object),
                            Throws.ArgumentNullException.With.Message.Contains("characterService"));
        }

        [Test]
        public void Throw_ArgumentNullException_When_IsPassed_ANull_MapperValue()
        {
            // Arrange
            var mockedService = new Mock<ICharacterService>();

            // Act & Assert
            Assert.That(() => new CharactersController(mockedService.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains("mapper"));
        }

        [Test]
        public void NotThrow_ArgumentNullException_When_ArePassed_ValidValues()
        {
            // Arrange
            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.DoesNotThrow(() => new CharactersController(mockedService.Object, mockedMapper.Object));
        }
    }
}
