using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyHomeWork
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",//wegamesoa/
                defaults: new { controller = "Home", action = "Index2", id = UrlParameter.Optional },
                namespaces: new[] { "MyHomeWork" }
            );
        }
    }
}
