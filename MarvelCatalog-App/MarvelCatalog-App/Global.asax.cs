using MarvelCatalog_App.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;
using MarvelCatalog_App.Data.Migrations;
using MarvelCatalog_App.App_Start;
using MarvelCatalog_App.Models;
using MarvelCatalog_App.ViewModels;

namespace MarvelCatalog_App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MsSqlDbContext, Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var mapper = new AutoMapperConfig();
            //mapper.Execute(Assembly.GetExecutingAssembly());

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<CharacterModel, CharacterViewModel>();
                config.CreateMap<IList<CharacterModel>, IList<CharacterViewModel>>();
            });
        }
    }
}
