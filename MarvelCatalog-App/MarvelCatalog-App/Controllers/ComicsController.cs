using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelCatalog_App.Controllers
{
    public class ComicsController : Controller
    {
        public ComicsController() { }

        public ActionResult MainComicsPage()
        {
            return base.View();
        }
    }
}