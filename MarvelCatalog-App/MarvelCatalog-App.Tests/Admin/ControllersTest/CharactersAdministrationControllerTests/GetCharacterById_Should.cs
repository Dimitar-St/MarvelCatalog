using AutoMapper;
using Marvel_Catalog_App.Data.Models;
using Marvel_Catalog_App.Data.Models.Contracts;
using MarvelCatalog_App.Areas.Admin.Controllers;
using MarvelCatalog_App.Areas.Admin.Models;
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
    public class GetCharacterById_Should
    {
        [Test]
        public void Call_GetCharacterByIdMethod_FromTheService()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();
            var characterVeiwModel = new CharactersAdminViewModel();

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.GetCharacterById(1))
                         .Returns(characterDataModel);
            mockedMapper.Setup(mapper => mapper.Map<CharactersAdminViewModel>(characterVeiwModel))
                        .Returns(characterVeiwModel);

            var characterAdminController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            characterAdminController.GetCharacterById(1);


            // Arrange
            mockedService.Verify(service => service.GetCharacterById(1), Times.Once);
        }

        [Test]
        public void Call_MapMethod_FromTheMapper()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();
            var characterVeiwModel = new CharactersAdminViewModel();

            var mockedService = new Mock<ICharacterService>();
            var mockedMapper = new Mock<IMapper>();
            var mockedFactory = new Mock<IDataModelsFactory>();

            mockedService.Setup(service => service.GetCharacterById(1))
                         .Returns(characterDataModel);
            mockedMapper.Setup(mapper => mapper.Map<CharactersAdminViewModel>(characterVeiwModel))
                        .Returns(characterVeiwModel);

            var characterAdminController = new CharactersAdministrationController(mockedService.Object, mockedMapper.Object, mockedFactory.Object);

            // Act
            characterAdminController.GetCharacterById(1);
            
            // Arrange
            mockedMapper.Verify(mapper => mapper.Map<CharactersAdminViewModel>(characterDataModel), Times.Once);
        }
    }
}
