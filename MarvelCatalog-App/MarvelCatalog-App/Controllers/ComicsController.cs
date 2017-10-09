using AutoMapper;
using Bytes2you.Validation;
using MarvelCatalog_App.Services.Contracts;
using MarvelCatalog_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelCatalog_App.Controllers
{
    public class ComicsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IComicsService comicsService;

        public ComicsController(IComicsService comicsService, IMapper mapper)
        {
            Guard.WhenArgument(comicsService, nameof(comicsService)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.comicsService = comicsService;
            this.mapper = mapper;
        }

        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult MainComicsPage()
        {
            var comics = this.comicsService.GetComics();

            var comicsViewModel = this.mapper.Map<IEnumerable<ComicsViewModel>>(comics);

            return base.View(comicsViewModel);
        }

        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult GivenComicsPage(string name)
        {
            var comic = this.comicsService.GetComic(name);

            ComicsViewModel comicViewModel = this.mapper.Map<ComicsViewModel>(comic);

            return this.View(comicViewModel);
        }
    }
}