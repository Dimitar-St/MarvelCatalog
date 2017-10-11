using AutoMapper;
using Marvel_Catalog_App.Data.Models;
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
    public class GetCharacterByName_Should
    {
        [Test]
        public void ThrowArgumentNullExceptio_WhenIsPassed_InvalidValue()
        {
            // Arrange
            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            var characterAdministrationController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act & Assert
            Assert.That(() => characterAdministrationController.GetCharacterByName(null),
                        Throws.ArgumentNullException.With.Message.Contain("name"));
        }

        [Test]
        public void Call_GetCharacterMethod_FromTheService()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.GetCharacter("name")).Returns(characterDataModel);

            var characterAdministrationController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act 
            characterAdministrationController.GetCharacterByName("name");

            // Assert
            mockedService.Verify(service =>  service.GetCharacter("name"), Times.Once);
        }
    }
}
