using AutoMapper;
using Bytes2you.Validation;
using MarvelCatalog_App.Services;
using MarvelCatalog_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelCatalog_App.Controllers
{
    public class CreatorsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICreatorsService service;

        public CreatorsController(ICreatorsService service, IMapper mapper)
        {
            Guard.WhenArgument(service, nameof(service)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult MainCreatorsPage()
        {
            var creatersDataModel = this.service.GetCreators();

            var creatersViewModel = this.mapper.Map<IEnumerable<CreatorViewModel>>(creatersDataModel);

            return base.View(creatersViewModel);
        }
    }
}