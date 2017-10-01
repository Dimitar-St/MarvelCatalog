using MarvelCatalog_App.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MarvelCatalog_App.Data.Migrations;
using MarvelCatalog_App.ViewModels;
using System.Reflection;
using MarvelCatalog_App.App_Start;
using Marvel_Catalog_App.Data.API.Models;

namespace MarvelCatalog_App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfMarvelCatalogDbContext, Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           // var mapper = new AutoMapperConfig();
           // mapper.Execute(Assembly.GetExecutingAssembly());

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<CharacterDataModel, CharacterViewModel>();
            });
        }
    }
}
