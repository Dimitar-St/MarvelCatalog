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

namespace MarvelCatalog_App.Tests.Services.ComicsServiceTests
{
    [TestFixture]
    public class GetComics_Should
    {
        //[Test]
        //public void Call_AllProperty_FromEfRepository()
        //{
        //    var comics = new List<ComicsDataModel>()
        //    {
        //        new ComicsDataModel()
        //    };
        //
        //    var mockedUnitOfWork= new Mock<IUnitOfWork>();
        //    var mockedRepo = new Mock<IEfRepository<ComicsDataModel>>();
        //
        //    mockedUnitOfWork.SetupGet(unit => unit.ComicsRepository).Returns(mockedRepo.Object);
        //    mockedRepo.SetupGet(repo => repo.All).Returns(comics);
        //
        //    var comicsService = new ComicsService(mockedUnitOfWork.Object);
        //
        //    comicsService.GetComics();
        //
        //    mockedRepo.Verify(r => r.All, Times.Once);
        //}
    }
}
