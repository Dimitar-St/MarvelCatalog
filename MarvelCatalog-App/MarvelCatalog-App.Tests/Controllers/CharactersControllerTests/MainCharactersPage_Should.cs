using AutoMapper;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Controllers;
using MarvelCatalog_App.Services.Contracts;
using MarvelCatalog_App.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace MarvelCatalog_App.Tests.Controllers.CharactersControllerTests
{
    [TestFixture]
    class MainCharactersPage_Should
    {
        [Test]
        public void Call_GetCharactersMethod_FromTheService()
        {
            // Arrange
            var charactersDataModel = new List<CharacterDataModel>();
            var charactersViewModel = new List<CharacterViewModel>();

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();

            mockedService.Setup(service => service.GetCharacters())
                         .Returns(charactersDataModel);

            mockedMapper.Setup(mapper => mapper.Map<IEnumerable<CharacterViewModel>>(charactersDataModel))
                        .Returns(charactersViewModel);
                         

            var characterController = new CharactersController(mockedService.Object, mockedMapper.Object);
            
            // Act
            characterController.MainCharactersPage();

            // Assert
            mockedService.Verify(service => service.GetCharacters(), Times.Once);
        }

        [Test]
        public void Call_MapMethod_FromTheMapper()
        {
            // Arrange
            var charactersDataModel = new List<CharacterDataModel>();
            var charactersViewModel = new List<CharacterViewModel>();

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();

            mockedService.Setup(service => service.GetCharacters())
                         .Returns(charactersDataModel);

            mockedMapper.Setup(mapper => mapper.Map<IEnumerable<CharacterViewModel>>(charactersDataModel))
                        .Returns(charactersViewModel);


            var characterController = new CharactersController(mockedService.Object, mockedMapper.Object);

            // Act
            characterController.MainCharactersPage();

            // Assert
            mockedMapper.Verify(mapper => mapper.Map<IEnumerable<CharacterViewModel>>(It.IsAny<IEnumerable<CharacterDataModel>>()), Times.Once);
        }
    }
}
