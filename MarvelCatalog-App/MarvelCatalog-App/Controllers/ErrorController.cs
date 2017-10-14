using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelCatalog_App.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController() { }

        public ActionResult BadRequest()
        {
            return this.View("BadRequest");
        }

        public ActionResult UnAuthorized()
        {
            return this.View("UnAuthorized");
        }

        public ActionResult Forbidden()
        {
            return this.View("Forbidden");
        }

        public ActionResult NotFound()
        {
            return this.View("NotFound");
        }

        public ActionResult InternalServer()
        {
            return this.View("InternalServer");
        }
    }
}