using MarvelCatalog_App.Models;
using MarvelCatalog_App.Services.API.Contracts;
using MarvelCatalog_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelCatalog_App.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ICharacterService service;

        public CharactersController(ICharacterService service)
        {
            this.service = service;
        }

        // TODO: Make a view model and don't user ViewBag
        public ActionResult MainCharactersPage()
        {
            var characters = this.service.GetCharecters();

            ViewBag.Characters = characters;

            return base.View();
        } 
    }
}