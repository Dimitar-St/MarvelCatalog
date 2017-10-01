using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelCatalog_App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CharactersController : Controller
    {
        public CharactersController() { }

        public ActionResult Index()
        {
            return this.View();
        }
        
    }
}