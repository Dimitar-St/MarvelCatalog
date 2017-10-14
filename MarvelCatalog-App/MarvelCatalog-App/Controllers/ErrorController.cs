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
            return this.View();
        }

        public ActionResult UnAuthorized()
        {
            return this.View();
        }

        public ActionResult Forbidden()
        {
            return this.View();
        }

        public ActionResult NotFound()
        {
            return this.View();
        }

        public ActionResult InternalServer()
        {
            return this.View();
        }
    }
}