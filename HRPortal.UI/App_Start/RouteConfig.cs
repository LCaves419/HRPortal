using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HRPortal.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Policy", "View", new {controller = "Policy", action = "Index"});

            routes.MapRoute("HomeAdmin", "Admin", new {controller = "Home", action = "Index"});
            routes.MapRoute("HomeAppReceived", "AppReceived", new { controller = "Home", action = "AppReceived" });
            routes.MapRoute("HomeCreate", "Apply", new { controller = "Home", action = "Create" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
