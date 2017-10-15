using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Contracts;
using MarvelCatalog_App.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Tests.Data.RepositoriesTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void Call_AddMethod_OfTheDbSet()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();

            var mockedDbSet = new Mock<IDbSet<CharacterDataModel>>();
            var mockedDbContext = new Mock<IEfMarvelCatalogDbContext>();

            mockedDbContext.Setup(db => db.GetSet<CharacterDataModel>()).Returns(mockedDbSet.Object);
            mockedDbSet.Setup(set => set.Add(characterDataModel));
            
            var repo = new EfRepository<CharacterDataModel>(mockedDbContext.Object);

            // Act
            repo.Add(characterDataModel);

            // Assert
            mockedDbSet.Verify(set => set.Add(characterDataModel), Times.Once);
        }

        [Test]
        public void Call_AddMethod_Twice_OfTheDbSet()
        {
            // Arrange
            var characterDataModel = new CharacterDataModel();

            var mockedDbSet = new Mock<IDbSet<CharacterDataModel>>();
            var mockedDbContext = new Mock<IEfMarvelCatalogDbContext>();

            mockedDbContext.Setup(db => db.GetSet<CharacterDataModel>()).Returns(mockedDbSet.Object);
            mockedDbSet.Setup(set => set.Add(characterDataModel));

            var repo = new EfRepository<CharacterDataModel>(mockedDbContext.Object);

            // Act
            repo.Add(characterDataModel);
            repo.Add(characterDataModel);

            // Assert
            mockedDbSet.Verify(set => set.Add(characterDataModel), Times.Exactly(2));
        }
    }
}
