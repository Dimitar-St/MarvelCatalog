using AutoMapper;
using Bytes2you.Validation;
using Marvel_Catalog_App.Data.Models;
using Marvel_Catalog_App.Data.Models.Contracts;
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
        private readonly IDataModelsFactory factory;

        public CharactersAdministrationController(ICharacterService service, IMapper mapper,
                                                  IDataModelsFactory factory)
        {
            Guard.WhenArgument(service, nameof(service)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.service = service;
            this.mapper = mapper;
            this.factory = factory;
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
            var characterDataModel = this.factory.CreateCharacter();

            characterDataModel.Name = character.Name;
            characterDataModel.Description = character.Description;
            characterDataModel.Image = character.Image;
            characterDataModel.isDeleted = false;
            characterDataModel.CreatedOn = DateTime.Now;
            characterDataModel.AbilitiesDesctiption = character.AbilitiesDesctiption;
            characterDataModel.Origin = character.Origin;
            characterDataModel.Powers = character.Powers;

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
            Guard.WhenArgument(character, nameof(character)).IsNull().Throw();

            var characterDataModel = this.factory.CreateCharacter();

            characterDataModel.Name = character.Name;

            this.service.RemoveCharacter(characterDataModel);

            return RedirectToAction("RemoveCharacter");
        }

        [HttpPost]
        public ActionResult EditCharacter(CharactersAdminViewModel character)
        {
            Guard.WhenArgument(character, nameof(character)).IsNull().Throw();

            dynamic characterDataObject = new
            {
                Id = character.Id,
                Name = character.Name,
                Description = character.Description,
                isDeleted = character.isDeleted,
                Image = character.Image,
                ModifiedOn = DateTime.Now
            };

            this.service.EditCharacter(character);

            return RedirectToAction("GetCharacterById", new { id = character.Id });
        }

        [HttpPost]
        public ActionResult GetCharacterByName(string name)
        {
            Guard.WhenArgument(name, nameof(name)).IsNull().Throw();

            var character = this.service.GetCharacter(name);

            if(character == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return RedirectToAction("GetCharacterById", new { id = character.Id });
        }

    }
}