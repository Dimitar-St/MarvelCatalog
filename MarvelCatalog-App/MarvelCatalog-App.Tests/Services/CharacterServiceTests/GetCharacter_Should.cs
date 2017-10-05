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
    public class GetCharacter_Should
    {
        [Test]
        public void Throw_AArgumentNullException_When_ThePassedArgument_IsNull()
        {
            var charatcersDataModel = new List<CharacterDataModel>();

            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedRepo.Setup(repo => repo.All).Returns(charatcersDataModel);

            var characterService = new CharacterService(mockedUnitOfwork.Object, mockedRepo.Object);

            Assert.Throws<ArgumentNullException>(() => characterService.GetCharacter(null));
        }

        [Test]
        public void Return_AValidCharacter_WhenIsPassed_ValidCharacterName()
        {
            var expectedName = "mitko";

            var charatcersDataModel = new List<CharacterDataModel>()
            {
                new CharacterDataModel(expectedName, "", "", new Dictionary<string, string>()),
                new CharacterDataModel("differentName", "", "", new Dictionary<string, string>())
            };

            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();
            
            mockedRepo.SetupGet(repo => repo.All).Returns(charatcersDataModel);

            var characterService = new CharacterService(mockedUnitOfwork.Object, mockedRepo.Object);

            var character = characterService.GetCharacter(expectedName);

            Assert.AreEqual(expectedName, character.Name);
        }
    }
}
