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
    public class ComicsAdministrationController : Controller
    {
        private readonly IMapper mapper;
        private readonly IComicsService service;
        private readonly IDataModelsFactory factory;

        public ComicsAdministrationController(IComicsService service, IMapper mapper,
                                              IDataModelsFactory factory)
        {
            Guard.WhenArgument(service, nameof(service)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(factory, nameof(factory)).IsNull().Throw();

            this.service = service;
            this.mapper = mapper;
            this.factory = factory;
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

        [HttpGet]
        public ActionResult AddComics()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddComicsToDb(ComicsViewModel comics)
        {
            var comicsData = this.factory.CreateComics();

            comicsData.Title = comics.Title;
            comicsData.Price = comics.Price;
            comicsData.Image = comics.Image;
            comicsData.isDeleted = false;
            comicsData.CreatedOn = DateTime.Now;
            comicsData.Description = comics.Description;

            this.service.AddComic(comicsData);

            return RedirectToAction("AddComics");
    }

}
}