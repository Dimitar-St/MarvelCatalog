using MarvelCatalog_App.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MarvelCatalog_App.Tests.Controllers.ErrorControllerTests
{
    [TestFixture]
    public class Bad_Request_Should
    {
        [Test]
        public void ReturnViewBadRequest()
        {
            // Arrange
            var errorController = new ErrorController();

            var badRequest = errorController.BadRequest() as ViewResult;

            // Act & Assert
            Assert.AreEqual("BadRequest", badRequest.ViewName);
        }
    }
}
