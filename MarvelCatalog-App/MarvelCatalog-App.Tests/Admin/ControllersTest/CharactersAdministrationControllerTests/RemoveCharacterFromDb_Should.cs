using AutoMapper;
using Marvel_Catalog_App.Data.Models;
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

namespace MarvelCatalog_App.Tests.Admin.ControllersTest.CharactersAdministrationControllerTests
{
    [TestFixture]
    public class RemoveCharacterFromDb_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidValue()
        {
            // Arrange
            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();
            
            var characterAdminController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act & Assert
            Assert.That(() => characterAdminController.RemoveCharacterFromDb(null),
                        Throws.ArgumentNullException.With.Message.Contain("character"));
        }

        [Test]
        public void Call_CreateCharacterMethod_FromTheFactory()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();
            var characterViewModel = new CharacterViewModel();

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedFactory.Setup(fac => fac.CreateCharacter()).Returns(characterDataModel);
            mockedService.Setup(service => service.RemoveCharacter(characterDataModel));

            var characterAdminController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            characterAdminController.RemoveCharacterFromDb(characterViewModel);

            // Assert
            mockedFactory.Verify(fac => fac.CreateCharacter(), Times.Once);
        }

        [Test]
        public void Call_RemoveCharcterMethod_FromTheService()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();
            var characterViewModel = new CharacterViewModel();

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedFactory.Setup(fac => fac.CreateCharacter()).Returns(characterDataModel);
            mockedService.Setup(service => service.RemoveCharacter(characterDataModel));

            var characterAdminController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            characterAdminController.RemoveCharacterFromDb(characterViewModel);

            // Assert
            mockedService.Verify(service => service.RemoveCharacter(characterDataModel), Times.Once);
        }
    }
}
