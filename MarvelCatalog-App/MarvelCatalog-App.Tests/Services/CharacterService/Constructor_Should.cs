using Marvel_Catalog_App.Data.API.Models;
using MarvelCatalog_App.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Tests.Services.CharacterService
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Throw_ArgumentNullException_When_IEfRepository_IsNull()
        {
            var mockEfRepository = new Mock<IEfRepository<CharacterDataModel>>();
            
        }
    }
}
