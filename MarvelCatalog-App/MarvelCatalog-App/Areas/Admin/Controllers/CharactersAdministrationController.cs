using AutoMapper;
using Bytes2you.Validation;
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
        
    }
}