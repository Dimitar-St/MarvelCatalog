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
    public class ComicsAdministrationController : Controller
    {
        private readonly IMapper mapper;
        private readonly IComicsService service;

        public ComicsAdministrationController(IComicsService service, IMapper mapper)
        {
            Guard.WhenArgument(service, nameof(service)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAllComics()
        {
            var comicsData = this.service.GetComics();

            var comicsViewModel = this.mapper.Map<IEnumerable<ComicsAdminViewModel>>(comicsData);

            return this.View(comicsViewModel);
        }

        [HttpGet]
        public ActionResult GetComicByTitle(string title)
        {
            var comicData = this.service.GetComic(title);

            var comicsViewModel = this.mapper.Map<ComicsAdminViewModel>(comicData);

            return this.View(comicsViewModel);
        }

    }
}