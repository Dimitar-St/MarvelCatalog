using System.Web.Mvc;
using System.Web.Routing;

namespace MarvelCatalog_App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Superhero",
            //    url: "{controller}/GivenCharacterPage/{name}",
            //    defaults: new { controller = "Home", action = "Index", name = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{name}",
                defaults: new { controller = "Home", action = "Index", name = UrlParameter.Optional }
            );
        }
    }
}
