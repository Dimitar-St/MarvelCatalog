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

namespace MarvelCatalog_App.Tests.Services.CreatorsServiceTests
{
    [TestFixture]
    public class GetCreators_Should
    {
        [Test]
        public void Call_TheAllProperty_OfTheEfRepository()
        {
            // Arrange
            var creators = new List<CreatorsDataModel>();

            var mockedRepo = new Mock<IEfRepository<CreatorsDataModel>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            mockedRepo.Setup(repo => repo.All).Returns(creators);

            var creatorsService = new CreatorsService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            creatorsService.GetCreators();

            // Assert
            mockedRepo.Verify(repo => repo.All, Times.Once);
        }

        [Test]
        public void Return_AListOfCraetors()
        {
            // Arrange
            var creators = new List<CreatorsDataModel>()
            {
                new CreatorsDataModel() { FullName = "Mitko", isDeleted = false, Image ="this is image" }
            };

            var mockedRepo = new Mock<IEfRepository<CreatorsDataModel>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            mockedRepo.Setup(repo => repo.All).Returns(creators);

            var creatorsService = new CreatorsService(mockedUnitOfWork.Object, mockedRepo.Object);

            // Act
            var creatorsModels = creatorsService.GetCreators().ToList();

            // Assert
            var expected = creators[0].FullName;
            var actual = creatorsModels[0].FullName;

            Assert.AreEqual(expected, actual);
        }
    }
}
