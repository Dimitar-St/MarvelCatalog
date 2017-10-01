using AutoMapper;
using MarvelCatalog_App.Models;
using MarvelCatalog_App.Services;
using MarvelCatalog_App.Services.Contracts;
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

        //TODO: fix this method later.
        public ActionResult MainCharactersPage()
        {
            var charactersData = this.service.GetCharacters();

            IEnumerable<CharacterViewModel> characters = Mapper.Map<IEnumerable<CharacterViewModel>>(charactersData);

            return base.View(characters);
        } 
    }
}