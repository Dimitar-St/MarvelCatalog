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
    public class GetCharacters_Should
    {
        [Test]
        public void Return_AListOf_CharactersDataModel()
        {
            var charatcersDataModel = new List<CharacterDataModel>()
            {
                new CharacterDataModel()
            };

            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedUnitOfwork.SetupGet(unit => unit.CharactersRepository).Returns(mockedRepo.Object);
            mockedRepo.SetupGet(repo => repo.All).Returns(charatcersDataModel);

            var characterService = new CharacterService(mockedUnitOfwork.Object);

            var characters = characterService.GetCharacters();

            Assert.AreEqual(charatcersDataModel.Count, characters.Count());
        }
    }
}
