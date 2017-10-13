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
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidUnitofWork()
        {
            var mockedRepo = new Mock<IEfRepository<User>>();

            Assert.That(() => new UserService(null, mockedRepo.Object),
                        Throws.ArgumentNullException.With.Message.Contain("unitOfwork"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIsPassed_InvalidRepo()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.That(() => new UserService(mockedUnitOfWork.Object, null),
                        Throws.ArgumentNullException.With.Message.Contain("usersRepository"));
        }

        [Test]
        public void NotThrowArgumentNullException()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedRepo = new Mock<IEfRepository<User>>();

            Assert.DoesNotThrow(() => new UserService(mockedUnitOfWork.Object, mockedRepo.Object));
        }
    }
}
