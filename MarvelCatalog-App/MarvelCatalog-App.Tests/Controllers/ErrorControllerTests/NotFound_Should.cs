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
    public class NotFound_Should
    {
        [Test]
        public void ReturnViewNotFound()
        {
            // Arrange
            var errorController = new ErrorController();

            var badRequest = errorController.NotFound() as ViewResult;

            // Act & Assert
            Assert.AreEqual("NotFound", badRequest.ViewName);
        }
    }
}
