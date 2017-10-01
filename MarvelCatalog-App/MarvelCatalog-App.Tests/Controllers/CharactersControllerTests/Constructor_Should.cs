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
            var mockedMapper = new Mock<IMapper>();

            Assert.That(() => new CharactersController(null, mockedMapper.Object),
                            Throws.ArgumentNullException.With.Message.Contains("service"));
        }

        [Test]
        public void Throw_ArgumentNullException_When_IsPassed_ANull_MapperValue()
        {
            var mockedService = new Mock<ICharacterService>();

            Assert.That(() => new CharactersController(mockedService.Object, null),
                            Throws.ArgumentNullException.With.Message.Contains("mapper"));
        }

        [Test]
        public void NotThrow_ArgumentNullException_When_ArePassed_ValidValues()
        {
            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();

            Assert.DoesNotThrow(() => new CharactersController(mockedService.Object, mockedMapper.Object));
        }
    }
}
