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
    }
}
