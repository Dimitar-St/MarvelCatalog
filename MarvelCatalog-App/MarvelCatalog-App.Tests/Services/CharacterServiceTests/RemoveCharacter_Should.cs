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
    public class RemoveCharacter_Should
    {
        [Test]
        public void Throw_ArgumentNullException_When_IsPassed_InvalidArguemnt()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            var characterService = new CharacterService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act & Assert
            Assert.That(() => characterService.RemoveCharacter(null), 
                        Throws.ArgumentNullException.With.Message.Contains("character"));
        }

        [Test]
        public void Call_AllProperty_OfTheRepository()
        {
            // Arrange
            var charactersDataModel = new List<CharacterDataModel>()
            {
                new CharacterDataModel()
                {
                    Id = 1,
                    isDeleted = false,
                    Name = "Mitko"
                }
            };

            var characterModel = new CharacterDataModel()
            {
                Id = 1,
                Image = "asdasd",
                Description = "asdasds",
                Name = "Mitko"
            };

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedRepo.Setup(repo => repo.All).Returns(charactersDataModel);
            mockedUnitOfWork.Setup(unit => unit.SaveChanges());

            var characterService = new CharacterService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            characterService.RemoveCharacter(characterModel);

            // Assert
            mockedRepo.Verify(repo => repo.All, Times.Once);
        }

        [Test]
        public void Call_SaveChanges_OfTheUnitOfWork()
        {
            // Arrange
            var charactersDataModel = new List<CharacterDataModel>()
            {
                new CharacterDataModel()
                {
                    Id = 1,
                    isDeleted = false,
                    Name = "Mitko"
                }
            };

            var characterModel = new CharacterDataModel()
            {
                Id = 1,
                Image = "asdasd",
                Description = "asdasds",
                Name = "Mitko"
            };

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedRepo.Setup(repo => repo.All).Returns(charactersDataModel);
            mockedUnitOfWork.Setup(unit => unit.SaveChanges());

            var characterService = new CharacterService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            characterService.RemoveCharacter(characterModel);

            // Assert
            mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
        }
    }
}
