using AutoMapper;
using Marvel_Catalog_App.Data.Models;
using Marvel_Catalog_App.Data.Models.Contracts;
using MarvelCatalog_App.Areas.Admin.Controllers;
using MarvelCatalog_App.Areas.Admin.Models;
using MarvelCatalog_App.Data.Repositories;
using MarvelCatalog_App.Data.UnitOfWork;
using MarvelCatalog_App.Services;
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
    public class EditCharacter_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidValue()
        {
            // Arrange
            var mcokedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            var characterService = new CharactersAdministrationController(mcokedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act & Assert
            Assert.That(() => characterService.EditCharacter(null),
                        Throws.ArgumentNullException.With.Message.Contain("character"));
        }

        [Test]
        public void Call_EditCharacterMethod_fromCharatcerServiceClass()
        {
            // Arrange
            var characterAdminViewModel = new CharactersAdminViewModel();

            characterAdminViewModel.Id = 1;
            characterAdminViewModel.Image = "asdasd";
            characterAdminViewModel.isDeleted = false;
            characterAdminViewModel.Name = "asdasd";
            characterAdminViewModel.Description = "asda";

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.EditCharacter(characterAdminViewModel));

            var characterService = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            characterService.EditCharacter(characterAdminViewModel);

            // Assert
            mockedService.Verify(service => service.EditCharacter(characterAdminViewModel), Times.Once);
        }
    }
}
