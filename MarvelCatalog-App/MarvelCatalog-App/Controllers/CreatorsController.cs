using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelCatalog_App.Controllers
{
    public class CreatorsController : Controller
    {
        public CreatorsController() { }

        public ActionResult MainCreatorsPage()
        {
            return base.View();
        }
    }
}