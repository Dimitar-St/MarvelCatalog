using AutoMapper;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Controllers;
using MarvelCatalog_App.Services.Contracts;
using MarvelCatalog_App.ViewModels;
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
    public class GivenCharacterPage_Should
    {
        [Test]
        public void Call_GetCharacterMethod_FromService()
        {
            // Arrange
            var characterName = "some name";

            var characterDataModel = new CharacterDataModel();
            var characterViewModel = new CharacterViewModel("", "", "", "asd", "asdasd", "asdasd");

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();

            mockedService.Setup(service => service.GetCharacter("characterName")).Returns(characterDataModel);
            mockedMapper.Setup(mapper => mapper.Map<CharacterViewModel>(characterDataModel)).Returns(characterViewModel);

            var characterController = new CharactersController(mockedService.Object, mockedMapper.Object);

            // Act
            characterController.GivenCharacterPage(characterName);

            // Assert
            mockedService.Verify(service => service.GetCharacter(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Call_MapMethod_FromMapper()
        {
            // Arrange
            var characterName = "some name";

            var characterDataModel = new CharacterDataModel();
            var characterViewModel = new CharacterViewModel("", "", "", "asda", "asdasd", "asdasda");

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();

            mockedService.Setup(service => service.GetCharacter(characterName)).Returns(characterDataModel);
            mockedMapper.Setup(mapper => mapper.Map<CharacterViewModel>(characterDataModel)).Returns(characterViewModel);

            var characterController = new CharactersController(mockedService.Object, mockedMapper.Object);

            // Act
            characterController.GivenCharacterPage(characterName);

            // Assert
            mockedMapper.Verify(mapper => mapper.Map<CharacterViewModel>(characterDataModel), Times.Once);
        }
    }
}
