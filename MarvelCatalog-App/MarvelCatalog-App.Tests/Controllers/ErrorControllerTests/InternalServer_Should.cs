using MarvelCatalog_App.Controllers;
using NUnit.Framework;
using System.Web.Mvc;

namespace MarvelCatalog_App.Tests.Controllers.ErrorControllerTests
{
    [TestFixture]
    public class InternalServer_Should
    {
        [Test]
        public void ReturnViewInternalServer()
        {
            // Arrange
            var errorController = new ErrorController();

            var badRequest = errorController.InternalServer() as ViewResult;

            // Act & Assert
            Assert.AreEqual("InternalServer", badRequest.ViewName);
        }
    }
}
