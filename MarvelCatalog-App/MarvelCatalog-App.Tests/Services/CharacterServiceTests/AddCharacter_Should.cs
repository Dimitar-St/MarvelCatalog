using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Repositories;
using MarvelCatalog_App.Data.UnitOfWork;
using MarvelCatalog_App.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Tests.Services.CharacterServiceTests
{
    [TestFixture]
    public class AddCharacter_Should
    {
        [Test]
        public void ThrowArgumentNullException_When_IsPassedA_InvalidCharacterDataModel()
        {
            // Arrange
            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            var characterService = new CharacterService(mockedUnitOfwork.Object, mockedRepo.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => characterService.AddCharacter(null));
        }

        [Test]
        public void Call_AddMethod_OfTheEfRepository()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();

            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedUnitOfwork.Setup(unit => unit.SaveChanges()).Returns(1);
            mockedRepo.Setup(repo => repo.Add(characterDataModel));

            var characterService = new CharacterService(mockedUnitOfwork.Object, mockedRepo.Object);

            // Act
            characterService.AddCharacter(characterDataModel);

            // Assert
            mockedRepo.Verify(repo => repo.Add(characterDataModel), Times.Once);
        }

        [Test]
        public void Call_SaveChangesMethod_OfTheEfUnitOfWork()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();

            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedUnitOfwork.Setup(unit => unit.SaveChanges()).Returns(1);
            mockedRepo.Setup(repo => repo.Add(characterDataModel));

            var characterService = new CharacterService(mockedUnitOfwork.Object, mockedRepo.Object);

            // Act
            characterService.AddCharacter(characterDataModel);

            // Assert
            mockedUnitOfwork.Verify(unit => unit.SaveChanges(), Times.Once);
        }
    }
}
