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

namespace MarvelCatalog_App.Tests.Services.UserserviceTests
{
    [TestFixture]
    public class AddToFavoritesCharacters_Should
    {
        [Test]
        public void ThrowArgumentNullException_WheIsPassed_InvalidUsername()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<User>>();

            var userService =  new UserService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act & Assert
            Assert.That(() => userService.AddToFavoritesCharacters(null, characterDataModel),
                        Throws.ArgumentNullException.With.Message.Contain("username"));
        }

        [Test]
        public void ThrowArgumentNullException_WheIsPassed_InvalidCharacterDataModel()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<User>>();

            var userService = new UserService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act & Assert
            Assert.That(() => userService.AddToFavoritesCharacters("username", null),
                        Throws.ArgumentNullException.With.Message.Contain("characterModel"));
        }

        [Test]
        public void Call_AllPropertyOfTheRepository()
        {
            // Arrange
            var characters = new List<User>()
            {
                new User()
                {
                    UserName = "username",
                    FavoritesCharacters = new HashSet<CharacterDataModel>()
                }
            };
            var characterData = new CharacterDataModel();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<User>>();

            mockedUnitOfWork.Setup(unit => unit.SaveChanges());
            mockedRepo.Setup(repo => repo.All).Returns(characters);

            var userService = new UserService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            userService.AddToFavoritesCharacters("username", characterData);

            // Assert
            mockedRepo.Verify(repo => repo.All, Times.Once);
        }

        [Test]
        public void Call_SaveChangesMethodOfTheUnitOfWork()
        {
            // Arrange
            var characters = new List<User>()
            {
                new User()
                {
                    UserName = "username",
                    FavoritesCharacters = new HashSet<CharacterDataModel>()
                }
            };
            var characterData = new CharacterDataModel();

            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<User>>();

            mockedUnitOfWork.Setup(unit => unit.SaveChanges());
            mockedRepo.Setup(repo => repo.All).Returns(characters);

            var userService = new UserService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            userService.AddToFavoritesCharacters("username", characterData);

            // Assert
            mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
        }
    }
}
