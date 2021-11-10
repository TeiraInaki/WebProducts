using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebProducts
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "IndexPorCategoriaNombre",
               url: "{controller}/{action}/{category}/{name}",
               defaults: new { controller = "Product", action = "IndexByCategoryName", category = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "IndexPorCategoria",
               url: "{controller}/{action}/{category}",
               defaults: new { controller = "Product", action = "Index", category= UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Edit",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Product", action = "Edit" }
           );

            routes.MapRoute(
               name: "Delete",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Product", action = "Delete" }
            );

            routes.MapRoute(
               name: "Detail",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Product", action = "Detail" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
