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
    public class UnAuthorized_Should
    {
        [Test]
        public void ReturnViewUnAuthorized()
        {
            // Arrange
            var errorController = new ErrorController();

            var badRequest = errorController.UnAuthorized() as ViewResult;

            // Act & Assert
            Assert.AreEqual("UnAuthorized", badRequest.ViewName);
        }
    }
}
