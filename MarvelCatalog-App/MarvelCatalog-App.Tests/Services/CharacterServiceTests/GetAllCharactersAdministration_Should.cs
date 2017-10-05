using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Repositories;
using MarvelCatalog_App.Data.UnitOfWork;
using MarvelCatalog_App.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MarvelCatalog_App.Tests.Services.CharacterServiceTests
{
    [TestFixture]
    public class GetAllCharactersAdministration_Should
    {
        [Test]
        public void Call_TheAll_Property_OfTheEfRepository()
        {
            // Arrange
            var characters = new List<CharacterDataModel>()
            {
                new CharacterDataModel()
            };

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedUnitOfWork.Setup(unit => unit.CharactersRepository).Returns(mockedRepo.Object);
            mockedRepo.Setup(repo => repo.All).Returns(characters);

            var characterService = new CharacterService(mockedUnitOfWork.Object);

            // Act
            characterService.GetAllCharactersAdministration();

            // Assert
            mockedRepo.Verify(repo => repo.All, Times.Once);
        }

        [Test]
        public void Return_ACharactersDataModels()
        {
            // Arrange
            var characters = new List<CharacterDataModel>()
            {
                new CharacterDataModel()
            };

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedUnitOfWork.Setup(unit => unit.CharactersRepository).Returns(mockedRepo.Object);
            mockedRepo.Setup(repo => repo.All).Returns(characters);

            var characterService = new CharacterService(mockedUnitOfWork.Object);

            // Act
            var charactersData = characterService.GetAllCharactersAdministration();

            // Assert
            Assert.IsInstanceOf<CharacterDataModel>(charactersData.First());
        }
    }
}
