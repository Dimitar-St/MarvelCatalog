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

namespace MarvelCatalog_App.Tests.Admin.ControllersTest.CharactersAdministrationControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Create_ACharactersAdministrationController()
        {
            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            var characterAdministrationController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            Assert.IsInstanceOf<CharactersAdministrationController>(characterAdministrationController);
        }

        [Test]
        public void Throw_ArgumentNullException_When_TheService_IsNull()
        {
            ICharacterService invalidService = null;
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            Assert.That(() => new CharactersAdministrationController(invalidService, mockedMapper.Object, mockedFactory.Object),
                Throws.ArgumentNullException.With.Message.Contains("service"));

        }

        [Test]
        public void Throw_ArgumentNullException_When_TheMapper_IsNull()
        {
            var mockedService = new Mock<ICharacterService>();
            IMapper invalidMapper = null;
            var mockedFactory = new Mock<IDataModelsFactory>();

            Assert.That(() => new CharactersAdministrationController(mockedService.Object, invalidMapper, mockedFactory.Object),
                Throws.ArgumentNullException.With.Message.Contains("mapper"));
        }
    }
}
