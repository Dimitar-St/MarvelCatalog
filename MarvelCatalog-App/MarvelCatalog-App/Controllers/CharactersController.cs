using AutoMapper;
using Bytes2you.Validation;
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
        private IMapper mapper;

        public CharactersController(ICharacterService service, IMapper mapper)
        {
            Guard.WhenArgument(service, nameof(service)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.service = service;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult MainCharactersPage()
        {
            var charactersData = this.service.GetCharacters();

            IEnumerable<CharacterViewModel> characters = this.mapper.Map<IEnumerable<CharacterViewModel>>(charactersData);

            return base.View(characters);
        }

        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult GivenCharacterPage(string name)
        {
            var characterData = this.service.GetCharacter(name);

            CharacterViewModel characterViewModel = this.mapper.Map<CharacterViewModel>(characterData);

            return this.View(characterViewModel);
        }

        public void AddToFavorites(int characterId)
        {
            var character = this.service.GetCharacterById(characterId);


        }
    }
}