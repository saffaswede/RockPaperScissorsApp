using System.Web.Mvc;
using System.Web.Routing;

namespace RockPaperScissorsWebApp
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "NewGame",
            //    url: "game/newgame/{gametype}",
            //    defaults: new { controller = "Game", action = "NewGame", gametype = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Game", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
