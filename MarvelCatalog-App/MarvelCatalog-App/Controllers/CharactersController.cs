using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelCatalog_App.Controllers
{
    public class CharactersController : Controller
    {
        public CharactersController() { }

        public ActionResult MainCharactersPage()
        {
            return base.View();
        } 
    }
}