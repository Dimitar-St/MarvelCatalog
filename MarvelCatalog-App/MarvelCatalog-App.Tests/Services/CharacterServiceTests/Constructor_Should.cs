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
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_When_UnitOfWork_IsNull()
        {
            // Arrang & Act & Assert
            Assert.That(() => new CharacterService(null),
                        Throws.ArgumentNullException.With.Message.Contains("unitOfWork")); 
        }

        [Test]
        public void Throw_ArgumentNullException_When_IEfRepository_IsNull()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            IEfRepository<CharacterDataModel> invalidRepo = null;

            mockedUnitOfWork.SetupGet(unit => unit.CharactersRepository).Returns(invalidRepo);
            
            // Act & Assert
            Assert.That(() => new CharacterService(mockedUnitOfWork.Object),
                                Throws.ArgumentNullException.With.Message.Contains("CharactersRepository"));
        }

        [Test]
        public void NotThrow_ArgumentNullException_When_AValid_ArgumentIsPassed()
        {
            // Arrange
            var mockedUnitOfwork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<CharacterDataModel>>();

            mockedUnitOfwork.SetupGet(unit => unit.CharactersRepository).Returns(mockedRepo.Object);

            // Act & Assert
            Assert.DoesNotThrow(() => new CharacterService(mockedUnitOfwork.Object));
        }
    }
}
