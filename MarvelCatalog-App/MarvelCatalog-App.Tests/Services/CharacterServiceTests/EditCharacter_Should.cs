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
    public class EditCharacter_Should
    {
        [Test]
        public void Call_AllProperty_OfTheRepository()
        {
            // Arrange
            var charactersDataModels = new List<CharacterDataModel>()
            {
                new CharacterDataModel() { Id = 1 }

            };

            var characterDataObject = new CharacterDataModel()
            {
                Id = 1,
                Image = "asdasda",
                Description = "asdasdsa",
                isDeleted = false,
                Name = "adasd"
            };

            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedRepo.Setup(repo => repo.All).Returns(charactersDataModels);
            mockedUnitOfwork.Setup(unit => unit.SaveChanges());

            var characterService = new CharacterService(mockedUnitOfwork.Object, mockedRepo.Object);
            

            // Act
            characterService.EditCharacter(characterDataObject);

            // Assert
            mockedRepo.Verify(repo => repo.All, Times.Once);
        }

        [Test]
        public void Call_SaveChangesMethod_OfTheUnitOfWork()
        {
            // Arrange
            var charactersDataModels = new List<CharacterDataModel>()
            {
                new CharacterDataModel() { Id = 1 }

            };

            var characterDataObject = new CharacterDataModel()
            {
                Id = 1,
                Image = "asdasda",
                Description = "asdasdsa",
                isDeleted = false,
                Name = "adasd"
            };

            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedRepo.Setup(repo => repo.All).Returns(charactersDataModels);
            mockedUnitOfwork.Setup(unit => unit.SaveChanges());

            var characterService = new CharacterService(mockedUnitOfwork.Object, mockedRepo.Object);


            // Act
            characterService.EditCharacter(characterDataObject);

            // Assert
            mockedUnitOfwork.Verify(unit => unit.SaveChanges(), Times.Once);
        }
    }
}
