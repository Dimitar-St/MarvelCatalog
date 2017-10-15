using AutoMapper;
using Marvel_Catalog_App.Data.Models;
using Marvel_Catalog_App.Data.Models.Contracts;
using MarvelCatalog_App.Areas.Admin.Controllers;
using MarvelCatalog_App.Areas.Admin.Models;
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
    public class GetAllCharacters_Should
    {
        [Test]
        public void Call_GetAllCharactersAdministrationMethod_FromTheService()
        {
            // Arrange
            var charactersDataModels = new List<CharacterDataModel>();
            var charactersVeiwModel = new List<CharactersAdminViewModel>()
            {
                new CharactersAdminViewModel() { Id = 1 },
                new CharactersAdminViewModel() { Id = 2 },
                new CharactersAdminViewModel() { Id = 3 },
                new CharactersAdminViewModel() { Id = 4 },
                new CharactersAdminViewModel() { Id = 5 },
                new CharactersAdminViewModel() { Id = 6 },
                new CharactersAdminViewModel() { Id = 7 },
                new CharactersAdminViewModel() { Id = 8 },
                new CharactersAdminViewModel() { Id = 9 },
                new CharactersAdminViewModel() { Id = 10 }
            };

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.GetAllCharactersAdministration())
                         .Returns(charactersDataModels);
            mockedMapper.Setup(mapper => mapper.Map<IEnumerable<CharactersAdminViewModel>>(charactersDataModels))
                        .Returns(charactersVeiwModel);

            var characterAdminController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            characterAdminController.GetAllCharacters(1);

            // Assert
            mockedService.Verify(service => service.GetAllCharactersAdministration(), Times.Once);
        }

        [Test]
        public void Call_MapMethod_FromTheMapper()
        {
            // Arrange
            var charactersDataModels = new List<CharacterDataModel>();
            var charactersVeiwModel = new List<CharactersAdminViewModel>()
            {
                new CharactersAdminViewModel() { Id = 1 },
                new CharactersAdminViewModel() { Id = 2 },
                new CharactersAdminViewModel() { Id = 3 },
                new CharactersAdminViewModel() { Id = 4 },
                new CharactersAdminViewModel() { Id = 5 },
                new CharactersAdminViewModel() { Id = 6 },
                new CharactersAdminViewModel() { Id = 7 },
                new CharactersAdminViewModel() { Id = 8 },
                new CharactersAdminViewModel() { Id = 9 },
                new CharactersAdminViewModel() { Id = 10 }
            };

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.GetAllCharactersAdministration())
                         .Returns(charactersDataModels);
            mockedMapper.Setup(mapper => mapper.Map<IEnumerable<CharactersAdminViewModel>>(charactersDataModels))
                        .Returns(charactersVeiwModel);

            var characterAdminController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            characterAdminController.GetAllCharacters(1);

            // Assert
            mockedMapper.Verify(mapper => mapper.Map<IEnumerable<CharactersAdminViewModel>>(charactersDataModels), Times.Once);
        }
    }
}
