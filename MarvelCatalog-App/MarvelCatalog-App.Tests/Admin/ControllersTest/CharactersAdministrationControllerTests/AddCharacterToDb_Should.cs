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
    public class AddCharacterToDb_Should
    {
        [Test]
        public void Call_AddCharacterToDbMethod_FromTheService()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();
            var characterViewModel = new CharacterViewModel();

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedFactory.Setup(fac => fac.CreateCharacter()).Returns(characterDataModel);
            mockedService.Setup(service => service.AddCharacter(characterDataModel));

            var characterAdminController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            characterAdminController.AddCharacterToDb(characterViewModel);

            // Assert
            mockedService.Verify(service => service.AddCharacter(characterDataModel), Times.Once);
        }
    }
}
