using AutoMapper;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Services.Contracts;
using MarvelCatalog_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelCatalog_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserService service;

        public UserController(IUserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public void AddToFavoriteCharacters(string username, CharacterViewModel characterModel)
        {
            var characterDataModel = this.mapper.Map<CharacterDataModel>(characterModel);

            this.service.AddToFavoritesCharacters(username, characterDataModel);
        }
    }
}