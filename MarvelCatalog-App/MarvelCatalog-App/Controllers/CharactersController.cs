using AutoMapper;
using Bytes2you.Validation;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Models;
using MarvelCatalog_App.Services;
using MarvelCatalog_App.Services.Contracts;
using MarvelCatalog_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MarvelCatalog_App.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ICharacterService characterService;
        private readonly IMapper mapper;

        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            Guard.WhenArgument(characterService, nameof(characterService)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.characterService = characterService;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult MainCharactersPage()
        {
            var charactersData = this.characterService.GetCharacters();

            IEnumerable<CharacterViewModel> characters = this.mapper.Map<IEnumerable<CharacterViewModel>>(charactersData);

            return base.View(characters);
        }

        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult GivenCharacterPage(string name)
        {
            var characterData = this.characterService.GetCharacter(name);

            CharacterViewModel characterViewModel = this.mapper.Map<CharacterViewModel>(characterData);

            return this.View(characterViewModel);
        }
    }
}