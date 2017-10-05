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
    public class GetCharacterById_Should
    {
        [Test]
        public void Call_AllProperty_FromEfRepository()
        {
            // Arrange
            var characters = new List<CharacterDataModel>()
            {
                new CharacterDataModel()
            };

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedRepo.Setup(repo => repo.All).Returns(characters);

            var characterService = new CharacterService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            characterService.GetCharacterById(1);

            // Assert
            mockedRepo.Verify(repo => repo.All, Times.Once);
        }

        [Test]
        public void Return_ACharacterModel()
        {
            // Arrange
            var characters = new List<CharacterDataModel>()
            {
                new CharacterDataModel()
                {
                    Id = 1,
                    Name = "Mitko"
                },
                new CharacterDataModel()
                {
                    Id = 123,
                    Name = "Niki"
                }
            };

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();
            var expected = characters[1]; 
            
            mockedRepo.Setup(repo => repo.All).Returns(characters);

            var characterService = new CharacterService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            var character = characterService.GetCharacterById(123);

            // Assert
            Assert.AreEqual(expected.Name, character.Name);
        }
    }
}
