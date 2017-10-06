using AutoMapper;
using Bytes2you.Validation;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Areas.Admin.Models;
using MarvelCatalog_App.Services.Contracts;
using MarvelCatalog_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelCatalog_App.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CharactersAdministrationController : Controller
    {
        private readonly ICharacterService service;
        private readonly IMapper mapper;

        public CharactersAdministrationController(ICharacterService service, IMapper mapper)
        {
            Guard.WhenArgument(service, nameof(service)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.service = service;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult GetAllCharacters()
        {
            var allCharacters = this.service.GetAllCharactersAdministration();

            var characterDataModel = this.mapper.Map<IEnumerable<CharactersAdminViewModel>>(allCharacters);

            return this.View(characterDataModel);
        }

        [HttpGet]
        public ActionResult GetCharacterById(int id)
        {
            var characterDataModel = this.service.GetCharacterById(id);

            var characterViewModel = this.mapper.Map<CharactersAdminViewModel>(characterDataModel);

            return this.View(characterViewModel);
        }

        [HttpGet]
        public ActionResult AddCharacter()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddCharacterToDb(CharacterViewModel character)
        {
            var characterDataModel = new CharacterDataModel()
            {
                Name = character.Name,
                Description = character.Description,
                Image = character.Image,
                isDeleted = false,
                CreatedOn = DateTime.Now
            };

            this.service.AddCharacter(characterDataModel);

            return RedirectToAction("AddCharacter");
        }

        [HttpGet]
        public ActionResult RemoveCharacter()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult RemoveCharacterFromDb(CharacterViewModel character)
        {
            var characterDataModel = new CharacterDataModel() { Name = character.Name };

            this.service.RemoveCharacter(characterDataModel);

            return RedirectToAction("RemoveCharacter");
        }

    }
}