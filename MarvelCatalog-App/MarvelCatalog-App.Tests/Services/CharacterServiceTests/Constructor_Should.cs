using Marvel_Catalog_App.Data.API.Models;
using MarvelCatalog_App.Data.Repositories;
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
        public void Throw_ArgumentNullException_When_IEfRepository_IsNull()
        {
            Assert.That(() => new CharacterService(null),
                        Throws.ArgumentNullException.With.Message.Contains("charatcers")); 
        }

        [Test]
        public void NotThrow_ArgumentNullException_When_AValid_ArgumentIsPassed()
        {
            var mockEfRepository = new Mock<IEfRepository<CharacterDataModel>>();

            Assert.DoesNotThrow(() => new CharacterService(mockEfRepository.Object));
        }
    }
}
